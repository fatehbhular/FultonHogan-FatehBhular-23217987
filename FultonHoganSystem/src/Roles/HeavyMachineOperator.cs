using Core.Interfaces;
using Core.Models;

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
            // TODO: Write logic for viewing instructions
        }

        // Issues a problem report
        public void IssueProblem()
        {
            // TODO: Write logic for issuing a problem report
        }

        // Accesses the timesheet for this operator
        public void AccessTimeSheet()
        {
            // TODO: Write logic for accessing a timesheet
        }
    }
}