using Core.Interfaces;
using Core.Models;
using Services;

namespace Roles
{
    // This is a concrete class that represents an Auditor in the system.
    // Extends the Employee abstract class.
    public class Auditor : Employee
    {
        // This is a constructor that initialises a new Auditor object
        // This method creates an auditor.
        public Auditor(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Auditor", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        // This method creates an empty auditor.
        public Auditor() : base("", "", "", "Auditor", "")
        {

        }

        // Creates a compliance report
        // This method creates and saves a compliance report.
        public void CreateComplianceReport(ReportService reportService)
        {
            Console.WriteLine($"Auditor: {Name} is initiating a compliance audit...");
            Report newReport = reportService.CreateReport("compliance");
            
            if (newReport != null)
            {
                newReport.AuthorID = this.EmployeeID;
                newReport.Department = this.Department;
                reportService.SaveReport(newReport);
                Console.WriteLine($"Compliance Report {newReport.ReportID} created and saved.");
            }
        }

        // Accesses an existing financial report
        // This method opens a financial report.
        public void AccessFinancialReport(string reportID, ReportService reportService)
        {
            Report report = reportService.ViewReport(reportID, this.EmployeeID);
            if (report != null)
            {
                Console.WriteLine($"Auditor: {Name} is reviewing Financial Report: {reportID}");
            }
        }

        // This method checks a report.
        public void VerifyReportAccuracy(Report report)
        {
            // Logic: In a real system, this would perform a checksum or data validation
            Console.WriteLine($"Auditor {Name} is verifying the data integrity of Report {report.ReportID}...");
        }
    }
}
