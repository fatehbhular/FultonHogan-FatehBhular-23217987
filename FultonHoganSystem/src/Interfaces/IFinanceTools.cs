namespace FultonHogan.Interfaces
{
    public interface IFinanceTools
    {
        bool HasAccessToFinanceTools { get; }
        void ApproveBudget();
        void ViewFinancialResources();
        void TrackEstimateVsActualCosts();
        void CreateFinancialReport();
        void CreateComplianceReport();
        void AccessFinancialReports();
        void IssueFinancialProblem();
        void VerifyFinancialAccuracy();
    }

    public interface IFinancialControllerTools : IFinanceTools
    {
    }

    public interface IAuditorFinanceTools
    {
        bool HasAccessToFinanceTools { get; }
        void VerifyFinancialAccuracy();
        void IssueFinancialProblem();
        void AccessFinancialReports();
        void CreateComplianceReport();
    }

    public interface IProjectAccountantFinanceTools
    {
        bool HasAccessToFinanceTools { get; }
        void TrackEstimateVsActualCosts();
        void CreateFinancialReport();
        void IssueFinancialProblem();
    }
}