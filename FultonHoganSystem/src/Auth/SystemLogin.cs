using Core.Interfaces;
using Core.Models;
using Factories;
using Repositories;
using Microsoft.Data.Sqlite;

namespace Auth
{
    public class SystemLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        private DatabaseEmployeeRepository EmployeeRepository;

        public SystemLogin(string email, string password)
        {
            Email = email;
            Password = password;
            EmployeeRepository = new DatabaseEmployeeRepository();
        }

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