namespace Quarto.Algorithms
{
    public interface IMove<TGameState>
    {
        TGameState Apply(TGameState gameState);
    }
}