using CommunityToolkit.Maui;
using GoalTracker.Application.Abstractions;
using GoalTracker.Persistence.Implementation;
using GoalTracker.UI.Pages.Common;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace GoalTracker.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IGoalService, CsvGoalService>();

        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddSingleton<GoalsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}