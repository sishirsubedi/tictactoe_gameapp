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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tfour_Main
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    
    // Register window is used to open a new profile in the database
        // Name, username, password, a reentered password, and email must be provided
    public partial class Register : Window
    {
        DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);
        Window prevWindow;

        public Register(Window window)
        {
            InitializeComponent();
            Label_usernameTaken.Visibility = Visibility.Hidden;
            Label_passwordsDontMatch.Visibility = Visibility.Hidden;
            prevWindow = window;
        }


        // Button to create the profile in database
            // All textbox designated are checked for input
            // The username is checked in the database for any similar usernames ( No double usernames allowed )
        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_Name.Text)
                || string.IsNullOrWhiteSpace(TextBox_userID.Text)
                || string.IsNullOrWhiteSpace(PasswordBox_password.Password)
                || string.IsNullOrWhiteSpace(TextBox_email.Text))
            {
                MessageBox.Show("Required fields missing, please complete the registration form.");
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
                        MessageBox.Show("Username is already taken. Please choose a different username.");
                        TextBox_userID.Text = "";
                        TextBox_userID.Focus();
                    }
                    else if (!PasswordBox_ReenterPassword.Password.Equals(PasswordBox_password.Password))
                    {
                        MessageBox.Show("Passwords do not match. Please reenter you password.");
                        PasswordBox_password.Password = "";
                        PasswordBox_ReenterPassword.Password = "";
                        PasswordBox_password.Focus();
                    }
                    else
                    {
                        // Create new player information object
                        PlayerInformation newplayer = new PlayerInformation();
                        newplayer.Name = TextBox_Name.Text;
                        newplayer.UserID = TextBox_userID.Text;
                        newplayer.Password = PasswordBox_password.Password;
                        newplayer.Email = TextBox_email.Text.Trim();

                        db.PlayerInformations.InsertOnSubmit(newplayer);
                        db.SubmitChanges();


                        prevWindow.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error processing your registration, please try again.");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void PasswordBox_Reenterpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!PasswordBox_ReenterPassword.Password.Equals(PasswordBox_password.Password))
            {
                Label_passwordsDontMatch.Visibility = Visibility.Visible;
            }
            else
            {
                Label_passwordsDontMatch.Visibility = Visibility.Hidden;
            }
        }

        private void PasswordBox_ReenterPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            Label_passwordsDontMatch.Visibility = Visibility.Hidden;
        }

        private void PasswordBox_ReenterPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!PasswordBox_ReenterPassword.Password.Equals(PasswordBox_password.Password))
            {
                Label_passwordsDontMatch.Visibility = Visibility.Visible;
            }
            else
            {
                Label_passwordsDontMatch.Visibility = Visibility.Hidden;
            }
        }
    
        // Button to return to previous screen ( Login, Login2, and GameOver windows )
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            prevWindow.Show();
            this.Close();
        }
    }
}
