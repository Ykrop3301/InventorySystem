using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory
{
	public class InventoryWindow : MonoBehaviour
	{
        [SerializeField] private Transform _weaponsContentHolder;
        [SerializeField] private Transform _foodsContentHolder;
        [SerializeField] private Transform _usableItemsContentHolder;
        [SerializeField] private Image _infoItemImage;
        [SerializeField] private TMP_Text _infoItemNameTextField;
        [SerializeField] private TMP_Text _infoItemDescriptionTextField;

		public event System.Action Destroyed;

        private void Start()
        {
            Hide();
        }

        public void ShowCells<T>() where T : IInventoryItem
        {
            gameObject.SetActive(true);
            _weaponsContentHolder.gameObject.SetActive(typeof(T) == typeof(IWeaponItem));
            _foodsContentHolder.gameObject.SetActive(typeof(T) == typeof(IFoodItem));
            _usableItemsContentHolder.gameObject.SetActive(typeof(T) == typeof(IUsableItem));
        }

        public Transform GetContentHolder<T>() where T : IInventoryItem
        {
            if (typeof(T) == typeof(IWeaponItem)) return _weaponsContentHolder;
            else if (typeof(T) == typeof(IFoodItem)) return _foodsContentHolder;
            else return _usableItemsContentHolder;
        }

        public void Hide()
        {
            _weaponsContentHolder.gameObject.SetActive(false);
            _foodsContentHolder.gameObject.SetActive(false);
            _usableItemsContentHolder.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }

        public void ShowItemInfo(Sprite sprite, string itemName, string itemDescription)
        {
            _infoItemImage.sprite = sprite;
            _infoItemNameTextField.text = itemName;
            _infoItemDescriptionTextField.text = itemDescription;
        }
    }
}