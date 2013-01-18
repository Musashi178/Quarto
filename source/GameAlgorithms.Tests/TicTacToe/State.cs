using System;
using System.Diagnostics;
using System.Linq;

namespace Quarto.GameAlgorithms.Tests.TicTacToe
{
    internal class State
    {
        private readonly Lazy<bool> isEndState;
        private readonly PlayField<Sign> playField;

        public State(PlayField<Sign> playField)
        {
            if (playField.Width != 3 || playField.Height != 3)
            {
                throw new ArgumentException("A 3x3 playfield is required.", "playField");
            }

            this.playField = playField;
            this.isEndState = new Lazy<bool>(() => CheckForEndState(this.playField));
        }

        public PlayField<Sign> PlayField
        {
            get { return this.playField; }
        }

        public bool IsEndState
        {
            get { return this.isEndState.Value; }
        }

        private static bool CheckForEndState(PlayField<Sign> playField)
        {
            Debug.Assert(playField != null);

            if (playField.AllFields.All(s => s != Sign.None))
            {
                return true;
            }

            return playField.Columns.Concat(playField.Rows).Concat(playField.Diagonals).Any(l =>
                {
                    Sign[] d = l.Distinct().ToArray();
                    return d.Length == 1 && d[0] != Sign.None;
                });
        }
    }
}
