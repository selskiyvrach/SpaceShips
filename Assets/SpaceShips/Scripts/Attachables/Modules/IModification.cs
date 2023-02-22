using SpaceShips.Ships;

namespace SpaceShips.Attachables.Modules
{
    internal interface IModification
    {
        void ApplyTo(IShipStructure ship);
    }
}