using System;
using Avalonia;
using Database;
using Core.Models;
using Reports;
using Repositories;
using Roles;
using Tests;
using Task = Core.Models.Task;

namespace FultonHogan
{
    class Program
    {
        [STAThread]
        // This method starts the program or runs the self tests.
        public static void Main(string[] args)
        {
            // 1. Initialise tables
            var db = new DatabaseSetup();
            db.Initialise();

            if (args.Contains("--self-test"))
            {
                WorkflowTests.RunAll();
                return;
            }

            var repo = new DatabaseEmployeeRepository();
            // Operations
            repo.Save(new HeavyMachineOperator("Dave Operator", "EMP-001", "dave@fh.com", "Operations"), "123");
            repo.Save(new SiteForeman("Sam Foreman", "EMP-004", "sam@fh.com", "Operations"), "123");
            repo.Save(new GeneralLabourer("Gia Labourer", "EMP-005", "gia@fh.com", "Operations"), "123");
            // Finance
            repo.Save(new FinancialController("John Money", "EMP-002", "john@fh.com", "Finance"), "123");
            repo.Save(new ProjectAccountant("Priya Ledger", "EMP-006", "priya@fh.com", "Finance"), "123");
            repo.Save(new Auditor("Amelia Audit", "EMP-007", "amelia@fh.com", "Finance"), "123");
            // Management
            repo.Save(new ProjectManager("Alice Manager", "EMP-003", "alice@fh.com", "Management"), "123");
            repo.Save(new ProjectCoordinator("Chris Coordinator", "EMP-008", "chris@fh.com", "Management"), "123");
            repo.Save(new SiteLead("Lena Lead", "EMP-009", "lena@fh.com", "Management"), "123");

            SeedDemoData();

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // This method adds sample data so the GUI has useful things to show.
        private static void SeedDemoData()
        {
            var projectRepo = new DatabaseProjectRepository();
            var taskRepo = new DatabaseTaskRepository();
            var reportRepo = new DatabaseReportRepository();

            var highway = new Project(
                "PROJ-99",
                "State Highway Resurfacing",
                DateOnly.FromDateTime(DateTime.Today.AddDays(-14)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(45)),
                120000
            )
            {
                CurrentSpendings = 73500,
                Status = "Active"
            };

            var bridge = new Project(
                "PROJ-42",
                "Bridge Drainage Upgrade",
                DateOnly.FromDateTime(DateTime.Today.AddDays(-30)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(20)),
                85000
            )
            {
                CurrentSpendings = 61200,
                Status = "At Risk"
            };

            projectRepo.Save(highway);
            projectRepo.Save(bridge);

            var pavingList = new TaskList("TL-PROJ-99-OPS", highway.ProjectID, "Operations work package");
            pavingList.AddTask(new Task("TASK-001", pavingList.TaskListID, "Inspect heavy machinery before paving shift", "Completed"));
            pavingList.AddTask(new Task("TASK-002", pavingList.TaskListID, "Complete northbound lane resurfacing", "In Progress"));
            pavingList.AddTask(new Task("TASK-003", pavingList.TaskListID, "Submit end-of-day safety notes", "Not Started"));
            taskRepo.SaveTaskList(pavingList);

            var drainageList = new TaskList("TL-PROJ-42-SITE", bridge.ProjectID, "Drainage and compliance work package");
            drainageList.AddTask(new Task("TASK-004", drainageList.TaskListID, "Install temporary traffic controls", "Completed"));
            drainageList.AddTask(new Task("TASK-005", drainageList.TaskListID, "Replace damaged culvert sections", "In Progress"));
            drainageList.AddTask(new Task("TASK-006", drainageList.TaskListID, "Prepare compliance evidence pack", "Not Started"));
            taskRepo.SaveTaskList(drainageList);

            reportRepo.Save(new FinancialReport(
                "FIN-001",
                highway.ProjectID,
                "EMP-006",
                "Monthly cost tracking shows resurfacing spend is within approved budget.",
                "Finance"
            ));

            reportRepo.Save(new ProgressReport(
                "PROG-001",
                bridge.ProjectID,
                "EMP-003",
                "Drainage upgrade is progressing, with culvert replacement requiring close monitoring.",
                "Management"
            ));

            reportRepo.Save(new ComplianceReport(
                "COMP-001",
                highway.ProjectID,
                "EMP-007",
                "Safety audit completed with PPE checks and traffic control records verified.",
                "Finance"
            ));

            reportRepo.Save(new ProblemReport(
                "PROB-001",
                bridge.ProjectID,
                "EMP-001",
                "Unexpected water pooling detected near the work zone after overnight rain.",
                "Operations"
            ));
        }

        // This method builds the Avalonia desktop app.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<GUI.App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}
