using Gameplay.Inventory;
using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private InventoryWindow _windowPrefab;
    [SerializeField] private ItemCellObject _itemCellPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ItemCellObject>().FromInstance(_itemCellPrefab).AsSingle();
        Container.BindInterfacesAndSelfTo<ItemCellsFactory>().AsSingle();

        Container.BindInterfacesAndSelfTo<Inventory<IFoodItem>>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<Inventory<IWeaponItem>>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<Inventory<IUsableItem>>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<InventoryVisualizer<IFoodItem>>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InventoryVisualizer<IWeaponItem>>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InventoryVisualizer<IUsableItem>>().AsSingle().NonLazy();

        InventoryWindow window = Container.InstantiatePrefabForComponent<InventoryWindow>(_windowPrefab);

        Container.BindInterfacesAndSelfTo<InventoryWindow>().FromInstance(window).AsSingle();
        Container.BindInterfacesAndSelfTo<InventoryContentFilter>().FromInstance(window.GetComponent<InventoryContentFilter>()).AsSingle();
    }
}