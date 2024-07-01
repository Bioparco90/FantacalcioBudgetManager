using Microsoft.EntityFrameworkCore;
using Model;

namespace DataContext
{
    public class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Goalkeeper> Goalkeepers { get; set; }
        public DbSet<Defender> Defenders { get; set; }
        public DbSet<Midfielder> Midfielders { get; set; }
        public DbSet<Forward> Forwards { get; set; }

        public Context() { }

        public Context(DbContextOptions<Context> options)
            :base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }
    }
}

