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
    
    // The MainWindow is the first window to appear for the application

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // This button will load the login window for a One Player game
        private void Button_playerOneGame_Click(object sender, RoutedEventArgs e)
        {
            // Create and display one player login form
            Login loginForm = new Login(this);
            loginForm.Visibility = System.Windows.Visibility.Visible;
            // Hide welcome window
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        // This button will load the login window for a Two Player game
        private void Button_playerTwoGame_Click(object sender, RoutedEventArgs e)
        {
            // Create and display two player login form
           Login2 loginForm = new Login2(this);
            loginForm.Visibility = System.Windows.Visibility.Visible;
            // Hide welcome window
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        // This button is used to exit the application
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
