using Core.Models;
using Microsoft.Data.Sqlite;

namespace Auth
{
    // This class handles the login process for Fulton Hogan employees who are trying to access their timesheet.
    // Checks if the employee's email and password match the record in the database.
    public class TimesheetLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }

        // This is a constructor that initialises a new TimesheetLogin object using the employees credentials
        // This method stores the timesheet login details.
        public TimesheetLogin(string email, string password)
        {
            Email = email;
            Password = password;
        }

        // Returns a boolean if the employee logged in successfully or not
        // This method checks if the timesheet login is valid.
        public bool Login()
        {
            var dbConnection = DatabaseConnection.GetInstance();
            dbConnection.Connect();

            // Retrieve the active Sqlite connection
            SqliteConnection connection = dbConnection.GetConnect();

            string sql = @"Select COUNT(1) FROM Employees WHERE Email = @Email AND Password = @Password";

            using (var command = new SqliteCommand(sql, connection)) {
                // This will bind the paramters to protect against SQL injection
                command.Parameters.AddWithValue("@Email", this.Email);
                command.Parameters.AddWithValue("@Password", this.Password);

                try {
                    long count = (long)command.ExecuteScalar();
                    return count > 0; // If count is > 0, credentials match
                } catch (SqliteException ex) {
                    Console.WriteLine($"Database error during timesheet login: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
