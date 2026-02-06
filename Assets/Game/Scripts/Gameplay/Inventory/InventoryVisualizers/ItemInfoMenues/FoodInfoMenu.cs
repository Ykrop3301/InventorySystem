namespace Gameplay.Inventory
{ 
	public class FoodInfoMenu : ItemInfoMenu
	{
        public void Show(IFoodItem food)
        {
            _icon.sprite = food.Icon;
            _itemNameTextField.text = food.Name;
            _descriptionTextField.text = food.Description;
            gameObject.SetActive(true);
        }
    }
}