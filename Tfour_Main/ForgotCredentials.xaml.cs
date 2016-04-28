using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for ForgotCredentials.xaml
    /// </summary>
    
    // Forgot Credentials window is used to retrieve a users username or password
            // Email must be provided
            // If user request for their username - it will be displayed on button click
            // If user request for their password - it will be sent to their email
    public partial class ForgotCredentials : Window
    {

        private DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.Tfour_ConnectionString);
        private Window prevWindow;

        public ForgotCredentials(Window window)
        {
            InitializeComponent();
            prevWindow = window;
        }
        
        // Button used to retrieve a users username only if email provided matches the email in the database
        private void Button_RetriveUserName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Trim white spaces
                string email = Textbox_Email.Text.Trim();

                var query = from p in db.PlayerInformations
                            where (p.Email.Equals(email))
                            select p;

                if (query.Any())
                {
                    PlayerInformation player = db.PlayerInformations.Single(p => p.Email.Equals(email));

                   

                    MessageBox.Show("Your username is : " + player.UserID);
                    // Navigate back to the previous window
                    this.Visibility = Visibility.Hidden;
                    prevWindow.Visibility = Visibility.Visible;

                }
                else 
                {
                    MessageBox.Show("Your email is not registered in the system.");
                    Textbox_Email.Text = "";
                    Textbox_Email.Focus();
                }



             
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred please try again.");
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException);
                Textbox_Email.Text = "";
                Textbox_Email.Focus();
            }
        }

        // Button used to retrieve a password only if the email matched the one provided in the database
        private void Button_ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Trim white spaces
                string email = Textbox_Email.Text.Trim();
                // Trim white spaces
               

                var query = from p in db.PlayerInformations
                            where (p.Email.Equals(email))
                            select p;

                if (query.Any())
                {

                    // Look up user account associated with email address
                    PlayerInformation player = db.PlayerInformations.Single(p => p.Email.Equals(email));


                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("tfourgame@outlook.com", "Tfour Team");
                    mail.To.Add(player.Email);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Password Reset Request";
                    mail.Body = "<html><body><h2>Password Reset Request</h2><p>Hi " + player.Name + "!<br>Your new system generated password is: " + player.Password + "<br>You can change this password using the edit profile menu within the application.<h3>Thank you for playing!<br>The Tfour Team</h3></body></html>";
                    mail.Priority = MailPriority.High;
                    // Send email
                    SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("tfourgame@outlook.com", "uhdcsse3420");
                    smtp.Send(mail);
                    MessageBox.Show("Password reset sucessful!");
                   



                    MessageBox.Show("Password reset sucessful!");
                   
                    // Navigate back to the previous window
                    this.Visibility = Visibility.Hidden;
                    prevWindow.Visibility = Visibility.Visible;
                }

                else
                {
                    MessageBox.Show("Your email is not registered in the system.");
                    Textbox_Email.Text = "";
                    Textbox_Email.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred please try again.");
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException);
                Textbox_Email.Text = "";
                Textbox_Email.Focus();
            }
        }

     
        // Button will close down this window
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
