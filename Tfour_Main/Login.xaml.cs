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
    
    // This Login window is used for a One Player game VS an AI
    public partial class Login : Window
    {
        // Sishir's Server
        // DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);
        // Gabriel's Server
        private DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.TfourConnectionString1);
        private Window prevWindow;

        private string playerOneUserID;
        private string playerTwoUserID;

        private Boolean playerOneValid;



        // This function initializes the initial display of the window
        public Login(Window window)
        {
            InitializeComponent();
            prevWindow = window;
            Label_LoggedInAs_Player1.Visibility = Visibility.Hidden;
            Label_PLAYER1_LOGUSER.Visibility = Visibility.Hidden;

            button_Profile.Visibility = Visibility.Hidden;

            playerOneValid = false;

        }

        // This button retrieves the username and password in the textbox and verifies the information is correct in the database
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
                    else
                    {

                        playerOneUserID = Textbox_Username.Text;
                        playerTwoUserID = "Computer";

                        Label_PLAYER1_LOGUSER.Content = playerOneUserID;
                        Label_PLAYER1_LOGUSER.Visibility = Visibility.Visible;
                        Label_LoggedInAs_Player1.Visibility = Visibility.Visible;
                        button_Profile.Visibility = Visibility.Visible;

                        playerOneUserID = Textbox_Username.Text;
                        playerTwoUserID = "Computer";

                        playerOneValid = true;

                        Button_playerOneLogin.IsEnabled = false;
                        Button_GuestLogin.IsEnabled = false;
                        Button_Register.IsEnabled = false;
                        Button_Register.Visibility = Visibility.Hidden;
                        Button_Forgot.IsEnabled = false;
                        Button_Forgot.Visibility = Visibility.Hidden;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error ocurred, please try again.");
                    Console.WriteLine(ex);
                }

            }
        }

        // This button is used to open the Forgot Credentials window
        private void Button_Forgot_Click(object sender, RoutedEventArgs e)
        {
            ForgotCredentials forgot = new ForgotCredentials(this);
            forgot.Show();
        }

        // This button is used to open the Register window
        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register(this);
            register.Show();
        }
        
        
        // This button checks if player has logged in with a registered user or if it is a guest.
        // If a player is logged in as a guest or registered user then open the Game options window.  
        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {

            if (playerOneValid)
            {

                // GameOptions window is opened with 4 arguments
                // 1. current window, 2. Player Ones ID, 3. Player Twos ID, 4. 1 for One player game / 2 for Two players
                GameOptions go = new GameOptions (this, playerOneUserID, playerTwoUserID, 1);
                this.Hide();
                go.Show();
            }
            else
            {
                MessageBox.Show("Please provide valid Player One credentials.");
            }

        }

        // Button to return to previous window ( The Main Window )
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            prevWindow.Show();
        }

        // Button to exit the application
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

      
        // Button for a player to sign in as a guest
        private void Button_GuestLogin_Click(object sender, RoutedEventArgs e)
        {
            playerOneUserID = "Guest";


            Label_PLAYER1_LOGUSER.Content = playerOneUserID;
            Label_PLAYER1_LOGUSER.Visibility = Visibility.Visible;
            Label_LoggedInAs_Player1.Visibility = Visibility.Visible;
            button_Profile.Visibility = Visibility.Hidden;

            playerTwoUserID = "Computer";

            playerOneValid = true;

            Button_playerOneLogin.IsEnabled = false;
            Button_GuestLogin.IsEnabled = false;
            Button_Register.IsEnabled = false;
            Button_Register.Visibility = Visibility.Hidden;
            Button_Forgot.IsEnabled = false;
            Button_Forgot.Visibility = Visibility.Hidden;
        }

        // Button to open the Profile window
        private void button_Profile_Click(object sender, RoutedEventArgs e)
        {
            // Profile is open with two arguments
            // 1. current window, 2. Player One user ID
            Profile profile = new Profile(this, playerOneUserID);
            profile.Show();
            this.Hide();
        }
    }
}
