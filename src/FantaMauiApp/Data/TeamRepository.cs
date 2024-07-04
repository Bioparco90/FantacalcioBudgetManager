using Model;
using DataContext;
using Microsoft.EntityFrameworkCore;
using FantaMauiApp.Data.Interfaces;

namespace FantaMauiApp.Data
{
    internal class TeamRepository(Context context) : IRepository<Team>
    {
        private readonly Context dbContext = context;

        public async Task<int> InsertAsync(Team item)
        {
            dbContext.Teams.Add(item);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<Team?> GetAsync(Team item)
        {
            return await dbContext.Teams.FindAsync(item);
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await dbContext.Teams.ToListAsync();
        }

        public async Task<int> DeleteAsync(Team item)
        {
            dbContext.Teams.Remove(item);
            return await dbContext.SaveChangesAsync();
        }
    }
}
