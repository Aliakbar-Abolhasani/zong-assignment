using System;
using System.Collections.Generic;
using UnityEngine;
using ZongDemo.Core;
using ZongDemo.Core.Inventory;

namespace ZongDemo.Gameplay.UI.Panels
{
    public class InstrumentsPanel : MonoBehaviour
    {
        [SerializeField] private Transform _itemsParent;
        [SerializeField] private InstrumentItemView _itemViewPrefab;

        private readonly List<InstrumentItemView> _itemViews = new();

        private IInventoryService _inventoryService;

        private void OnEnable()
        {
            if (_inventoryService == null)
            {
                ServiceLocator.Instance.TryGet(out _inventoryService);
            }

            // NOTE: Creating and destroying is not efficient but since
            // we only have a couple of items it doesn't really matter
            CreateViews();
        }

        private void OnDisable()
        {
            DestroyViews();
        }

        private void CreateViews()
        {
            var items = _inventoryService.GetItems();
            foreach (var itemData in items)
            {
                if (itemData.Item is not InstrumentItem instrumentItem || itemData.Amount == 0)
                {
                    continue;
                }

                var view = Instantiate(_itemViewPrefab, _itemsParent);
                view.Set(instrumentItem, itemData.Amount);
                _itemViews.Add(view);
            }
        }

        private void DestroyViews()
        {
            foreach (var view in _itemViews)
            {
                Destroy(view.gameObject);
            }

            _itemViews.Clear();
        }
    }
}