using FantaMauiApp.Data.Exceptions;
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
                _ = await CanAdd(team, player);

                player.TeamId = team.Id;
                player.Id = Guid.NewGuid();
                return await db.InsertAsync(player);
            });
        }

        private async Task<bool> CanAdd(Team team, Player player)
        {
            var isLimitReached = await IsRoleComplete(team, player);
            if (isLimitReached)
            {
                throw new LimitReachedException("You have already reached the player limit for the selected role");
            }

            var playerExists = await PlayerExists(team, player);
            if (playerExists)
            {
                throw new PlayerExistsException("The player you are trying to add is already on the team");
            }

            return true;
        }

        private async Task<bool> IsRoleComplete(Team team, Player player)
        {
            return await GetConnection(async db =>
            {
                var count = await (from p in db.Table<Player>()
                            where p.TeamId == team.Id && p.Role == player.Role
                            select p).CountAsync();

                return count >= player.MaxPerTeam;
            });

        }

        private async Task<bool> PlayerExists(Team team, Player player)
        {
            return await GetConnection(async db =>
            {
                var playerFound = await (from p in db.Table<Player>()
                                   where p.TeamId == team.Id && p.Name.ToLower() == player.Name.ToLower()
                                   select p).FirstOrDefaultAsync();

                return playerFound is not null;
            });
        }
    }
}
