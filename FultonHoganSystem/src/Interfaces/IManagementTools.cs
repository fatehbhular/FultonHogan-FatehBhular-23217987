using System.Dynamic;
using FultonHogan.Projects;

namespace FultonHogan.Interfaces
{
    public interface IManagementTools
    {
        bool HasAccessToManagementTools { get; }
    }

    public interface IProjectManagerTools : IManagementTools
    {
        void InitialiseProject(Project project);
        void ModifyProject(Project project, string newStatus);
        void ViewProgress(Project project);
        void SendInstructions();
        void ViewProjectTasks();
        void ManageTasks();
    }

    public interface IProjectCoordinatorTools : IManagementTools
    {
        void LogProgress();
        void LogFindings();
        void CreateProgressReport();
        void UploadFiles();
        void ManageTasks();
    }

    public interface ISiteLeadTools : IManagementTools
    {
        void ViewProjectTasks();
        void CreateInstructions(string projectId, string instructions);
        void SendInstructions();
    }
}