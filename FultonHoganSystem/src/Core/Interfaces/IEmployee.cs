namespace Core.Interfaces
{
    // This interface defines behaviour for the all Employee sub-classes.
    public interface IEmployee
    {
        // This method will return the role of the employee type. E.g. "Project Manager" or "SiteLead".
        string GetRole();
        // This method sends the employees login details to the system and attemps to log them in.
        bool Login(string email, string password);
        // This method logs the employee out of the system, and will return true if it was successful.
        bool Logout();
    }
}