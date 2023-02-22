using SpaceShips.Attachables.Modules;
using SpaceShips.Attachables.Weapons;
using SpaceShips.Ships;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/WeaponModificationFactory", fileName = "WeaponModificationFactory", order = 0)]
    internal sealed class WeaponModificationFactory : ModificationFactory
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;

        internal override IModification Create()
        {
            var weapon = new Weapon(_damage, _cooldown);
            return new WeaponUnitModification(weapon);
        }
    }
}