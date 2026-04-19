using FultonHogan.Interfaces;

namespace FultonHogan.Users
{
    public class SiteLead : User, ISiteLeadTools
    {
        public bool HasAccessToManagementTools => true;
        public string ProjectId { get; protected set; }

        public SiteLead(string employeeId, string name, string email, string phoneNumber, string role, string department, string projectId) : base(employeeId, name, email, phoneNumber, role, department)
        {
            ProjectId = projectId;
        }

        // ISiteLeadTools methods

        public void ViewProjectTasks()
        {
            Console.WriteLine($"{Name} has viewed project tasks.");
        }

        public void CreateInstructions(string projectId, string instructions)
        {
            Console.WriteLine($"{Name} has created instructions for project {projectId}.");
        }

        public void SendInstructions()
        {
            Console.WriteLine($"{Name} has sent instructions.");
        }
    }
}