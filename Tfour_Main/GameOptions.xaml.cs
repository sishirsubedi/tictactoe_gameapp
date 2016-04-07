using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tfour_Main
{
    /// <summary>
    /// Interaction logic for GameOptions.xaml
    /// </summary>
    public partial class GameOptions : Window
    {
        private string playerOneUserID;
        private string playerOneGameStone;
        private Boolean playerOneTurn;

        private string playerTwoUserID;
        private string playerTwoGameStone;
        private Boolean playerTwoTurn;

        private string gameLevel;
        
        private int playMode;

        public GameOptions(string p1, string p2, int mode)
        {
            InitializeComponent();
            playerOneUserID = p1;
            playerTwoUserID = p2;
            playMode = mode;

            if(mode == 1)
            {
                Grid_AILevel.Visibility = Visibility.Visible;
            }

            playerOneTurn = true;

            playerTwoTurn = false;
  
            gameLevel = "";
        }



        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            
            Game newgame = new Game(playMode, playerOneUserID, playerOneTurn, playerOneGameStone, playerTwoUserID, playerTwoTurn, playerTwoGameStone, gameLevel);
            newgame.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;

        
            
        }

        private void First_PlayerOne(object sender, RoutedEventArgs e)
        {
            playerOneTurn = true;

            playerTwoTurn = false;
        }

        private void First_PlayerTwo(object sender, RoutedEventArgs e)
        {
            playerOneTurn = false;

            playerTwoTurn = true;
        }

        private void GameLevel_Easy(object sender, RoutedEventArgs e)
        {
            gameLevel = "Easy";
        }

        private void GameLevel_Medium(object sender, RoutedEventArgs e)
        {
            gameLevel = "Medium";
        }

        private void GameLevel_Hard(object sender, RoutedEventArgs e)
        {
            gameLevel = "Hard";
        }
    }
}
