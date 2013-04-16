using System;
using System.Collections.Generic;

namespace Quarto.Algorithms
{
    public class GenericGameDescription<TState> : IGameDescription<TState>
    {
        private readonly Func<TState, IEnumerable<IMove<TState>>> _getMoves;
        private readonly Func<TState, float> _getUtilityValue;
        private readonly Func<TState, bool> _isTerminalState;

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

            this._getMoves = getMoves;
            this._getUtilityValue = getUtilityValue;
            this._isTerminalState = isTerminalState;
        }

        public bool IsTerminalState(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this._isTerminalState(state);
        }

        public float GetUtilityValue(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this._getUtilityValue(state);
        }

        public IEnumerable<IMove<TState>> GetMoves(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            return this._getMoves(state);
        }
    }
}
