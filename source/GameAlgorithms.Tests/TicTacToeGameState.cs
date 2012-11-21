using System.Collections.Generic;
using Quarto.Algorithms;

namespace Quarto.GameAlgorithms.Tests
{
    public class TicTacToeGameState : IGameState<TicTacToeMove>
    {
        private readonly int[,] playField;
        private readonly int playerToMove;

        private TicTacToeGameState(int[,] playField, int playerToMove)
        {
            this.playField = playField;
            this.playerToMove = playerToMove;
        }

        public static TicTacToeGameState Init()
        {
            return new TicTacToeGameState(new int[3,3], 1);
        }

        public TicTacToeGameState Apply(TicTacToeMove move)
        {
            return new TicTacToeGameState(move.Apply(this.playField, this.playerToMove), this.playerToMove * -1);
        }

        public IEnumerable<TicTacToeMove> GetPossibleMoves()
        {
            for(int x = 0; x < 3; ++x)
            {
                for(int y = 0; y < 3; ++y)
                {
                    if(this.playField[x,y] == 0) yield return new TicTacToeMove(x,y);
                }
            }
        }

        public bool IsWinState()
        {
            return false;
        }
    }
}