namespace SpaceShips.Parameters
{
    internal class Term : ParameterModifier
    {
        private readonly float _value;

        public Term(float value) => 
            _value = value;

        internal override void Modify(Parameter target) => 
            target.Value += _value;
    }
}