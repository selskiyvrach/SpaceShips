using SpaceShips.Attachables;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/RepositoryEntry", fileName = "RepositoryEntry", order = 0)]
    internal sealed class RepositoryEntry : ScriptableObject, IEntry
    {
        [SerializeField] private string _tip;
        [SerializeField] private ModuleView _viewPrefab;
        [SerializeField] private AttachableFactory _attachableFactory;
 
        private IAttachable _peek;

        public IAttachable Peek => _peek ??= Create();
        public string Tip => _tip;
        public ModuleView ViewPrefab => _viewPrefab;
        public IAttachable Create() => _attachableFactory.Create();
    }
}