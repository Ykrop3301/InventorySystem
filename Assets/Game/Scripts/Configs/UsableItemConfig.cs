using UnityEngine;
using Gameplay.Inventory;

namespace Assets.Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Config/InventoryItem/UsableItem", fileName = "New Usable Item")]
    public class UsableItemConfig : ScriptableObject, IUsableItem
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Action { get; private set; }
    }
}