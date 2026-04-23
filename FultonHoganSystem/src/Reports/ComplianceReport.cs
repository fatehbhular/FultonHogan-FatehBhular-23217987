namespace FultonHogan.Reports
{
    public class ComplianceReport : Report
    {
        public List<String> AuditHistory { get; private set; }
        public bool IsApproved { get; protected set; }

        public ComplianceReport(string reportId, string projectId, string authorId, string description, string department, List<String> auditHistory, bool isApproved) : base(reportId, projectId, authorId, description, department)
        {
            AuditHistory = auditHistory;
            IsApproved = isApproved;
        }

        // Auditor calls to verify financial report accuracy
        public bool VerifyReportAccuracy(bool isVerified)
        {
            if (isVerified == true)
            {
                Console.WriteLine("This report has been verified.");
                return true;
            }
            else
            {
                Console.WriteLine("This report hasn't passed verification.");
                return false;
            }
        }

        // Auditor calls to flag any problems if something is wrong in the financial report
        public void FlagInconsistency(string content)
        {
            Console.WriteLine($"{content} has been flagged as an inconsistency.");
        }
    }
}