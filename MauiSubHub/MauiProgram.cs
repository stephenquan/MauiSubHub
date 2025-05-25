using Microsoft.Extensions.Logging;

namespace MauiSubHub;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<AppViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PressAndReleaseButtonPage>();

        Routing.RegisterRoute(nameof(PressAndReleaseButtonPage), typeof(PressAndReleaseButtonPage));

        return builder.Build();
    }
}
