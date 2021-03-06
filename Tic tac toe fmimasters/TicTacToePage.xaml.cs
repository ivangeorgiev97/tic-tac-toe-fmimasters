using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_tac_toe_fmimasters.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tic_tac_toe_fmimasters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToePage : ContentPage
    {
        Player playerOne;
        Player playerTwo;
        bool isInProgress;

        public TicTacToePage(string player1Name, string player2Name)
        {
            InitializeComponent();

            playerOne = new Player(player1Name);
            playerTwo = new Player(player2Name);

            WhoPlays.Text = $"{player1Name} с X е на ход";

            board.TicTacToeStarted += Board_GameStarted;
            board.TicTacToeEnded += Board_GameEnded;
            board.IsPlayerTwoStatusChanged += Board_IsPlayerTwoStatusChanged;

            board.StartNewGame();
        }

        private void Board_GameEnded(object sender, string e)
        {
            WhoPlays.Text = String.Empty;
            isInProgress = false;

            switch (e)
            {
                case "one":
                    GameStatus.Text = $"{playerOne.Name} с X е Победител";
                    break;
                case "two":
                    GameStatus.Text = $"{playerTwo.Name} с O е Победител";
                    break;
                case "draw":
                    GameStatus.Text = "Равен резултат";
                    break;
            }
        }

        private void Board_GameStarted(object sender, EventArgs e)
        {
            isInProgress = true;
        }


        private void Board_IsPlayerTwoStatusChanged(object sender, EventArgs e)
        {
            WhoPlays.Text = Board.IsPlayerTwo ? $"{playerTwo.Name} с O е на ход" : $"{playerOne.Name} с X е на ход";
        }

        private void ContentView_SizeChanged(object sender, EventArgs e)
        {
            ContentView cv = (ContentView)sender;
            double width = cv.Width;
            double height = cv.Height;

            bool isLandscape = width > height;

            if (isLandscape)
            {
                uiGrid.RowDefinitions[0].Height = 0;
                uiGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);

                uiGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                uiGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                uiGrid.RowDefinitions[0].Height = new GridLength(3, GridUnitType.Star);
                uiGrid.RowDefinitions[1].Height = new GridLength(7, GridUnitType.Star);

                uiGrid.ColumnDefinitions[0].Width = 0;
                uiGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            }

        }

        private void ContentViewGame_SizeChanged(object sender, EventArgs e)
        {
        }

        private void ResetGame_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
            // board.StartNewGame();
        }
    }
}