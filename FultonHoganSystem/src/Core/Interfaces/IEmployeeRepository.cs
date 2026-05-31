using System.Data;
using Core.Models;
using Microsoft.Data.Sqlite;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface defining the behavior for employee data persistence operations.
    /// Responsible for saving and retrieving employee records from the database.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Saves an employee and their password to the database.
        /// </summary>
        /// <param name="employee">The employee record to save</param>
        /// <param name="password">The employee's password (plaintext or hashed)</param>
        void Save(Employee employee, string password);

        /// <summary>
        /// Retrieves an employee record from the database based on credentials.
        /// </summary>
        /// <param name="email">The employee's email address</param>
        /// <param name="password">The employee's password</param>
        /// <returns>A SqliteDataReader containing the employee record if found, null otherwise</returns>
        SqliteDataReader GetUser(string email, string password);
    }
}
