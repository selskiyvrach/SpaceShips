using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/Effects/TermFactory", fileName = "TermFactory", order = 0)]
    internal class TermFactory : ModifierFactory
    {
        protected override ParameterModifier Create(float value) => 
            new Term(value);
    }
}