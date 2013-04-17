using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Quarto.Domain
{
    internal class GameState
    {
        private readonly Player _currentPlayer;
        private readonly Stone _nextStone;
        private readonly PlayingBoard _playingBoard;
        private Lazy<bool> _isWinState;

        public GameState(PlayingBoard playingBoard, Stone nextStone, Player currentPlayer)
        {
            if (playingBoard == null)
            {
                throw new ArgumentNullException("playingBoard");
            }

            if (nextStone != null)
            {
                if (playingBoard.GetAllFields().Contains(nextStone))
                {
                    throw new ArgumentException("nextStone is already set on the playing board.", "nextStone");
                }
            }

            this._playingBoard = playingBoard;
            this._nextStone = nextStone;
            this._currentPlayer = currentPlayer;
            this._isWinState = new Lazy<bool>(() => DetectIsWinState(this));
        }

        public PlayingBoard PlayingBoard
        {
            get { return this._playingBoard; }
        }

        public Stone NextStone
        {
            get { return this._nextStone; }
        }

        public Player CurrentPlayer
        {
            get { return this._currentPlayer; }
        }

        public bool IsWinState
        {
            get { return this._isWinState.Value; }
        }

        private static bool DetectIsWinState(GameState gameState)
        {
            Debug.Assert(gameState != null, "gamestate != null");

            var fullLines = gameState.PlayingBoard.GetAllLines().Where(l => l.All(s => s != null));
            return fullLines.Any(IsWinLine);
        }

        internal static bool IsWinLine(IEnumerable<Stone> line)
        {
            Debug.Assert(line != null, "line != null");
            var ids = line.Select(s => (byte) s.Id).ToArray();

            var allHigh = ids.Aggregate((b, b1) => (byte) (b & b1));
            var allLow = ids.Aggregate((b, b1) => (byte) (b | b1));

            return allHigh != 0 || allLow != 15;
        }

        public GameState ChooseAsNextStone(Stone nextStone)
        {
            if (this._nextStone != null)
            {
                throw new InvalidOperationException("Set the next stone first.");
            }

            var newPlayer = this._currentPlayer == Player.One ? Player.Two : Player.One;
            return new GameState(this._playingBoard, nextStone, newPlayer);
        }

        public GameState SetNextStoneTo(int column, int row)
        {
            if (this._nextStone == null)
            {
                throw new InvalidOperationException("Choose a stone first.");
            }

            var newPlayingBoard = this._playingBoard.SetStone(row, column, this._nextStone);

            return new GameState(newPlayingBoard, null, this._currentPlayer);
        }
    }
}
