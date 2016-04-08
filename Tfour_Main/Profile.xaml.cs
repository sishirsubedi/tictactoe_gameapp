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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {

        DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);

        String userID;
        private Window prevWindow;

        public Profile(Window window, String id)
        {
            InitializeComponent();
            userID = id;
            prevWindow = window;


        }




 

        private void Button_Profile_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            prevWindow.Visibility = Visibility.Visible;
        }

        private void button_ProfileInformation_Click(object sender, RoutedEventArgs e)
        {
            var query = from s in db.PlayerInformations
                        where (s.UserID.Equals(userID))
                        select s;

            DataGrid_ProfileInformation.ItemsSource = query.ToList();
        }

        private void button_GameHistory_Click(object sender, RoutedEventArgs e)
        {
            var query = from s in db.PlayerHistories
                        where (s.PlayerOne.Equals(userID))
                        select s;

            DataGrid_GameHistory.ItemsSource = query.ToList();
        }
    }
}
