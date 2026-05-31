using Core.Interfaces;
using Core.Models;
using Task = Core.Models.Task;
using Services;

namespace Roles
{
    // This is a concrete class that represents a Project Coordinator in the system.
    // Extends the Employee abstract class, and implements the IProjectObserver interface to receive project notifications.
    public class ProjectCoordinator : Employee, IProjectObserver
    {
        // This is a constructor that initialises a new ProjectCoordinator object
        public ProjectCoordinator(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Project Coordinator", department)
        {

        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public ProjectCoordinator() : base("", "", "", "Project Coordinator", "")
        {

        }

        // Logs any progress this employee puts
        public void LogProgress(string projectID, string details)
        {
            // In a real system, this appends to a project log table
            Console.WriteLine($"Coordinator {Name} logged progress for {projectID}: {details}");
        }

        // Logs any findings this employee puts
        public void LogFindings()
        {
            Console.WriteLine($"Coordinator {Name} logged inspection findings.");
        }

        // Creates a progress report
        public void CreateReport(string projectID, ReportService reportService)
        {
            Report report = reportService.CreateReport("progress");
            if (report != null)
            {
                report.ProjectID = projectID;
                report.AuthorID = this.EmployeeID;
                reportService.SaveReport(report);
                Console.WriteLine($"Progress Report {report.ReportID} generated for Project {projectID}.");
            }
        }

        // Manages the tasklist of a project
        public void ManageTaskList()
        {
            Console.WriteLine($"Coordinator {Name} is updating the project Trello/Jira board.");
        }

        // This method is called by ProjectNotify() when the project's status changes
        public void OnProjectUpdate(string projectID, string status)
        {
            Console.WriteLine($"[NOTIFICATION] Coordinator {Name} notified: Project {projectID} is now {status}. Updating schedule...");
        }

        public void ManageTaskList(string projectID, TaskService taskService)
        {
            taskService.AddTaskToList("LIST-01", "Pour concrete for foundation", this);
        }
    }
}