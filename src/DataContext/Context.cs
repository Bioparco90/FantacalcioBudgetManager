using Microsoft.EntityFrameworkCore;
using Model;

namespace DataContext
{
    public class Context : DbContext
    {
        public const string DatabaseFilename = "FantaBudget.db3";
        public DbSet<Team> Teams { get; set; }
        public DbSet<Goalkeeper> Goalkeepers { get; set; }
        public DbSet<Defender> Defenders { get; set; }
        public DbSet<Midfielder> Midfielders { get; set; }
        public DbSet<Forward> Forwards { get; set; }

        public static string DbPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        public static async Task DropDatabase()
        {
            await Task.Run(() =>
            {
                if (File.Exists(DbPath))
                {
                    File.Delete(DbPath);
                }
            });
        }
    }
}
