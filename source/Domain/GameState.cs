using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto.Domain
{
    class GameState
    {
        private PlayingBoard playingBoard;
        private Stone nextStone;

        public GameState(PlayingBoard playingBoard, Stone nextStone)
        {
            this.playingBoard = playingBoard;
            this.nextStone = nextStone;
        }

        public PlayingBoard PlayingBoard { get { return this.playingBoard; } }

        public GameState ChooseAsNextStone(Stone nextStone)
        {
            return null;
        }

        public GameState SetNextStoneTo(int column, int row)
        {
            return null;
        }
    }
}
