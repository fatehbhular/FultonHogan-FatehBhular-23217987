using System;
using Avalonia;
using Database;
using Repositories;
using Roles;

namespace FultonHogan
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // 1. Initialise tables
            var db = new DatabaseSetup();
            db.Initialise();

            // 2. CREATE A TEST USER (Bob) so you can actually log in
            // Email: bob@fh.com | Password: 123
            var repo = new DatabaseEmployeeRepository();
            var bob = new SiteLead("Bob Jones", "EMP-001", "bob@fh.com", "Management");
            repo.Save(bob, "123");

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<GUI.App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}