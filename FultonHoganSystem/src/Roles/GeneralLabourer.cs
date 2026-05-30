using Core.Interfaces;
using Core.Models;
using Services;

namespace Roles
{
    // This is a concrete class that represents a General Labourer in the system.
    // Extends the Employee abstract class.
    public class GeneralLabourer : Employee
    {
        // This is a constructor that initialises a new GeneralLabourer object
        public GeneralLabourer(string name, string employeeID, string email, string department) : base(name, employeeID, email, "General Labourer", department)
        {
            
        }

        // This is a DEFAULT constructor that lets the factory create employee object without other details e.g. name, department, etc.
        public GeneralLabourer() : base("", "", "", "General Labourer", "")
        {

        }

        // Accesses the timesheet for this labourer
        public void AccessTimeSheet()
        {
            Console.WriteLine($"Labourer: {Name} (ID: {EmployeeID}) is logging hours into the timesheet system.");
        }
    }
}