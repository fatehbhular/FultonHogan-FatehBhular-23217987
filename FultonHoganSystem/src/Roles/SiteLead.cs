using Core.Interfaces;
using Core.Models;
using Task = Core.Models.Task;
using Services;

namespace Roles
{
    // This is a concrete class that represents a Site Lead in the system.
    // Extends the Employee abstract class, and implements the IProjectObserver interface to receive project notifications.
    public class SiteLead : Employee, IProjectObserver
    {
        // This is a constructor that initialises a new SiteLead object
        // This method creates a site lead.
        public SiteLead(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Site Lead", department)
        {

        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        // This method creates an empty site lead.
        public SiteLead() : base("", "", "", "Site Lead", "")
        {

        }

        // Views the task list of the project this employee is assigned to
        // This method shows the task list.
        public void ViewTaskList()
        {
            Console.WriteLine($"Site Lead {Name} is reviewing the construction task list.");
        }

        // Sends instructions to the Site
        // This method sends site instructions.
        public void SendInstructions(string details)
        {
            // This saves to the 'Instructions' table in database
            Console.WriteLine($"Site Lead {Name} broadcasted instructions: {details}");
        }

        // This method is called by ProjectNotify() when the project's status changes
        // This method receives project update messages.
        public void OnProjectUpdate(string projectID, string status)
        {
            Console.WriteLine($"[SITE NOTIFY] Site Lead {Name} aware that {projectID} is {status}. Adjusting site safety protocols.");
        }

        // This method updates task progress.
        public void UpdateProgress(Task task, string status, TaskService taskService)
        {
            taskService.UpdateTaskStatus(task, status, this);
        }
    }
}
