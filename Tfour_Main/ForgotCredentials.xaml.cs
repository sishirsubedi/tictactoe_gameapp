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
    public partial class ForgotCredentials : Window
    {

        private DatabaseDataContext db = new DatabaseDataContext(Properties.Settings.Default.TfourConnectionString);
        private Window prevWindow;

        public ForgotCredentials(Window window)
        {
            InitializeComponent();
            prevWindow = window;
        }

        private void Button_RetriveUserName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Trim white spaces
                string email = Textbox_Email.Text.Trim();
                // Look up user account associated with email address
                PlayerInformation player = db.PlayerInformations.Single(p => p.Email.Equals(email));
                // Compose username request email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("tfourgame@outlook.com", "Tfour Team");
                mail.To.Add(email);
                mail.IsBodyHtml = true;
                mail.Subject = "Username retrival Request";
                mail.Body = "<html><body><h2>Username Request</h2><p>Hi " + player.Name + "!<br>The username associated with your Tfour account is: " + player.Password + "<h3>Thank you for playing!<br>The Tfour Team</h3></body></html>";
                mail.Priority = MailPriority.High;
                // Send email
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 465);
                smtp.Credentials = new System.Net.NetworkCredential("tfourgame@outlook.com", "uhdcsse3420");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Your username has been sent to the provided email address.");
                // Navigate back to the previous window
                this.Visibility = Visibility.Hidden;
                prevWindow.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred please try again.");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException);
                Textbox_Email.Text = "";
                Textbox_Email.Focus();
            }
        }

        private void Button_ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Trim white spaces
                string email = Textbox_Email.Text.Trim();
                // Look up user account associated with email address
                PlayerInformation player = db.PlayerInformations.Single(p => p.Email.Equals(email));
                // Generate random password
                player.Password = RandomString(5);
                // Compose password reset email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("tfourgame@outlook.com", "Tfour Team");
                mail.To.Add(email);
                mail.IsBodyHtml = true;
                mail.Subject = "Password Reset Request";
                mail.Body = "<html><body><h2>Password Reset Request</h2><p>Hi " + player.Name + "!<br>Your new system generated password is: " + player.Password + "<br>You can change this password using the edit profile menu within the application.<h3>Thank you for playing!<br>The Tfour Team</h3></body></html>";
                mail.Priority = MailPriority.High;
                // Send email
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 465);
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("tfourgame@outlook.com", "uhdcsse3420");
                smtp.Send(mail);
                MessageBox.Show("Password reset sucessful!");
                db.SubmitChanges();
                // Navigate back to the previous window
                this.Visibility = Visibility.Hidden;
                prevWindow.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred or there's no Tfour account associated with your email address.");
                Console.WriteLine(ex.Message);
                Textbox_Email.Text = "";
                Textbox_Email.Focus();
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
