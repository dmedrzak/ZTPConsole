using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Singleton
{
    public sealed class Logger
    {
        private string path = @"C:\Logs\log.txt";
        private static Logger _instance = null;
        private static readonly object padlock = new object();
        public string msg { get; set; }
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }
        private Logger()
        {            
        }

        public void SetLoggerMessage(string msg)
        {
            this.msg = msg;
        }

        public void AppendLoggerMessage(string msg)
        {
            try
            {
                File.AppendAllText(path, $"Date: {DateTime.Now} {msg} \r\n");
            }
            catch (Exception)
            {
                File.AppendAllText(path, $"Date: {DateTime.Now} Error- UNABLE TO SAVE MESSAGE \r\n");
            }
        }
    }
}
