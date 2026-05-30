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
                case "financial":
                    return new FinancialReport(reportID, projectID, authorID, description, department);
                case "compliance":
                    return new ComplianceReport(reportID, projectID, authorID, description, department);
                case "progress":
                    return new ProgressReport(reportID, projectID, authorID, description, department);
                case "problem":
                    return new ProblemReport(reportID, projectID, authorID, description, department);
                default:
                    // If the report type is not any of the above options -> return null
                    return null;
            }
        }
    }
}