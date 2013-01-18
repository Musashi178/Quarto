using System;
using System.Collections.Generic;

namespace Quarto.GameAlgorithms.Tests.TicTacToe
{
    public class PlayField<TStone>
    {
        private readonly int height;
        private readonly int width;

        public int Width
        {
            get { return this.width; }
        }

        public int Height
        {
            get { return this.height; }
        }

        public IEnumerable<TStone> AllFields
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IEnumerable<TStone>> Columns
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IEnumerable<TStone>> Rows
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IEnumerable<TStone>> Diagonals
        {
            get { throw new NotImplementedException(); }
        }
    }
}