using System.Collections.Generic;

namespace SpaceShips.Repository
{
    internal interface IAttachablesRepository
    {
        IReadOnlyList<IEntry> All { get; }
    }
}