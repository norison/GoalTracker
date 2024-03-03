using System.Windows;
using GoalTracker.DesktopUI.Constants;
using GoalTracker.DesktopUI.Services.Themes;
using GoalTracker.DesktopUI.ViewModels;
using GoalTracker.DesktopUI.Views;
using Prism.Ioc;

namespace GoalTracker.DesktopUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Persistence

        // Services
        containerRegistry.RegisterSingleton<IThemeService, ThemeService>();

        // Pages
        containerRegistry.RegisterForNavigation<MainContentView>();
        containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>(PageNames.Dashboard);
        containerRegistry.RegisterForNavigation<GoalsView, GoalsViewModel>(PageNames.Goals);
        containerRegistry.RegisterForNavigation<TrackerView, TrackerViewModel>(PageNames.Tracker);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MainView>();
    }
}