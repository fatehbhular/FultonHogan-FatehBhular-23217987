using Core.Interfaces;
using Core.Models;

namespace Roles
{
    // This is a concrete class that represents a Financial Controller in the system.
    // Extends the Employee abstract class.
    public class FinancialController : Employee
    {
        // This is a constructor that initialises a new FinancialController object
        public FinancialController(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Financial Controller", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public FinancialController() : base("", "", "", "Financial Controller", "")
        {

        }

        // Approves the budget for a project
        public void ApproveProjectBudget()
        {
            // TODO: Create logic for budget approval
        }

        // Views all finance reports in the system
        public void ViewFinanceReports()
        {
            // TODO: Create logic for viewing finance reports
        }
    }
}