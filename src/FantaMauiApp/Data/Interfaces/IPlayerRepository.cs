using Model;

namespace FantaMauiApp.Data.Interfaces
{
    internal interface IPlayerRepository
    {
        Task<int> DeleteAsync(Player player);
        Task<List<Player>> GetAllAsync(Team team);
        Task<List<Player>> GetAllAsync();
        Task<Player> GetAsync(Guid playerId);
        Task<int> InsertAsync(Team team, Player player);
    }
}