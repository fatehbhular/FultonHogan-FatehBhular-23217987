using Core.Models;

namespace Reports
{
    public class ProblemReport : Report
    {
        public ProblemReport(string reportID, string projectID, string authorID, string description, string department) : base(reportID, projectID, authorID, description, department)
        {

        }

        public void SendAlert()
        {
            // TODO: Write the send alert logic
        }

        // Generates a problem report template
        public override void GenerateTemplate()
        {
            // TODO: Problem report template generation
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