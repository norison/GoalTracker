using GoalTracker.UI.Pages.Desktop;
using GoalTracker.UI.Pages.Mobile;
using Shell = Microsoft.Maui.Controls.Shell;

namespace GoalTracker.UI;

public partial class App
{
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
            "MzA3MzY0MUAzMjM0MmUzMDJlMzBLQWRqckRzRzE4Y0xiZFdCSXN3dHBxTS8zVU82ejFDdzJ3SmlSdk9yU2ZjPQ==");

        InitializeComponent();

        MainPage = Config.IsDesktop ? new DesktopShell() : new MobileShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);

        if (!Config.IsDesktop)
        {
            return window;
        }

        window.MinimumWidth = 1080;
        window.MinimumHeight = 500;

        window.SizeChanged += Window_SizeChanged;

        return window;
    }

    private static void Window_SizeChanged(object? sender, EventArgs e)
    {
        if (sender is not Window window)
        {
            return;
        }

        Shell.Current.FlyoutBehavior = window.Width < 1200 ? FlyoutBehavior.Flyout : FlyoutBehavior.Locked;
    }
}