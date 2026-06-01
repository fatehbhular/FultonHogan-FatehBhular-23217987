using Avalonia.Controls;
using Avalonia.Interactivity;
using Core.Models;
using Core.Interfaces;
using GUI.Shared;

namespace GUI.Views
{
    public partial class DashboardView : UserControl
    {
        // This method creates the dashboard view.
        public DashboardView() => InitializeComponent();

        // This method shows the logged in user's name.
        public void SetUser(IEmployee user)
        {
            if (user is Employee emp)
            {
                WelcomeLabel.Text = $"Welcome back, {emp.Name}!";
            }
        }

        // This method logs the user out and shows the login page.
        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            // Go back to login
            if (this.VisualRoot is MainWindow window)
            {
                window.NavigateToLogin();
            }
        }
    }
}
