using System;

namespace SpaceShips.Attachables
{
    internal interface ISlot
    {
        void Attach(IAttachable attachable);
        IAttachable Attachable { get; }
        event Action OnContentChanged;
    }
}