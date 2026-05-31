using Avalonia.Controls;
using Avalonia.Interactivity;
using Core.Interfaces;
using Core.Models;
using Services;
using Repositories;
using Roles;
using GUI.Shared;
using System;

namespace GUI.Views.RoleViews
{
    public partial class OperationsView : UserControl
    {
        private IEmployee User;
        private ReportService ReportService;
        private DatabaseTimesheetRepository TimesheetRepository;

        // This method creates the view for the designer.
        public OperationsView()
        {
            InitializeComponent();
        }

        // This method creates the operations view for the logged in user.
        public OperationsView(IEmployee user)
        {
            InitializeComponent();
            User = user;
            // Initialise the service with the database repository
            ReportService = new ReportService(new DatabaseReportRepository());
            TimesheetRepository = new DatabaseTimesheetRepository();
            
            WelcomeLabel.Text = $"{((Employee)user).Name} - {user.GetRole()}";

            // Role-based button visibility
            if (user is GeneralLabourer)
            {
                InstructionsBtn.IsVisible = false;
                ReportProblemBtn.IsVisible = false;
            }
        }

        // This method shows the user's work instructions.
        private void OnInstructionsClick(object sender, RoutedEventArgs e)
        {
            ProblemForm.IsVisible = false;
            TimesheetPanel.IsVisible = false;
            StatusTitle.Text = "Daily Instructions";
            
            if (User is HeavyMachineOperator operatorUser)
            {
                StatusContent.Text = operatorUser.ViewInstructions();
            }
            else
            {
                StatusContent.Text = "General Site Safety: Wear PPE and follow site lead directions.";
            }
        }

        // This method opens the problem report form.
        private void OnReportProblemClick(object sender, RoutedEventArgs e)
        {
            StatusTitle.Text = "Report Site Issue";
            StatusContent.Text = "Fill out the details below to notify management.";
            TimesheetPanel.IsVisible = false;
            ProblemForm.IsVisible = true;
        }

        // This method saves a problem report.
        private void OnSubmitProblemClick(object sender, RoutedEventArgs e)
        {
            string details = ProblemInput.Text ?? "";
            
            if (User is HeavyMachineOperator operatorUser)
            {
                operatorUser.IssueProblem("PROJ-99", details, ReportService);
            }
            
            StatusContent.Text = "Report Submitted Successfully.";
            ProblemForm.IsVisible = false;
            ProblemInput.Text = "";
        }

        // This method opens the timesheet panel.
        private void OnTimesheetClick(object sender, RoutedEventArgs e)
        {
            StatusTitle.Text = "Timesheet Management";
            StatusContent.Text = "Enter your hours worked for today.";
            ProblemForm.IsVisible = false;
            TimesheetPanel.IsVisible = true;
            LoadTimesheetEntries();
        }

        // This method saves a timesheet entry.
        private void OnSubmitHoursClick(object sender, RoutedEventArgs e)
        {
            // 1. Get data from UI
            string hours = HoursInput.Text ?? "0";
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            
            // 2. Cast User to Employee to access the EmployeeID property
            if (User is Employee emp)
            {
                // 3. Call the Repository to save
                TimesheetRepository.AddEntry(emp.EmployeeID, date, hours);

                // 4. Update UI
                StatusContent.Text = $"Successfully logged {hours} hours for {date}.";
                HoursInput.Text = "";
                LoadTimesheetEntries();
            }
        }

        // This method shows the saved timesheet entries for the logged in user.
        private void LoadTimesheetEntries()
        {
            if (User is Employee emp)
            {
                TimesheetEntriesList.ItemsSource = TimesheetRepository.GetEntriesForEmployee(emp.EmployeeID);
            }
        }

        // This method logs the user out and shows the login page.
        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is MainWindow window)
            {
                window.NavigateToLogin();
            }
        }
    }
}
