using System.Collections.Generic;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/AttachablesRepository", fileName = "AttachablesRepository", order = 0)]
    internal class AttachablesRepository : ScriptableObject, IAttachablesRepository
    {
        [SerializeField] private RepositoryEntry[] _entries;
        public IReadOnlyList<IEntry> All => _entries;
    }
}