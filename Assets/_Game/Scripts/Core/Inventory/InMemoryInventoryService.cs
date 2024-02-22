using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZongDemo.Core.Inventory
{
    /// <summary>
    ///     Saves the items in memory (it resets after application quit)
    /// </summary>
    public class InMemoryInventoryService : IInventoryService
    {
        private readonly List<InventoryItemData> _items = new();

        public List<InventoryItemData> GetItems()
        {
            return _items;
        }

        public void SetItem(InventoryItem item, int amount)
        {
            var itemData = _items.FirstOrDefault(x => x.Item == item);
            if (itemData == null)
            {
                _items.Add(new InventoryItemData { Item = item, Amount = amount });
            }
            else
            {
                itemData.Amount = amount;
            }
        }

        public void AddItem(InventoryItem item, int amount)
        {
            var itemData = _items.FirstOrDefault(x => x.Item == item);
            if (itemData == null)
            {
                _items.Add(new InventoryItemData { Item = item, Amount = amount });
            }
            else
            {
                itemData.Amount += amount;
            }
        }

        public bool TryRemoveItem(InventoryItem item, int amount)
        {
            var itemData = _items.FirstOrDefault(x => x.Item == item);
            if (itemData == null)
            {
                Debug.LogError($"Item {item.Name} not found in the inventory");
                return false;
            }

            if (itemData.Amount < amount)
            {
                return false;
            }

            itemData.Amount -= amount;
            if (itemData.Amount == 0)
            {
                _items.Remove(itemData);
            }

            return true;
        }
    }
}