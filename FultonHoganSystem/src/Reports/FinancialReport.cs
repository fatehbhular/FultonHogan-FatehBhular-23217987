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
        // This method creates a financial report.
        public FinancialReport(string reportID, string projectID, string authorID, string description, string department) : base(reportID, projectID, authorID, description, department)
        {

        }

        // Calculates the Estimated vs Actual costs for this project
        // This method calculates estimated and actual costs.
        public void CalulcateEVA()
        {
            Console.WriteLine("Calculating Estimated vs Actual costs...");
        }

        // Generates a financial report template
        // This method fills in the financial report template.
        public override void GenerateTemplate()
        {
            Description = "Standard Financial Template: Budget allocations, spendings, and EVA analysis.";
        }

        // Saves this report to the database
        // This method saves the financial report.
        public override void Save()
        {
            DatabaseReportRepository repo = new DatabaseReportRepository();
            repo.Save(this);
        }

        // Exports this report in PDF format
        // This method exports the financial report to PDF.
        public override void ExportToPDF()
        {
            Console.WriteLine($"Exporting Financial Report {ReportID} to PDF...");
        }
    }
}
