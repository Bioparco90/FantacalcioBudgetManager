using DataContext;
using FantaMauiApp.Data;
using Microsoft.Extensions.Logging;
using Model;
using Radzen;

namespace FantaMauiApp
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
                });

            builder.Services.AddRadzenComponents();
            builder.Services.AddScoped<DialogService>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<Context>();
            builder.Services.AddScoped<Repository>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
