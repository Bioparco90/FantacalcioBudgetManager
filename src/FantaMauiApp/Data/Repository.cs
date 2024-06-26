using Model;

namespace FantaMauiApp.Data
{
    internal class Repository<T>(Context context) where T : DataObject, new()
    {
        private Context Context { get; } = context;

        public async Task<int> InsertAsync(T item)
        {
            await Context.Init();
            var table = await GetAllAsync();
            if (item is Player p && table.Count >= p.MaxPerTeam)
            {
                return 0;
            }
            return await Context.GetDatabase()!.InsertAsync(item);
        }

        public async Task<T> GetAsync(string name)
        {
            await Context.Init();
            return await Context.GetDatabase()!.Table<T>().FirstOrDefaultAsync(p => p.Name.Equals(name));
        }

        public async Task<List<T>> GetAllAsync()
        {
            await Context.Init();
            return await Context.GetDatabase()!.Table<T>().ToListAsync();
        }

        public async Task<int> DeleteAsync(T item)
        {
            await Context.Init();
            return await Context.GetDatabase()!.DeleteAsync(item);
        }
    }
}
