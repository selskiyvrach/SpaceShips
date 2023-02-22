using System.Collections.Generic;
using SpaceShips.Attachables;

namespace SpaceShips.Ships
{
    internal class ShipStructure : IShipStructure
    {
        private readonly Slot[] _slots;

        public HashSet<IWeapon> Weapons { get; } = new();
        
        public Parameters.Parameters Parameters { get; } = new();
        
        public IReadOnlyList<ISlot> Slots => _slots;

        public ShipStructure(Slot[] slots)
        {
            _slots = slots;
            foreach (var slot in slots) 
                slot.Initialize(this);
        }
    }
}