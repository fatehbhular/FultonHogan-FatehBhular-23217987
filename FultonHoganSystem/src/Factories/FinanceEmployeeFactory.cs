using Core.Interfaces;
using Core.Models;
using Roles;

namespace Factories
{
    // This is a concrete factory responsible for creating the correct finance employee type.
    // Implements the "Factory" method.
    public class FinanceEmployeeFactory : IEmployeeFactory
    {
        // This method creates and returns an employee from the financial department depending on the role passed in the method.
        // Initialisation of "Financial Controller", "Project Accountant", and "Auditor".
        public IEmployee CreateEmployee(string role)
        {
            switch (role.ToLower())
            {
                case "financialcontroller":
                    return new FinancialController();
                case "projectaccountant":
                    return new ProjectAccountant();
                case "auditor":
                    return new Auditor();
                default:
                    // If role doesn't match any of the above -> return argument exception
                    throw new ArgumentException($"Unknown finance role: {role}");
            }
        }
    }
}