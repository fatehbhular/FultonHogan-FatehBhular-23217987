using Core.Interfaces;

namespace Core.Models
{
    // This is a concrete class that represents a project in the system.
    // Acts as the "subject" in the OBSERVER design pattern.
    // Notifies observers ("Project Manager", "Project Coordinator", "Site Lead") when the status changes.
    public class Project
    {
        public string ProjectID { get; set; }
        public string Title { get; set; }
        public List<Employee> ProjectTeam { get; set; }
        public List<TaskList> TaskLists { get; set; }
        public string Status { get; set; }
        public int BudgetLimit { get; set; }
        public int CurrentSpendings { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly Deadline { get; set; }
        private List<IProjectObserver> Observers { get; set; }

        // Constructor that initialises a new project and saves it to the database.
        // ProjectTeam, TaskLists, and Observers are initialised as empty lists - later added dynamically.
        public Project(string projectID, string title, DateOnly startDate, DateOnly deadline, int budgetLimit)
        {
            ProjectID = projectID;
            Title = title;
            StartDate = startDate;
            Deadline = deadline;
            BudgetLimit = budgetLimit;
            CurrentSpendings = 0;
            Status = "Active";
            ProjectTeam = new List<Employee>();
            TaskLists = new List<TaskList>();
            Observers = new List<IProjectObserver>();
        }

        // Adds an observer to the list so they can receive status updates
        public void Subscribe(IProjectObserver observer)
        {
            Observers.Add(observer);
        }

        // Removes an observer from the list, so they no longer receive status updates
        public void Unsubscribe(IProjectObserver observer)
        {
            Observers.Remove(observer);
        }

        // Notifies all observers when the status of this project changes - called automatically when status is changed
        public void Notify()
        {
            // TODO: Notify all observers logic
        }

        // Calculates the current progress depending on completed tasks and task lists
        public void CalculateProgress()
        {
            // TODO: Create the progress calculation logic
        }

        // Updates the project status and notifies observers of the change
        public void UpdateStatus(string status)
        {
            Status = status;
            Notify();
        }

        // Retrieves a report from the database by its ID
        public Report GetReport(string reportID)
        {
            // TODO: Logic for retrieving report from database
            return null;
        }
    }
}