using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory
{
    public class InventoryContentFilter : MonoBehaviour
    {
        public event Action<Type> OnShow;

        public void ShowFood()
        {
            OnShow?.Invoke(typeof(IFoodItem));
        }

        public void ShowUsable()
        {
            OnShow?.Invoke(typeof(IUsableItem));
        }

        public void ShowWeapons()
        {
            OnShow?.Invoke(typeof(IWeaponItem));
        }
    }
}