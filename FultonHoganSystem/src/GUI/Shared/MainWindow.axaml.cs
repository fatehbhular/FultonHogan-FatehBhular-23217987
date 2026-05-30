using Avalonia.Controls;
using GUI.Views;
using Core.Interfaces;

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
            // Create the new dashboard view
            var dashboard = new DashboardView();
            
            // Pass the user info to the dashboard
            dashboard.SetUser(user);
            
            // Swap the content
            ContentDisplay.Content = dashboard;
        }
    }
}