using FultonHogan.Users;
using FultonHogan.Projects;
using FultonHogan.Reports;

namespace FultonHogan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("____ Fulton Hogan - Project Costing & Management System ____");

            Console.WriteLine("");
            Console.WriteLine("");


            // Initlising a Project - done by Project Manager

            Console.WriteLine("---- Initialising a Project TEST ----");

            ProjectManager John = new ProjectManager("001", "john", "john001@fultonhogan.com", "0211234567", "project manager", "management");

            Project project1 = new Project("100", "Construction", 50000);

            John.InitialiseProject(project1);

            Console.WriteLine("");
            Console.WriteLine("");


            // Generating a Progress Report - done by Project Coordinator

            Console.WriteLine("---- Generating a Progress Report TEST ----");

            ProjectCoordinator Alex = new ProjectCoordinator("002", "alex", "alex002@fultonhogan.com", "0219876543", "project coordinator", "management", "100");

            GenerateReport gr = new GenerateReport("progress", "0001", Alex.ProjectId, Alex.EmployeeId, "This is a report test", Alex.Department);

            Report newReport = gr.CreateReport();
            newReport.GenerateTemplate();

            Console.WriteLine("");
            Console.WriteLine("");


            // Tracking Estimated Vs Actual Costs - done by Project Accountant

            Console.WriteLine("---- Tracking Estimated vs Actual Costs TEST ----");

            ProjectAccountant Mary = new ProjectAccountant("024", "mary", "mary024@fultonhogan.com", "0214859234", "project accountant", "financial", 3);

            Mary.TrackEstimateVsActualCosts();

            Console.WriteLine("");
            Console.WriteLine("");


            // Verify Financial Accuracy - done by Auditor

            Console.WriteLine("---- Initialising a Project TEST ----");

            Auditor Lisa = new Auditor("020", "lisa", "lisa020@fultonhogan.com", "0214561234", "auditor", "finance", 2);

            Lisa.VerifyFinancialAccuracy();

            Console.WriteLine("");
            Console.WriteLine("");


            // Sending instructions - done by Site Lead

            Console.WriteLine("---- Sending Instructions TEST ----");

            SiteLead Mort = new SiteLead("012", "mort", "mort012@fultonhogan.com", "0218479588", "site lead", "management", "001");

            Mort.SendInstructions();

            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}