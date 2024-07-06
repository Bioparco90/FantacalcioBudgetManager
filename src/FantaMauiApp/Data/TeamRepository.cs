using Model;
using DataContext;
using Microsoft.EntityFrameworkCore;
using FantaMauiApp.Data.Interfaces;

namespace FantaMauiApp.Data
{
    public class TeamRepository(Context context) : IRepository<Team>
    {
        private readonly Context dbContext = context;

        public async Task<int> InsertAsync(Team item)
        {
            dbContext.Teams.Add(item);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<Team?> GetAsync(Guid id)
        {
            return await dbContext.Teams.FindAsync(id);
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await dbContext.Teams.Include(t => t.Goalkeepers).ToListAsync();
        }

        public async Task<int> DeleteAsync(Team item)
        {
            dbContext.Teams.Remove(item);
            return await dbContext.SaveChangesAsync();
        }

        public async Task AddGK(Team item, Goalkeeper gk)
        {
            item.Goalkeepers.Add(gk);
            dbContext.Update(item);
            await dbContext.SaveChangesAsync();
        }

        public void RemoveGK(Team item, Goalkeeper gk)
        {
            dbContext.Teams.Find(item)?.Goalkeepers.Remove(gk);
            dbContext.SaveChanges();
        }

        public DbSet<Goalkeeper> GetDbSet() => dbContext.Goalkeepers;
        public ICollection<Goalkeeper> GetGoalkeepers(Team team) => dbContext.Teams.Find(team.Id).Goalkeepers;

        //private void Reflection(Team team, object item)
        //{

        //}
    }
}
