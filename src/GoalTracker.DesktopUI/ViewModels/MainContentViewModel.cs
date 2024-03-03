using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalTracker.DesktopUI.Constants;
using Prism.Regions;

namespace GoalTracker.DesktopUI.ViewModels;

public partial class MainContentViewModel : ObservableObject
{
    private readonly IRegionManager _regionManager;

    public MainContentViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        _regionManager.RegisterViewWithRegion(RegionNames.MainContentRegion, PageNames.Dashboard);
    }
    
    [RelayCommand]
    private void Navigate(string pageName)
    {
        _regionManager.RequestNavigate(RegionNames.MainContentRegion, pageName);
    }
}