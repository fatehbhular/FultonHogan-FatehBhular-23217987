using FultonHogan.Projects;

namespace FultonHogan.Reports
{
    public class ProgressReport : Report
    {
        public List<Projects.Task> TasksCompleted { get; protected set; }
        public double PercentageCompleted { get; protected set; }
        public string NewFindings { get; protected set; }

        public ProgressReport(string reportId, string projectId, string authorId, string description, string department, List<Projects.Task> tasksCompleted, double percentageCompleted, string newFindings) : base(reportId, projectId, authorId, description, department)
        {
            TasksCompleted = tasksCompleted;
            PercentageCompleted = percentageCompleted;
            NewFindings = newFindings;
        }

        public void UpdateTasksCompleted()
        {
            Console.Write($"The tasks completed for project <{ProjectId}> has been updated.");
        }
    }
}