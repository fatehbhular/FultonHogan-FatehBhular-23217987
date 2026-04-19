namespace FultonHogan.Interfaces
{
    public interface IOperationTools
    {
        bool HasAccessToSiteTools { get; }
        void FlagSiteIssue();
    }

    public interface ISiteForemanTools : IOperationTools
    {
        void ViewInstructions();
        void RecieveInstructions();
        void RelayInstructionsToSite();
    }

    public interface IHeavyMachineOperatorTools : IOperationTools
    {
        void LogEquipmentUsage();
        void ReportEquipmentCondition();
        void CommunicateWithForeman();
        void LogDailyWorkingHours();
        void ViewLoggedHoursSummary();
    }

    public interface IGeneralLabourerTools : IOperationTools
    {
        void CommunicateWithForeman();
        void LogDailyWorkingHours();
        void ViewLoggedHoursSummary();
    }
}