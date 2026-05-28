using Core.Models;

namespace Core.Interfaces
{
    // This interface defines the behaviour for report storing and retrieving.
    public interface IReportRepository
    {
        // Saves the report to the database
        void Save(Report report);
        
        // Retrieves a report from the database using "ReportID" as the key identifier.
        Report GetByID(string reportID);
    }
}