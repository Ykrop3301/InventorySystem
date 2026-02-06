using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Gameplay.Inventory
{
	public abstract class ItemInfoMenu : MonoBehaviour
	{
        [SerializeField] protected Image _icon;
        [SerializeField] protected TMP_Text _itemNameTextField;
        [SerializeField] protected TMP_Text _descriptionTextField;

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}