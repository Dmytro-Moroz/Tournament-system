using System.Collections.Generic;
using System.Net.Mail;
using TournamentLibrary.Configuration;

namespace TournamentLibrary
{
    public static class EmailLogic
    {
        public static void SendEmail(string to, string subject, string body)
        {
            SendEmail(new List<string>{to}, new List<string>(), subject, body);
        }

        public static void SendEmail(List<string> to, List<string> bcc, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderDisplayName"));

            MailMessage mailMessage = new MailMessage();
            foreach (string addressForSend in to)
            {
                mailMessage.To.Add(addressForSend);
            }
            foreach (string addressForSend in bcc)
            {
                mailMessage.Bcc.Add(addressForSend);
            }
            mailMessage.From = fromAddress;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Send(mailMessage);
        }
    }
}