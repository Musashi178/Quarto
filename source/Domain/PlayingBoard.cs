using System.Collections.Generic;
using System.Linq;

namespace Quarto.Domain
{
    public class PlayingBoard
    {
        private const int Height = 4;
        private const int Width = 4;

        private readonly Stone[,] _playingBoard;

        internal PlayingBoard(Stone[,] playingBoard)
        {
            this._playingBoard = playingBoard;
        }

        public PlayingBoard()
            : this(new Stone[Height,Width])
        {
        }

        public Stone GetStone(int column, int row)
        {
            return this._playingBoard[column, row];
        }

        public IEnumerable<Stone> GetAllFields()
        {
            return this.GetRows().SelectMany(r => r);
        }

        public IEnumerable<IEnumerable<Stone>> GetColumns()
        {
            for (var w = 0; w < Width; ++w)
            {
                var columnIndex = w;
                yield return Enumerable.Range(0, Height).Select(i => this._playingBoard[i, columnIndex]);
            }
        }

        public IEnumerable<IEnumerable<Stone>> GetRows()
        {
            for (var h = 0; h < Height; ++h)
            {
                var rowIndex = h;
                yield return Enumerable.Range(0, Width).Select(i => this._playingBoard[rowIndex, i]);
            }
        }

        public IEnumerable<IEnumerable<Stone>> GetDiagonals()
        {
            const int maxIndex = Width - 1;

            yield return Enumerable.Range(0, maxIndex).Select(i => this._playingBoard[i, i]);
            yield return Enumerable.Range(0, maxIndex).Select(i => this._playingBoard[i, maxIndex - i]);
        }

        public PlayingBoard SetStone(int column, int row, Stone stone)
        {
            var playingBoardCopy = (Stone[,]) this._playingBoard.Clone();
            playingBoardCopy[column, row] = stone;
            return new PlayingBoard(playingBoardCopy);
        }
    }
}
