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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Net.Mail;

namespace SimpleMailClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string to = txtRecipient.Text;
            string from = txtSender.Text;
            string subject = txtSubject.Text;
            string body = txtBody.Text;
           
            MailAddress senderAddress = new MailAddress(from);
            MailAddress recipientAddress = new MailAddress(to);
            MailMessage message = new MailMessage(senderAddress,recipientAddress);
            message.Subject = subject;
            message.Body = body;
            

            SendMail(message);
           
        }

        public void SendMail(MailMessage msg)
        {
            try
            {
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential
                {
                    UserName = "dddd@gmail.com",
                    Password = "password"
                    
                }; //Gmail Username and Password

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = credentials;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
                MessageBox.Show("Message Successfully Sent!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
