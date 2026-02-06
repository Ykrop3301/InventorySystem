using Gameplay.Inventory;
using UnityEngine;

namespace Assets.Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Config/InventoryItem/WeaponItem", fileName = "New Weapon")]
    public class WeaponItemConfig : ScriptableObject, IWeaponItem
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }

    }
}
