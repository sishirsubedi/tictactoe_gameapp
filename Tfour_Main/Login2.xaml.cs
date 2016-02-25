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
        DatabaseDataContext db = new DatabaseDataContext(
          Properties.Settings.Default.Tfour_ConnectionString);

        public Login2()
        {
            InitializeComponent();
            Grid_gameOptions.Visibility = System.Windows.Visibility.Hidden;
            Button_View_Profile2.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
        }

      

        private void Button_Game_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_PayerOneLogin(object sender, RoutedEventArgs e)
        {

            var query = from u in db.PlayerInformations
                        where (u.UserID.Equals(Textbox_Username.Text) &&
                        u.Password.Equals(Textbox_Password.Text))
                        select u;
            if (query.Count() != 0)
            {

                MessageBox.Show(" Login 1 Success. Please try Login 2 !");
            }
            else
            {
                MessageBox.Show(" Credentials are Incorrect. Please Try Again !");
            }

        }

        private void Button_Click_PayerTwoLogin(object sender, RoutedEventArgs e)
        {

            var query = from u in db.PlayerInformations
                        where (u.UserID.Equals(Textbox_Username.Text) &&
                        u.Password.Equals(Textbox_Password.Text))
                        select u;
            if (query.Count() != 0)
            {

                Button_View_Profile2.Visibility = System.Windows.Visibility.Visible;
                Grid_gameOptions.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show(" Credentials are Incorrect. Please Try Again !");
            }

            
            Button_View_Profile2.Visibility = System.Windows.Visibility.Visible;
            Grid_gameOptions.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_ForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgetPassword forgetpassword = new ForgetPassword();
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
            Profile2 profile = new Profile2();
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
