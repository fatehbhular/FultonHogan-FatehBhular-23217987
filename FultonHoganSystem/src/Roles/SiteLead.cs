using Core.Interfaces;
using Core.Models;

namespace Roles
{
    // This is a concrete class that represents a Site Lead in the system.
    // Extends the Employee abstract class, and implements the IProjectObserver interface to receive project notifications.
    public class SiteLead : Employee, IProjectObserver
    {
        // This is a constructor that initialises a new SiteLead object
        public SiteLead(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Site Lead", department)
        {

        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public SiteLead() : base("", "", "", "Site Lead", "")
        {

        }

        // Views the task list of the project this employee is assigned to
        public void ViewTaskList()
        {
            // TODO: Create logic to view task list
        }

        // Sends instructions to the Site
        public void SendInstructions()
        {
            // TODO: Create logic for sending instructions
        }

        // This method is called by ProjectNotify() when the project's status changes
        public void OnProjectUpdate(string projectID, string status)
        {
            // TODO: Create logic for updating project status
        }
    }
}