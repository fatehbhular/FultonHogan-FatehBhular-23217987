using Core.Interfaces;
using Core.Models;
using Microsoft.Data.Sqlite;

namespace Repositories
{
    public class DatabaseReportRepository : IReportRepository
    {
        private DatabaseConnection _connection;

        public DatabaseReportRepository()
        {
            _connection = DatabaseConnection.GetInstance();
            _connection.Connect();
        }

        public void Save(Report report)
        {
            // TODO: Write logic for saving a report to the database
        }

        public Report GetByID(string reportID)
        {
            // TODO: Write logic for retrieving a report from the database
            return null;
        }
    }
}