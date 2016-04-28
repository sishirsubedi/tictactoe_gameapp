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
    /// test github
    public partial class Login2 : Window
    {
        private DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);
        private Window prevWindow;

        private string playerOneUserID;
        private string playerTwoUserID;

        private Boolean playerOneValid;
        private Boolean playerTwoValid;

        public Login2(Window window)
        {
            InitializeComponent();
            prevWindow = window;
            Button_playerTwoLogin.IsEnabled = false;
            Button_GuestPlayer2Login.IsEnabled = false;
            Label_LoggedInAs_Player1.Visibility = System.Windows.Visibility.Hidden;
            Label_LoggedInAs_Player2.Visibility = System.Windows.Visibility.Hidden;
            Label_PLAYER1_LOGUSER.Visibility = System.Windows.Visibility.Hidden;
            Label_PLAYER2_LOGUSER.Visibility = System.Windows.Visibility.Hidden;


            playerOneValid = false;
            playerTwoValid = false;

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
                        Button_GuestPlayer2Login.IsEnabled = true;


                        Button_playerOneLogin.IsEnabled = false;
                        Button_GuestPlayer1Login.IsEnabled = false;


                        Button_ViewProfilePlayer1.Visibility = Visibility.Visible;

                        playerOneUserID = Textbox_Username.Text;
                        playerOneValid = true;
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

                        playerTwoUserID = Textbox_Username2.Text;
                        playerTwoValid = true;


                        Button_playerTwoLogin.IsEnabled = false;
                        Button_GuestPlayer2Login.IsEnabled = false;

                        Button_ViewProfilePlayer2.Visibility = Visibility.Visible;
                        Button_Register.IsEnabled = false;
                        Button_Register.Visibility = Visibility.Hidden;
                        Button_ForgetPassword.IsEnabled = false;
                        Button_ForgetPassword.Visibility = Visibility.Hidden;


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
            Register register = new Register(this);
            register.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_View_Profile_Click(object sender, RoutedEventArgs e)
        {
            /*
            Profile profile = new Profile(Textbox_Username.Text, Textbox_Username2.Text);
            profile.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
            */
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {

            if (playerOneValid && playerTwoValid)
            {

                GameOptions go = new GameOptions(this, playerOneUserID, playerTwoUserID, 2);
                this.Hide();
                go.Show();
            }

            else
            {
                MessageBox.Show("Please provide valid Player One credentials.");
            }
        }



        private void Button_GuestPlayer2Login_Click(object sender, RoutedEventArgs e)
        {
            Label_PLAYER2_LOGUSER.Content = "Guest2";
            Label_LoggedInAs_Player2.Visibility = System.Windows.Visibility.Visible;
            Label_PLAYER2_LOGUSER.Visibility = System.Windows.Visibility.Visible;

            Button_playerTwoLogin.IsEnabled = false;
            Button_GuestPlayer2Login.IsEnabled = false;


            Button_ViewProfilePlayer2.Visibility = Visibility.Hidden;

            Button_Register.IsEnabled = false;
            Button_Register.Visibility = Visibility.Hidden;
            Button_ForgetPassword.IsEnabled = false;
            Button_ForgetPassword.Visibility = Visibility.Hidden;

            playerTwoUserID = "Guest2";
            playerTwoValid = true;
        }

        private void Button_GuestPlayer1Login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Login 1 as Guest. Please try Login 2 !");
            Label_PLAYER1_LOGUSER.Content = "Guest1";
            Label_LoggedInAs_Player1.Visibility = System.Windows.Visibility.Visible;
            Label_PLAYER1_LOGUSER.Visibility = System.Windows.Visibility.Visible;
            Button_playerTwoLogin.IsEnabled = true;

            playerOneUserID = "Guest1";
            playerOneValid = true;


            Button_playerOneLogin.IsEnabled = false;
            Button_GuestPlayer1Login.IsEnabled = false;


            Button_playerTwoLogin.IsEnabled = true;
            Button_GuestPlayer2Login.IsEnabled = true;

            Button_ViewProfilePlayer1.Visibility = Visibility.Hidden;



        }

        private void Button_ViewProfilePlayer1_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(this, playerOneUserID);
            profile.Show();
            this.Hide();
        }

        private void Button_ViewProfilePlayer2_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(this, playerTwoUserID);
            profile.Show();
            this.Hide();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            prevWindow.Show();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    
}
