using Model;
using DataContext;
using Microsoft.EntityFrameworkCore;

namespace FantaMauiApp.Data
{
    internal class Repository(Context context)
    {
        private readonly Context dbContext = context;

        public async Task<int> InsertAsync(Team item)
        {
            await dbContext.Teams.AddAsync(item);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<Team?> GetAsync(Team item)
        {
            return await dbContext.Teams.FindAsync(item);
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await dbContext.Teams.ToListAsync();

            //await Context.Init();
            //return await Context.GetDatabase()!.Table<T>().ToListAsync();
        }

        public async Task<int> DeleteAsync(Team item)
        {
            dbContext.Teams.Remove(item);
            return await dbContext.SaveChangesAsync();

            //await Context.Init();
            //return await Context.GetDatabase()!.DeleteAsync(item);
        }
    }
}
