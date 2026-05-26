using Core.Models;

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
            // TODO: Report accuracy logic
        }

        // Notes any inconsistences found in the selected financial report
        public void FlagInconsistency()
        {
            // TODO: Flagging logic
        }

        // Generates a compliance report template
        public override void GenerateTemplate()
        {
            // TODO: Compliance report template generation
        }

        // Saves this report to the database
        public override void Save()
        {
            // TODO: Saving to database logic
        }

        // Exports this report in PDF format
        public override void ExportToPDF()
        {
            // TODO: Exporting as PDF logic
        }
    }
}