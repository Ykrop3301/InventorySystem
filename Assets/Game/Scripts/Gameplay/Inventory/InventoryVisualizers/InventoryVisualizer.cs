using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory
{
    public class InventoryVisualizer<TItem> 
        where TItem : IInventoryItem 
    {
        private readonly Inventory<TItem> _inventory;
        private readonly InventoryWindow _window;
        private readonly ItemCellsFactory _itemCellsFactory;

        private List<ItemCell<TItem>> _cells;
        private InventoryContentFilter _inventoryContentFilter;
        private TItem _lastItemInfoShowed;

        [Inject]
        public InventoryVisualizer(Inventory<TItem> inventory, ItemCellsFactory itemCellsFactory, InventoryWindow inventoryWindow, InventoryContentFilter inventoryContentFilter)
        {
            _inventory = inventory;
            _itemCellsFactory = itemCellsFactory;
            _window = inventoryWindow;
            _cells = new();
            _inventoryContentFilter = inventoryContentFilter;

            Subscribe();
        }

        public void Subscribe()
        {
            _inventory.ItemsChanged += OnItemsChanged;
            _window.Destroyed += Unsubscribe;

            _inventoryContentFilter.OnShow += OnNeedShow;   
        }

        public void Unsubscribe()
        {
            _inventory.ItemsChanged -= OnItemsChanged;
            _window.Destroyed -= Unsubscribe;

            _inventoryContentFilter.OnShow -= OnNeedShow;
        }

        private void OnNeedShow(System.Type type)
        {
            if (type == typeof(TItem))
                ShowItems();
        }

        public void ShowItems()
        {
            _window.ShowCells<TItem>();
            if (_lastItemInfoShowed == null && _cells.Count >= 1)
                ShowInfo(_cells[0].Item);
            else if (_cells.Count >= 1)
                ShowInfo(_lastItemInfoShowed);
        }

        public void Hide()
            => _window.Hide();

        private void OnItemsChanged()
        {
            IReadOnlyList<TItem> items = _inventory.GetItems();
            Transform windowContent = _window.GetContentHolder<TItem>();

            int itemsInInventory = items.Count;
            int itemsOnScreen = _cells.Count;
            int maxItems = Mathf.Max(itemsInInventory, itemsOnScreen);
            for (int i = 0; i < maxItems; i++)
            {
                if (i < itemsOnScreen && i < itemsInInventory)
                {
                    _cells[i].Item = items[i];
                }
                else if (i >= itemsOnScreen)
                {
                    ItemCellObject cellObject = _itemCellsFactory.CreateCellObject(windowContent);
                    ItemCell<TItem> cell = new ItemCell<TItem>(cellObject, this);
                    cellObject.Initialize(cell);
                    cell.Item = items[i];
                    _cells.Add(cell);
                }
                else if (i >= itemsInInventory)
                {
                    _cells[i].Destroy();
                    _cells.RemoveAt(i);
                }
            }
        }

        public void ShowInfo(TItem item)
        {
            _lastItemInfoShowed = item;
            _window.ShowItemInfo(item.Icon, item.Name, item.Description);
        }
    }
}
