using FultonHogan.Interfaces;
using FultonHogan.Projects;
using FultonHogan.Reports;

namespace FultonHogan.Users
{
    public class Auditor : User, IAuditorFinanceTools
    {
        public bool HasAccessToFinanceTools => true;
        public int SecurityLevel { get; protected set; }

        public Auditor(string employeeId, string name, string email, string phoneNumber, string role, string department, int securityLevel) : base(employeeId, name, email, phoneNumber, role, department)
        {
            SecurityLevel = securityLevel;
        }

        // IAuditorFinanceTools methods

        public void VerifyFinancialAccuracy()
        {
            Console.WriteLine($"{Name} has verified the financial accuracy of all financial documents");
        }

        public void IssueFinancialProblem()
        {
            Console.WriteLine($"{Name} has issued a financial problem.");
        }

        public void AccessFinancialReports()
        {
            Console.WriteLine($"{Name} is accessing financial reports from the database...");
        }

        public void CreateComplianceReport()
        {
            Console.WriteLine($"{Name} created a compliance report.");
        }
    }
}