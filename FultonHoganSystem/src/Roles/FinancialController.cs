using Core.Interfaces;
using Core.Models;
using System;
using Services;

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
        public void ApproveProjectBudget(Project project)
        {
            if (project != null)
            {
                project.Status = "Budget Approved";
                Console.WriteLine($"Financial Controller: {Name} approved budget for: {project.Title}");
            }
        }

        // Views all finance reports in the system
        public void ViewFinanceReports(IReportRepository reportRepository)
        {
            Console.WriteLine($"Financial Controller: {Name} is accessing the general ledger and financial statements.");
        }
    }
}