namespace Quarto.Algorithms
{
    internal struct MoveValue<TState>
    {
        private readonly IMove<TState> move;
        private readonly float value;

        public MoveValue(IMove<TState> move, float value)
        {
            this.move = move;
            this.value = value;
        }

        public IMove<TState> Move
        {
            get { return this.move; }
        }

        public float Value
        {
            get { return this.value; }
        }
    }
}
