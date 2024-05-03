using BoardFormat.MVVM.ViewsModels;
//using BoardFormat.MVVM.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BoardFormat
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
#endif
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();

            /// <summary>
            /// Loads the configuration from the embedded resource "appsettings.json" and adds it to the configuration builder.
            /// appsettings.json is set to Embedded Resource in file properties->Build Action.
            /// </summary>
            using var stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("BoardFormat.MyResources.appsettings.json");
            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);

            var app = builder.Build();

            Services = app.Services;

            return app;
        }

        public static IServiceProvider Services { get; private set; }
    }
}
