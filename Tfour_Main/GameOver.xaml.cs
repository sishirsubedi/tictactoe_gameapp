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
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {

        private Window prevWindow;
        private string playerOneId;

        public GameOver(Window gameWindow, string gwinner, string p1id)
        {
            InitializeComponent();

            Label_WinnerName.Content = gwinner;
            prevWindow = gameWindow;
            playerOneId = p1id;

        }

        private void button_Replay_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            
            prevWindow.Visibility = Visibility.Visible;
        }

        private void button_Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_Home_Click(object sender, RoutedEventArgs e)
        {
            prevWindow.Hide();
            MainWindow newwindow = new MainWindow();
            newwindow.Show();
            this.Hide();
        }

        private void button_profile_Click(object sender, RoutedEventArgs e)
        {
            prevWindow.Hide();

            MainWindow newwindow = new MainWindow();

            Profile profile = new Profile(newwindow, playerOneId);
            profile.Show();
            this.Hide();
        }
    }
}
