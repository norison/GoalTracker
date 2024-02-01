namespace GoalTracker.UI;

public static class Config
{
    public static bool IsDesktop { get; } = DeviceInfo.Platform == DevicePlatform.WinUI ||
                                            DeviceInfo.Platform == DevicePlatform.MacCatalyst;
}