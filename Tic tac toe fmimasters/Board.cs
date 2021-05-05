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
        public static bool HasWinnerOrDraw { get; set; }

        public event EventHandler TicTacToeStarted;
        public event EventHandler<string> TicTacToeEnded;
        public event EventHandler IsPlayerTwoStatusChanged;

        Cell[,] cells = new Cell[ROWS, COLUMNS];

        bool inProgress;
       // bool initialized;
       // int usedCells;

        public int UsedCellsCount { set; get; }

        public Board()
        {
            IsPlayerTwo = false;
            HasWinnerOrDraw = false; 

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

            IsPlayerTwo = false;
            inProgress = false;
            UsedCellsCount = 0;
            HasWinnerOrDraw = false;
            // initialized = false;
            // usedCells = 0;
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

        private string WhoWins()
        {
            if (UsedCellsCount > 4 && UsedCellsCount <= MAX_MOVES)
            {
                if (CheckWinenrByStatus(CellStatus.X)) 
                {
                    return "one";
                } 
                else if (CheckWinenrByStatus(CellStatus.O))
                {
                    return "two";
                }

                if (UsedCellsCount == MAX_MOVES)
                    return "draw";
            }

            return String.Empty;
        }

        private bool CheckWinenrByStatus(CellStatus cellStatus)
        {
            bool hasWinner = false;

            // Check rows
            bool winnerRows = (cells[0, 0].Status == cellStatus && cells[0, 1].Status == cellStatus && cells[0, 2].Status == cellStatus) ||
                         (cells[1, 0].Status == cellStatus && cells[1, 1].Status == cellStatus && cells[1, 2].Status == cellStatus) ||
                         (cells[2, 0].Status == cellStatus && cells[2, 1].Status == cellStatus && cells[2, 2].Status == cellStatus);
            if (winnerRows)
                return true;

            // Check cols
            bool winnerCols = (cells[0, 0].Status == cellStatus && cells[1, 0].Status == cellStatus && cells[2, 0].Status == cellStatus) ||
                         (cells[0, 1].Status == cellStatus && cells[1, 1].Status == cellStatus && cells[2, 1].Status == cellStatus) ||
                         (cells[0, 2].Status == cellStatus && cells[1, 2].Status == cellStatus && cells[2, 2].Status == cellStatus);
            if (winnerCols)
                return true;

            // Check other
            bool winnerOther = (cells[0, 0].Status == cellStatus && cells[1, 1].Status == cellStatus && cells[2, 2].Status == cellStatus) ||
                         (cells[0, 2].Status == cellStatus && cells[1, 1].Status == cellStatus && cells[2, 0].Status == cellStatus);
            if (winnerOther)
                return true;

            return hasWinner;
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

            if (UsedCellsCount < MAX_MOVES)
            {
                IsPlayerTwoStatusChanged(this, EventArgs.Empty);
            }

            // Cell currentCell = (Cell)sender;

            string whoWins = WhoWins();
            if (whoWins != String.Empty)
            {
                HasWinnerOrDraw = true;

                TicTacToeEnded(this, whoWins);
            }
        }

    }
}
