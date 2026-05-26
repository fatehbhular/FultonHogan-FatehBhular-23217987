using Core.Interfaces;

namespace Core.Models
{
    // This is an abstract base class that represents an employee in the system. 
    // Because it is abstract, it cannot be initialised directly. 
    public abstract class Employee : IEmployee
    {
        public string Name { get; set; }
        public string EmployeeID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }

        // Constructor that initialises a new employee.
        // This is only called by employee sub-classes e.g. Finance Controller, Site Foreman, etc.
        public Employee(string name, string employeeID, string email, string role, string department)
        {
            Name = name;
            EmployeeID = employeeID;
            Email = email;
            Role = role;
            Department = department;
        }

        // Returns the role of the employee.
        public string GetRole()
        {
            return Role;
        }

        // Attempts to log the employee in matching the username and password, with a match in the database.
        public bool Login(string email, string password)
        {
            // TODO: Authentication logic which is in LoginService
            return true;
        }

        // Logs the employee out of the system.
        public bool Logout()
        {
            return true;
        }
    }
}