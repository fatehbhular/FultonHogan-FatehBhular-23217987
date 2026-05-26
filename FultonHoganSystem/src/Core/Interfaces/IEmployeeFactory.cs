namespace Core.Interfaces
{
    // This interface defines the behaviour for all EmployeeFactories, where each factory is responsible for creating employees from specific departments.
    public interface IEmployeeFactory
    {
        // This method creates and returns an employee based on the role given to them.
        IEmployee CreateEmployee(string role);
    }
}