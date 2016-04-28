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
    
    // This Login2 window is used for a Two Player Game
    public partial class Login2 : Window
    {
        private DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);
        private Window prevWindow;

        private string playerOneUserID;
        private string playerTwoUserID;

        private Boolean playerOneValid;
        private Boolean playerTwoValid;

        //Sets the display for the window onload
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

        // Button for Player One to login using their username and password
        // The button checks for the username and password within the designated textboxes on the left and verifies it through the database
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

        // Button for Player Two to login using their username and password
        // The button checks for the username and password within the designated textboxes on the right and verifies it through the database
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

        // Button is used to open the Forgot Credentials window
        private void Button_ForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotCredentials forgetpassword = new ForgotCredentials(this);
            forgetpassword.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        // Button is used to open a Register window
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

        // Button is used to open the GameOptions window only after both Players has logged in as guest or as a registered user
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


        // Button is used to sign in Player Two as "Guest2"
        // Disables the buttons for Player Two to sign in as a registered user
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

        // Button is used to sign in Player One as "Guest1"
        // Disables the buttons for Player One to sign in as a registered user
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

        // Button is used to open the Profile window for Player One
        private void Button_ViewProfilePlayer1_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(this, playerOneUserID);
            profile.Show();
            this.Hide();
        }

        // Button to open the Profile window
        private void Button_ViewProfilePlayer2_Click(object sender, RoutedEventArgs e)
        {
            // Profile window is opened using Player Two username
            Profile profile = new Profile(this, playerTwoUserID);
            profile.Show();
            this.Hide();
        }

        // Button to return to previous window
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            prevWindow.Show();
        }

        // Button to close the application
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    
}
