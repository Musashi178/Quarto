using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto.Domain
{
    public class PlayingBoard
    {
        private readonly int height;
        private readonly int width;

        private readonly Stone[,] playingBoard;

        internal PlayingBoard(Stone[,] playingBoard)
        {
            this.playingBoard = playingBoard;
        }

        public PlayingBoard() : this(new Stone[4,4])
        {
        }

        public int Width
        {
            get { return this.width; }
        }

        public int Height
        {
            get { return this.height; }
        }

        public Stone GetStone(int column, int row)
        {
            return playingBoard[column, row];
        }

        public IEnumerable<Stone> GetAllFields()
        {
            return this.GetRows().SelectMany(r => r);
        }

        public IEnumerable<IEnumerable<Stone>> GetColumns()
        {
            for (var w = 0; w < width; ++w)
            {
                yield return Enumerable.Range(0, height).Select(i => this.playingBoard[i, w]);
            }
        }

        public IEnumerable<IEnumerable<Stone>> GetRows()
        {
            for (var h = 0; h < height; ++h)
            {
                yield return Enumerable.Range(0, width).Select(i => this.playingBoard[h, i]);
            }
        }

        public IEnumerable<IEnumerable<Stone>> GetDiagonals()
        {
            if (width != height)
            {
                throw new InvalidOperationException("GetDiagonals can only be called on square playing boards.");
            }
            
            var maxIndex = width - 1;

            yield return Enumerable.Range(0, maxIndex).Select(i => this.playingBoard[i, i]);
            yield return Enumerable.Range(0,maxIndex).Select(i => this.playingBoard[i, maxIndex - i]);
        }

        public PlayingBoard SetStone(int column, int row, Stone stone)
        {
            var playingBoardCopy = (Stone[,])this.playingBoard.Clone();
            playingBoardCopy[column, row] = stone;
            return new PlayingBoard(playingBoard);
        }
    }
}
