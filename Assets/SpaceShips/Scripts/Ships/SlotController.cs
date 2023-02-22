using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceShips.Attachables;
using SpaceShips.Repository;
using SpaceShips.UI;
using Object = UnityEngine.Object;

namespace SpaceShips.Ships
{
    internal class SlotController
    {
        private readonly SlotView _view;
        private readonly ISlot _model;
        private readonly List<IEntry> _suitableModules = new();
        private bool _moduleSelected;

        public SlotController(ISlot model, SlotView view, IAttachablesRepository attachablesRepository)
        {
            _view = view;
            _model = model;
                
            foreach (var attachable in attachablesRepository.All)
                if (attachable.Peek.Compatible(model))
                    _suitableModules.Add(attachable);
        }

        internal async Task SelectSlotContentAsync(IMultilineDialogue dialogueWindow, string dialogueHeader)
        {
            dialogueWindow.Show(dialogueHeader,
                _suitableModules.Select(
                    n => new ValueTuple<string, Action>(n.Tip, () => OnModuleSelected(n)))
                    .ToArray());
            while (!_moduleSelected) 
                await Task.Yield();
        }

        private void OnModuleSelected(IEntry entry)
        {
            _model.Attach(entry.Create());
            _view.Attach(Object.Instantiate(entry.ViewPrefab));
            _moduleSelected = true;
        }
    }
}