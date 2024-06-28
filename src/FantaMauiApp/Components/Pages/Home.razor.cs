using Model;
using System.Diagnostics;


namespace FantaMauiApp.Components.Pages
{
    public partial class Home
    {
        private Team? Team { get; set; }

        private IList<Team> teams = [];

        private async Task AddItem(Team team)
        {
            await TeamRepository.InsertAsync(team);
            await GetTeams();
        }

        private async Task GetTeams() => teams = await TeamRepository.GetAllAsync();

        private async Task DeleteItemBtnClick(Team item)
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
