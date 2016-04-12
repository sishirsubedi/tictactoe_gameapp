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
        private BitmapImage playerOneGameStone;
        private Boolean playerOneTurn;

        private string playerTwoUserID;
        private BitmapImage playerTwoGameStone;
        private Boolean playerTwoTurn;

        private string gameLevel;
        private Boolean player1ChoseStone;
        
        private int playMode;

        string dir = System.IO.Directory.GetCurrentDirectory();
        

        public GameOptions(string p1, string p2, int mode)
        {
            InitializeComponent();
            playerOneUserID = p1;
            playerTwoUserID = p2;
            playMode = mode;
            player1ChoseStone = false;

            msg_PlayerTwoSelectStone.Visibility = Visibility.Hidden;
            Grid_AILevel.Visibility = Visibility.Hidden;

            if(mode == 1)
            {
                Grid_AILevel.Visibility = Visibility.Visible;
                label_GameStone_PlayerTwo.Content = "Computer Stone";
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\CompStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
                radioButton_PlayerTwo.Content = "Computer";

            }

            playerOneTurn = false;

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

        private void Orange_Click(object sender, RoutedEventArgs e)
        {
            Orange.Visibility = Visibility.Hidden;

            if (player1ChoseStone == false)
            {
                
                playerOneGameStone = new BitmapImage(new Uri(dir + @"\OrangeStone.png"));
                player1SelectedSTONE.Source = playerOneGameStone;
                player1ChoseStone = true;
                msg_PlayerOneSelectFirst.Visibility = Visibility.Hidden;
                

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\OrangeStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
            }
        }

        private void btn_Red_Click(object sender, RoutedEventArgs e)
        {
            Red.Visibility = Visibility.Hidden;

            if (player1ChoseStone == false)
            {

                playerOneGameStone = new BitmapImage(new Uri(dir + @"\RedStone.png"));
                player1SelectedSTONE.Source = playerOneGameStone;
                player1ChoseStone = true;
                msg_PlayerOneSelectFirst.Visibility = Visibility.Hidden;
                

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\RedStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
            }
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            Green.Visibility = Visibility.Hidden;

            if (player1ChoseStone == false)
            {

                playerOneGameStone = new BitmapImage(new Uri(dir + @"\GreenStone.png"));
                player1SelectedSTONE.Source = playerOneGameStone;
                player1ChoseStone = true;
                msg_PlayerOneSelectFirst.Visibility = Visibility.Hidden;
                

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\GreenStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
            }
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            Blue.Visibility = Visibility.Hidden;
            if (player1ChoseStone == false)
            {

                playerOneGameStone = new BitmapImage(new Uri(dir + @"\BlueStone.png"));
                player1SelectedSTONE.Source = playerOneGameStone;
                player1ChoseStone = true;
                msg_PlayerOneSelectFirst.Visibility = Visibility.Hidden;

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\BlueStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
            }
        }

        private void Purple_Click(object sender, RoutedEventArgs e)
        {
            Purple.Visibility = Visibility.Hidden;
            if (player1ChoseStone == false)
            {

                playerOneGameStone = new BitmapImage(new Uri(dir + @"\PurpleStone.png"));
                player1SelectedSTONE.Source = playerOneGameStone;
                player1ChoseStone = true;
                msg_PlayerOneSelectFirst.Visibility = Visibility.Hidden;

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\PurpleStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
            }
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            Yellow.Visibility = Visibility.Hidden;
            if (player1ChoseStone == false)
            {

                playerOneGameStone = new BitmapImage(new Uri(dir + @"\YellowStone.png"));
                player1SelectedSTONE.Source = playerOneGameStone;
                player1ChoseStone = true;
                msg_PlayerOneSelectFirst.Visibility = Visibility.Hidden;
                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
                
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\YellowStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
            }
        }
    }
}
