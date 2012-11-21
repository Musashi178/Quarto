using System;
using System.Collections.Generic;
using System.Linq;

namespace Quarto.Algorithms
{
    public class MinimaxAlgorithm<TGameState, TMove> where TMove : IMove<TGameState>
    {
        private readonly Func<TGameState, IEnumerable<TMove>> getPossibleMoves;
        private readonly Func<TGameState, float> getScore;
        private int searchDepth = 3;

        public MinimaxAlgorithm(Func<TGameState, IEnumerable<TMove>> getPossibleMoves, Func<TGameState, float> getScore, int searchDepth = 1)
        {
            this.SearchDepth = searchDepth;
            this.getPossibleMoves = getPossibleMoves;
            this.getScore = getScore;
        }

        public int SearchDepth
        {
            get { return this.searchDepth; }
            set
            {
                if (this.searchDepth <= 0)
                {
                    throw new ArgumentException("SearchDepth must be greater than 0.");
                }

                this.searchDepth = value;
            }
        }

        public TMove GetBestMove(TGameState gameState)
        {
            return this.Max(gameState, 0).OrderBy(t => t.Score).First().Move;
        }

        private IEnumerable<EvaluatedMove> Max(TGameState gameState, int currentDepth)
        {
            IEnumerable<Tuple<TMove, TGameState>> possibleMoves = this.getPossibleMoves(gameState).Select(m => new Tuple<TMove, TGameState>(m, m.Apply(gameState)));

            if (currentDepth >= this.SearchDepth)
            {
                return possibleMoves.Select(t => new EvaluatedMove(t.Item1, this.getScore(t.Item2)));
            }
            else
            {
                return possibleMoves.Select(t => new EvaluatedMove(t.Item1, this.Min(t.Item2, currentDepth + 1).Select(r => r.Score).Max()));
            }
        }

        private IEnumerable<EvaluatedMove> Min(TGameState gameState, int currentDepth)
        {
            IEnumerable<Tuple<TMove, TGameState>> possibleMoves = this.getPossibleMoves(gameState).Select(m => new Tuple<TMove, TGameState>(m, m.Apply(gameState)));

            if (currentDepth >= this.SearchDepth)
            {
                return possibleMoves.Select(t => new EvaluatedMove(t.Item1, -this.getScore(t.Item2)));
            }
            else
            {
                return possibleMoves.Select(t => new EvaluatedMove(t.Item1, this.Max(t.Item2, currentDepth + 1).Select(r => r.Score).Min()));
            }
        }

        private class EvaluatedMove
        {
            private readonly TMove move;
            private readonly float score;

            public EvaluatedMove(TMove move, float score)
            {
                this.move = move;
                this.score = score;
            }

            public TMove Move
            {
                get { return this.move; }
            }

            public float Score
            {
                get { return this.score; }
            }
        }
    }
}
