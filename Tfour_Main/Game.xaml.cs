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

        private ComputerPlayer AI_mario;

        private Board gameBoard;

        private Boolean GameOver;

        private String gameLevel;

        private Boolean isPlayerOneGame;

        private BitmapImage playerOneGameStone;

        private BitmapImage  playerTwoGameStone;

        private string gameWinner;

        private string playerOneId;

        private string playerTwoId;

        private int gameMode;

        bool soundON;

      



        public Game(int playMode, String player1,  Boolean player1turn, BitmapImage p1gstone, String player2, Boolean player2turn, BitmapImage  p2gstone, String gLevel )
        {

            InitializeComponent();
            
            gameCounter = 36;
            gamePlayers = new Player[2];
            gameBoard = new Board();
            gameLevel = gLevel;
            GameOver = false;
            gameMode = playMode;
            playerOneGameStone = p1gstone;
            playerTwoGameStone = p2gstone;
            playerOneId = player1;
            playerTwoId = player2;
            Label_PlayerOneName.Content = player1;
            Label_PlayerTwoName.Content = player2;
            player2Image.Source = p2gstone;
            player1Image.Source = p1gstone;
            soundON = false;


         

            if (playMode == 1)
            {
                isPlayerOneGame = true;
          
                gamePlayers[0] = new Player (player1, player1turn);

                AI_mario=  new ComputerPlayer(player2, player2turn, gameBoard, gameLevel);

                gamePlayers[1] = AI_mario;

                if (player2turn)
                {
                   

                    Button_1x1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }

            }
            else if (playMode == 2)
            {

                isPlayerOneGame = false;
           

                gamePlayers[0] = new Player (player1, player1turn);
                gamePlayers[1] = new Player (player2, player2turn);
            }


        }

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            --gameCounter;

           

            if (isPlayerOneGame)
            {
                // player one vs AI
                // player 1 will always be human player
                // player 2 will be AI

                if (gamePlayers[0].getPlayerTurn())
                {
                    // human player goes first


                    int row = (int)btn.GetValue(Grid.RowProperty);
                    int col = (int)btn.GetValue(Grid.ColumnProperty);

                    ImageSource ImgSrc = playerOneGameStone;
                    ImageBrush imgBrush = new ImageBrush(ImgSrc);
                    btn.Background = imgBrush;
                   
                    btn.IsEnabled = false;


                    gameBoard.updateBoard(row, col, 1);


                    // update score board for player one

                    Label_PlayerOneScore.Content = gameBoard.getPlayerOneScore();
                    gamePlayers[0].setScore(gameBoard.getPlayerOneScore());

                    gamePlayers[0].setPlayerTurn(false);
                    gamePlayers[1].setPlayerTurn(true);

                    

                    if (gameCounter == 0)
                    {

                        if (gamePlayers[0].getScore() > gamePlayers[1].getScore())
                        {
                            gameWinner = gamePlayers[0].getPlayerID();
                            gamePlayers[0].setWinner(true);
                            gamePlayers[1].setWinner(false);
                        }
                        else if (gamePlayers[0].getScore() < gamePlayers[1].getScore())
                        {
                            gameWinner = gamePlayers[1].getPlayerID();
                            gamePlayers[0].setWinner(false);
                            gamePlayers[1].setWinner(true);
                        }
                        else
                        {
                            gameWinner = "Draw";

                            gamePlayers[0].setWinner(false);
                            gamePlayers[1].setWinner(false);
                        }


                        GameOver = true;
                        isGameOver();
                    }
                    else
                    {
                        btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }


                   
                }
                else
                {
                    // AI goes second 


                    AImove();

                }

            }
            else
            {

                // two player game
                // player 1 will always be human player
                // player 2 will be SECOND polayer


                int row = (int)btn.GetValue(Grid.RowProperty);
                int col = (int)btn.GetValue(Grid.ColumnProperty);

                if (gamePlayers[0].getPlayerTurn())
                {
                    // human player goes first
                    ImageSource ImgSrc = playerOneGameStone;
                    ImageBrush imgBrush = new ImageBrush(ImgSrc);
                    btn.Background = imgBrush;
                    btn.IsEnabled = false;

                    gameBoard.updateBoard(row, col, 1);


                    // update score board for player one

                    Label_PlayerOneScore.Content = gameBoard.getPlayerOneScore();
                    gamePlayers[0].setScore(gameBoard.getPlayerOneScore());


                    gamePlayers[0].setPlayerTurn(false);
                    gamePlayers[1].setPlayerTurn(true);

                    
                    if (gameCounter == 0)
                    {

                        if (gamePlayers[0].getScore() > gamePlayers[1].getScore())
                        {
                            gameWinner = gamePlayers[0].getPlayerID();
                            gamePlayers[0].setWinner(true);
                            gamePlayers[1].setWinner(false);
                        }
                        else if (gamePlayers[0].getScore() < gamePlayers[1].getScore())
                        {
                            gameWinner = gamePlayers[1].getPlayerID();
                            gamePlayers[0].setWinner(false);
                            gamePlayers[1].setWinner(true);
                        }
                        else
                        {
                            gameWinner = "Draw";

                            gamePlayers[0].setWinner(false);
                            gamePlayers[1].setWinner(false);
                        }


                        GameOver = true;
                        isGameOver();
                    }

                }
                else
                {
                    ImageSource ImgSrc = playerTwoGameStone;
                    ImageBrush imgBrush = new ImageBrush(ImgSrc);
                    btn.Background = imgBrush;
                    btn.IsEnabled = false;


                    gameBoard.updateBoard(row, col, 2);

                    // update score board for player two
                    Label_PlayerTwoScore.Content = gameBoard.getPlayerTwoScore();
                    gamePlayers[1].setScore(gameBoard.getPlayerTwoScore());

                    gamePlayers[1].setPlayerTurn(false);
                    gamePlayers[0].setPlayerTurn(true);

                    
                    if (gameCounter == 0)
                    {

                        if (gamePlayers[0].getScore() > gamePlayers[1].getScore())
                        {
                            gameWinner = gamePlayers[0].getPlayerID();
                            gamePlayers[0].setWinner(true);
                            gamePlayers[1].setWinner(false);
                        }
                        else if (gamePlayers[0].getScore() < gamePlayers[1].getScore())
                        {
                            gameWinner = gamePlayers[1].getPlayerID();
                            gamePlayers[0].setWinner(false);
                            gamePlayers[1].setWinner(true);
                        }
                        else
                        {
                            gameWinner = "Draw";

                            gamePlayers[0].setWinner(false);
                            gamePlayers[1].setWinner(false);
                        }


                        GameOver = true;
                        isGameOver();
                    }



                }





            }


        }

        private void isGameOver()
        {

           


            MainWindow newwindow = new MainWindow();

            GameOver gmover = new GameOver(newwindow,this, gameWinner, playerOneId, playerTwoId, gameMode);
            updateHistory();
            this.IsEnabled=false;
            gmover.Show();



            mediaPlayer.Stop();
            Button_Soundplay.Content = "OFF";
            soundON = false;



        }

        private void updateHistory()
        {

            DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);

            PlayerHistory newPH = new PlayerHistory();

            newPH.PlayerOne = gamePlayers[0].getPlayerID();
            newPH.PlayerOneScore = gamePlayers[0].getScore();
            newPH.Opponet = gamePlayers[1].getPlayerID();
            newPH.OpponetScore = gamePlayers[1].getScore();
            newPH.GameDate = DateTime.Now;

            if (gamePlayers[0].isWinner())
            {
                newPH.Winner = gamePlayers[0].getPlayerID();

            }
            else if (gamePlayers[1].isWinner())
            {
                newPH.Winner = gamePlayers[1].getPlayerID();
            }
            else
            {
                newPH.Winner = "Draw";
            }


            db.PlayerHistories.InsertOnSubmit(newPH);

            db.SubmitChanges();
        }
       


        private void AImove( )
        {

           

           int[] bestMove =  AI_mario.getAI().findMove();

            int AIcolumn = bestMove[0];
            int AIrow = bestMove[1];

           // MessageBox.Show("hello  : " + bestMove[0] + bestMove[1]);

            Button targetButton;

            int currentRow, currentCol;

            foreach (var btn in GameGrid.Children)
            {

                   targetButton = btn as Button;

               
                    currentRow = (int)targetButton.GetValue(Grid.RowProperty);
                    currentCol = (int)targetButton.GetValue(Grid.ColumnProperty);
                    //If the current row and column match the random coordinates.
                    //Write an O in the button and disable it.
                    if (currentRow == AIcolumn && currentCol == AIrow)
                    {
                        ImageSource ImgSrc = playerTwoGameStone;
                        ImageBrush imgBrush = new ImageBrush(ImgSrc);
                        targetButton.Background = imgBrush;
                        targetButton.IsEnabled = false;

                        gameBoard.updateBoard(currentRow, currentCol, 2);

                        // update score board for player two

                        Label_PlayerTwoScore.Content = gameBoard.getPlayerTwoScore();
                        gamePlayers[1].setScore(gameBoard.getPlayerTwoScore());

                        gamePlayers[1].setPlayerTurn(false);
                        gamePlayers[0].setPlayerTurn(true);

                    }
                
            }
                   

                       

                        if (gameCounter == 0)
                        {

                            if (gamePlayers[0].getScore() > gamePlayers[1].getScore())
                            {
                                gameWinner = gamePlayers[0].getPlayerID();
                                gamePlayers[0].setWinner(true);
                                gamePlayers[1].setWinner(false);
                            }
                            else if (gamePlayers[0].getScore() < gamePlayers[1].getScore())
                            {
                                gameWinner = gamePlayers[1].getPlayerID();
                                gamePlayers[0].setWinner(false);
                                gamePlayers[1].setWinner(true);
                            }
                            else
                            {
                                gameWinner = "Draw";

                                gamePlayers[0].setWinner(false);
                                gamePlayers[1].setWinner(false);
                            }


                            GameOver = true;
                            isGameOver();
                        }


            }



        private void image_click(object sender, MouseButtonEventArgs e)
        {

        

            MainWindow newwindow = new MainWindow();
            newwindow.Show();
           this.Hide();

            mediaPlayer.Stop();
            Button_Soundplay.Content = "OFF";
            soundON = false;
        }

      
        private void play_Click(object sender, RoutedEventArgs e)
        {

            if (!soundON)
            {

                mediaPlayer.Source = new Uri(@"C:\Users\ibm-lenovo\Desktop\GitHub\TicTacToe\Tfour_Main\mariotheme.mp3");
                Button_Soundplay.Content = "ON";
                mediaPlayer.Play();
                soundON = true;

            }
            else
            {
                mediaPlayer.Stop();
                Button_Soundplay.Content = "OFF";
                soundON = false;

            }
        }
    }
}
