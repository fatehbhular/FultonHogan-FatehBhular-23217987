using System;
using Core.Interfaces;
using Core.Models;
using Microsoft.Data.Sqlite;
using Factories;

namespace Repositories
{
    public class DatabaseReportRepository : IReportRepository
    {
        private DatabaseConnection DbConnection;

        public DatabaseReportRepository()
        {
            DbConnection = DatabaseConnection.GetInstance();
        }

        public void Save(Report report)
        {
            // Ensure the connection is open
            DbConnection.Connect();
            SqliteConnection connection = DbConnection.GetConnect();

            string sql = @"INSERT OR REPLACE INTO REPORTS (ReportID, ProjectID, AuthorID, Description, Timestamp, Department, ReportType) VALUES (@ReportID, @ProjectID, @AuthorID, @Description, @Timestamp, @Department, @ReportType)";

            using (var command = new SqliteCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ReportID", report.ReportID);
                command.Parameters.AddWithValue("@ProjectID", report.ProjectID);
                command.Parameters.AddWithValue("@AuthorID", report.AuthorID);
                command.Parameters.AddWithValue("@Description", report.Description);
                // SQLite's DATETIME type - Got from internet
                command.Parameters.AddWithValue("@Timestamp", report.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@Department", report.Department);
                
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
                            return report;
                        }
                    }
                }
            }

            return null;
        }
    }
}