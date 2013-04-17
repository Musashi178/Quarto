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

        public Stone GetStone(int row, int column)
        {
            return this._playingBoard[row, column];
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
            yield return Enumerable.Range(0, Width).Select(i => this._playingBoard[i, i]);
            yield return Enumerable.Range(0, Width).Select(i => this._playingBoard[i, Width - i - 1]);
        }

        public PlayingBoard SetStone(int row, int column, Stone stone)
        {
            var playingBoardCopy = (Stone[,]) this._playingBoard.Clone();
            playingBoardCopy[row, column] = stone;
            return new PlayingBoard(playingBoardCopy);
        }
    }
}
