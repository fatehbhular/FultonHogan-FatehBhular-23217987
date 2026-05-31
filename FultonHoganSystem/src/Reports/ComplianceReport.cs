using Core.Models;
using Repositories;

namespace Reports
{
    // Concrete class that represents a compliance report for a project.
    // Extends the Report abstract class and provides compliance-related functionality.
    public class ComplianceReport : Report
    {
        // Constructor that initialises a new compliance report.
        // Calls the base Report constructor using base().
        // This method creates a compliance report.
        public ComplianceReport(string reportID, string projectID, string authorID, string description, string department)
            : base(reportID, projectID, authorID, description, department)
        {

        }

        // Verifies the accuracy of selected financial report
        // This method checks if the report is accurate.
        public void VerifyReportAccuracy()
        {
            Console.WriteLine($"Verifying accuracy for Compliance Report: {ReportID}");
        }

        // Notes any inconsistences found in the selected financial report
        // This method marks a report problem.
        public void FlagInconsistency()
        {
            Console.WriteLine("Inconsistency flagged in compliance audit.");
        }

        // Generates a compliance report template
        // This method fills in the compliance report template.
        public override void GenerateTemplate()
        {
            Description = "Standard Compliance Template: Regulatory checks and audit history.";
        }

        // Saves this report to the database
        // This method saves the compliance report.
        public override void Save()
        {
            // Uses the Repository to save itself
            DatabaseReportRepository repo = new DatabaseReportRepository();
            repo.Save(this);
        }

        // Exports this report in PDF format
        // This method exports the compliance report to PDF.
        public override void ExportToPDF()
        {
            Console.WriteLine($"Exporting Compliance Report {ReportID} to PDF...");
        }
    }
}
