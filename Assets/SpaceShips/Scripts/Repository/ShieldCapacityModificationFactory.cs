using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Effects/ShieldCapacityModificationFactory", fileName = "ShieldCapacityModificationFactory", order = 0)]
    internal class ShieldCapacityModificationFactory : ParameterModificationFactory<ShieldCapacity>
    {
    }
}