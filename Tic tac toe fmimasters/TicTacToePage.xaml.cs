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

            board.TicTacToeStarted += Board_GameStarted;
            board.TicTacToeEnded += Board_GameEnded;

            board.StartNewGame();
        }

        private void Board_GameEnded(object sender, bool e)
        {
            isInProgress = false;
        }

        private void Board_GameStarted(object sender, EventArgs e)
        {
            isInProgress = true;
        }
    }
}