using Core.Models;

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
            // TODO: Write logic to update tasks
        }

        // Generates a progress report template
        public override void GenerateTemplate()
        {
            // TODO: Progress report template generation
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