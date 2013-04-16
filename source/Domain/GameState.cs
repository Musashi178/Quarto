using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto.Domain
{
    class GameState
    {
        private readonly PlayingBoard _playingBoard;
        private readonly Stone _nextStone;
        private readonly Player _currentPlayer;

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
        }

        public PlayingBoard PlayingBoard { get { return this._playingBoard; } }

        public Stone NextStone
        {
            get { return this._nextStone; }
        }

        public Player CurrentPlayer
        {
            get { return this._currentPlayer; }
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

            var newPlayingBoard = this._playingBoard.SetStone(column, row, this._nextStone);
           
            return new GameState(newPlayingBoard, null, this._currentPlayer);
        }
    }
}
