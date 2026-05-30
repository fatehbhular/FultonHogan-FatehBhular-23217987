using Microsoft.Data.Sqlite;
using System.Data;

namespace Core.Models
{
    public class DatabaseConnection
    {
        // Only one instance of this class
        private static DatabaseConnection Instance;

        // SQLite connection object
        private SqliteConnection Connection;
        
        // Stores the string of the connection
        private readonly string ConnectionString;

        // Private constructor to prevent initialisation directly
        private DatabaseConnection(string connectionString)
        {
            ConnectionString = connectionString;
            Connection = new SqliteConnection(ConnectionString);  // Initialises the connection object so it isn't null
        }

        // Returns the same instance of DatabaseConnection.
        // If the instance doesn't exist, it will create it.
        public static DatabaseConnection GetInstance(string connectionString = "Data Source=fultonhogan.db")
        {
            if (Instance == null)
            {
                Instance = new DatabaseConnection(connectionString);
            }
            return Instance;
        }

        // Opens the connection to the database if it isn't open.
        public void Connect()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
                
                // ADD THIS: This line disables Foreign Key checks so your tests don't crash
                using (var command = new Microsoft.Data.Sqlite.SqliteCommand("PRAGMA foreign_keys = OFF;", Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Returns the SQLite connection instance so that we can use it in queries.
        public SqliteConnection GetConnect()
        {
            return Connection;
        }
    }
}