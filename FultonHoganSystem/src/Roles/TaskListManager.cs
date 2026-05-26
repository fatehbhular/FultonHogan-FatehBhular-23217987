using Core.Interfaces;
using Core.Models;

namespace Roles
{
    // This is a concrete class that represents a TaskList Manager in the system.
    // Extends the Employee abstract class.
    // Responsible for managing tasks in task lists.
    public class TaskListManager : Employee
    {
        // This is a constructor that initialises a new TaskListManager object
        public TaskListManager(string name, string employeeID, string email, string department) : base(name, employeeID, email, "TaskList Manager", department)
        {

        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public TaskListManager() : base("", "", "", "TaskList Manager", "")
        {

        }

        // Vefifies whether an employee can manage tasks by checking their role
        public void VerifyEmployee()
        {
            // TODO: Create logic for verifying employee role
        }

        // Views the task list and shows it to the verified employee
        public void ViewTaskList()
        {
            // TODO: Create logic for viewing a task list
        }

        // Manages and updates the task list
        public void ManageTaskList()
        {
            // TODO: Create logic for managing a task list
        }
    }
}