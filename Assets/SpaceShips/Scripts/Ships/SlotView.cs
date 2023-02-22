using SpaceShips.Repository;
using UnityEngine;

namespace SpaceShips.Ships
{
    internal class SlotView : MonoBehaviour
    {
        public void Attach(ModuleView moduleView) => 
            moduleView.transform.SetParent(transform, false);
    }
}