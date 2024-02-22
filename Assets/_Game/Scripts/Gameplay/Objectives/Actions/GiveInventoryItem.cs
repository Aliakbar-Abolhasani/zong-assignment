using System;
using System.Collections.Generic;
using UnityEngine;
using ZongDemo.Core;
using ZongDemo.Core.Inventory;

namespace ZongDemo.Gameplay.Objectives.Actions
{
    public sealed class GiveInventoryItem : ObjectiveAction
    {
        private enum InventoryOperation
        {
            Set = 0,
            Add = 1
        }

        [SerializeField] private InventoryOperation _operation;
        [SerializeField] private List<InventoryItemData> _items;

        private IInventoryService _inventoryService;

        public override void OnStart()
        {
            ServiceLocator.Instance.TryGet(out _inventoryService);
        }

        public override ActionStatus Execute()
        {
            switch (_operation)
            {
                case InventoryOperation.Set:
                    _items.ForEach(x => _inventoryService.SetItem(x.Item, x.Amount));
                    break;

                case InventoryOperation.Add:
                    _items.ForEach(x => _inventoryService.AddItem(x.Item, x.Amount));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return ActionStatus.Success;
        }
    }
}