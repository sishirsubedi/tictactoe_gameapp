﻿using System;
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

        private Window prevWindow;

        private string playerOneUserID;
        private BitmapImage playerOneGameStone;
        private Boolean playerOneTurn;

        private string playerTwoUserID;
        private BitmapImage playerTwoGameStone;
        private Boolean playerTwoTurn;

        private string gameLevel;
        private Boolean player1ChoseStone;

        private Boolean player2ChoseStone;
        private Boolean whosFirstSelected;
        private Boolean AISelected;
        
        private int playMode;

        string dir = System.IO.Directory.GetCurrentDirectory();
        

        public GameOptions(Window pwindow, string p1, string p2, int mode)
        {
            InitializeComponent();

            prevWindow = pwindow;
            playerOneUserID = p1;
            playerTwoUserID = p2;
            playMode = mode;
            player1ChoseStone = false;
            player2ChoseStone = false;
            whosFirstSelected = false;
            AISelected = false;

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

            if (playMode == 1 && player1ChoseStone && whosFirstSelected && AISelected || playMode == 2 && player2ChoseStone && whosFirstSelected)
            {
                Game newgame = new Game(playMode, playerOneUserID, playerOneTurn, playerOneGameStone, playerTwoUserID, playerTwoTurn, playerTwoGameStone, gameLevel);
                newgame.Visibility = System.Windows.Visibility.Visible;
                this.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Please complete all selections!");
            }

        
            
        }

        private void First_PlayerOne(object sender, RoutedEventArgs e)
        {
            playerOneTurn = true;

            playerTwoTurn = false;

            whosFirstSelected = true;
        }

        private void First_PlayerTwo(object sender, RoutedEventArgs e)
        {
            playerOneTurn = false;

            playerTwoTurn = true;

            whosFirstSelected = true;
        }

        private void GameLevel_Easy(object sender, RoutedEventArgs e)
        {
            gameLevel = "Easy";

            AISelected = true;
        }

        private void GameLevel_Medium(object sender, RoutedEventArgs e)
        {
            gameLevel = "Medium";

            AISelected = true;
        }

        private void GameLevel_Hard(object sender, RoutedEventArgs e)
        {
            gameLevel = "Hard";

            AISelected = true;
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

                if(playMode == 1)
                {
                    Grid_StoneSelection.IsEnabled = false;
                    Grid_StoneSelection.Visibility = Visibility.Hidden;
                }
                
                

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\OrangeStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
                Grid_StoneSelection.IsEnabled = false;
                Grid_StoneSelection.Visibility = Visibility.Hidden;
                player2ChoseStone = true;
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

                if (playMode == 1)
                {
                    Grid_StoneSelection.IsEnabled = false;
                    Grid_StoneSelection.Visibility = Visibility.Hidden;
                }

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\RedStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
                Grid_StoneSelection.IsEnabled = false;
                Grid_StoneSelection.Visibility = Visibility.Hidden;
                player2ChoseStone = true;
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

                if (playMode == 1)
                {
                    Grid_StoneSelection.IsEnabled = false;
                    Grid_StoneSelection.Visibility = Visibility.Hidden;
                }

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\GreenStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
                Grid_StoneSelection.IsEnabled = false;
                Grid_StoneSelection.Visibility = Visibility.Hidden;
                player2ChoseStone = true;
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

                if (playMode == 1)
                {
                    Grid_StoneSelection.IsEnabled = false;
                    Grid_StoneSelection.Visibility = Visibility.Hidden;
                }

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\BlueStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
                Grid_StoneSelection.IsEnabled = false;
                Grid_StoneSelection.Visibility = Visibility.Hidden;
                player2ChoseStone = true;
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
                if (playMode == 1)
                {
                    Grid_StoneSelection.IsEnabled = false;
                }

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\PurpleStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
                Grid_StoneSelection.IsEnabled = false;
                Grid_StoneSelection.Visibility = Visibility.Hidden;
                player2ChoseStone = true;
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

                if (playMode == 1)
                {
                    Grid_StoneSelection.IsEnabled = false;
                    Grid_StoneSelection.Visibility = Visibility.Hidden;
                    
                }

                if (playMode != 1)
                {
                    msg_PlayerTwoSelectStone.Visibility = Visibility.Visible;
                }
                
            }
            else
            {
                playerTwoGameStone = new BitmapImage(new Uri(dir + @"\YellowStone.png"));
                player2SelectedSTONE.Source = playerTwoGameStone;
                Grid_StoneSelection.IsEnabled = false;
                Grid_StoneSelection.Visibility = Visibility.Hidden;
                player2ChoseStone = true;
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            prevWindow.Show();
            this.Close();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
