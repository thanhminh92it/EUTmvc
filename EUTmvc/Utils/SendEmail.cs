using System.Web.Helpers;
using EUTmvc.Models;
using System;
using System.Net.Mail;
using System.Text;

namespace EUTmvc.Utils
{
    public class SendEmail
    {
        public static string send_Mail(EmailFrom emailFrom, EmailTo emailTo)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("<table>");
                sb.Append("<tr><td>" + emailTo.contents + "</td></tr>");
                sb.Append("</table>");
                var msg = new MailMessage
                {
                    From = new MailAddress(emailFrom.account, emailFrom.displayName, Encoding.UTF8),
                    Subject = emailTo.subject
                };
                msg.To.Add(emailTo.mailto);
                msg.Body = sb.ToString();
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                //Add the Creddentials
                var client = new SmtpClient
                {
                    Credentials = new System.Net.NetworkCredential(emailFrom.account, emailFrom.pass),
                    Port = emailFrom.port,
                    Host = emailFrom.host,
                    EnableSsl = true
                };
                client.Send(msg);
                return "Successfull!";
            }
            catch (Exception ms)
            {
                return "Error : " + ms.Message;
            }
        }
        public static string sendMail(EmailFrom emailFrom, EmailTo emailTo)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("<table>");
                sb.Append("<tr><td>" + emailTo.contents + "</td></tr>");
                sb.Append("</table>");
                WebMail.SmtpServer = emailFrom.host;
                WebMail.SmtpPort = emailFrom.port;
                WebMail.EnableSsl = true;
                WebMail.UserName = emailFrom.account;
                WebMail.Password = emailFrom.pass;
                //WebMail.From = emailFrom.account;

                WebMail.Send(emailTo.mailto, emailTo.subject, sb.ToString());
                return "Successfull!";
            }
            catch (Exception ms)
            {
                return "Error : " + ms.Message;
            }
        }
    }
}