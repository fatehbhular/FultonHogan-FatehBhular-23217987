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
        public ComplianceReport(string reportID, string projectID, string authorID, string description, string department)
            : base(reportID, projectID, authorID, description, department)
        {

        }

        // Verifies the accuracy of selected financial report
        public void VerifyReportAccuracy()
        {
            Console.WriteLine($"Verifying accuracy for Compliance Report: {ReportID}");
        }

        // Notes any inconsistences found in the selected financial report
        public void FlagInconsistency()
        {
            Console.WriteLine("Inconsistency flagged in compliance audit.");
        }

        // Generates a compliance report template
        public override void GenerateTemplate()
        {
            Description = "Standard Compliance Template: Regulatory checks and audit history.";
        }

        // Saves this report to the database
        public override void Save()
        {
            // Uses the Repository to save itself
            DatabaseReportRepository repo = new DatabaseReportRepository();
            repo.Save(this);
        }

        // Exports this report in PDF format
        public override void ExportToPDF()
        {
            Console.WriteLine($"Exporting Compliance Report {ReportID} to PDF...");
        }
    }
}