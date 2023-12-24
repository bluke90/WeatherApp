using Microsoft.Extensions.Logging;
using WeatherApp.Mechanics;

namespace WeatherApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ApiAccess>();
            builder.Services.AddSingleton <MainPage>();
            builder.Services.AddSingleton<CameraPage>();
            builder.Services.AddSingleton<SensorsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
