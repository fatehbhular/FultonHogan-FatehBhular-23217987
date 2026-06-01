using Avalonia.Controls;
using Avalonia.Interactivity;
using Auth;
using Core.Interfaces;
using GUI.Shared;

namespace GUI.Views
{
    public partial class LoginView : UserControl
    {
        // This method creates the login view.
        public LoginView() => InitializeComponent();

        // This method checks the login details and opens the right dashboard.
        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text ?? "";
            string pass = PasswordBox.Text ?? "";

            Auth.SystemLogin auth = new Auth.SystemLogin(email, pass);
            IEmployee user = auth.Login();

            if (user != null)
            {
                // Try to find the window through the TopLevel helper (more reliable)
                var topLevel = TopLevel.GetTopLevel(this);
                if (topLevel is MainWindow window)
                {
                    Console.WriteLine("Navigating to dashboard...");
                    window.NavigateToDashboard(user);
                }
                else 
                {
                    // Fallback if the above fails
                    var windowFallback = (MainWindow)this.VisualRoot;
                    windowFallback?.NavigateToDashboard(user);
                }
            }
            else
            {
                ErrorLabel.Text = "Invalid email or password.";
            }
        }
    }
}
