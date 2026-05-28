using Core.Interfaces;
using Core.Models;
using Repositories;
using System;
using Factories;


namespace Services
{
    public class ReportService
    {
        private IReportRepository reportRepository;

        public ReportService()
        {
            reportRepository = new DatabaseReportRepository();
        }

        // Creates and returns a new report - uses type to decide which one to create
        public Report CreateReport(string type)
        {
            // TODO: Write logic to create report using ReportFactory
            ReportFactory factory = new ReportFactory();
            
            string generatedID = Guid.NewGuid().ToString();
            string initialDesc = $"New {type} generated.";
            
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
            reportRepository.Save(report);
        }

        public Report ViewReport(string reportID, string employeeID)
        {
            // TODO: Write logic to verify the employee has access to this report
            Report report = reportRepository.GetByID(reportID);

            if (report == null) {
                return null;
            }

            if (report.AuthorID == employeeID) {
                return report;
            }

            // fallback -> just returns the report (security isn't a priority)
            return report;
        }
    }
}