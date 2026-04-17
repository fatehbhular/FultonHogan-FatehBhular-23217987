namespace FultonHogan.Reports
{
    public class Report
    {
        // Properties for the Report class with getters + setters.
        public string ReportId { get; private set; }
        public string ProjectId { get; private set; }
        public string AuthorId { get; private set; }
        public string Description { get; protected set; }
        public DateTime Timestamp { get; protected set; }
        public string Department { get; protected set; }

        public Report(string reportId, string projectId, string authorId, string description, string department)
        {
            ReportId = reportId;
            ProjectId = projectId;
            AuthorId = authorId;
            Description = description;
            Department = department;
            Timestamp = DateTime.Now;
        }

        public void GenerateTemplate()
        {
            // Generates a CUI template for the user to see.
            Console.WriteLine($"ReportId: {ReportId}, ProjectId: {ProjectId}, AuthorId: {AuthorId}");
            Console.WriteLine($"Report Content: {Description}");
        }

        public void SaveToDatabase()
        {
            // Should save this report into the Reports Database.
            Console.WriteLine($"This report <{ReportId}> has been saved to the database");
        }

        public void ExportToPDF()
        {
            // Should convert the information in this report into a PDF document.
            Console.WriteLine($"This report <{ReportId}> is ready to be downloaded as a PDF.");
        }
    }
}