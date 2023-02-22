using SpaceShips.Attachables.Modules;
using SpaceShips.Ships;

namespace SpaceShips.Parameters
{
    internal class ParameterModification<T> : IModification where T : Parameter
    {
        private readonly ParameterModifier _modifier;
        
        public ParameterModification(ParameterModifier modifier) => 
            _modifier = modifier;

        public void ApplyTo(IShipStructure ship) =>
            _modifier.Modify(ship.Parameters.Get<T>());
    }
}