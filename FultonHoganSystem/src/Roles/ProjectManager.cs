using Core.Interfaces;
using Core.Models;
using Services;

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
        public void ModifyProject(string projectID, IProjectRepository projectRepository)
        {
            Project project = projectRepository.GetByID(projectID);
            if (project != null) {
                project.Status = "Modified by PM";
                projectRepository.Save(project);
                Console.WriteLine($"PM {Name} updated Project {projectID} status.");
            }
        }

        // Manages the employees this manager oversees.
        public void ManageMembers()
        {
            Console.WriteLine($"PM {Name} is reviewing team performance and resource allocation.");
        }

        // Views the progress of a project
        public void ViewProgress(string projectID, IProjectRepository projectRepository)
        {
            Project project = projectRepository.GetByID(projectID);
            if (project != null) {
                Console.WriteLine($"\n--- PM Dashboard: {project.Title} ---");
                Console.WriteLine($"Status: {project.Status} | Budget: ${project.BudgetLimit:N2}");
            }
        }

        // This method is called by ProjectNotify() when the project's status changes
        public void OnProjectUpdate(string projectID, string status)
        {
            Console.WriteLine($"[URGENT] PM {Name} received update: {projectID} is {status}. Checking milestones.");
        }
    }
}