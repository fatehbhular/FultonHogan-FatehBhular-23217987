using Core.Models;
using Reports;

namespace Factories
{
    // This is a concrete factory responsible for creating the correct report type.
    // Implements the "Simple Factory" method.
    public class ReportFactory
    {
        // Creates a returns a report sub-class of the specified type inputted as the first parameter.
        // Initialisation of "Financial Report", "Compliance Report", "Progress Report", and "Problem Report".
        public Report CreateReport(string type, string reportID, string projectID, string authorID, string description, string department)
        {
            switch (type.ToLower())
            {
                // If the role is financial, create a new instance of FinanicalReport
                case "financial":
                    return new FinancialReport(reportID, projectID, authorID, description, department);
                // If the role is compliance, create a new instance of ComplianceReport
                case "compliance":
                    return new ComplianceReport(reportID, projectID, authorID, description, department);
                // If the role is progress, create a new instance of ProgressReport
                case "progress":
                    return new ProgressReport(reportID, projectID, authorID, description, department);
                // If the role is problem, create a new instance of ProblemReport
                case "problem":
                    return new ProblemReport(reportID, projectID, authorID, description, department);
                default:
                    // If the report type is not any of the above options -> return null
                    return null;
            }
        }
    }
}