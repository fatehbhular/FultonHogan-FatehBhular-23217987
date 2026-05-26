using Core.Interfaces;
using Core.Models;

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
        public void LogProgress()
        {
            // TODO: Write logic for logging progress
        }

        // Logs any findings this employee puts
        public void LogFindings()
        {
            // TODO: Write logic for logging findings
        }

        // Creates a progress report
        public void CreateReport()
        {
            // TODO: Write logic for creating a report
        }

        // Manages the tasklist of a project
        public void ManageTaskList()
        {
            // TODO: Write logic for managing a task list
        }

        // This method is called by ProjectNotify() when the project's status changes
        public void OnProjectUpdate(string projectID, string status)
        {
            // TODO: Write logic for handling project update notifications
        }
    }
}