using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Effects/HealthCapacityModificationFactory", fileName = "HealthCapacityModificationFactory", order = 0)]
    internal class HealthCapacityModificationFactory : ParameterModificationFactory<HealthCapacity>
    {
    }
}