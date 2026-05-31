namespace Core.Models
{
    // This is a concrete class that represents a list of tasks.
    // A TaskList can contain multiple tasks, and a project can contain multiple task lists.
    public class TaskList
    {
        public string TaskListID { get; set; }
        public string ProjectID { get; set; }
        public string Description { get; set; }
        public List<Task> IncludedTasks { get; set; }

        // Constructor that initialises a new task list.
        // A new instance is initialised as an empty list.
        // This method creates a task list.
        public TaskList(string taskListID, string projectID, string description)
        {
            TaskListID = taskListID;
            ProjectID = projectID;
            Description = description;
            IncludedTasks = new List<Task>();
        }

        // Sends tasks to the Site Forman and Heavy Machine Operators
        // This method sends the task list.
        public void Send()
        {
            // TODO: Send taskList logic
        }

        // Adds a new task to this task list
        // This method adds a task to the list.
        public void AddTask(Task task)
        {
            IncludedTasks.Add(task);
        }
    }
}
