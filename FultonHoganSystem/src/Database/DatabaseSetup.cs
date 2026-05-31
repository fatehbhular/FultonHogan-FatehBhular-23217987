using Core.Models;
using Microsoft.Data.Sqlite;

namespace Database 
{   
    // This class is responsible for setting up the database tables when the application first starts.
    // It creates all the necessary tables if they don't exist.
    public class DatabaseSetup 
    {
        // The shared DatabaseConnection instance that is retrieved from the the Singleton
        private DatabaseConnection dbConnection;

        // Initialises the DatabaseSetup by retriving the singleton DatabaseConnection instance
        public DatabaseSetup() 
        {
            dbConnection = DatabaseConnection.GetInstance();
            dbConnection.Connect();
        }

        // Runs all the SQL commands to create the tables
        public void Initialise() 
        {
            CreateEmployeeTable();
            CreateProjectTable();
            CreateTaskListTable();
            CreateTaskTable();
            CreateReportTable();
            CreateTimesheetTable();
            CreateEntryTable();
            CreateInstructionsTable();
            AddIsApprovedColumn();
        }

        // Creates the Employees table if it doesn't exist
        private void CreateEmployeeTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Employees (
                EmployeeID TEXT PRIMARY KEY,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL,
                Department TEXT NOT NULL
            )";
            ExecuteSQL(sql);
        }

        // Creates the Projects table if it doesn't exist
        private void CreateProjectTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Projects (
                ProjectID TEXT PRIMARY KEY,
                Title TEXT NOT NULL,
                Status TEXT NOT NULL,
                BudgetLimit INTEGER NOT NULL,
                CurrentSpendings INTEGER NOT NULL,
                StartDate DATE NOT NULL,
                Deadline DATE NOT NULL
            )";
            ExecuteSQL(sql);
        }

        // Creates the TaskLists table if it doesn't exist
        private void CreateTaskListTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS TaskLists (
                TaskListID TEXT PRIMARY KEY,
                ProjectID TEXT NOT NULL,
                Description TEXT NOT NULL,
                FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
            )";
            ExecuteSQL(sql);
        }

        // Creates the Tasks table if it doesn't exist
        private void CreateTaskTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Tasks (
                TaskID TEXT PRIMARY KEY,
                TaskListID TEXT NOT NULL,
                Description TEXT NOT NULL,
                Status TEXT NOT NULL,
                FOREIGN KEY (TaskListID) REFERENCES TaskLists(TaskListID)
            )";
            ExecuteSQL(sql);
        }

        // Creates the Reports table if it doesn't exist
        private void CreateReportTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Reports (
                ReportID TEXT PRIMARY KEY,
                ProjectID TEXT NOT NULL,
                AuthorID TEXT NOT NULL,
                Description TEXT NOT NULL,
                Timestamp DATETIME NOT NULL,
                Department TEXT NOT NULL,
                ReportType TEXT NO NULL,
                FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
                FOREIGN KEY (AuthorID) REFERENCES Employees(EmployeeID)
            )";
            ExecuteSQL(sql);
        }

        // Creates the Timesheets table if it doesn't exist
        private void CreateTimesheetTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Timesheets (
                TimesheetID TEXT PRIMARY KEY,
                OwnerID TEXT NOT NULL,
                PayPeriod DATE NOT NULL,
                FOREIGN KEY (OwnerID) REFERENCES Employees(EmployeeID)
            )";
            ExecuteSQL(sql);
        }

        // Creates the Entries table if it doesn't exist
        private void CreateEntryTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Entries (
                EntryID TEXT PRIMARY KEY,
                TimesheetID TEXT NOT NULL,
                OwnerID TEXT NO NULL,
                DateWorked TEXT NOT NULL,
                TimeWorked TEXT NOT NULL,
                FOREIGN KEY (TimesheetID) REFERENCES Timesheets(TimesheetID),
                FOREIGN KEY (OwnerID) REFERENCES Employees(EmployeeID)
            )";
            ExecuteSQL(sql);
        }

        // Creates the Instructions table if it doesn't exist
        private void CreateInstructionsTable() 
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Instructions (
                InstructionsID TEXT PRIMARY KEY,
                SenderID TEXT NOT NULL,
                SiteID TEXT NOT NULL,
                Timestamp TEXT NOT NULL,
                FOREIGN KEY (SenderID) REFERENCES Employees(EmployeeID)
            )";
            ExecuteSQL(sql);
        }

        // Executes a SQL command to the database
        // This is used by all CreateTable methods
        private void ExecuteSQL(string sql) 
        {
            SqliteCommand command = new SqliteCommand(sql, dbConnection.GetConnect());
            command.ExecuteNonQuery();
        }

        private void AddIsApprovedColumn()
        {
            // We wrap it in a try-catch because if the column already exists, it will throw an error
            try {
                string sql = "ALTER TABLE Reports ADD COLUMN IsApproved INTEGER DEFAULT 0";
                ExecuteSQL(sql);
                Console.WriteLine("Database updated: IsApproved column added to Reports.");
            } catch {
                // If it fails, the column likely already exists, which is fine.
            }
        }
    }
}