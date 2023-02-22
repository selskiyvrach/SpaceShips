using SpaceShips.Attachables;
using SpaceShips.Attachables.Modules;
using SpaceShips.Attachables.Weapons;
using SpaceShips.Parameters;
using SpaceShips.Repository;
using UnityEngine;

namespace SpaceShips.Ships
{
    [CreateAssetMenu(menuName = "Configs/ShipFactory", fileName = "ShipFactory", order = 0)]
    internal class ShipFactory : ScriptableObject
    {
        [SerializeField] private ShipView _viewPrefab;
        [SerializeField] private int _modulesSlots = 2;
        [SerializeField] private int _weaponsSlots = 2;
        [SerializeField] private float _hp = 100;
        [SerializeField] private float _shield = 80;

        internal ShipConstructionController Create(IAttachablesRepository attachableRepo, Transform spawnPoint)
        {
            var slots = new Slot[_modulesSlots + _weaponsSlots];
            for (int i = 0; i < _modulesSlots; i++)
                slots[i] = new ModuleSlot();
            for (int i = _modulesSlots; i < _modulesSlots + _weaponsSlots; i++)
                slots[i] = new WeaponSlot();

            var ship = new ShipStructure(slots);
            ship.Parameters.Get<HealthCapacity>().Value = _hp;
            ship.Parameters.Get<ShieldCapacity>().Value = _shield;
            ship.Parameters.Get<ShieldRechargeRate>().Value = 1;
            ship.Parameters.Get<WeaponsReloadTimeFactor>().Value = 1;
            
            var view = Instantiate(_viewPrefab, spawnPoint, false);
            
            return new ShipConstructionController(ship, view, attachableRepo);
        }
    }
}