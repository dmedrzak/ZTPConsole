using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gielda.Decorator;

namespace Gielda.Singleton
{
    public sealed class FakeObserverData
    {
        private static FakeObserverData _instance=null;
        private static readonly object padlock = new object();

        public static FakeObserverData Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FakeObserverData();
                        }
                    }
                }
                return _instance;
            }
        }

        private FakeObserverData()
        {          
        }

        public void GenerateFakeProvision(Provision observered)
        {
            Random rnd = new Random();
            Console.WriteLine($"Press any button to get random provision. Press 'q' to exit.");
            do
            {
                string key = Console.ReadLine();
                if (key == "q")
                {
                    break;
                }
                else
                {
                    observered.ChangeProvision(rnd.Next(1,3));
                    observered.NotifyObservers();;
                }
            } while (true);
        }
    }
}
