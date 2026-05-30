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
            Console.WriteLine($"Foreman {Name} is reading the daily briefing for the site.");
        }

        // Issues a problem report for this site
        public void IssueProblem(string projectID, string details, ReportService reportService)
        {
            Report report = reportService.CreateReport("problem");
            if (report != null)
            {
                report.ProjectID = projectID;
                report.Description = details;
                report.AuthorID = this.EmployeeID;
                reportService.SaveReport(report);
                Console.WriteLine($"Foreman {Name} logged a site issue: {details}");
            }
        }
    }
}