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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        // Fields
        private int gameCounter;

        private Player[] gamePlayers;

        private Board gameBoard;

        private Boolean isGameOver;

        private String gameLevel;

        private Boolean isPlayerOneGame;

       // private  DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);

       

        public Game(int playMode, String player1,  Boolean player1turn, String player2, Boolean player2turn, String gLevel )
        {

            InitializeComponent();
           
            gameCounter = 36;
            gamePlayers = new Player[2];
            gameBoard = new Board();
            gameLevel = gLevel;

         if(playMode == 1)
            {
                isPlayerOneGame = true;
          
                gamePlayers[0] = new Player (player1, player1turn);

                gamePlayers[1] = new ComputerPlayer(player2, player2turn, gameBoard, gameLevel);

            }
         else if (playMode == 2)
            {

                isPlayerOneGame = false;
           

                gamePlayers[0] = new Player (player1, player1turn);
                gamePlayers[1] = new Player (player2, player2turn);
            }


        }


        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            int row = (int)btn.GetValue(Grid.RowProperty);
            int col = (int)btn.GetValue(Grid.ColumnProperty);

           
        }

       
    }
}
