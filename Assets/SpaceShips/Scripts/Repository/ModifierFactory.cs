using SpaceShips.Parameters;
using UnityEngine;

namespace SpaceShips.Repository
{
    internal abstract class ModifierFactory : ScriptableObject
    {
        [SerializeField] private float _value;

        internal ParameterModifier Create() => 
            Create(_value);

        protected abstract ParameterModifier Create(float value);
    }
}