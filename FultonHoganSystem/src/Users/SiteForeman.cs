using FultonHogan.Interfaces;

namespace FultonHogan.Users
{
    public class SiteForeman : User, ISiteForemanTools
    {
        public bool HasAccessToSiteTools => true;
        public string AssignedSite { get; protected set; }

        public SiteForeman(string employeeId, string name, string email, string phoneNumber, string role, string department, string assignedSite) : base(employeeId, name, email, phoneNumber, role, department)
        {
            AssignedSite = assignedSite;
        }

        // ISiteForemanTools methods

        public void FlagSiteIssue()
        {
            Console.Write($"{Name} has flagged a site issue.");
        }

        public void RecieveInstructions()
        {
            Console.Write($"{Name} has received the site instructions.");
        }

        public void ViewInstructions()
        {
            Console.Write($"{Name} has viewed the site instructions.");
        }

        public void RelayInstructionsToSite()
        {
            Console.Write($"{Name} has relayed instructions to the site.");
        }
    }
}