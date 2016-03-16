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
        private int turnsRemaining;
        private PlayerInformation p1, p2;
        // We can use a reference to keep track of who's turn it is
        private PlayerInformation activePlayer;
        private const int ROWS = 6, COLS = 6;
        private int[,] board;
        BitmapImage p1Token, p2Token; 
         
        public Game()
        {
            InitializeComponent();
            Loaded += Game_Loaded;

            turnsRemaining = 36;

            board = new int[ROWS, COLS];

            p1Token = new BitmapImage();
            p1Token.BeginInit();
            p1Token.UriSource = new Uri(".\\GreenStone.png");
            p1Token.EndInit();

            p2Token = new BitmapImage();
            p2Token.BeginInit();
            p2Token.UriSource = new Uri(".\\YellowStone.png");
            p2Token.EndInit();

        }

        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            GameOptions go = new GameOptions();
            go.Show();
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            int row = (int)btn.GetValue(Grid.RowProperty);
            int col = (int)btn.GetValue(Grid.ColumnProperty);

            NextTurn();
        }

        private void NextTurn()
        {
            if (activePlayer == p1)
                activePlayer = p2;
            else
                activePlayer = p1;

            turnsRemaining--;

            if (turnsRemaining == 0)
            {
                MessageBox.Show("Game Over");
                ClearBoard();
            }
        }

        private void ClearBoard()
        {
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    
                }
            }
        }
    }
}
