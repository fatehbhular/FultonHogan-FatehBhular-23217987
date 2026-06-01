using Avalonia.Controls;
using Avalonia.Interactivity;
using Core.Interfaces;
using Core.Models;
using Services;
using Repositories;
using Roles;
using Reports;
using GUI.Shared;
using System;
using System.Collections.Generic;

namespace GUI.Views.RoleViews
{
    public partial class FinanceGroupView : UserControl
    {
        private Employee _user;
        private DatabaseReportRepository _reportRepo;
        private ReportService _reportService;

        // This method creates the view for the designer.
        public FinanceGroupView()
        {
            InitializeComponent();
        }

        // This method creates the finance view for the logged in user.
        public FinanceGroupView(IEmployee user)
        {
            InitializeComponent();
            _user = (Employee)user;
            _reportRepo = new DatabaseReportRepository();
            _reportService = new ReportService(_reportRepo);

            WelcomeLabel.Text = $"{_user.Name} ({_user.Role})";

            // Role-based button visibility
            ApproveBudgetBtn.IsVisible = (_user is FinancialController);
            CreateReportBtn.IsVisible = (_user is ProjectAccountant);
            
            // Initial load of data
            LoadReportData();
        }

        // This method loads reports from the database.
        private void LoadReportData()
        {
            List<Report> reports = _reportRepo.GetAllReports();
            ReportListBox.ItemsSource = reports;
        }

        // This method shows details for the selected report.
        private void OnReportSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ReportListBox.SelectedItem is Report selected)
            {
                DetailPanel.IsVisible = true;
                DetailID.Text = $"{selected.ReportType}: {selected.ReportID}";
                DetailDesc.Text = selected.Description;

                // Show the action button to auditors and financial controllers.
                VerifyBtn.IsVisible = (_user is Auditor) || (_user is FinancialController);
                VerifyBtn.Content = _user is FinancialController ? "Approve Report" : "Verify Accuracy";
            }
        }

        // This method reloads the report list.
        private void OnViewArchiveClick(object sender, RoutedEventArgs e)
        {
            LoadReportData();
            StatusMessage.Text = "Ledger refreshed from database.";
        }

        // This method creates a new financial report.
        private void OnCreateReportClick(object sender, RoutedEventArgs e)
        {
            if (_user is ProjectAccountant accountant)
            {
                accountant.CreateFinancialReport("PROJ-99", _reportService);
                LoadReportData();
                StatusMessage.Text = "New Financial Report Created.";
            }
        }

        // This method approves a demo project budget.
        private void OnApproveBudgetClick(object sender, RoutedEventArgs e)
        {
            if (_user is FinancialController controller)
            {
                // Dummy project for demonstration
                Project proj = new Project("PROJ-99", "Maintenance", DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), 1000);
                controller.ApproveProjectBudget(proj, new DatabaseProjectRepository());
                StatusMessage.Text = "Budget Approved for PROJ-99.";
            }
        }

        // This method verifies or approves the selected report.
        private void OnVerifyClick(object sender, RoutedEventArgs e)
        {
            if (ReportListBox.SelectedItem is Report selected && _user is Auditor auditor)
            {
                auditor.VerifyReportAccuracy(selected);
                StatusMessage.Text = $"Report {selected.ReportID} verified by Auditor.";
            }
            else if (ReportListBox.SelectedItem is Report report && _user is FinancialController controller)
            {
                controller.ApproveReport(report, _reportRepo);
                LoadReportData();
                StatusMessage.Text = $"Report {report.ReportID} approved by Financial Controller.";
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
