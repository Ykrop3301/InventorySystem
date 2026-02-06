using UnityEngine;
using Gameplay.Inventory;
using Zenject;

namespace Assets.Game.Scripts.Tests
{
	public class ShowInventoryButton : MonoBehaviour
	{
		private InventoryVisualizer<IFoodItem> _visualizer;

		[Inject]
		private void Construct(InventoryVisualizer<IFoodItem> visualizer)
		{
			_visualizer = visualizer;
		}

		public void OnClick()
		{
			_visualizer.ShowItems();
		}
	}
}