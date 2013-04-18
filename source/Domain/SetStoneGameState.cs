using System;

namespace Quarto.Domain
{
    internal class SetStoneGameState : GameStateBase
    {
        public SetStoneGameState(PlayingBoard playingBoard, Stone nextStone, Player newPlayer) : base(playingBoard, nextStone, newPlayer)
        {
            if (nextStone == null)
            {
                throw new ArgumentNullException("nextStone");
            }
        }

        public ChooseStoneGameState SetNextStoneTo(int column, int row)
        {
            var newPlayingBoard = this.PlayingBoard.SetStone(row, column, this.NextStone);

            return new ChooseStoneGameState(newPlayingBoard, this.CurrentPlayer);
        }
    }
}