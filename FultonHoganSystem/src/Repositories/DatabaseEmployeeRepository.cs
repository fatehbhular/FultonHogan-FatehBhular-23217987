using System;
using Microsoft.Data.Sqlite;
using Core.Models;
using Core.Interfaces;

namespace Repositories
{
    // Implements IEmployeeRepository - database persistence for employees.
    public class DatabaseEmployeeRepository : IEmployeeRepository
    {
        // Holds the reference to the database connection helper instance
        private DatabaseConnection DbConnection;

        // Retrieves the singleton instance of the Database connection class
        public DatabaseEmployeeRepository()
        {
            DbConnection = DatabaseConnection.GetInstance();
        }

        // Saves an employee and their password to the database
        public void Save(Employee employee, string password)
        {
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();

            string sql = @"INSERT OR REPLACE INTO Employees (EmployeeID, Name, Email, Password, Role, Department) 
                           VALUES (@ID, @Name, @Email, @Pass, @Role, @Dept)";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Pass", password);
                cmd.Parameters.AddWithValue("@Role", employee.Role);
                cmd.Parameters.AddWithValue("@Dept", employee.Department);
                cmd.ExecuteNonQuery();
            }
        }

        // Retrieves a single row from the database based on credentials
        public SqliteDataReader GetUser(string email, string password)
        {
            DbConnection.Connect();
            var conn = DbConnection.GetConnect();

            string sql = @"SELECT * FROM Employees WHERE Email = @Email AND Password = @Password";
            var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);

            return cmd.ExecuteReader();
        }
    }
}