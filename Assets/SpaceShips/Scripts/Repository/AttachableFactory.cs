using SpaceShips.Attachables;
using UnityEngine;

namespace SpaceShips.Repository
{
    [CreateAssetMenu(menuName = "Configs/Attachables/AttachableFactory", fileName = "AttachableFactory", order = 0)]
    internal sealed class AttachableFactory : ScriptableObject
    {
        [SerializeField] private CompatibilityFactory _compatibilityFactory;
        [SerializeField] private ModificationFactory _modificationFactory;
        
        public IAttachable Create() => 
            new Attachable(_compatibilityFactory.Create(), _modificationFactory.Create());
    }
}