using Core.Models;
using Repositories;

namespace Reports
{
    // Concrete class that represents a financial report for a project.
    // Extends the Report abstract class and provides financial-related functionality.
    public class FinancialReport : Report
    {
        // Constructor that initialises a new financial report.
        // Calls the base Report constructor using base().
        public FinancialReport(string reportID, string projectID, string authorID, string description, string department) : base(reportID, projectID, authorID, description, department)
        {

        }

        // Calculates the Estimated vs Actual costs for this project
        public void CalulcateEVA()
        {
            Console.WriteLine("Calculating Estimated vs Actual costs...");
        }

        // Generates a financial report template
        public override void GenerateTemplate()
        {
            Description = "Standard Financial Template: Budget allocations, spendings, and EVA analysis.";
        }

        // Saves this report to the database
        public override void Save()
        {
            DatabaseReportRepository repo = new DatabaseReportRepository();
            repo.Save(this);
        }

        // Exports this report in PDF format
        public override void ExportToPDF()
        {
            Console.WriteLine($"Exporting Financial Report {ReportID} to PDF...");
        }
    }
}