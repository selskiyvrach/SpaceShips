using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShips.UI
{
    internal class TextButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _text;

        internal void Construct(string text, Action callback)
        {
            _text.text = text;
            _button.onClick.AddListener(() => callback?.Invoke());
        }

        internal void Clear()
        {
            _button.onClick.RemoveAllListeners();
            _text.text = string.Empty;
        }
    }
}