using System;
using System.Collections.Generic;

namespace Quarto.Algorithms
{
    public class GenericGameDescription<T> : IGameProblemDescription<T>
    {
        private readonly Func<T, IEnumerable<IMove<T>>> getMoves;
        private readonly Func<T, float> getUtilityValue;
        private readonly Func<T, bool> isTerminalState;

        public GenericGameDescription(Func<T, bool> isTerminalState, Func<T, float> getUtilityValue, Func<T, IEnumerable<IMove<T>>> getMoves)
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

        public bool IsTerminalState(T state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.isTerminalState(state);
        }

        public float GetUtilityValue(T state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.getUtilityValue(state);
        }

        public IEnumerable<IMove<T>> GetMoves(T state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this.getMoves(state);
        }
    }
}
