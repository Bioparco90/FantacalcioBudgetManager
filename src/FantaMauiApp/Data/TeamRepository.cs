using FantaMauiApp.Data.Interfaces;
using Model;

namespace FantaMauiApp.Data
{
    internal class TeamRepository(Context context) : Repository(context), ITeamRepository
    {
        public async Task<int> InsertAsync(Team team)
        {
            return await GetConnection(async db =>
            {
                team.Id = Guid.NewGuid();
                return await db.InsertAsync(team);
            });
        }

        public async Task<Team?> GetAsync(Guid id) => await GetConnection(async db => await db.GetAsync<Team>(id));

        public async Task<List<Team>> GetAllAsync() => await GetConnection(async db => await db.Table<Team>().ToListAsync());

        public async Task<int> DeleteAsync(Team team) => await GetConnection(async db => await db.DeleteAsync(team));
    }
}
