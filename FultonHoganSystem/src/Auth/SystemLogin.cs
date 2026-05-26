using Core.Interfaces;
using Core.Models;
using Factories;
using Microsoft.Data.Sqlite;

namespace Auth
{
    public class SystemLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }

        private DatabaseConnection dbConnection;

        public SystemLogin(string email, string password)
        {
            Email = email;
            Password = password;
            dbConnection = DatabaseConnection.GetInstance();
            dbConnection.Connect();
        }

        public IEmployee Login()
        {
            return null;
        }

        public IEmployeeFactory GetFactory(string department)
        {
            switch (department.ToLower())
            {
                case "finance":
                    return new FinanceEmployeeFactory();
                case "management":
                    return new ManagementEmployeeFactory();
                case "operations":
                    return new OperationsEmployeeFactory();
                default:
                    // If role doesn't match any of the above -> return null
                    return null;
            }
        }
    }
}