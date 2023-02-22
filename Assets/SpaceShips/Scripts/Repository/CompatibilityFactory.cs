using SpaceShips.Attachables;
using UnityEngine;

namespace SpaceShips.Repository
{
    internal abstract class CompatibilityFactory : ScriptableObject
    {
        internal abstract ICompatibility Create();
    }
}