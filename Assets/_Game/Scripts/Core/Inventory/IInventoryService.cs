using System.Collections.Generic;

namespace ZongDemo.Core.Inventory
{
    public interface IInventoryService
    {
        List<InventoryItemData> GetItems();
        void SetItem(InventoryItem item, int amount);
        void AddItem(InventoryItem item, int amount);
        bool TryRemoveItem(InventoryItem item, int amount);
    }
}