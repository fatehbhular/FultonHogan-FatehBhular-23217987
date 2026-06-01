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
        // This method creates a heavy machine operator.
        public HeavyMachineOperator(string name, string employeeID, string email, string department) : base(name, employeeID, email, "Heavy Machine Operator", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        // This method creates an empty heavy machine operator.
        public HeavyMachineOperator() : base("", "", "", "Heavy Machine Operator", "")
        {

        }

        // Views the instructions assigned to this operator
        // This method shows machine operator instructions.
        public string ViewInstructions()
        {
            return "Safety Check: Inspect hydraulic fluid levels. Site zone: B-4.";
        }

        // Issues a problem report
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

        // Accesses the timesheet for this operator
        // This method opens the timesheet.
        public void AccessTimeSheet()
        {
            Console.WriteLine($"Operator {Name} is updating their machine operation log and timesheet.");
        }
    }
}
