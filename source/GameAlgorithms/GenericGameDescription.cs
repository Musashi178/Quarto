using System;
using System.Collections.Generic;

namespace Quarto.Algorithms
{
    public class GenericGameDescription<TState> : IGameDescription<TState>
    {
        private readonly Func<TState, IEnumerable<IMove<TState>>> getMoves;
        private readonly Func<TState, float> getUtilityValue;
        private readonly Func<TState, bool> isTerminalState;

        public GenericGameDescription(Func<TState, bool> isTerminalState, Func<TState, float> getUtilityValue, Func<TState, IEnumerable<IMove<TState>>> getMoves)
        {
            if (isTerminalState == null)
            {
                throw new ArgumentNullException("isTerminalState");
            }

            if (getUtilityValue == null)
            {
                throw new ArgumentNullException("getUtilityValue");
            }

            if (getMoves == null)
            {
                throw new ArgumentNullException("getMoves");
            }

            this.getMoves = getMoves;
            this.getUtilityValue = getUtilityValue;
            this.isTerminalState = isTerminalState;
        }

        public bool IsTerminalState(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.isTerminalState(state);
        }

        public float GetUtilityValue(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.getUtilityValue(state);
        }

        public IEnumerable<IMove<TState>> GetMoves(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.getMoves(state);
        }
    }
}
