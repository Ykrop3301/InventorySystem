using UnityEngine;
namespace Gameplay.Inventory
{
	public class ItemCellsFactory
	{
		private readonly ItemCellObject _cellPrefab;

		public ItemCellsFactory(ItemCellObject cellPrefab)
		{
			_cellPrefab = cellPrefab;
		}

        public ItemCellObject CreateCellObject(Transform holder)
		{
			return GameObject.Instantiate(_cellPrefab, holder);
        }

	}
}