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

        public FinanceGroupView()
        {
            InitializeComponent();
        }

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

        private void LoadReportData()
        {
            List<Report> reports = _reportRepo.GetAllReports();
            ReportListBox.ItemsSource = reports;
        }

        // Logic for when a report is clicked in the list
        private void OnReportSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ReportListBox.SelectedItem is Report selected)
            {
                DetailPanel.IsVisible = true;
                DetailID.Text = $"{selected.ReportType}: {selected.ReportID}";
                DetailDesc.Text = selected.Description;

                // Only show Verify button to Auditors
                VerifyBtn.IsVisible = (_user is Auditor);
            }
        }

        private void OnViewArchiveClick(object sender, RoutedEventArgs e)
        {
            LoadReportData();
            StatusMessage.Text = "Ledger refreshed from database.";
        }

        private void OnCreateReportClick(object sender, RoutedEventArgs e)
        {
            if (_user is ProjectAccountant accountant)
            {
                accountant.CreateFinancialReport("PROJ-99", _reportService);
                LoadReportData();
                StatusMessage.Text = "New Financial Report Created.";
            }
        }

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

        // THIS IS THE METHOD THAT WAS MISSING AND CAUSING YOUR ERROR
        private void OnVerifyClick(object sender, RoutedEventArgs e)
        {
            if (ReportListBox.SelectedItem is Report selected && _user is Auditor auditor)
            {
                auditor.VerifyReportAccuracy(selected);
                StatusMessage.Text = $"Report {selected.ReportID} verified by Auditor.";
            }
        }

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