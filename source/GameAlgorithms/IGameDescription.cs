using System.Collections.Generic;

namespace Quarto.Algorithms
{
    public interface IGameDescription<TState>
    {
        bool IsTerminalState(TState state);
        float GetUtilityValue(TState state);
        IEnumerable<IMove<TState>> GetMoves(TState state);
    }
}