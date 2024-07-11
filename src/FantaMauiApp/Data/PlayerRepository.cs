using FantaMauiApp.Data.Interfaces;
using Model;

namespace FantaMauiApp.Data
{
    internal class PlayerRepository(Context context) : Repository(context), IPlayerRepository
    {
        public async Task<int> DeleteAsync(Player player) => await GetConnection(async db => await db.DeleteAsync(player));

        public async Task<List<Player>> GetAllAsync(Team team) => 
            await GetConnection(async db => await db.Table<Player>().Where(p => p.TeamId == team.Id).ToListAsync());

        public async Task<List<Player>> GetAllAsync() => await GetConnection(async db => await db.Table<Player>().ToListAsync());

        public async Task<Player> GetAsync(Guid playerId) => await GetConnection(async db => await db.GetAsync<Player>(playerId));

        public async Task<int> InsertAsync(Team team, Player player)
        {
            return await GetConnection(async db =>
            {
                player.TeamId = team.Id;
                player.Id = Guid.NewGuid();
                return await db.InsertAsync(player);
            });
        }
    }
}
