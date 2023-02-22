using SpaceShips.Ships;

namespace SpaceShips.Attachables
{
    internal interface IAttachable
    {
        bool Compatible(ISlot slot);
        void OnAttached(IShipStructure ship);
    }
}