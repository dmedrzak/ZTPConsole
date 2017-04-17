using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
//           emailBuilder.CreateEmail();
           emailBuilder.SendEmail();
        }
    }
}
