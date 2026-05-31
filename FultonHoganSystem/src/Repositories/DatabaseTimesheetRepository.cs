using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Core.Models;
using Core.Interfaces;

namespace Repositories
{
    // Implements ITimesheetRepository - database persistence for timesheets.
    public class DatabaseTimesheetRepository : ITimesheetRepository
    {
        private DatabaseConnection DbConnection;

        public DatabaseTimesheetRepository()
        {
            DbConnection = DatabaseConnection.GetInstance();
        }

        // Retrieves entries for a specific employee
        public List<string> GetEntriesForEmployee(string employeeID)
        {
            var entries = new List<string>();
            DbConnection.Connect();
            string sql = "SELECT DateWorked, TimeWorked FROM Entries WHERE OwnerID = @OwnerID";
            
            using (var cmd = new SqliteCommand(sql, DbConnection.GetConnect()))
            {
                cmd.Parameters.AddWithValue("@OwnerID", employeeID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entries.Add($"{reader["DateWorked"]}: {reader["TimeWorked"]} hours");
                    }
                }
            }
            return entries;
        }

        // Saves a new entry to the database
        public void AddEntry(string ownerID, string date, string hours)
        {
            DbConnection.Connect();
            // Note: TimesheetID is set to a default 'TS-01' for this project scope
            string sql = @"INSERT INTO Entries (EntryID, TimesheetID, OwnerID, DateWorked, TimeWorked) 
                           VALUES (@EID, @TID, @OID, @Date, @Time)";
            
            using (var cmd = new SqliteCommand(sql, DbConnection.GetConnect()))
            {
                cmd.Parameters.AddWithValue("@EID", Guid.NewGuid().ToString().Substring(0, 8));
                cmd.Parameters.AddWithValue("@TID", "TS-01"); 
                cmd.Parameters.AddWithValue("@OID", ownerID);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Time", hours);
                cmd.ExecuteNonQuery();
            }
        }
    }
}