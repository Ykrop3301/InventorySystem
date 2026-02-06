using System.Collections.Generic;

namespace Gameplay.Inventory
{
	public class Inventory<T> where T : IInventoryItem
	{
        public event System.Action ItemsChanged;
        private List<T> _items;

        public Inventory()
        {
            _items = new();
        }
        public IReadOnlyList<T> GetItems()
            => _items;
        public void AddItem(T item)
        {
            _items.Add(item);
            ItemsChanged?.Invoke();
        }
        public void RemoveItem(T item)
        {
            _items.Remove(item);
            ItemsChanged?.Invoke();
        }
    }
}