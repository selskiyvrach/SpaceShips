using System.Threading.Tasks;
using SpaceShips.Repository;
using SpaceShips.UI;

namespace SpaceShips.Ships
{
    internal class ShipConstructionController
    {
        public IShipStructure Model { get; }

        private readonly ShipView _view;
        private readonly IAttachablesRepository _attachablesRepository;
        
        private SlotController[] _slotControllers;

        public ShipConstructionController(IShipStructure model, ShipView view, IAttachablesRepository attachablesRepository)
        {
            Model = model;
            _view = view;
            _attachablesRepository = attachablesRepository;
            CreateSlotControllers();
        }

        internal async Task ConstructAsync(IMultilineDialogue dialogueWindow)
        {
            for (var i = 0; i < _slotControllers.Length; i++)
            {
                var slotController = _slotControllers[i];
                await slotController.SelectSlotContentAsync(dialogueWindow, $"Select slot No{i + 1} content");
            }
        }


        private void CreateSlotControllers()
        {
            var slots = Model.Slots;
            _slotControllers = new SlotController[slots.Count];
            for (var i = 0; i < slots.Count; i++)
                _slotControllers[i] = new SlotController(slots[i], _view.SlotViews[i], _attachablesRepository);
        }
    }
}