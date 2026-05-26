using Core.Interfaces;
using Core.Models;

namespace Roles
{
    // This is a concrete class that represents a Project Accountant in the system.
    // Extends the Employee abstract class.
    public class ProjectAccountant : Employee
    {
        // This is a constructor that initialises a new ProjectAccountant object
        public ProjectAccountant(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Project Accountant", department)
        {

        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public ProjectAccountant() : base("", "", "", "Project Accountant", "")
        {

        }

        // Creates a financial report for a project
        public void CreateFinancialReport()
        {
            // TODO: Create logic for creating a financial report
        }
    }
}