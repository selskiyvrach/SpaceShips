using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShips.UI
{
    internal class MultilineDialogue : MonoBehaviour, IMultilineDialogue
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextButton _buttonPrefab;
        [SerializeField] private LayoutGroup _buttonsLayout;
        
        private readonly List<TextButton> _textButtons = new();

        public void Show(string header, params (string, Action)[] options)
        {
            gameObject.SetActive(true);

            _headerText.text = header;
            
            PrepareButtons(options.Length);
            
            for (var i = 0; i < options.Length; i++) 
                _textButtons[i].Construct(options[i].Item1, OnOptionSelected(options[i].Item2));
        }

        private void PrepareButtons(int quantity)
        {
            for (var i = 0; i < _textButtons.Count; i++)
                _textButtons[i].gameObject.SetActive(i < quantity);

            for (var i = _textButtons.Count; i < quantity; i++)
                _textButtons.Add(Instantiate(_buttonPrefab, _buttonsLayout.transform));
        }

        private Action OnOptionSelected(Action callback) =>
            () =>
            {
                callback?.Invoke();
                Hide();
            };

        private void Hide()
        {
            gameObject.SetActive(false);
            _headerText.text = string.Empty;
            foreach (var textButton in _textButtons)
                textButton.Clear();
        }
    }
}