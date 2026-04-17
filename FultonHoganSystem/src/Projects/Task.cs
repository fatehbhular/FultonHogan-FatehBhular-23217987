using System.Security.Cryptography.X509Certificates;

namespace FultonHogan.Projects
{
    public class Task
    {
        // Properties of the Task class with getters + setters.
        public string TaskId { get; private set; }
        public string Description { get; protected set; }
        public string Status { get; protected set; }
        public string TaskListId { get; protected set; }

        public Task(string taskId, string description, string status, string taskListId)
        {
            TaskId = taskId;
            Description = description;
            Status = status;
            TaskListId = taskListId;
        }

        public void AssignTo(string taskListId)
        {
            // Assigns a TaskId to this task so that it can be stored there.
            TaskListId = taskListId;
            Console.WriteLine($"Task <{TaskId}> has been assigned to <{TaskListId}>");
        }

        public bool IsCompleted()
        {
            // Checks whether this class' status is "completed" or not.
            if (Status.Equals("completed"))
            {
                Console.WriteLine("Task is completed.");
                return true;
            }

            Console.WriteLine("Task is NOT completed.");
            return false;
        }
    }
}