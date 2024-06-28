using Microsoft.AspNetCore.Components;
using Model;

namespace FantaMauiApp.Components.Custom
{
    public partial class AddItem<TEntity> where TEntity : DataObject, new()
    {
        [Parameter] public EventCallback<TEntity> OnAdd { get; set; }
        [Parameter] public string? ItemTypeName { get; set; } = string.Empty;

        private string ItemName { get; set; } = string.Empty;

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
            await OnAdd.InvokeAsync(item);
            ItemName = string.Empty;
        }
    }
}
