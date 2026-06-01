using System;
using Core.Interfaces;
using Core.Models;
using Microsoft.Data.Sqlite;
using Factories;
using Reports;

namespace Repositories
{
    // Implements IReportRepository.
    // Resposible for all database persistence operations
    public class DatabaseReportRepository : IReportRepository
    {
        private DatabaseConnection DbConnection;

        // Gets the global instance instead of creating a new one
        // This method creates the report repository.
        public DatabaseReportRepository()
        {
            DbConnection = DatabaseConnection.GetInstance();
        }

        // This method saves a report.
        public void Save(Report report)
        {
            // Ensure the connection is open
            DbConnection.Connect();
            SqliteConnection connection = DbConnection.GetConnect();

            string sql = @"INSERT OR REPLACE INTO REPORTS (ReportID, ProjectID, AuthorID, Description, Timestamp, Department, ReportType, IsApproved) VALUES (@ReportID, @ProjectID, @AuthorID, @Description, @Timestamp, @Department, @ReportType, @IsApproved)";

            using (var command = new SqliteCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ReportID", report.ReportID);
                command.Parameters.AddWithValue("@ProjectID", report.ProjectID);
                command.Parameters.AddWithValue("@AuthorID", report.AuthorID);
                command.Parameters.AddWithValue("@Description", report.Description);
                // SQLite's DateTime type - Got from internet
                command.Parameters.AddWithValue("@Timestamp", report.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@Department", report.Department);
                command.Parameters.AddWithValue("@IsApproved", report.IsApproved ? 1 : 0);
                
                // Normalises report class name string to match factory switch statements
                string shortType = report.GetType().Name.Replace("Report", "").ToLower();
                command.Parameters.AddWithValue("@ReportType", shortType); // e.g. "financial", "progress"

                try {
                    command.ExecuteNonQuery();
                } catch (SqliteException ex) {
                    Console.WriteLine($"Database Error saving repoert: {ex.Message}");
                    throw;
                }
            }
        }

        // This method gets a report by its ID.
        public Report GetByID(string reportID)
        {
            // TODO: Write logic for retrieving a report from the database
            DbConnection.Connect();
            SqliteConnection connection = DbConnection.GetConnect();

            string sql = @"SELECT * FROM Reports WHERE ReportID = @ReportID";

            using (var command = new SqliteCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ReportID", reportID);

                using (var reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        string reportType = reader["ReportType"].ToString();

                        // Grabs individual column string values to build subclass
                        string id = reader["ReportID"].ToString();
                        string projID = reader["ProjectID"].ToString();
                        string author = reader["AuthorID"].ToString();
                        string desc = reader["Description"].ToString();
                        string dept = reader["Department"].ToString();

                        // Use factory to create the subclass
                        ReportFactory factory = new ReportFactory();
                        Report report = factory.CreateReport(reportType, id, projID, author, desc, dept);

                        if (report != null) {
                            // If report is created, return it with the timestamp
                            report.Timestamp = Convert.ToDateTime(reader["Timestamp"]);
                            report.ReportType = reportType;
                            report.IsApproved = Convert.ToInt32(reader["IsApproved"]) == 1;
                            return report;
                        }
                    }
                }
            }

            return null;
        }

        // Gets all the reports from the repository to display on the GUI
        // This method gets all reports.
        public List<Report> GetAllReports()
        {
            // Initialises the list
            List<Report> reports = new List<Report>();
            DbConnection.Connect();
            var connection = DbConnection.GetConnect();

            string sql = "SELECT * FROM Reports";

            using (var command = new SqliteCommand(sql, connection))
            using (var reader = command.ExecuteReader())
            {
                ReportFactory factory = new ReportFactory();
                while (reader.Read())
                {
                    // Get the type string from the database
                    string type = reader["ReportType"].ToString() ?? "";
                    
                    Report report = factory.CreateReport(
                        type,
                        reader["ReportID"].ToString() ?? "",
                        reader["ProjectID"].ToString() ?? "",
                        reader["AuthorID"].ToString() ?? "",
                        reader["Description"].ToString() ?? "",
                        reader["Department"].ToString() ?? ""
                    );

                    if (report != null)
                    {
                        report.ReportType = type; // Set the property we added to the model
                        report.Timestamp = Convert.ToDateTime(reader["Timestamp"]);
                        report.IsApproved = Convert.ToInt32(reader["IsApproved"]) == 1;
                        reports.Add(report);
                    }
                }
            }
            return reports; // Return the WHOLE LIST
        }
    }
}
