using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tic_tac_toe_fmimasters
{
    class Board : AbsoluteLayout
    {
        const int COLUMNS = 3;
        const int ROWS = 3;
        const int MAX_MOVES = 9;

        public event EventHandler TicTacToeStarted;
        public event EventHandler<bool> TicTacToeEnded;

        Cell[,] cells = new Cell[ROWS, COLUMNS];

        bool inProgress;
        bool initialized;
        int usedCells;

        public Board()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    Cell cell = new Cell(row, col);
                    cells[row, col] = cell;
                    Children.Add(cell);
                    // cell.TileStatusChanged += Cell_CellStatusChanged;
                }
            }

            // SizeChanged += Board_SizeChanged;//Събитие което възниква при промяна на размера

            // StartNewGame();
        }

    }
}
