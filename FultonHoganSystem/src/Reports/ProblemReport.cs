namespace FultonHogan.Reports
{
    public class ProblemReport : Report
    {
        public string ProblemCategory { get; protected set; }
        public string PriorityLevel { get; protected set; }
        public bool IsResolved { get; protected set; }

        public ProblemReport(string reportId, string projectId, string authorId, string description, string department, string problemCategory, string priorityLevel) : base(reportId, projectId, authorId, description, department)
        {
            ProblemCategory = problemCategory;
            PriorityLevel = priorityLevel;
            IsResolved = false;
        }

        public void SendAlert(string message)
        {
            Console.WriteLine("Alert has been sent.");
        }

        public void AttachEvidence(string evidence)
        {
            Console.WriteLine("Evidence has been attached to report.");
        }
    }
}