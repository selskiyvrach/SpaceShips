using SpaceShips.Attachables;
using SpaceShips.Attachables.Weapons;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Compatibility/Weapon", fileName = "WeaponCompatibilityFactory", order = 0)]
    internal class WeaponCompatibilityFactory : CompatibilityFactory
    {
        internal override ICompatibility Create() => 
            new WeaponSlotCompatibility();
    }
}