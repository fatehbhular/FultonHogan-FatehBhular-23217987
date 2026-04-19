using FultonHogan.Interfaces;
using FultonHogan.Projects;

namespace FultonHogan.Users
{
    public class ProjectManager : User, IProjectManagerTools
    {
        public bool HasAccessToManagementTools => true;
        public List<Project> ManagedProjects { get; private set; }

        public ProjectManager(string employeeId, string name, string email, string phoneNumber, string role, string department) : base(employeeId, name, email, phoneNumber, role, department)
        {
            ManagedProjects = new List<Project>();
        }

        // IProjectManagerTools methods

        public void InitialiseProject(Project project)
        {
            ManagedProjects.Add(project);
            Console.WriteLine($"{Name} has initialised project: <{project.ProjectId}>");
        }

        public void ModifyProject(Project project, string newStatus)
        {
            project.UpdateStatus(newStatus);
            project.SyncData();
            Console.WriteLine($"{Name} has modified project <{project.ProjectId}>");
        }

        public void ViewProgress(Project project)
        {
            Console.WriteLine($"{Name} is viewing progress for project <{project.ProjectId}>");
        }

        public void ManageTasks()
        {
            Console.WriteLine($"{Name} has modified a task.");
        }

        public void ViewProjectTasks()
        {
            Console.WriteLine($"{Name} has viewed project tasks.");
        }

        public void SendInstructions()
        {
            Console.WriteLine($"{Name} has sent instructions.");
        }
    }
}