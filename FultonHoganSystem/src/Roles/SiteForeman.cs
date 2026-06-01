using Core.Interfaces;
using Core.Models;
using Services;

namespace Roles
{
    // This is a concrete class that represents a Site Foreman in the system.
    // Extends the Employee abstract class.
    public class SiteForeman : Employee
    {
        // This is a constructor that initialises a new SiteForeman object
        // This method creates a site foreman.
        public SiteForeman(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Site Foreman", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        // This method creates an empty site foreman.
        public SiteForeman() : base("", "", "", "Site Foreman", "")
        {

        }

        // Views the instructions assigned to this site
        // This method shows site instructions.
        public void ViewInstructions()
        {
            Console.WriteLine($"Foreman {Name} is reading the daily briefing for the site.");
        }

        // Issues a problem report for this site
        // This method creates and saves a problem report.
        public void IssueProblem(string projectID, string issueDetails, ReportService reportService)
        {
            Report problemReport = reportService.CreateReport("problem");
            if (problemReport != null)
            {
                problemReport.ProjectID = projectID;
                problemReport.AuthorID = this.EmployeeID;
                problemReport.Description = issueDetails;
                reportService.SaveReport(problemReport);
            }
        }
    }
}
