using Core.Interfaces;
using Core.Models;
using Factories;
using Repositories;
using Microsoft.Data.Sqlite;

namespace Auth
{
    // Handles the authentication logic for employees
    public class SystemLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        private DatabaseEmployeeRepository EmployeeRepository;

        // Initialises a new instance of SystemLogin
        public SystemLogin(string email, string password)
        {
            Email = email;
            Password = password;
            EmployeeRepository = new DatabaseEmployeeRepository();
        }

        // Authenticates the user credientials and returns the employee that logged in
        public IEmployee Login()
        {
            using (var reader = EmployeeRepository.GetUser(Email, Password))
            {
                if (reader.Read())
                {
                    string dept = reader["Department"].ToString() ?? "";
                    // Remove spaces from role to match factory switch statements
                    string role = (reader["Role"].ToString() ?? "").Replace(" ", "").ToLower();

                    IEmployeeFactory factory = GetFactory(dept);
                    if (factory != null)
                    {
                        // Create the concrete object
                        IEmployee employee = factory.CreateEmployee(role);

                        // Since IEmployee is an interface, we cast it to Employee 
                        // to set the properties from the database
                        if (employee is Employee empObj)
                        {
                            empObj.Name = reader["Name"].ToString() ?? "";
                            empObj.EmployeeID = reader["EmployeeID"].ToString() ?? "";
                            empObj.Email = reader["Email"].ToString() ?? "";
                            empObj.Department = dept;
                        }

                        return employee;
                    }
                }
            }
            return null; // Login failed
        }

        // Determines and returns the right factory instance based on the department
        public IEmployeeFactory GetFactory(string department)
        {
            switch (department.ToLower())
            {
                case "finance": return new FinanceEmployeeFactory();
                case "management": return new ManagementEmployeeFactory();
                case "operations": return new OperationsEmployeeFactory();
                default: return null;
            }
        }
    }
}