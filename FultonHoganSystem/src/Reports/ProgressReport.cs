using Core.Models;
using Repositories;

namespace Reports
{
    // Concrete class that represents a progress report for a project.
    // Extends the Report abstract class and provides progress-related functionality.
    public class ProgressReport : Report
    {
        // Constructor that initialises a new progress report.
        // Calls the base Report constructor using base().
        // This method creates a progress report.
        public ProgressReport(string reportID, string projectID, string authorID, string description, string department) : base(reportID, projectID, authorID, description, department)
        {

        }

        // Updates the tasks completed in the project
        // This method updates completed task details.
        public void UpdateTasksCompleted()
        {
            Console.WriteLine("Updating task completion percentages...");
        }

        // Generates a progress report template
        // This method fills in the progress report template.
        public override void GenerateTemplate()
        {
            Description = "Standard Progress Template: Milestone tracking and percentage completion.";
        }

        // Saves this report to the database
        // This method saves the progress report.
        public override void Save()
        {
            DatabaseReportRepository repo = new DatabaseReportRepository();
            repo.Save(this);
        }

        // Exports this report in PDF format
        // This method exports the progress report to PDF.
        public override void ExportToPDF()
        {
            Console.WriteLine($"Exporting Progress Report {ReportID} to PDF...");
        }
    }
}
