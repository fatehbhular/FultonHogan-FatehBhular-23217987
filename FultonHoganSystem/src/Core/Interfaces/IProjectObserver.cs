namespace Core.Interfaces
{
    // This interface defines the behaviour for all employees that are notified of changes in a Project object.
    public interface IProjectObserver
    {
        // This method is called by .Notify() whenever the "status" of the project changes.
        void OnProjectUpdate(string projectId, string status);
    }
}