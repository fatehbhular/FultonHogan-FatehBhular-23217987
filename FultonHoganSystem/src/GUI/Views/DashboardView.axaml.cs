using Avalonia.Controls;
using Avalonia.Interactivity;
using Core.Models;
using Core.Interfaces;
using GUI.Shared;

namespace GUI.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView() => InitializeComponent();

        // Method to update the text with the actual user's name
        public void SetUser(IEmployee user)
        {
            if (user is Employee emp)
            {
                WelcomeLabel.Text = $"Welcome back, {emp.Name}!";
            }
        }

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