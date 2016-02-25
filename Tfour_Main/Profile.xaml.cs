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
        public Profile()
        {
            InitializeComponent();
        }

        private void Button_Profile_Back_Click(object sender, RoutedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
            loginForm.Button_View_Profile.Visibility = System.Windows.Visibility.Visible;
            loginForm.Grid_gameOptions.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
