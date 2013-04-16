namespace Quarto.Algorithms
{
    internal struct MoveValue<TState>
    {
        private readonly IMove<TState> _move;
        private readonly float _value;

        public MoveValue(IMove<TState> move, float value)
        {
            this._move = move;
            this._value = value;
        }

        public IMove<TState> Move
        {
            get { return this._move; }
        }

        public float Value
        {
            get { return this._value; }
        }
    }
}
