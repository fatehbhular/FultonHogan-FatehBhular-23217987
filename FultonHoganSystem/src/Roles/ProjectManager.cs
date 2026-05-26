using Core.Interfaces;
using Core.Models;

namespace Roles
{
    // This is a concrete class that represents a Project Manager in the system.
    // Extends the Employee abstract class, and implements the IProjectObserver interface to receive project notifications.
    public class ProjectManager : Employee, IProjectObserver
    {
        // This is a constructor that initialises a new ProjectManager object
        public ProjectManager(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Project Manager", department)
        {

        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public ProjectManager() : base("", "", "", "Project Manager", "")
        {

        }

        // Modifies a specific project using the ID passed in the method
        public void ModifyProject(string projectID)
        {
            // TODO: Create logic to modify project
        }

        // Manages the employees this manager oversees.
        public void ManageMembers()
        {
            // TODO: Create logic to manage team members
        }

        // Views the progress of a project
        public void ViewProgress()
        {
            // TODO: Create logic to view progress of a project
        }

        // This method is called by ProjectNotify() when the project's status changes
        public void OnProjectUpdate(string projectID, string status)
        {
            // TODO: Create logic for updating project status
        }
    }
}