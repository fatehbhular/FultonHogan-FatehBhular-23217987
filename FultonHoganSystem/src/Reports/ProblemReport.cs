using Core.Models;
using Repositories;

namespace Reports
{
    public class ProblemReport : Report
    {
        public ProblemReport(string reportID, string projectID, string authorID, string description, string department) : base(reportID, projectID, authorID, description, department)
        {

        }

        public void SendAlert()
        {
            Console.WriteLine($"ALERT: Problem reported on Project {ProjectID}. Notifying stakeholders...");
        }

        // Generates a problem report template
        public override void GenerateTemplate()
        {
            Description = "Standard Problem Template: Issue description, severity, and mitigation plan.";
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
            Console.WriteLine($"Exporting Problem Report {ReportID} to PDF...");
        }
    }
}