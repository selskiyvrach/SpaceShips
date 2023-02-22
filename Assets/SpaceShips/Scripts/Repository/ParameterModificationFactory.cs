using SpaceShips.Attachables.Modules;
using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    internal abstract class ParameterModificationFactory<TParameter> : ModificationFactory where TParameter : Parameter 
    {
        [SerializeField] private ModifierFactory _modifierFactory;
        
        internal override IModification Create() => 
            new ParameterModification<TParameter>(_modifierFactory.Create());
    }
}