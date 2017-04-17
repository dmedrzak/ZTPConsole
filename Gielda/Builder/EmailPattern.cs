using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Builder
{
    public class EmailPattern
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public int TimeOut { get; set; }
        public string UserCredential { get; set; }
        public string UserPassword { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

       }
}
