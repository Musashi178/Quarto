namespace Quarto.Algorithms
{
    public interface IMove<TState>
    {
        TState ApplyTo(TState state);
    }
}
