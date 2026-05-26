using Core.Interfaces;
using Core.Models;

namespace Roles
{
    // This is a concrete class that represents an Auditor in the system.
    // Extends the Employee abstract class.
    public class Auditor : Employee
    {
        // This is a constructor that initialises a new Auditor object
        public Auditor(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Auditor", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public Auditor() : base("", "", "", "Auditor", "")
        {

        }

        // Creates a compliance report
        public void CreateComplianceReport()
        {
            // TODO: Write logic for creating a compliance report
        }

        // Accesses an existing financial report
        public void AccessFinancialReport()
        {
            // TODO: Write logic for accessing a financial report
        }
    }
}