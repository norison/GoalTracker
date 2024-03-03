using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalTracker.DesktopUI.Constants;
using GoalTracker.DesktopUI.Enums;
using GoalTracker.DesktopUI.Services.Themes;
using Prism.Regions;

namespace GoalTracker.DesktopUI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IThemeService _themeService;

    [ObservableProperty] private bool _isDarkTheme;

    public MainViewModel(IRegionManager regionManager, IThemeService themeService)
    {
        _themeService = themeService;

        regionManager.RegisterViewWithRegion(RegionNames.MainRegion, PageNames.MainContent);
    }

    [RelayCommand]
    private void Load(Window window)
    {
        LoadTheme();
    }
    
    [RelayCommand]
    private static void Minimize(Window window)
    {
        window.WindowState = WindowState.Minimized;
    }

    [RelayCommand]
    private static void Maximize(Window window)
    {
        window.WindowState = window.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
    }

    [RelayCommand]
    private static void Close(Window window)
    {
        window.Close();
    }

    private void LoadTheme()
    {
        var theme = _themeService.GetTheme();
        IsDarkTheme = theme == ETheme.Dark;
        _themeService.SetTheme(theme);
    }

    partial void OnIsDarkThemeChanged(bool value)
    {
        _themeService.SetTheme(value ? ETheme.Dark : ETheme.Light);
    }
}