using System;
using System.Diagnostics;
using System.Linq;
using MoreLinq;

namespace Quarto.Algorithms
{
    public class MinimaxAlgorithm<TState>
    {
        private readonly IGameDescription<TState> gameDescription;

        public MinimaxAlgorithm(IGameDescription<TState> gameDescription)
        {
            if (gameDescription == null)
            {
                throw new ArgumentNullException("gameDescription");
            }

            this.gameDescription = gameDescription;
        }

        public IMove<TState> GetNextMove(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.GetMaximumValue(state).Move;
        }

        internal MoveValue<TState> GetMinimumValue(TState state)
        {
            Debug.Assert(state != null, "state != null");

            if (this.gameDescription.IsTerminalState(state))
            {
                return new MoveValue<TState>(null, this.gameDescription.GetUtilityValue(state));
            }

            return this.gameDescription.GetMoves(state).Select(m => new MoveValue<TState>(m, this.GetMinimumValue(m.ApplyTo(state)).Value)).MinBy(mv => mv.Value);
        }

        internal MoveValue<TState> GetMaximumValue(TState state)
        {
            Debug.Assert(state != null, "state != null");

            if (this.gameDescription.IsTerminalState(state))
            {
                return new MoveValue<TState>(null, this.gameDescription.GetUtilityValue(state));
            }
            
            return this.gameDescription.GetMoves(state).Select(m => new MoveValue<TState>(m, this.GetMaximumValue(m.ApplyTo(state)).Value)).MaxBy(mv => mv.Value);
        }
    }
}
