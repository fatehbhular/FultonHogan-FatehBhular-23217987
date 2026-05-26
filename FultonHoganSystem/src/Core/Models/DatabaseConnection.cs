using Microsoft.Data.Sqlite;

namespace Core.Models
{
    public class DatabaseConnection
    {
        // only one instance of this class
        private static DatabaseConnection dbConnection;
        
        // SQLite connection
        private SqliteConnection Connection { get; set; }

        // Private constructor to prevent initialisation directly
        private DatabaseConnection(string connectionString)
        {
            Connection = new SqliteConnection(connectionString);
        }

        // Returns the same instance of DatabaseConnection.
        // If the instance doesn't exist, it will create it.
        //
        // "connectionString" is the source to the database.
        public static DatabaseConnection GetInstance(string connectionString = "Data Source=fultonhogan.db")
        {
            if (dbConnection == null)
            {
                dbConnection = new DatabaseConnection(connectionString);
            }
            return dbConnection;
        }

        // Opens the connection to the database if it isn't open.
        public void Connect()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        // Returns the SQLite connection instance so that we can use it in queries.
        public SqliteConnection GetConnect()
        {
            return Connection;
        }
    }
}