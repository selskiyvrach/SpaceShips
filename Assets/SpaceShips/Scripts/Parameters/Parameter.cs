using System;

namespace SpaceShips.Parameters
{
    internal abstract class Parameter
    {
        private float _value;
        internal event Action OnChanged;

        internal float Value
        {
            get => _value;
            set { _value = value; OnChanged?.Invoke(); }
        }
    }
}