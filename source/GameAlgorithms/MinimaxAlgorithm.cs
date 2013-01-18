using System;
using System.Collections.Generic;
using System.Linq;

namespace Quarto.Algorithms
{
    public class MinimaxAlgorithm<T>
    {
        private readonly Func<T, IEnumerable<IMove<T>>> getMoves;
        private readonly Func<T, float> getUtilityValue;
        private readonly Func<T, bool> isTerminalState;

        public MinimaxAlgorithm(Func<T, bool> isTerminalState, Func<T, float> getUtilityValue, Func<T, IEnumerable<IMove<T>>> getMoves)
        {
            this.isTerminalState = isTerminalState;
            this.getUtilityValue = getUtilityValue;
            this.getMoves = getMoves;
        }

        internal float GetMinimumValue(T state)
        {
            if (this.isTerminalState(state))
            {
                return this.getUtilityValue(state);
            }

            return this.getMoves(state).Min(m => this.GetMinimumValue(m.ApplyTo(state)));
        }

        internal float GetMaximumValue(T state)
        {
            if (this.isTerminalState(state))
            {
                return this.getUtilityValue(state);
            }

            return this.getMoves(state).Max(m => this.GetMaximumValue(m.ApplyTo(state)));
        }

        public IMove<T> GetNextMove(T state)
        {
            return this.getMoves(state).Select(m => new {Move = m, UtilityValue = this.GetMaximumValue(m.ApplyTo(state))}).OrderByDescending(v => v.UtilityValue).First().Move;
        }
    }
}
