using UnityEngine;
namespace Gameplay.Inventory
{
    public interface IInventoryItem
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}