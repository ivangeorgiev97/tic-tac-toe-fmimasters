using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_tac_toe_fmimasters.Model;
using Xamarin.Forms;

namespace Tic_tac_toe_fmimasters
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            string playerOneName = PlayerOneEntry.Text;
            string playerTwoName = PlayerTwoEntry.Text;

            if (playerOneName.Equals(playerTwoName))
            {
                playerOneName += " 1";
                playerTwoName += " 2";
            }

            if (playerOneName != null && playerOneName != "" && playerTwoName != null && playerTwoName != "")
            {
                Navigation.PushAsync(new TicTacToePage(playerOneName, playerTwoName));
            }
            else
            {
                DisplayAlert("Моля въведете име на играчите", "Моля въведете име на играчите", "Добре");
            }
        }
    }
}
