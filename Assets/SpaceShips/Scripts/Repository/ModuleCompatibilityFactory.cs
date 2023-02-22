using SpaceShips.Attachables;
using SpaceShips.Attachables.Modules;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Compatibility/Module", fileName = "ModuleCompatibilityFactory", order = 0)]
    internal class ModuleCompatibilityFactory : CompatibilityFactory
    {
        internal override ICompatibility Create() => 
            new ModuleSlotCompatibility();
    }
}