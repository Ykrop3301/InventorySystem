namespace Gameplay.Inventory
{
    public interface IWeaponItem : IInventoryItem
    {
        public int Damage { get; }
    }
}
