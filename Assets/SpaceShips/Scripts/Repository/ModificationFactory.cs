using SpaceShips.Attachables.Modules;
using UnityEngine;

namespace SpaceShips.Repository
{
    internal abstract class ModificationFactory : ScriptableObject
    {
        internal abstract IModification Create();
    }
}