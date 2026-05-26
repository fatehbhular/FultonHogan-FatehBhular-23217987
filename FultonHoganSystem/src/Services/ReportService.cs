using Core.Interfaces;
using Core.Models;
using Repositories;

namespace Services
{
    public class ReportService
    {
        private IReportRepository reportRepository;

        public ReportService()
        {
            reportRepository = new DatabaseReportRepository();
        }

        public Report CreateReport(string type)
        {
            // TODO: Write logic for creating a report using ReportFactory
            return null;
        }

        public void SaveReport(Report report)
        {
            // Saving to the repository
            reportRepository.Save(report);
        }

        public Report ViewReport(string reportID, string employeeID)
        {
            // TODO: Write logic to verify the employee has access to this report
            return reportRepository.GetByID(reportID);
        }
    }
}