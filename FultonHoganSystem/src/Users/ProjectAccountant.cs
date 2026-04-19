using FultonHogan.Interfaces;
using FultonHogan.Projects;
using FultonHogan.Reports;

namespace FultonHogan.Users
{
    public class ProjectAccountant : User, IProjectAccountantFinanceTools
    {
        public bool HasAccessToFinanceTools => true;
        public int SecurityLevel { get; protected set; }

        public ProjectAccountant(string employeeId, string name, string email, string phoneNumber, string role, string department, int securityLevel) : base(employeeId, name, email, phoneNumber, role, department)
        {
            SecurityLevel = securityLevel;
        }

        // IProjectAccountantFinanceTools methods

        public void TrackEstimateVsActualCosts()
        {
            Console.WriteLine($"{Name} is tracking estimate vs actual costs.");
        }

        public void CreateFinancialReport()
        {
            Console.WriteLine($"{Name} has created a financial report.");
        }

        public void IssueFinancialProblem()
        {
            Console.WriteLine($"{Name} has issued a financial problem.");
        }
    }
}