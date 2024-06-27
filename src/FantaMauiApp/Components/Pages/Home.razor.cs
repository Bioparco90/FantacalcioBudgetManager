using FantaMauiApp.Data;
using Model;
using System.Diagnostics;


namespace FantaMauiApp.Components.Pages
{
    public partial class Home
    {
        public string? TeamName { get; set; } = string.Empty;
        private Team? Team { get; set; }
        private IList<Team> teams = [];

        private async Task AddTeam()
        {
            if (string.IsNullOrWhiteSpace(TeamName))
            {
                return;
            }

            Team team = new()
            {
                Name = TeamName,
            };
            await TeamRepository.InsertAsync(team);
            await GetTeams();
            TeamName = string.Empty;
        }

        private async Task GetTeams() => teams = await TeamRepository.GetAllAsync();

        private async Task DeleteItem(Team item)
        {
            Debug.WriteLine(item.Name);

            try
            {
                await TeamRepository.DeleteAsync(item);
                await GetTeams();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting team: {ex.Message}");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetTeams();


        }
    }
}
