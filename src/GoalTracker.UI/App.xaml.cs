using System.Windows;
using GoalTracker.UI.Views;
using Prism.Ioc;

namespace GoalTracker.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainView>();
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }
}