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
        public Profile2()
        {
            InitializeComponent();
        }

        private void Button_Profile_Back_Click(object sender, RoutedEventArgs e)
        {
            Login2 loginForm = new Login2();
            loginForm.Visibility = System.Windows.Visibility.Visible;
            this.Visibility = System.Windows.Visibility.Hidden;
            loginForm.Button_View_Profile2.Visibility = System.Windows.Visibility.Visible;
            loginForm.Grid_gameOptions.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
