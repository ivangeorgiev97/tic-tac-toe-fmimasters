using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_tac_toe_fmimasters.Model
{
    class TicTacToe
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public bool DrawResult { get; set; }

        public int Moves { get; set; }
    }
}
