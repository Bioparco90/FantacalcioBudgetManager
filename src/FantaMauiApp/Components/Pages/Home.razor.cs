using Model;
using Radzen;
using System.Diagnostics;

namespace FantaMauiApp.Components.Pages
{
    public partial class Home
    {
        private IList<Team> teams = [];

        private async Task AddItem(Team team)
        {
            await TeamRepository.InsertAsync(team);
            await GetTeams();
        }

        private async Task GetTeams() => teams = await TeamRepository.GetAllAsync();

        private async Task DeleteItem(Team item)
        {
            var options = new ConfirmOptions()
            {
                OkButtonText = "Yes",
                CancelButtonText = "No",
                
            };
            var confirm = await DialogService.Confirm("Are you sure?", "Delete", options) ?? false;
            if (!confirm)
            {
                return;
            }

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
