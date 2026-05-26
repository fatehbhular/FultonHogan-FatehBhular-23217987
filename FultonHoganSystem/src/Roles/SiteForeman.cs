using Core.Interfaces;
using Core.Models;

namespace Roles
{
    // This is a concrete class that represents a Site Foreman in the system.
    // Extends the Employee abstract class.
    public class SiteForeman : Employee
    {
        // This is a constructor that initialises a new SiteForeman object
        public SiteForeman(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Site Foreman", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public SiteForeman() : base("", "", "", "Site Foreman", "")
        {

        }

        // Views the instructions assigned to this site
        public void ViewInstructions()
        {
            // TODO: Write logic for viewing instructions
        }

        // Issues a problem report for this site
        public void IssueProblem()
        {
            // TODO: Write logic for issuing a problem report
        }
    }
}