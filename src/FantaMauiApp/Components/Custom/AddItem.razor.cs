using Microsoft.AspNetCore.Components;
using Model;
using Radzen;

namespace FantaMauiApp.Components.Custom
{
    public partial class AddItem<TEntity> where TEntity : DataObject, new()
    {
        [Parameter] public EventCallback<TEntity> OnAdd { get; set; }

        private string ItemName { get; set; } = string.Empty;
        private string League {  get; set; } = string.Empty;
        private string? Price { get; set; } = string.Empty;

        private async Task AddItemBtnClick()
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
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
                }
                else
                {
                    _ = await DialogService.Alert("Please insert a valid number", "Error", new() { CloseDialogOnOverlayClick = true, OkButtonText = "Close" });
                    Reset();
                    throw new FormatException();
                }
            }

            await OnAdd.InvokeAsync(item);
            Reset();
        }

        private void Reset()
        {
            ItemName = string.Empty;
            League = string.Empty;
            Price = string.Empty;
        }
    }
}
