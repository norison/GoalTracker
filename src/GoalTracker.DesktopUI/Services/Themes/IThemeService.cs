using GoalTracker.DesktopUI.Enums;

namespace GoalTracker.DesktopUI.Services.Themes;

public interface IThemeService
{
    ETheme GetTheme();
    void SetTheme(ETheme theme);
}