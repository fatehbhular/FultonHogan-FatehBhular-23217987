using Core.Interfaces;
using Core.Models;
using Roles;

namespace Factories
{
    // This is a concrete factory responsible for creating the correct management employee type.
    // Implements the "Factory" method.
    public class ManagementEmployeeFactory : IEmployeeFactory
    {
        // This method creates and returns an employee from the management department depending on the role passed in the method.
        // Initialisation of "Project Manager", "Project Coordinator", "Site Lead", and "TaskListManager"
        public IEmployee CreateEmployee(string role)
        {
            switch (role.ToLower())
            {
                case "projectmanager":
                    return new ProjectManager();
                case "projectcoordinator":
                    return new ProjectCoordinator();
                case "sitelead":
                    return new SiteLead();
                case "tasklistmanager":
                    return new TaskListManager();
                default:
                    // If role doesn't match any of the above -> return null
                    return null;
            }
        }
    }
}