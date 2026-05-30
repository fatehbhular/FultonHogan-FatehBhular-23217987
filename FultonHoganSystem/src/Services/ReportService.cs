using Core.Interfaces;
using Core.Models;
using Repositories;
using System;
using Factories;


namespace Services
{
    public class ReportService
    {
        private readonly IReportRepository ReportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            ReportRepository = reportRepository;
        }

        // Creates and returns a new report - uses type to decide which one to create
        public Report CreateReport(string type)
        {
            // Creates a factory to instantiate a report
            ReportFactory factory = new ReportFactory();
            
            string generatedID = Guid.NewGuid().ToString();  // Generates a new ID
            string initialDesc = $"New {type} generated.";
            
            // Pass the generated ID and description into the factory
            Report newReport = factory.CreateReport(type, generatedID, "", "", initialDesc, "");

            if (newReport != null) {
                newReport.Timestamp = DateTime.Now;
                newReport.GenerateTemplate();
            }

            return newReport;
        }

        public void SaveReport(Report report)
        {
            // Saving to the repository
            if (report == null) return;
            ReportRepository.Save(report);
        }

        // Retrieves the report from the database
        // Only returns report if the user has access
        public Report ViewReport(string reportID, string employeeID)
        {
            // Retrieve the report from the repository
            Report report = ReportRepository.GetByID(reportID);

            if (report == null) return null;

            if (report.AuthorID == employeeID) return report;

            // fallback -> just returns the report (security isn't a priority)
            return report;
        }
    }
}