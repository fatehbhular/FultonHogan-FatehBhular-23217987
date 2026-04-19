using FultonHogan.Users;

namespace FultonHogan.Projects
{
    public class TaskList
    {
        public string ProjectId { get; private set; }
        public string TaskListId { get; private set; }
        public List<Task> AllTasks { get; protected set; }
        public string Description { get; protected set; }
        public User Sender { get; protected set; }
        public User Recipient { get; protected set; }

        public TaskList(string projectId, string taskListId, string description, User sender, User recipient)
        {
            ProjectId = projectId;
            TaskListId = taskListId;
            Description = description;
            Sender = sender;
            Recipient = recipient;
            AllTasks = new List<Task>();
        }

        public void SendTaskList(List<Task> allTasks)
        {
            Console.WriteLine("The list has been sent!");
        }


    }
}