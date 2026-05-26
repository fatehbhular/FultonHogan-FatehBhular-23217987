namespace Core.Models
{
    // This is an abstract base class that represents a report in the system.
    // It cannot be initialised directly, only the inherited class can be initialised e.g. Financial Report, Progress Report, etc.
    public abstract class Report
    {
        public string ReportID { get; set; }
        public string ProjectID { get; set; }
        public string AuthorID { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string Department { get; set; }

        // Constructor that initialises a new report.
        // This is only called by report sub-classes.
        public Report(string reportID, string projectID, string authorID, string description, string department)
        {
            ReportID = reportID;
            ProjectID = projectID;
            AuthorID = authorID;
            Description = description;
            Timestamp = DateTime.Now;
            Department = department;
        }

        // Generates a template depending on the report type
        public abstract void GenerateTemplate();
        // Saves the report to the database
        public abstract void Save();
        // Exports the report to PDF
        public abstract void ExportToPDF();
    }
}