using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GUI.Shared;

namespace GUI
{
    public partial class App : Application
    {
        // This method loads the app XAML.
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        // This method opens the main window when the app is ready.
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}
