using Core.Interfaces;
using Core.Models;
using Services;

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
        public void CreateFinancialReport(string projectID, ReportService reportService)
        {
            Console.WriteLine($"Accountant {Name} is generating a monthly financial statement for Project {projectID}...");
            Report report = reportService.CreateReport("financial");
            if (report != null)
            {
                report.ProjectID = projectID;
                report.AuthorID = this.EmployeeID;
                report.Department = this.Department;
                reportService.SaveReport(report);
                Console.WriteLine($"Financial Report {report.ReportID} successfully saved.");
            }
        }
    }
}