using Microsoft.EntityFrameworkCore;
using Model;

namespace DataContext
{
    public class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public Context() { }

        public Context(DbContextOptions<Context> options)
            :base(options)
        {
            Database.EnsureCreated();
            //var cs = Database.GetConnectionString();
            //Debug.WriteLine($"CONNECTION STRING: {cs}");
        }

        // migration command:
        // dotnet ef migrations add AddCollectionsInitialization --startup-project ..\DataContext --project ..\DataContext
    }
}

