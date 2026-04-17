using FultonHogan.Projects;


namespace FultonHogan.Users
{
    public abstract class User
    {
        // Learning notes - In C#, we use { get; set; } which creates our getter and setter methods automatically instead of having to write them manually.
        //                - Use PascalCase for properties and methods, but camelCase for parameter variables.

        // Properties of User
        public string EmployeeId { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public Project CurrentProject { get; set; }

        protected User(string employeeId, string name, string email, string phoneNumber, string role, string department)
        {
            EmployeeId = employeeId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
            Department = department;
            CurrentProject = new Project("001", "Construction Project #1", 40000);
        }

        // Logs the user into the system with email + password checking
        public virtual bool Login(string email)
        {
            if (!(email == $"{EmployeeId}@fultonhogan.com"))
            {
                Console.WriteLine("Login failed: Invalid email address.");
                return false;
            }

            Console.WriteLine($"Welcome {Name}!");
            return true;
        }

        // logs the user out of the system
        public void Logout()
        {
            Console.WriteLine($"{Name} has logged out successfully.");
        }
    }
}