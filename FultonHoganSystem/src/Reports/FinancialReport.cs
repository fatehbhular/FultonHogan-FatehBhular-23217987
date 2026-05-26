using Core.Models;

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
            // TODO: Write EVA calculation logic
        }

        // Generates a financial report template
        public override void GenerateTemplate()
        {
            // TODO: Financial report template generation
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