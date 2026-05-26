using Core.Models;

namespace Auth
{
    // This class handles the login process for Fulton Hogan employees who are trying to access their timesheet.
    // Checks if the employee's email and password match the record in the database.
    public class TimesheetLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }

        // This is a constructor that initialises a new TimesheetLogin object using the employees credentials
        public TimesheetLogin(string email, string password)
        {
            Email = email;
            Password = password;
        }

        // Returns a boolean if the employee logged in successfully or not
        public bool Login()
        {
            // TODO: Write logic to check credentials against match in database
            return false;
        }
    }
}