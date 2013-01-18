using System;
using System.Diagnostics;
using System.Linq;

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

            return this.gameDescription.GetMoves(state).Select(m => new {Move = m, UtilityValue = this.GetMaximumValue(m.ApplyTo(state))}).OrderByDescending(v => v.UtilityValue).First().Move;
        }

        internal float GetMinimumValue(TState state)
        {
            Debug.Assert(state != null, "state != null");

            if (this.gameDescription.IsTerminalState(state))
            {
                return this.gameDescription.GetUtilityValue(state);
            }

            return this.gameDescription.GetMoves(state).Min(m => this.GetMinimumValue(m.ApplyTo(state)));
        }

        internal float GetMaximumValue(TState state)
        {
            Debug.Assert(state != null, "state != null");
            if (this.gameDescription.IsTerminalState(state))
            {
                return this.gameDescription.GetUtilityValue(state);
            }

            return this.gameDescription.GetMoves(state).Max(m => this.GetMaximumValue(m.ApplyTo(state)));
        }
    }
}
