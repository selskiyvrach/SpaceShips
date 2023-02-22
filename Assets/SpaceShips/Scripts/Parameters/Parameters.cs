using System;
using System.Collections.Generic;

namespace SpaceShips.Parameters
{
    internal sealed class Parameters
    {
        private readonly Dictionary<Type, Parameter> _parameters = new();

        public T Get<T>() where T : Parameter
        {
            if (_parameters.TryGetValue(typeof(T), out var parameter))
                return (T)parameter;
            var newParameter = Activator.CreateInstance<T>();
            _parameters.Add(typeof(T), newParameter);
            return newParameter;
        }
    }
}