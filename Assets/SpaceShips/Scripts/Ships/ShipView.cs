using UnityEngine;

namespace SpaceShips.Ships
{
    internal class ShipView : MonoBehaviour
    {
        [SerializeField] private SlotView[] _slotViews;
        public SlotView[] SlotViews => _slotViews;

        internal void Construct( )
        {
               
        }
    }
}