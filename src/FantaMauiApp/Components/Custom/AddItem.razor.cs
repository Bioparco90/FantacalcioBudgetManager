using Microsoft.AspNetCore.Components;
using Model;
using Radzen;

namespace FantaMauiApp.Components.Custom
{
    public partial class AddItem<TEntity> where TEntity : DataObject, new()
    {
        [Parameter] public EventCallback<TEntity> OnAdd { get; set; }
        private Role SelectedRole { get; set; } = Role.None;

        private string ItemName { get; set; } = string.Empty;
        private string League { get; set; } = string.Empty;
        private string? Price { get; set; } = string.Empty;

        private async Task AddItemBtnClick()
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                await ErrorAlert("Please insert the name");
                return;
            }

            if (typeof(TEntity) == typeof(Player) && SelectedRole == Role.None)
            {
                await ErrorAlert("Please insert a Role");
                return;
            }

            TEntity item = new()
            {
                Name = ItemName,
            };

            if (item is Team t)
            {
                t.League = League;
            }

            if (item is Player p)
            {
                if (int.TryParse(Price, out int price))
                {
                    p.Price = price;
                    p.Role = SelectedRole;
                }
                else
                {
                    await ErrorAlert("Please insert a valid price");
                    return;
                }
            }

            await OnAdd.InvokeAsync(item);
            Reset();
        }

        private async Task ErrorAlert(string message)
        {
            _ = await DialogService.Alert(message, "Error", new() { CloseDialogOnOverlayClick = true, OkButtonText = "Close" });
            Reset();
        }

        private void Reset()
        {
            ItemName = string.Empty;
            League = string.Empty;
            Price = string.Empty;
            SelectedRole = Role.None;
        }
    }
}
