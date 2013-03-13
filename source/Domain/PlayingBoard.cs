using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Quarto.Domain
{
    public class PlayingBoard<TStone>
    {
        private readonly int height;
        private readonly int width;

        private readonly TStone[,] playingBoard;

        public PlayingBoard(int height, int width)
        {
            this.playingBoard = new TStone[height, width];
        }

        public int Width
        {
            get { return this.width; }
        }

        public int Height
        {
            get { return this.height; }
        }

        public IEnumerable<TStone> GetAllFields()
        {
            return this.GetRows().SelectMany(r => r);
        }

        public IEnumerable<IEnumerable<TStone>> GetColumns()
        {
            for (var w = 0; w < width; ++w)
            {
                yield return Enumerable.Range(0, height).Select(i => this.playingBoard[i, w]);
            }
        }

        public IEnumerable<IEnumerable<TStone>> GetRows()
        {
            for (var h = 0; h < height; ++h)
            {
                yield return Enumerable.Range(0, width).Select(i => this.playingBoard[h, i]);
            }
        }

        public IEnumerable<IEnumerable<TStone>> GetDiagonals()
        {
            if (width != height)
            {
                throw new InvalidOperationException("GetDiagonals can only be called on square playing boards.");
            }
            
            var maxIndex = width - 1;

            yield return Enumerable.Range(0, maxIndex).Select(i => this.playingBoard[i, i]);
            yield return Enumerable.Range(0,maxIndex).Select(i => this.playingBoard[i, maxIndex - i]);
        }
    }
}
