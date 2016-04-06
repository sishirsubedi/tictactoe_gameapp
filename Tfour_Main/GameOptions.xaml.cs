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
        private string playerOneUserID;
        private Boolean playerOneTurn;

        private string playerTwoUserID;
        private Boolean playerTwoTurn;

        private string gameLevel;
        
        private int playMode;

        public GameOptions(string p1, string p2, int mode)
        {
            InitializeComponent();
            playerOneUserID = p1;
            playerTwoUserID = p2;
            playMode = mode;

            // this is for temp...need to complete game options 
            playerOneTurn = true;

            playerTwoTurn = false;

            gameLevel = "Easy";
        }



        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            //playMode,playerOneUserID,playerOneTurn,playerTwoUserID,playerTwoTurn,gameLevel);
            Game newgame = new Game(playMode, playerOneUserID, playerOneTurn, playerTwoUserID, playerTwoTurn, gameLevel);
            newgame.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;

        
            
        }
    }
}
