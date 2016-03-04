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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tfour_Main
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {


        DatabaseDataContext db = new DatabaseDataContext(
          Properties.Settings.Default.TfourConnectionString);


        public Register()
        {
            InitializeComponent();
            Label_usernameTaken.Visibility = Visibility.Hidden;
        }

        private void Textbox_userID_TextChanged(object sender, RoutedEventArgs e)
        {
            var query = from p in db.PlayerInformations
                        where (p.UserID.Equals(TextBox_userID.Text))
                        select p;
            if (query.Any())
            {
                Label_usernameTaken.Visibility = Visibility.Visible;
            }
            else
            {
                Label_usernameTaken.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_Name.Text)
                || string.IsNullOrWhiteSpace(TextBox_userID.Text)
                || string.IsNullOrWhiteSpace(TextBox_password.Text)
                || string.IsNullOrWhiteSpace(TextBox_email.Text))
            {
                MessageBox.Show("You are missing required fields, please complete the registration form.");
            }
            else
            {
                try
                {

                    var query = from p in db.PlayerInformations
                                where (p.UserID.Equals(TextBox_userID.Text))
                                select p;


                    if (query.Any())
                    {
                        MessageBox.Show("The username you entered is already taken. Please choose a different one and try again.");
                    }
                    else
                    {
                        PlayerInformation newplayer = new PlayerInformation();
                        newplayer.Name = TextBox_Name.Text;
                        newplayer.UserID = TextBox_userID.Text;
                        newplayer.Password = TextBox_password.Text;
                        newplayer.Email = TextBox_email.Text;

                        db.PlayerInformations.InsertOnSubmit(newplayer);
                        db.SubmitChanges();

                        Login loginForm = new Login();
                        loginForm.Visibility = System.Windows.Visibility.Visible;
                        this.Visibility = System.Windows.Visibility.Hidden;
                    }
                }
                catch
                {
                    MessageBox.Show("Registration error.Please Try Again  !");
                }
            }
        }
    }
}
