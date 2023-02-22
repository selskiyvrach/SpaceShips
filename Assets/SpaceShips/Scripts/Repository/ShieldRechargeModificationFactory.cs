using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Effects/ShieldRechargeModificationFactory", fileName = "ShieldRechargeModificationFactory", order = 0)]
    internal class ShieldRechargeModificationFactory : ParameterModificationFactory<ShieldRechargeRate>
    {
    }
}