using System.Windows;
using GoalTracker.UI.Constants;
using GoalTracker.UI.Views;
using Prism.Regions;

namespace GoalTracker.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IRegionManager regionManager)
    {
        InitializeComponent();

        regionManager.RegisterViewWithRegion(RegionNames.WindowRegion, nameof(MainView));
    }
}