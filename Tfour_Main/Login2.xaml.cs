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
    /// Interaction logic for Login2.xaml
    /// </summary>
    public partial class Login2 : Window
    {
        private DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.TfourConnectionString);
        private Window prevWindow;

        public Login2(Window window)
        {
            InitializeComponent();
            prevWindow = window;
            Button_playerTwoLogin.IsEnabled = false;
            Label_LoggedInAs_Player1.Visibility = System.Windows.Visibility.Hidden;
            Label_LoggedInAs_Player2.Visibility = System.Windows.Visibility.Hidden;
            Label_PLAYER1_LOGUSER.Visibility = System.Windows.Visibility.Hidden;
            Label_PLAYER2_LOGUSER.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Game_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_PayerOneLogin(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Textbox_Username.Text) || string.IsNullOrWhiteSpace(PasswordBox_LoginOne.Password))
            {
                MessageBox.Show("TextBox is empty");
            }
            else
            {
                try
                {

                    var query = from s in db.PlayerInformations
                                where (s.UserID.Equals(Textbox_Username.Text) &&
                                s.Password.Equals(PasswordBox_LoginOne.Password))
                                select s;


                    if (query.Any())
                    {
                        MessageBox.Show(" Login 1 Success. Please try Login 2 !");
                        Label_PLAYER1_LOGUSER.Content = Textbox_Username.Text;
                        Label_LoggedInAs_Player1.Visibility = System.Windows.Visibility.Visible;
                        Label_PLAYER1_LOGUSER.Visibility = System.Windows.Visibility.Visible;
                        Button_playerTwoLogin.IsEnabled = true;

                    }
                    else
                    {
                        MessageBox.Show("Credential is Incorrect. Please Try Again !");
                    }
                }
                catch
                {
                    MessageBox.Show("Credential is Incorrect.Please Try Again  !");
                }

            }
        }

        private void Button_Click_PayerTwoLogin(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Textbox_Username2.Text) || string.IsNullOrWhiteSpace(PasswordBox_LoginTwo.Password))
            {
                MessageBox.Show("TextBox is empty");
            }
            else
            {
                try
                {

                    var query = from s in db.PlayerInformations
                                where (s.UserID.Equals(Textbox_Username2.Text) &&
                                s.Password.Equals(PasswordBox_LoginTwo.Password))
                                select s;


                    if (query.Any())
                    {
                        Label_PLAYER2_LOGUSER.Content = Textbox_Username2.Text;
                        Label_LoggedInAs_Player2.Visibility = System.Windows.Visibility.Visible;
                        Label_PLAYER2_LOGUSER.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Credential is Incorrect. Please Try Again !");
                    }
                }
                catch
                {
                    MessageBox.Show("Credential is Incorrect.Please Try Again  !");
                }

            }
        }

        private void Button_ForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotCredentials forgetpassword = new ForgotCredentials(this);
            forgetpassword.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_View_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile2 profile = new Profile2(Textbox_Username.Text, Textbox_Username2.Text);
            profile.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            Game newGame = new Game();
            newGame.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
