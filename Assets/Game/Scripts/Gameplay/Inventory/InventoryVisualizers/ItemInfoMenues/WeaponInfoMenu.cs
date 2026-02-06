using UnityEngine;
using TMPro;

namespace Gameplay.Inventory
{
	public class WeaponInfoMenu : ItemInfoMenu
	{
		[SerializeField] private TMP_Text _damageTextField;
		public void Show(IWeaponItem weapon)
		{
			_icon.sprite = weapon.Icon;
			_itemNameTextField.text = weapon.Name;
			_descriptionTextField.text = weapon.Description;
			_damageTextField.text = weapon.Damage.ToString();
			gameObject.SetActive(true);
		}
	}
}