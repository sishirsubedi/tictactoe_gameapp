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
        //private Board board;

        public Game()
        {
            InitializeComponent();
        }
    }
}
