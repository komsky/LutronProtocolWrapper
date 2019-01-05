namespace Lutron.Common.Models
{
    public class VariableState
    {
        private readonly int _stateNumber;

        public VariableState(int stateNumber)
        {
            _stateNumber = stateNumber;
        }

        public override string ToString()
        {
            return $"{_stateNumber}";
        }
    }
}