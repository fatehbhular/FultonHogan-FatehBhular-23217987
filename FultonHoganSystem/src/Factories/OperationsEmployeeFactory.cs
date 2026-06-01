using Core.Interfaces;
using Core.Models;
using Roles;

namespace Factories
{
    // This is a concrete factory responsible for creating the correct operations employee type.
    // Implements the "Factory" method.
    public class OperationsEmployeeFactory : IEmployeeFactory
    {
        // This method creates and returns an employee from the management department depending on the role passed in the method.
        // Initialisation of "Site Foreman", "Heavy Machine Operator", and "Auditor".
        // This method creates an operations employee for a role.
        public IEmployee CreateEmployee(string role)
        {
            switch (role.ToLower())
            {
                case "siteforeman":
                    return new SiteForeman();
                case "heavymachineoperator":
                    return new HeavyMachineOperator();
                case "generallabourer":
                    return new GeneralLabourer();
                default:
                    // If role doesn't match any of the above -> return argument exception
                    throw new ArgumentException($"Unknown operations role: {role}");
            }
        }
    }
}
