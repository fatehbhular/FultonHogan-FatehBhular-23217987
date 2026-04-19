using System.Runtime.InteropServices;
using FultonHogan.Reports;

namespace FultonHogan.Projects
{
    public class Project
    {
        // Properties of the Project class with getters + setters.
        public string ProjectId { get; private set; }
        public string Title { get; protected set; }
        public List<TaskList> TaskLists { get; protected set; } = new List<TaskList>();
        public string CurrentStatus { get; protected set; }
        public int BudgetLimit { get; protected set; }
        public int CurrentSpendings { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime Deadline { get; protected set; }

        public Project(string projectId, string title, int budgetLimit)
        {
            ProjectId = projectId;
            Title = title;
            BudgetLimit = budgetLimit;
            CurrentStatus = "Not Started";
            StartDate = DateTime.Now;
        }

        public double CalculateProgress(List<TaskList> taskLists)
        {
            // Calculating % based on individual tasks' status
            Console.WriteLine("Returns the % of tasks completed for this Project");
            return 0.0;
        }

        public string UpdateStatus(string status)
        {
            // Changes the current status of this project to the new status given via argument
            CurrentStatus = status;
            Console.WriteLine($"Changed this project's status to: {CurrentStatus}");
            return CurrentStatus;
        }

        public bool SyncData()
        {
            // Sync all data so that everything is updated.
            Console.WriteLine("Project has been updated.");
            return true;
        }

        public Report GetReport(string reportId)
        {
            // Returns a report with the reportId
            Report NewReport = new Report(reportId, "1", "xnk5455", "This is a new report.", "Finance");
            Console.WriteLine($"Report to return: {NewReport.ReportId} by {NewReport.AuthorId}.");

            return NewReport;
        }
    }
}