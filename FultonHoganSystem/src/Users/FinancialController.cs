using FultonHogan.Interfaces;
using FultonHogan.Projects;
using FultonHogan.Reports;

namespace FultonHogan.Users
{
    public class FinancialController : User, IFinancialControllerTools
    {
        public bool HasAccessToFinanceTools => true;
        public int SecurityLevel { get; protected set; }

        public FinancialController(string employeeId, string name, string email, string phoneNumber, string role, string department, int securityLevel) : base(employeeId, name, email, phoneNumber, role, department)
        {
            SecurityLevel = securityLevel;
        }

        // IFinancialControllerTools methods

        public void ApproveBudget()
        {
            Console.WriteLine($"{Name} has approved the budget.");
        }

        public void ViewFinancialResources()
        {
            Console.WriteLine($"{Name} is accessing financial resources.");
        }

        public void TrackEstimateVsActualCosts()
        {
            Console.WriteLine($"{Name} is tracking estimate vs actual costs.");
        }

        public void CreateFinancialReport()
        {
            Console.WriteLine($"{Name} has created a financial report.");
        }

        public void CreateComplianceReport()
        {
            Console.WriteLine($"{Name} created a compliance report.");
        }

        public void AccessFinancialReports()
        {
            Console.WriteLine($"{Name} is accessing financial reports from the database...");
        }

        public void IssueFinancialProblem()
        {
            Console.WriteLine($"{Name} has issued a financial problem.");
        }

        public void VerifyFinancialAccuracy()
        {
            Console.WriteLine($"{Name} has verified the financial accuracy of all financial documents");
        }
    }
}