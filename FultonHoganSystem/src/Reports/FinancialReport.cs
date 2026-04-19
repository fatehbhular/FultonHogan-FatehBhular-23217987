namespace FultonHogan.Reports
{
    public class FinancialReport : Report
    {
        public decimal EstimatedCost { get; protected set; }
        public decimal ActualCost { get; protected set; }
        public bool IsApproved { get; protected set; }

        public FinancialReport(string reportId, string projectId, string authorId, string description, string department, decimal estimatedCost, decimal actualCost, bool isApproved) : base(reportId, projectId, authorId, description, department)
        {
            EstimatedCost = estimatedCost;
            ActualCost = actualCost;
            IsApproved = isApproved;
        }

        public decimal CalculateEVA(decimal estimatedCost, decimal actualCost)
        {
            decimal variance = actualCost - estimatedCost;

            if (variance > 0)
            {
                Console.WriteLine($"Project has ${variance} more for more spendings.");
            }
            else
            {
                Console.WriteLine($"Project has already spent ${variance} over the limit");
            }

            return variance;
        }
    }
}