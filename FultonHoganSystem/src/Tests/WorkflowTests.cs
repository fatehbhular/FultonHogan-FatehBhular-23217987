using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Models;
using Repositories;
using Roles;
using Services;
using Task = Core.Models.Task;

namespace Tests
{
    public static class WorkflowTests
    {
        private static readonly List<string> Results = new List<string>();

        // This method runs every workflow test for the project.
        public static void RunAll()
        {
            Results.Clear();
            TestProjectManagerProjectAndTasks();
            TestProjectCoordinatorReport();
            TestObserverNotifications();
            TestReportsAndTimesheets();
            TestOperationsTimesheets();
            TestFinancialControllerReports();

            Console.WriteLine("SELF TEST RESULTS");
            foreach (string result in Results)
            {
                Console.WriteLine(result);
            }
        }

        // This method checks that a project manager can save a project and its tasks.
        private static void TestProjectManagerProjectAndTasks()
        {
            var projectRepo = new DatabaseProjectRepository();
            var taskRepo = new DatabaseTaskRepository();
            string projectID = NewID("PM-PROJ");
            string listID = NewID("PM-LIST");
            string taskID = NewID("PM-TASK");

            var project = new Project(projectID, "Test Manager Project", DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today.AddDays(14)), 50000);
            projectRepo.Save(project);

            var taskList = new TaskList(listID, projectID, "Project manager test tasks");
            taskList.AddTask(new Task(taskID, listID, "Build test task", "Not Started"));
            taskRepo.SaveTaskList(taskList);

            Project savedProject = projectRepo.GetByID(projectID);
            List<TaskList> savedLists = taskRepo.GetProjectTaskLists(projectID);
            bool ok = savedProject != null && savedLists.Any(list => list.IncludedTasks.Any(task => task.TaskID == taskID));
            AddResult("Project manager can save a project and tasks", ok);
        }

        // This method checks that a project coordinator can create and save a report.
        private static void TestProjectCoordinatorReport()
        {
            var reportRepo = new DatabaseReportRepository();
            var reportService = new ReportService(reportRepo);
            var coordinator = new ProjectCoordinator("Test Coordinator", "TEST-PC", "pc@test.com", "Management");
            string projectID = NewID("PC-PROJ");

            coordinator.CreateReport(projectID, reportService);

            bool ok = reportRepo.GetAllReports().Any(report => report.ProjectID == projectID && report.AuthorID == coordinator.EmployeeID && report.ReportType == "progress");
            AddResult("Project coordinator can save a progress report", ok);
        }

        // This method checks that management observers receive project updates.
        private static void TestObserverNotifications()
        {
            var project = new Project(NewID("OBS-PROJ"), "Observer Test Project", DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today.AddDays(7)), 10000);
            project.Subscribe(new ProjectManager("Test PM", "OBS-PM", "pm@test.com", "Management"));
            project.Subscribe(new ProjectCoordinator("Test PC", "OBS-PC", "pc@test.com", "Management"));
            project.Subscribe(new SiteLead("Test Lead", "OBS-SL", "sl@test.com", "Management"));

            var originalOutput = Console.Out;
            using var writer = new StringWriter();
            Console.SetOut(writer);
            project.UpdateStatus("Testing Notification");
            Console.SetOut(originalOutput);

            string output = writer.ToString();
            bool ok = output.Contains("PM") && output.Contains("Coordinator") && output.Contains("Site Lead");
            AddResult("Management roles receive observer notifications", ok);
        }

        // This method checks that reports and timesheets can save and load.
        private static void TestReportsAndTimesheets()
        {
            var reportRepo = new DatabaseReportRepository();
            var timesheetRepo = new DatabaseTimesheetRepository();
            string reportID = NewID("REP");
            string employeeID = NewID("EMP");

            var report = new Reports.FinancialReport(reportID, "TEST-PROJ", employeeID, "Report save test", "Finance");
            reportRepo.Save(report);
            timesheetRepo.AddEntry(employeeID, DateTime.Today.ToString("yyyy-MM-dd"), "7.5");

            bool reportOk = reportRepo.GetByID(reportID) != null;
            bool timesheetOk = timesheetRepo.GetEntriesForEmployee(employeeID).Any(entry => entry.Contains("7.5"));
            AddResult("Reports and timesheets save and load", reportOk && timesheetOk);
        }

        // This method checks that labourer and operator entries can be saved and viewed.
        private static void TestOperationsTimesheets()
        {
            var timesheetRepo = new DatabaseTimesheetRepository();
            var labourer = new GeneralLabourer("Test Labourer", NewID("GL"), "gl@test.com", "Operations");
            var machineOperator = new HeavyMachineOperator("Test Operator", NewID("HMO"), "hmo@test.com", "Operations");

            timesheetRepo.AddEntry(labourer.EmployeeID, DateTime.Today.ToString("yyyy-MM-dd"), "8");
            timesheetRepo.AddEntry(machineOperator.EmployeeID, DateTime.Today.ToString("yyyy-MM-dd"), "9");

            bool labourerOk = timesheetRepo.GetEntriesForEmployee(labourer.EmployeeID).Any(entry => entry.Contains("8"));
            bool operatorOk = timesheetRepo.GetEntriesForEmployee(machineOperator.EmployeeID).Any(entry => entry.Contains("9"));
            AddResult("General labourer and heavy machine operator can save and view timesheets", labourerOk && operatorOk);
        }

        // This method checks that a financial controller can view and approve reports.
        private static void TestFinancialControllerReports()
        {
            var reportRepo = new DatabaseReportRepository();
            var controller = new FinancialController("Test Controller", "TEST-FC", "fc@test.com", "Finance");
            string reportID = NewID("FC-REP");
            var report = new Reports.FinancialReport(reportID, "TEST-PROJ", controller.EmployeeID, "Approve report test", "Finance");

            reportRepo.Save(report);
            controller.ViewFinanceReports(reportRepo);
            controller.ApproveReport(report, reportRepo);

            Report savedReport = reportRepo.GetByID(reportID);
            bool ok = reportRepo.GetAllReports().Any(r => r.ReportID == reportID) && savedReport != null && savedReport.IsApproved;
            AddResult("Financial controller can see and approve reports", ok);
        }

        // This method makes a short unique ID for test data.
        private static string NewID(string prefix)
        {
            return $"{prefix}-{Guid.NewGuid().ToString()[..8].ToUpper()}";
        }

        // This method records whether a test passed or failed.
        private static void AddResult(string name, bool passed)
        {
            if (!passed)
            {
                throw new Exception($"Self-test failed: {name}");
            }

            Results.Add($"PASS: {name}");
        }
    }
}
