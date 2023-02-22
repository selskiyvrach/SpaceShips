using SpaceShips.Attachables.Modules;
using SpaceShips.Ships;

namespace SpaceShips.Attachables.Weapons
{
    internal class WeaponUnitModification : IModification
    {
        private readonly IWeapon _weapon;

        public WeaponUnitModification(IWeapon weapon) => 
            _weapon = weapon;

        public void ApplyTo(IShipStructure ship) => 
            ship.Weapons.Add(_weapon);
    }
}