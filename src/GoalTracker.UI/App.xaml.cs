using System.Windows;
using GoalTracker.Application.Abstractions;
using GoalTracker.Persistence.Implementation;
using GoalTracker.UI.Views;
using Prism.Ioc;

namespace GoalTracker.UI;

public partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IGoalService, CsvGoalService>();
        
        containerRegistry.RegisterForNavigation<MainView>();
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }
}