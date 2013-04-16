using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Quarto.Algorithms
{
    public class MinimaxAlgorithmWithAlphaBetaPruning<TState>
    {
        //private readonly IGameDescription<TState> gameDescription;

        //public MinimaxAlgorithmWithAlphaBetaPruning(IGameDescription<TState> gameDescription)
        //{
        //    if (gameDescription == null)
        //    {
        //        throw new ArgumentNullException("gameDescription");
        //    }

        //    this.gameDescription = gameDescription;
        //}

        //public IMove<TState> GetNextMove(TState state)
        //{
        //    if (state == null)
        //    {
        //        throw new ArgumentNullException("state");
        //    }

        //    return this.gameDescription.GetMoves(state).Select(m => new {Move = m, UtilityValue = this.GetMaximumValue(m.ApplyTo(state))}).OrderByDescending(v => v.UtilityValue).First().Move;
        //}

        //internal float GetMaximumValue(TState state, float alpha, float beta)
        //{
        //    Debug.Assert(state != null, "state != null");

        //    if (this.gameDescription.IsTerminalState(state))
        //    {
        //        return this.gameDescription.GetUtilityValue(state);
        //    }

        //    IEnumerable<TState> successorStates = this.gameDescription.GetMoves(state).Select(m => m.ApplyTo(state));

        //    float v = float.MinValue;

        //    foreach (TState successorState in successorStates)
        //    {
        //        v = Math.Max(v, this.GetMinimumValue(successorState, alpha, beta));
        //        if (v >= beta)
        //        {
        //            return v;
        //        }
        //        alpha = Math.Max(alpha, v);
        //    }

        //    return v;
        //}

        //internal float GetMinimumValue(TState state, float alpha, float beta)
        //{
        //    Debug.Assert(state != null, "state != null");

        //    if (this.gameDescription.IsTerminalState(state))
        //    {
        //        return this.gameDescription.GetUtilityValue(state);
        //    }

        //    IEnumerable<TState> successorStates = this.gameDescription.GetMoves(state).Select(m => m.ApplyTo(state));

        //    float v = float.MaxValue;

        //    foreach (TState successorState in successorStates)
        //    {
        //        v = Math.Min(v, this.GetMinimumValue(successorState, alpha, beta));
        //        if (v <= alpha)
        //        {
        //            return v;
        //        }
        //        beta = Math.Min(beta, v);
        //    }

        //    return v;
        //}
    }
}