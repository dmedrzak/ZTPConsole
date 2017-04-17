using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Builder
{
    public class PostmanCompanyOne : EmailBuilder
    {
        private MailMessage objeto_mail;
        private SmtpClient client;
        public PostmanCompanyOne()
        {
            this.objeto_mail=new MailMessage();
            this.client = new SmtpClient();
        }

        public override void SetPort(int port)
        {
            emailPattern.Port =port;
            client.Port = port;
        }
        public override void SetHost(string host)
        {
            emailPattern.Host= host;
            client.Host = host;
        }
        public override void SetTimeOut(int timeout)
        {
            emailPattern.TimeOut=timeout;
            client.Timeout = timeout;
        }
        public override void SetDeliveryMethod()
        {
           // emailPattern.SetDeliveryMethod();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
        public override void SetDefaultCredential()
        {
           // emailPattern.SetDefaultCredential();
          //  client.UseDefaultCredentials = false;
        }
        public override void SetUserSettingsCredential(string user, string password)
        {
            emailPattern.UserCredential=user;
            emailPattern.UserPassword = password;
            client.Credentials = new NetworkCredential(user,password);
        }
        public override void SetMailFrom(string from)
        {
            emailPattern.From=from;
            objeto_mail.From = new MailAddress(from);
        }
        public override void SetMailTo(string to)
        {
            emailPattern.To=to;
            objeto_mail.To.Add(new MailAddress(to));
        }
        public override void SetSubject(string subject)
        {
            emailPattern.Subject=subject;
            objeto_mail.Subject = subject;
        }
        public override void SetMailBody(string body)
        {
            emailPattern.Body=body;
            objeto_mail.Body = body;
        }
        public override void SendEmail()
        {
            client.EnableSsl = true;
           client.Send(objeto_mail);
        }

    }
}
