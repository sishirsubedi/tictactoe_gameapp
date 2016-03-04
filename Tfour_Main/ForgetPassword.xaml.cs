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
using System.Net.Mail;

namespace Tfour_Main
{
    /// <summary>
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {

        DatabaseDataContext db = new DatabaseDataContext(
         Properties.Settings.Default.Tfour_ConnectionString);

        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void Button_SendEmail_Click(object sender, RoutedEventArgs e)
        {

           


            try
            {
                PlayerInformation player = db.PlayerInformations.Single(p => p.UserID.Equals(Textbox_UserID.Text));
                MessageBox.Show(" The password for " + player.UserID + " is " + player.Password);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("subedisishir@gmail.com", "Tfour:Password Request");
                mail.To.Add(Textbox_Email.Text);
                mail.IsBodyHtml = true;
                mail.Subject = "Password Request";
                mail.Body = " Your Password is :" + player.Password ;
                mail.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 465);

                smtp.Credentials = new System.Net.NetworkCredential("subedisishir@gmail.com", "trkdnag2");
                smtp.EnableSsl = true;
                
                smtp.Send(mail); 


                MessageBox.Show(player.Password);

                Login loginform = new Login();
                loginform.Visibility = System.Windows.Visibility.Visible;
                this.Visibility = System.Windows.Visibility.Hidden;

            }
            catch
            {

                {
                    MessageBox.Show("Error : Email was not sent !");

                }

            }

        }
    }
}
