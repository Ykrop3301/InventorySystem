using Gameplay.Inventory;
using UnityEngine;

namespace Assets.Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Config/InventoryItem/FoodItem", fileName = "New Food")]
    public class FoodItemConfig : ScriptableObject, IFoodItem
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}