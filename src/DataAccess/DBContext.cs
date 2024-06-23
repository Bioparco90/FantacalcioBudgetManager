using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Context : DbContext
    {
        private readonly string? _connectionString;

        public DbSet<Team> Teams { get; set; }
        public DbSet<Goalkeeper> Goalkeepers { get; set; }
        public DbSet<Defender> Defenders { get; set; }
        public DbSet<Midfielder> Midfielders { get; set; }
        public DbSet<Forward> Forwards { get; set; }

        public Context()
        {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //_connectionString = config.GetConnectionString("default")!;
            var dbName = config.GetRequiredSection("DbName").Value;
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var dbPath = Path.Combine(basePath, dbName);
            _connectionString = $"Data Source={dbPath}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

    }
}
