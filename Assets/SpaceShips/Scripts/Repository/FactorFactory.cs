using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Effects/FactorFactory", fileName = "FactorFactory", order = 0)]
    internal class FactorFactory : ModifierFactory
    {
        protected override ParameterModifier Create(float value) => 
            new Factor(value);
    }
}