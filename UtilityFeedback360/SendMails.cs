using System.Net.Mail;
using System.Net;

namespace UtilityFeedback360
{
    public static class SendMails
    {
            
        public static void SendEmail( string To_User, string subject, string msgBody)
        {
            string From_User = "1997abhijitsmp@gmail.com";
            try
            {

                MailMessage message = new MailMessage(From_User, To_User);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = msgBody;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("", "please add app password");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;

                smtp.Send(message);

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
    }
}
