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

        public SystemLogin(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public IEmployee Login()
        {
            var dbConnection = DatabaseConnection.GetInstance();
            dbConnection.Connect();

            // Returns the SQLite connection so we can use it in queries.
            SqliteConnection connection = dbConnection.GetConnect();

            // SQL query that searches the Employees database for these inputs
            string sql = @"SELECT * FROM Employees WHERE Email = @Email AND Password = @Password";

            using (var command = new SqliteCommand(sql, connection)) 
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);

                using (var reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        string department = reader["Department"].ToString();
                        string role = reader["Role"].ToString();

                        IEmployeeFactory factory = GetFactory(department);
                        if (factory != null) {
                            return factory.CreateEmployee(role);
                        }
                    }
                }
            }

            // Fallback -> incase the credentials fail
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