using System.Net;
using System.Net.Mail;

namespace BookSharingApp.Services
{
    public class EmailService
    {
        private static readonly string From = "sarthak.vadgama.hs@gmail.com";
        private static readonly string Password = "pkcj demt ogvi ewws";
        private static readonly string smtpAddress = "smtp.gmail.com";
        private static readonly int portNumber = 587;

        public static async Task SendEmail(string To, string Sub, string Body)
        {
            try
            {
                using(MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(From);
                    mail.To.Add(To);
                    mail.Subject = Sub;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(From, Password);
                        smtp.EnableSsl = true;
                        //smtp.Send(mail);
                        await smtp.SendMailAsync(mail);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
