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
        public ProgressReport(string reportID, string projectID, string authorID, string description, string department) : base(reportID, projectID, authorID, description, department)
        {

        }

        // Updates the tasks completed in the project
        public void UpdateTasksCompleted()
        {
            Console.WriteLine("Updating task completion percentages...");
        }

        // Generates a progress report template
        public override void GenerateTemplate()
        {
            Description = "Standard Progress Template: Milestone tracking and percentage completion.";
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
            Console.WriteLine($"Exporting Progress Report {ReportID} to PDF...");
        }
    }
}