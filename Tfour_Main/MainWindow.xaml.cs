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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tfour_Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_playerOneGame_Click(object sender, RoutedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_playerTwoGame_Click(object sender, RoutedEventArgs e)
        {
            Login2 loginForm = new Login2();
            loginForm.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
