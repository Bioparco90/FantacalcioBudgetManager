using Model;
using SQLite;

namespace FantaMauiApp.Data
{
    public class Context : SQLiteAsyncConnection
    {
        private SQLiteAsyncConnection? Database;
        public const string DatabaseFilename = "FantaBudget.db3";

        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;
        public static string DbPath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public Context()
            : base(DbPath, Flags)
        {
        }

        private async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DatabasePath, Flags);
            await CreateTableAsync<Team>();
            await CreateTableAsync<Goalkeeper>();
            await CreateTableAsync<Defender>();
            await CreateTableAsync<Midfielder>();
            await CreateTableAsync<Forward>();
        }

        public async Task<int> InsertTeam()
        {
            await Init();
            return await InsertAsync(new Team() { Name = "Bioparco" });
        }

        public async Task<int> InsertPlayer<T>(string name) where T : Player, new()
        {
            await Init();
            return await InsertAsync(new T() { Name = name });
        }

        public async Task<Team> GetTeam()
        {
            await Init();
            return await Table<Team>().FirstOrDefaultAsync();
        }

        public async Task<List<Team>> GetTeams()
        {
            await Init();
            return await Table<Team>().ToListAsync();
        }


    }
}
