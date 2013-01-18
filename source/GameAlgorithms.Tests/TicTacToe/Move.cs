using System;
using Quarto.Algorithms;

namespace Quarto.GameAlgorithms.Tests.TicTacToe
{
    internal class Move : IMove<State>
    {
        private int column;
        private int row;
        private Sign sign;

        public Move(Sign sign, int row, int column)
        {
            if (row < 0 || row >= 3)
            {
                throw new ArgumentOutOfRangeException("row", row, "Must not be less than 0 or more than 2");
            }

            if (column < 0 || column >= 3)
            {
                throw new ArgumentOutOfRangeException("column", column, "Must not be less than 0 or more than 2");
            }

            if (sign == Sign.None)
            {
                throw new ArgumentException("sign cannot be none, must be X or O", "sign");
            }

            this.sign = sign;
            this.row = row;
            this.column = column;
        }

        public State ApplyTo(State state)
        {
            throw new NotImplementedException();
        }
    }
}