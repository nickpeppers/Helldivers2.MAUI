using Helldivers2.MAUI.Helpers;
using MemoryToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Helldivers2.MAUI
{
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

            builder.UseLeakDetection(collectionTarget =>
            {
                // This callback will run any time a leak is detected.
                Application.Current?.MainPage?.DisplayAlert("💦Leak Detected💦",
                    $"❗🧟❗{collectionTarget.Name} is a zombie!", "OK");
            });
#endif

            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);
            return app;
        }
    }
}