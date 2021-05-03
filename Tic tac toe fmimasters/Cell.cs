using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Tic_tac_toe_fmimasters
{
    enum CellStatus
    {
        Closed,
        X,
        O
    }

    class Cell : Frame
    {
        CellStatus cellStatus = CellStatus.Closed;
        Label whoPlays;
        Label gameStatus;
        Image oImage;
        Image xImage;
        public int Row { get; set; }
        public int Col { get; set; }
        public bool isPlayerTwo { get; set; } // false - player 1, true - player 2

        public event EventHandler<CellStatus> CellStatusChanged;
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
            isPlayerTwo = false;

            BackgroundColor = Color.White;
            BorderColor = Color.Gray;
            Padding = 2;

            whoPlays = new Label
            {
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            gameStatus = new Label
            {
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            Assembly assembly = Assembly.GetExecutingAssembly();

            oImage = new Image { Source = ImageSource.FromResource("Tic_tac_toe_fmimasters.images.o.png", assembly) };
            xImage = new Image { Source = ImageSource.FromResource("Tic_tac_toe_fmimasters.images.x.png", assembly) };


            TapGestureRecognizer singleTap = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            singleTap.Tapped += SingleTap;

            GestureRecognizers.Add(singleTap);
        }

        private void SingleTap(object sender, EventArgs e)
        {
        }

        internal void reset()
        {
            Status = CellStatus.Closed;
        }

        public CellStatus Status
        {
            set
            {
                if (cellStatus != value)
                {
                    cellStatus = value;

                    switch (cellStatus)
                    {
                        case CellStatus.Closed:
                            Content = null;
                            break;

                        case CellStatus.X:
                            Content = xImage;
                            break;

                        case CellStatus.O:
                            Content = oImage;
                            break;
                    }

                    if (CellStatusChanged != null)
                        CellStatusChanged(this, cellStatus);
                }
            }

            get
            {
                return cellStatus;
            }

        }

    }
}
