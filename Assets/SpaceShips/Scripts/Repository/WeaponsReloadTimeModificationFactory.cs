using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Effects/WeaponsReloadTimeModificationFactory", fileName = "WeaponsReloadTimeModificationFactory", order = 0)]
    internal class WeaponsReloadTimeModificationFactory : ParameterModificationFactory<WeaponsReloadTimeFactor>
    {
    }
}