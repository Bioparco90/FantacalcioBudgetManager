using Model;

namespace FantaMauiApp.Data.Interfaces
{
    interface ITeamRepository
    {
        Task<int> DeleteAsync(Team team);
        Task<List<Team>> GetAllAsync();
        Task<Team?> GetAsync(Guid id);
        Task<int> InsertAsync(Team team);
    }
}
