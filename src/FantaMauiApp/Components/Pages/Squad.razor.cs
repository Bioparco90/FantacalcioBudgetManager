using FantaMauiApp.Data.Exceptions;
using FantaMauiApp.Data;
using Microsoft.AspNetCore.Components;
using Model;
using Radzen;
using System.Diagnostics;

namespace FantaMauiApp.Components.Pages
{
    public partial class Squad
    {
        [Parameter]
        public Guid Id { get; set; }

        public List<Player> Players { get; set; } = [];

        private async Task GetPlayers()
        {
            var team = await TeamRepository.GetAsync(Id);
            Players = await PlayerRepository.GetAllAsync(team);
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await base.OnInitializedAsync();
                await GetPlayers();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

        }

        private async Task AddPlayer(Player player)
        {
            try
            {
                var team = await TeamRepository.GetAsync(Id);
                await PlayerRepository.InsertAsync(team, player);
                await GetPlayers();
            }
            catch (LimitReachedException ex)
            {
                _ = await DialogService.Alert(ex.Message, "Error", new() { CloseDialogOnOverlayClick = true, OkButtonText = "Close" });
            }
            catch (PlayerExistsException ex)
            {
                _ = await DialogService.Alert(ex.Message, "Error", new() { CloseDialogOnOverlayClick = true, OkButtonText = "Close" });
            }
            catch (Exception ex)
            {
                _ = await DialogService.Alert("A problem occurred", "Error", new() { CloseDialogOnOverlayClick = true, OkButtonText = "Close" });
                Debug.WriteLine(ex.Message);
            }

        }

        private async Task DeleteItem(Player item)
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
                var affected = await PlayerRepository.DeleteAsync(item);
                if (affected > 0)
                {
                    await GetPlayers();
                }
            }
            catch
            {
                _ = await DialogService.Alert("A problem occurred", "Error", new() { CloseDialogOnOverlayClick = true, OkButtonText = "Close" });
            }

        }
    }
}
