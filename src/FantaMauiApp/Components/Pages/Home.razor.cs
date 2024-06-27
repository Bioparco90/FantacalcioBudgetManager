using FantaMauiApp.Data;
using Model;
using System.Diagnostics;


namespace FantaMauiApp.Components.Pages
{
    public partial class Home
    {
        public string? TeamName { get; set; } = "";
        private Team? Team { get; set; }
        private List<Team> teams = [];

        private async Task AddTeam()
        {
            Team team = new() { Name = "Test" };
            Repository<Team> repo = new(new());
            await repo.InsertAsync(team);
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
