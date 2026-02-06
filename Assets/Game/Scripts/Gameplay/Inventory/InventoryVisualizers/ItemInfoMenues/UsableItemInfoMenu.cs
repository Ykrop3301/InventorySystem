namespace Gameplay.Inventory
{
	public class UsableItemInfoMenu : ItemInfoMenu
	{
        public void Show(IUsableItem item)
        {
            _icon.sprite = item.Icon;
            _itemNameTextField.text = item.Name;
            _descriptionTextField.text = item.Description;
            gameObject.SetActive(true);
        }
    }
}