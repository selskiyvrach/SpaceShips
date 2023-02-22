using SpaceShips.Attachables.Modules;
using SpaceShips.Ships;

namespace SpaceShips.Attachables
{
    internal sealed class Attachable : IAttachable
    {
        private readonly ICompatibility _compatibility;
        private readonly IModification _modification;

        public Attachable(ICompatibility compatibility, IModification modification)
        {
            _compatibility = compatibility;
            _modification = modification;
        }

        public bool Compatible(ISlot slot) =>
            _compatibility.Compatible(slot);

        public void OnAttached(IShipStructure ship) =>
            _modification.ApplyTo(ship);
    }
}