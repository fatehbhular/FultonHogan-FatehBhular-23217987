using FultonHogan.Interfaces;

namespace FultonHogan.Users
{
    public class HeavyMachineOperator : User, IHeavyMachineOperatorTools
    {
        public bool HasAccessToSiteTools => true;
        public string AssignedEquipment { get; protected set; }

        public HeavyMachineOperator(string employeeId, string name, string email, string phoneNumber, string role, string department, string assignedEquipment) : base(employeeId, name, email, phoneNumber, role, department)
        {
            AssignedEquipment = assignedEquipment;
        }

        // IHeavyMachineOperatorTools methods

        public void FlagSiteIssue()
        {
            Console.Write($"{Name} has flagged a site issue.");
        }

        public void LogEquipmentUsage()
        {
            Console.Write($"{Name} has logged their equipment usage.");
        }

        public void ReportEquipmentCondition()
        {
            Console.Write($"{Name} has reported an equipment condition.");
        }

        public void CommunicateWithForeman()
        {
            Console.Write($"{Name} has sent a message to the site foreman.");
        }

        public void LogDailyWorkingHours()
        {
            Console.Write($"{Name} has logged in their work hours");
        }

        public void ViewLoggedHoursSummary()
        {
            Console.Write($"{Name} has viewed a summary of their logged hours.");
        }
    }
}