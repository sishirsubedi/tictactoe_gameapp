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
    /// Interaction logic for Profile2.xaml
    /// </summary>
    public partial class Profile2 : Window
    {
        DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.TfourConnectionString);

        String userID, userID2;

        public Profile2( String id1, string id2)
        {
            InitializeComponent();
            userID = id1;
            userID2 = id2;
            displayPlayerInformation(userID, userID2);
        }

        private void displayPlayerInformation(String id1, String id2)
        {
            var query = from s in db.PlayerInformations
                        where (s.UserID.Equals(id1) || s.UserID.Equals( id2) )
                        select s;

            DataGrid_ProfileInformation2.ItemsSource = query.ToList();

        }

        private void Button_Profile_Back_Click(object sender, RoutedEventArgs e)
        {
            Login2 loginForm = new Login2(this);
            loginForm.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
