using System;
using Core.Interfaces;
using Core.Models;
using Microsoft.Data.Sqlite;
using Factories;

namespace Repositories
{
    public class DatabaseReportRepository : IReportRepository
    {
        private DatabaseConnection dbConnection;

        public DatabaseReportRepository()
        {
            dbConnection = DatabaseConnection.GetInstance();
            dbConnection.Connect();
        }

        public void Save(Report report)
        {
            // TODO: Write logic for saving a report to the database
            dbConnection.Connect();
            SqliteConnection connection = dbConnection.GetConnect();

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
            dbConnection.Connect();
            SqliteConnection connection = dbConnection.GetConnect();

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
                            // Grab values from database rows
                            report.ReportID = reader["ReportID"].ToString();
                            report.ProjectID = reader["ProjectID"].ToString();
                            report.AuthorID = reader["AuthorID"].ToString();
                            report.Description = reader["Description"].ToString();
                            report.Timestamp = Convert.ToDateTime(reader["Timestamp"]);
                            report.Department = reader["Department"].ToString();

                            return report;
                        }
                    }
                }
            }

            return null;
        }
    }
}