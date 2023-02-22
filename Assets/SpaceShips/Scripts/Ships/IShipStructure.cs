using System.Collections.Generic;
using SpaceShips.Attachables;

namespace SpaceShips.Ships
{
    internal interface IShipStructure
    {
        Parameters.Parameters Parameters { get; }
        HashSet<IWeapon> Weapons { get; }
        IReadOnlyList<ISlot> Slots { get; }
    }
}