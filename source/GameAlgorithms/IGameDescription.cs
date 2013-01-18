using System.Collections.Generic;

namespace Quarto.Algorithms
{
    public interface IGameProblemDescription<T>
    {
        bool IsTerminalState(T state);
        float GetUtilityValue(T state);
        IEnumerable<IMove<T>> GetMoves(T state);
    }
}