using FultonHogan.Interfaces;

namespace FultonHogan.Users
{
    public class ProjectCoordinator : User, IProjectCoordinatorTools
    {
        public bool HasAccessToManagementTools => true;
        public string ProjectId { get; protected set; }

        public ProjectCoordinator(string employeeId, string name, string email, string phoneNumber, string role, string department, string projectId) : base(employeeId, name, email, phoneNumber, role, department)
        {
            ProjectId = projectId;
        }

        // IProjectCoordinatorTools methods

        public void LogProgress()
        {
            Console.WriteLine($"{Name} is logging project progress.");
        }

        public void LogFindings()
        {
            Console.WriteLine($"{Name} is logging findings.");
        }

        public void CreateProgressReport()
        {
            Console.WriteLine($"{Name} has created a progress report.");
        }

        public void UploadFiles()
        {
            Console.WriteLine($"{Name} is uploading files.");
        }

        public void ManageTasks()
        {
            Console.WriteLine($"{Name} has modified a task.");
        }
    }
}