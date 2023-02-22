using System;

namespace SpaceShips.UI
{
    internal interface IMultilineDialogue
    {
        void Show(string header, params (string, Action)[] options);
    }
}