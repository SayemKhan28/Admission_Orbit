using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Admission_Orbit
{
    public static class EmailHelper
    {

        
            private static string senderEmail = "orbitadmission31@gmail.com";
            private static string appPassword = "hgxusvsdbftljiya"; 

            public static void SendEmail(string recipientEmail, string subject, string body)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Email sending failed: " + ex.Message);
                }
            }
        }
    }


