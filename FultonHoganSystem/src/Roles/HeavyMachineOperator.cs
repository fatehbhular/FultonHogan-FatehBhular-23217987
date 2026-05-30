using Core.Interfaces;
using Core.Models;
using Services;

namespace Roles
{
    // This is a concrete class that represents a Heavy Machine Operator in the system.
    // Extends the Employee abstract class.
    public class HeavyMachineOperator : Employee
    {
        // This is a constructor that initialises a new HeavyMachineOperator object
        public HeavyMachineOperator(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Heavy Machine Operator", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public HeavyMachineOperator() : base("", "", "", "Heavy Machine Operator", "")
        {

        }

        // Views the instructions assigned to this operator
        public void ViewInstructions()
        {
            Console.WriteLine($"Operator {Name} is viewing safety and operation instructions for heavy machinery.");
        }

        // Issues a problem report
        public void IssueProblem(ReportService reportService, string projectID, string issueDetails)
        {
            Console.WriteLine($"Operator {Name} is reporting a site issue...");
            Report problemReport = reportService.CreateReport("problem");

            if (problemReport != null)
            {
                problemReport.ProjectID = projectID;
                problemReport.AuthorID = this.EmployeeID;
                problemReport.Description = issueDetails;
                reportService.SaveReport(problemReport);
                
                Console.WriteLine($"Problem Report {problemReport.ReportID} issued for Project {projectID}.");
            }
        }

        // Accesses the timesheet for this operator
        public void AccessTimeSheet()
        {
            Console.WriteLine($"Operator {Name} is updating their machine operation log and timesheet.");
        }
    }
}