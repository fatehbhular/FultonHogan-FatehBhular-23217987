namespace FultonHogan.Reports
{
    public class GenerateReport
    {
        public string ReportType { get; protected set; }
        public string ReportId { get; private set; }
        public string ProjectId { get; private set; }
        public string AuthorId { get; private set; }
        public string Description { get; protected set; }
        public DateTime Timestamp { get; protected set; }
        public string Department { get; protected set; }

        public GenerateReport(string reportType, string reportId, string projectId, string authorId, string description, string department)
        {
            ReportType = reportType;
            ReportId = reportId;
            ProjectId = projectId;
            AuthorId = authorId;
            Description = description;
            Department = department;
            Timestamp = DateTime.Now;
        }

        public Report CreateReport()
        {
            switch (ReportType.ToLower())
            {
                case "financial":
                    return new FinancialReport(ReportId, ProjectId, AuthorId, Description, Department, 0, 0, false);
                case "compliance":
                    List<String> AuditHistory = new List<String>();
                    return new ComplianceReport(ReportId, ProjectId, AuthorId, Description, Department, AuditHistory, false);
                case "problem":
                    return new ProblemReport(ReportId, ProjectId, AuthorId, Description, Department, "blueprints", "urgent");
                case "progress":
                    List<Projects.Task> TasksCompleted = new List<Projects.Task>();
                    return new ProgressReport(ReportId, ProjectId, AuthorId, Description, Department, TasksCompleted, 68.2, "Need ot buy more concrete");
                default:
                    return new Report(ReportId, ProjectId, AuthorId, Description, Department);
            }
        }
    }
}