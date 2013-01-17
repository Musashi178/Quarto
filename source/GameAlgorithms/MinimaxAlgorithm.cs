using System;
using System.Collections.Generic;
using System.Linq;

namespace Quarto.Algorithms
{
    public class MinimaxAlgorithm<T>
    {
    	private readonly Func<T, bool> isTerminalState;
    	private readonly Func<T, float> getUtilityValue;
    	private readonly Func<T, IEnumerable<IMove<T>>> getMoves;
    	
        public MinimaxAlgorithm(Func<T, bool> isTerminalState, Func<T, float> getUtilityValue, Func<T, IEnumerable<IMove<T>>> getMoves)
        {
        	this.isTerminalState = isTerminalState;
        	this.getUtilityValue = getUtilityValue;
        	this.getMoves = getMoves;
        }

        internal float GetMinimumValue(T state)
        {
        	if(isTerminalState(state))
        	{
        		return getUtilityValue(state);
        	}
        	
        	return getMoves(state).Min(m => GetMinimumValue(m.ApplyTo(state)));
        }
        
        internal float GetMaximumValue(T state)
        {
        	if(isTerminalState(state))
        	{
        		return getUtilityValue(state);
        	}
        	
        	return getMoves(state).Max(m => GetMaximumValue(m.ApplyTo(state)));
        }
        
        public IMove<T> GetNextMove(T state)
        {
        	return getMoves(state).Select(m => new { Move = m, UtilityValue = GetMaximumValue(m.ApplyTo(state)) }).OrderByDescending(v => v.UtilityValue).First().Move;
        }
    }
    
 
}
