using System.Collections.Generic;
using UnityEngine;
using ZongDemo.Core;
using ZongDemo.Core.Inventory;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public class RemoveInventoryItem : ObjectiveAction
    {
        [SerializeField] private List<InventoryItemData> _items;

        private IInventoryService _inventoryService;

        public override void OnStart()
        {
            ServiceLocator.Instance.TryGet(out _inventoryService);
        }

        public override ActionStatus Execute()
        {
            _items.ForEach(x => _inventoryService.TryRemoveItem(x.Item, x.Amount));
            return ActionStatus.Success;
        }
    }
}