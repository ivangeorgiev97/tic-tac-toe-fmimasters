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
        public static bool IsPlayerTwo { get; set; } // false - player 1, true - player 2

        public event EventHandler TicTacToeStarted;
        public event EventHandler<bool> TicTacToeEnded;

        Cell[,] cells = new Cell[ROWS, COLUMNS];

        bool inProgress;
        bool initialized;
        int usedCells;

        public int UsedCellsCount { set; get; }

        public Board()
        {
            IsPlayerTwo = false;

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    Cell cell = new Cell(row, col);
                    cells[row, col] = cell;
                    Children.Add(cell);
                    cell.CellStatusChanged += Cell_CellStatusChanged;
                }
            }

            SizeChanged += Board_SizeChanged;

            StartNewGame();
        }

        public void StartNewGame()
        {
            foreach (Cell cell in cells)
            {
                cell.reset();
            }

            inProgress = false;
            initialized = false;
            usedCells = 0;
        }

        private void Board_SizeChanged(object sender, EventArgs e)
        {
            double cellWidth = Width / COLUMNS;
            double cellHeight = Height / ROWS;

            foreach (Cell cell in cells)
            {
                Rectangle rect = new Rectangle(cell.Col * cellWidth, cell.Row * cellHeight, cellWidth, cellHeight);
                SetLayoutBounds(cell, rect);
            }
        }

        private void Cell_CellStatusChanged(object sender, CellStatus e)
        {

            if (!inProgress)
            {
                inProgress = true;

                if (TicTacToeStarted != null)
                {
                    TicTacToeStarted(this, EventArgs.Empty);
                }
            }

            int usedCellsCount = 0;

            foreach (Cell cell in cells)
            {
                if (cell.Status == CellStatus.O || cell.Status == CellStatus.X)
                    usedCellsCount++;
            }

            UsedCellsCount = usedCellsCount;

            Cell currentCell = (Cell)sender;

            if (e == CellStatus.X || e == CellStatus.O)
            {
                if (!initialized)
                    initialized = true;

                inProgress = false;

                if (TicTacToeEnded != null)
                {
                    TicTacToeEnded(this, true);
                }

            }



        }

    }
}
