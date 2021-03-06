﻿using System;
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
    
    // Profile window is used to very a Players information
        //  Profile displays - Name, username, and email
        // Game History displays - player, opponent, scores for each, time and date game was played
    public partial class Profile : Window
    {

        DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);

        String userID;
        private Window prevWindow;

        // Profile window is loaded with the username ID that was given
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
            DataGrid_ProfileInformation.Columns[3].Visibility = Visibility.Hidden;
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
