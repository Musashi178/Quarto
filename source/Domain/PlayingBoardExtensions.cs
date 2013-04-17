using System;
using System.Collections.Generic;
using System.Linq;

namespace Quarto.Domain
{
    public static class PlayingBoardExtensions
    {
        public static IEnumerable<IEnumerable<Stone>> GetAllLines(this PlayingBoard playingBoard)
        {
            if (playingBoard == null)
            {
                throw new ArgumentNullException("playingBoard");
            }

            return playingBoard.GetColumns().Concat(playingBoard.GetRows()).Concat(playingBoard.GetDiagonals());
        }

        public static IEnumerable<Stone> GetAllFields(this PlayingBoard playingBoard)
        {
            if (playingBoard == null)
            {
                throw new ArgumentNullException("playingBoard");
            }

            return playingBoard.GetRows().SelectMany(r => r);
        }
    }
}
