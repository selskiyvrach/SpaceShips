namespace SpaceShips.Parameters
{
    internal class Factor : ParameterModifier
    {
        private readonly float _value;

        public Factor(float value) => 
            _value = value;

        internal override void Modify(Parameter target) => 
            target.Value *= _value;
    }
}