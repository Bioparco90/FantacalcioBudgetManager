using Model;
using SQLite;

namespace FantaMauiApp.Data
{
    internal class Context
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

        public async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DbPath, Flags);
            await Database.CreateTableAsync<Team>();
            await Database.CreateTableAsync<Goalkeeper>();
            await Database.CreateTableAsync<Defender>();
            await Database.CreateTableAsync<Midfielder>();
            await Database.CreateTableAsync<Forward>();
        }

        public SQLiteAsyncConnection? GetDatabase() => Database;
    }
}
