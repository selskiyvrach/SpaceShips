using System;

namespace SpaceShips.Ships
{
    internal interface IDestroyedCallback
    {
        event Action OnDestroyed;
    }
}