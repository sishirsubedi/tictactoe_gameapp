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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        // Sishir's Server
        // DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);
        // Gabriel's Server
        private DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.TfourConnectionString);
        private Window prevWindow;

        public Login(Window window)
        {
            InitializeComponent();
            prevWindow = window;
        }

        private void Button_playerOneLogin_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Textbox_Username.Text))
            {
                MessageBox.Show("The username field is empty. You must provide a valid username to log in.");
            }
            else if (string.IsNullOrWhiteSpace(PasswordBox_LoginOne.Password))
            {
                MessageBox.Show("The password field is empty. You must provide a password to log in.");
            }
            else
            {
                try
                {

                    var query = from s in db.PlayerInformations
                                where (s.UserID.Equals(Textbox_Username.Text) &&
                                s.Password.Equals(PasswordBox_LoginOne.Password))
                                select s;

                    if (!query.Any())
                    {
                        MessageBox.Show("Invalid username or password. Please Try Again!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error ocurred, please try again.");
                    Console.WriteLine(ex);
                }

            }
        }

        private void Button_Forgot_Click(object sender, RoutedEventArgs e)
        {
            ForgotCredentials forgot = new ForgotCredentials(this);
            forgot.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Button_View_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(Textbox_Username.Text);
            profile.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            Game newGame = new Game();
            newGame.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
