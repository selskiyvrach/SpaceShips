using System;
using SpaceShips.Ships;

namespace SpaceShips.Attachables
{
    internal abstract class Slot : ISlot
    {
        private IShipStructure _ship;
        public IAttachable Attachable { get; private set; }

        public event Action OnContentChanged;

        internal void Initialize(IShipStructure ship) => 
            _ship = ship;

        public void Attach(IAttachable attachable)
        {
            Attachable = attachable;
            Attachable.OnAttached(_ship);
            OnContentChanged?.Invoke();
        }
    }
}