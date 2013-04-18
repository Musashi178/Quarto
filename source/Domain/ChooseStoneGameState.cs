using System;

namespace Quarto.Domain
{
    internal class ChooseStoneGameState : GameStateBase
    {
        public ChooseStoneGameState(PlayingBoard playingBoard, Player currentPlayer) : base(playingBoard, null, currentPlayer)
        {
        }

        public SetStoneGameState ChooseAsNextStone(Stone nextStone)
        {
            if (nextStone == null)
            {
                throw new ArgumentNullException("nextStone");
            }

            var newPlayer = this.CurrentPlayer == Player.One ? Player.Two : Player.One;
            return new SetStoneGameState(this.PlayingBoard, nextStone, newPlayer);
        }
    }
}