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
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_Name.Text)
                || string.IsNullOrWhiteSpace(TextBox_userID.Text)
                || string.IsNullOrWhiteSpace(TextBox_password.Text)
                || string.IsNullOrWhiteSpace(TextBox_email.Text)

                )
            {
                MessageBox.Show("Please Complete the form.");
            }
            else
            {
                try
                {

                    var query = from s in db.PlayerInformations
                                where (s.UserID.Equals(TextBox_userID.Text))
                                select s;


                    if (query.Any())
                    {
                        MessageBox.Show("User ID is already taken. Please Try Again!");
                  
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
