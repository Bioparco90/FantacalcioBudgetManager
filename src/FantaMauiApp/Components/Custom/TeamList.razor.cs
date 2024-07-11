using Microsoft.AspNetCore.Components;
using Model;
using Radzen;

namespace FantaMauiApp.Components.Custom
{
    public partial class TeamList
    {
        private IList<Team> teams = [];

        private async Task GetTeams() => teams = await TeamRepository.GetAllAsync();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetTeams();
        }

        private async Task AddTeam(Team team)
        {
            var affected = await TeamRepository.InsertAsync(team);
            if (affected > 0)
            {
                await GetTeams();
            }
        }

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
                var affected = await TeamRepository.DeleteAsync(item);
                if (affected > 0)
                {
                    await GetTeams();
                }
            }
            catch
            {
                _ = await DialogService.Alert("A problem occurred", "Error", new() { CloseDialogOnOverlayClick = true, OkButtonText = "Close" });
            }
        }

        private void GoToTeam(DataGridRowMouseEventArgs<Team> args) => NavigationManager.NavigateTo($"/squad/{args.Data.Id}");
    }
}
