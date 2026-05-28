using Core.Models;

namespace Interfaces
{
    // This interface defines the behaviour for data persistence
    public interface IProjectRepository
    {
        // Retrieves a project using its ID
        Project GetByID(string projectID);

        // Saves changes of a project in the database
        void Save(Project project);
    }
}