using Avalonia.Controls;
using GUI.Views;
using Core.Interfaces;
using GUI.Views.RoleViews;

namespace GUI.Shared
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // On startup, put the LoginView into the window
            NavigateToLogin();
        }

        public void NavigateToLogin()
        {
            ContentDisplay.Content = new LoginView();
        }

        public void NavigateToDashboard(IEmployee user)
        {
            string role = user.GetRole();

            switch (role)
            {
                case "Project Manager":
                case "Project Coordinator":
                case "Site Lead":
                    ContentDisplay.Content = new ManagementGroupView(user);
                    break;
                case "Financial Controller":
                case "Project Accountant":
                case "Auditor":
                    ContentDisplay.Content = new FinanceGroupView(user);
                    break;
                case "Heavy Machine Operator":
                case "Site Foreman":
                case "General Labourer":
                    ContentDisplay.Content = new OperationsView(user);
                    break;
                default:
                    ContentDisplay.Content = new DashboardView();
                    break;
            }
        }
    }
}