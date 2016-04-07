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

        private string playerOneGameStone;

        private string playerTwoGameStone;

        // private  DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);



        public Game(int playMode, String player1,  Boolean player1turn, string p1gstone, String player2, Boolean player2turn, string p2gstone, String gLevel )
        {

            InitializeComponent();
           
            gameCounter = 36;
            gamePlayers = new Player[2];
            gameBoard = new Board();
            gameLevel = gLevel;

            playerOneGameStone = p1gstone;
            playerTwoGameStone = p2gstone;

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

            if (isPlayerOneGame)
            {
                // player one vs AI
                // player 1 will always be human player
                // player 2 will be AI

                     if (gamePlayers[0].getPlayerTurn())
                     {
                              // human player goes first
                            string image_string = playerOneGameStone;
                    btn.Content = 'x';

                    gameBoard.updateBoard(row, col, 1);


                    // update score board for player one

                    Label_PlayerOneScore.Content = gameBoard.getPlayerOneScore();
                            
                            gamePlayers[0].setPlayerTurn(false);
                             gamePlayers[1].setPlayerTurn(true);

                     }
                     else
                     {
                              // AI goes second 


                             string image_string = playerTwoGameStone;
                    btn.Content = 'o';


                    gameBoard.updateBoard(row, col, 2);

                            // update score board for player two

                             Label_PlayerTwoScore.Content = gameBoard.getPlayerTwoScore();

                             gamePlayers[1].setPlayerTurn(false);
                             gamePlayers[0].setPlayerTurn(true);
                      }


            }
            else
            {

                // two player game
                // player 1 will always be human player
                // player 2 will be SECOND polayer

                if (gamePlayers[0].getPlayerTurn())
                {
                    // human player goes first
                    string image_string = playerOneGameStone;
                    btn.Content = 'X';

                    gameBoard.updateBoard(row, col, 1);


                    // update score board for player one

                    Label_PlayerOneScore.Content = gameBoard.getPlayerOneScore();


                    gamePlayers[0].setPlayerTurn(false);
                    gamePlayers[1].setPlayerTurn(true);

                }
                else
                {
                    string image_string = playerTwoGameStone;
                    btn.Content = 'O';

                    gameBoard.updateBoard(row, col, 2);

                    // update score board for player two
                    Label_PlayerTwoScore.Content = gameBoard.getPlayerTwoScore();

                    gamePlayers[1].setPlayerTurn(false);
                    gamePlayers[0].setPlayerTurn(true);

                }





            }


        }

       
    }
}
