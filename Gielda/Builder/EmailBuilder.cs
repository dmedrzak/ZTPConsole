using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Builder
{
    public abstract class EmailBuilder
    {
        protected EmailPattern emailPattern;

        public EmailBuilder()
        {
            this.emailPattern = new EmailPattern();
        }
        public void CreateEmail()
        {
            this.emailPattern = new EmailPattern();
        }
        public EmailPattern GetEmail()
        {
            return emailPattern;
        }

        public abstract void SetPort(int port);
        public abstract void SetHost(string host);
        public abstract void SetTimeOut(int timeout);
        public abstract void SetDeliveryMethod();
        public abstract void SetDefaultCredential();
        public abstract void SetUserSettingsCredential(string user, string password);
        public abstract void SetMailFrom(string from);
        public abstract void SetMailTo(string to);
        public abstract void SetSubject(string subject);
        public abstract void SetMailBody(string body);
        public abstract void SendEmail();


       
    }
}
