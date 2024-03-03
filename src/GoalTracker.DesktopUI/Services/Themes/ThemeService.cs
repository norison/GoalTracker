using System.Windows.Media;
using GoalTracker.DesktopUI.Enums;
using MaterialDesignThemes.Wpf;

namespace GoalTracker.DesktopUI.Services.Themes;

public class ThemeService : IThemeService
{
    private readonly PaletteHelper _paletteHelper = new();
    private ETheme _theme = ETheme.Light;

    public ETheme GetTheme()
    {
        return _theme;
    }

    public void SetTheme(ETheme theme)
    {
        if (theme == ETheme.Light)
        {
            SetLightTheme();
        }
        else
        {
            SetDarkTheme();
        }

        _theme = theme;
    }

    private void SetLightTheme()
    {
        var theme = Theme.Create(new MaterialDesignLightTheme(), Colors.Black, Colors.White);
        _paletteHelper.SetTheme(theme);
    }

    private void SetDarkTheme()
    {
        var theme = Theme.Create(new MaterialDesignDarkTheme(), Colors.White, Colors.Black);
        _paletteHelper.SetTheme(theme);
    }
}