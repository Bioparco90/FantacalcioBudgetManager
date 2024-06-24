using SQLite;

namespace DataAccess
{
    public class Context
    {

        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        private readonly string? _connectionString;

        //public DbSet<Team> Teams { get; set; }
        //public DbSet<Goalkeeper> Goalkeepers { get; set; }
        //public DbSet<Defender> Defenders { get; set; }
        //public DbSet<Midfielder> Midfielders { get; set; }
        //public DbSet<Forward> Forwards { get; set; }

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
