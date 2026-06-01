namespace Core.Models
{
    // This is a concrete class that represents a single task in a task list.
    // Tasks are assigned to a TaskList and contain a status that is updated during progress.
    public class Task
    {
        public string TaskID { get; set; }
        public string TaskListID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        // Constructor that initialises a new task.
        // Called on initialisation on a new Task instance.
        // This method creates a task.
        public Task(string taskID, string taskListID, string description, string status)
        {
            TaskID = taskID;
            TaskListID = taskListID;
            Description = description;
            Status = status;
        }

        // Assigns this task to a task list by updating the taskListID
        // This method puts the task in a task list.
        public void AssignToList(string taskListID)
        {
            TaskListID = taskListID;
        }

        // Changes the status of this task ("Not Started", "In Progress", "Completed")
        // This method changes the task status.
        public void ChangeStatus(string status)
        {
            Status = status;
        }

        // This method shows the task as simple text.
        public override string ToString()
        {
            return $"{Description} [{Status}]";
        }
    }
}
