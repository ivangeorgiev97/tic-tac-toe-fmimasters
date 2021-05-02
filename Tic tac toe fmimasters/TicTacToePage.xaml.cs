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

        public TicTacToePage(string player1Name, string player2Name)
        {
            InitializeComponent();
            playerOne = new Player(player1Name);
            playerTwo = new Player(player2Name);
        }
    }
}