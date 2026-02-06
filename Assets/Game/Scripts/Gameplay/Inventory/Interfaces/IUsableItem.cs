namespace Gameplay.Inventory
{
    public interface IUsableItem : IInventoryItem
    {
        public string Action { get; }
    }
}
