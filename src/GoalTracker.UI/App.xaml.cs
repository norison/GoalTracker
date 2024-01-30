namespace GoalTracker.UI;

public partial class App : Application
{
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
            "MzA3MzY0MUAzMjM0MmUzMDJlMzBLQWRqckRzRzE4Y0xiZFdCSXN3dHBxTS8zVU82ejFDdzJ3SmlSdk9yU2ZjPQ==");

        InitializeComponent();

        MainPage = new AppShell();
    }
}