using SQLite;

namespace FantaMauiApp.Data
{
    internal abstract class Repository(Context context)
    {
        private readonly Context dbContext = context;

        protected async Task<T> GetConnection<T>(Func<SQLiteAsyncConnection, Task<T>> action)
        {
            var db = await dbContext.GetConnection();
            return await action(db);
        }
    }
}
