namespace SpaceShips.Ships
{
    internal interface IShip : IAttackTarget
    {
        IShipStructure ShipStructure { get; }
    }
}