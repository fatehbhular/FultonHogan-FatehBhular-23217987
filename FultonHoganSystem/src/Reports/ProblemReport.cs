using Core.Models;
using Repositories;

namespace Reports
{
    // Concrete class that represents a problem report for a project.
    // Extends the Report abstract class and provides functionality regarding submitting a problem.
    public class ProblemReport : Report
    {
        // Constructor that initialises a new problem report.
        // Calls the base report constructor using base.
        public ProblemReport(string reportID, string projectID, string authorID, string description, string department) : base(reportID, projectID, authorID, description, department)
        {

        }

        // Sends an alert to the project management team.
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