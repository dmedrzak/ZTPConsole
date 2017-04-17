using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.Singleton;

namespace Gielda.Builder
{
    public class EmailDirector
    {
        private EmailBuilder emailBuilder;

        public EmailDirector(EmailBuilder builder)
        {
            this.emailBuilder = builder;
        }

        public void SendMail()
        {
            try
            {
                emailBuilder.SendEmail();
                Logger.Instance.AppendLoggerMessage($"Email with action send to: {emailBuilder.GetEmail().To}");
            }
            catch (Exception ex)
            {
                Logger.Instance.AppendLoggerMessage($"ERROR-Unable to send email. Exception: {ex}");
            }
           
        }
    }
}
