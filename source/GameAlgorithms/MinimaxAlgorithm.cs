using System;
using System.Diagnostics;
using System.Linq;

namespace Quarto.Algorithms
{
    public class MinimaxAlgorithm<T>
    {
        private readonly IGameProblemDescription<T> gameDescription;

        public MinimaxAlgorithm(IGameProblemDescription<T> gameDescription)
        {
            if (gameDescription == null)
            {
                throw new ArgumentNullException("gameDescription");
            }

            this.gameDescription = gameDescription;
        }

        public IMove<T> GetNextMove(T state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.gameDescription.GetMoves(state).Select(m => new {Move = m, UtilityValue = this.GetMaximumValue(m.ApplyTo(state))}).OrderByDescending(v => v.UtilityValue).First().Move;
        }

        internal float GetMinimumValue(T state)
        {
            Debug.Assert(state != null, "state != null");

            if (this.gameDescription.IsTerminalState(state))
            {
                return this.gameDescription.GetUtilityValue(state);
            }

            return this.gameDescription.GetMoves(state).Min(m => this.GetMinimumValue(m.ApplyTo(state)));
        }

        internal float GetMaximumValue(T state)
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
