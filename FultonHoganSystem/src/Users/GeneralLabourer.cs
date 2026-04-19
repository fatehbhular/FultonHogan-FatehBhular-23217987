using FultonHogan.Interfaces;

namespace FultonHogan.Users
{
    public class GeneralLabourer : User, IGeneralLabourerTools
    {
        public bool HasAccessToSiteTools => true;

        public GeneralLabourer(string employeeId, string name, string email, string phoneNumber, string role, string department) : base(employeeId, name, email, phoneNumber, role, department)
        {
            
        }

        // IGeneralLabourerTools methods

        public void FlagSiteIssue()
        {
            Console.Write($"{Name} has flagged a site issue.");
        }

        public void CommunicateWithForeman()
        {
            Console.Write($"{Name} has sent a message to the site foreman.");
        }

        public void LogDailyWorkingHours()
        {
            Console.Write($"{Name} has logged in their work hours.");
        }

        public void ViewLoggedHoursSummary()
        {
            Console.Write($"{Name} has viewed a summary of their work hours.");
        }
    }
}