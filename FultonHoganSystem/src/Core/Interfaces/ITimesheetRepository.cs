using System.Collections.Generic;
using Core.Models;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface defining the behavior for timesheet data persistence operations.
    /// Responsible for managing timesheet entries and retrieving employee hours worked.
    /// </summary>
    public interface ITimesheetRepository
    {
        /// <summary>
        /// Retrieves all time entries for a specific employee.
        /// </summary>
        /// <param name="employeeID">The ID of the employee whose entries are being retrieved</param>
        /// <returns>A list of formatted time entries (date: hours) for the specified employee</returns>
        List<string> GetEntriesForEmployee(string employeeID);

        /// <summary>
        /// Adds a new timesheet entry for an employee.
        /// </summary>
        /// <param name="ownerID">The ID of the employee who performed the work</param>
        /// <param name="date">The date the work was performed</param>
        /// <param name="hours">The number of hours worked</param>
        void AddEntry(string ownerID, string date, string hours);
    }
}
