using Model;
using SQLite;
using System.Diagnostics;

namespace FantaMauiApp.Data
{
    internal class Context
    {
        private SQLiteAsyncConnection Database;

        public Context()
        {
        }

        private async Task Init()
        {
            Debug.WriteLine("PATH-------------->" + Database?.DatabasePath);
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _ = await Database.CreateTableAsync<Team>();
            _ = await Database.CreateTableAsync<Player>();
        }

        public async Task<SQLiteAsyncConnection> GetConnection()
        {
            await Init();
            return Database;
        }
    }
}
