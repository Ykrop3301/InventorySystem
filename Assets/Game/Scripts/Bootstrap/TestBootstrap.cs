using Assets.Game.Scripts.Configs;
using Gameplay.Inventory;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
	public class TestBootstrap : MonoBehaviour
	{
		[SerializeField] private List<FoodItemConfig> _foods;
		[SerializeField] private List<UsableItemConfig> _usables;
		[SerializeField] private List<WeaponItemConfig> _weapons;

		[Inject]
		public void Construct(
			Inventory<IFoodItem> foodInventory,
			Inventory<IUsableItem> usablesInventory,
			Inventory<IWeaponItem> weaponInventory)
		{
			foreach (var item in _usables)
			{
				usablesInventory.AddItem(item);
			}

            foreach (var item in _weapons)
            {
                weaponInventory.AddItem(item);
            }

            foreach (var item in _foods)
            {
                foodInventory.AddItem(item);
            }
        }
	}
}