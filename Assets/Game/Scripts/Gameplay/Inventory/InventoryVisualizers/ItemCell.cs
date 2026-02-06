using UnityEngine;

namespace Gameplay.Inventory
{
    public class ItemCell<T> : IItemCell where T : IInventoryItem
	{
		private ItemCellObject _cellObject;
        private readonly InventoryVisualizer<T> _inventoryVisualizer;

        public T Item
		{
			get { return _item; }
			set 
			{
				_item = value;
				_cellObject.Icon.sprite = _item.Icon;
			}
		}

		private T _item;

		public ItemCell(ItemCellObject cellObject, InventoryVisualizer<T> inventoryVisualizer)
		{
			_cellObject = cellObject;
			_inventoryVisualizer = inventoryVisualizer;
		}

		public void Destroy()
		{
			GameObject.Destroy(_cellObject);
		}

        public void OnCellClicked()
        {
			_inventoryVisualizer.ShowInfo(Item);
        }
    }
}