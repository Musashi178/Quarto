using System;

namespace Quarto.GameAlgorithms.Tests
{
    public sealed class TicTacToeMove
    {
        private readonly int xCoordinate;
        private readonly int yCoordinate;

        public TicTacToeMove(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public int[,] Apply(int[,] playField, int player)
        {
            playField[this.xCoordinate, this.yCoordinate] = player;

            throw new NotImplementedException();
        }
    }
}