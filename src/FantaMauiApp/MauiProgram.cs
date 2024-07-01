using DataContext;
using FantaMauiApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            builder.Services.AddDbContext<Context>(options => options.UseSqlite($"Filename={GetDatabasePath()}"));
            builder.Services.AddTransient<Repository>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static string GetDatabasePath()
        {
            var databaseName = "db.db3";
            return Path.Combine(FileSystem.AppDataDirectory, databaseName);
        }

    }
}
