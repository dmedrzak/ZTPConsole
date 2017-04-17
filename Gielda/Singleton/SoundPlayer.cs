using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Gielda.Decorator;
using Gielda.Observer;

namespace Gielda.Singleton
{
    public sealed class SoundPlayer : IObserver
    {
        private double lastProvision = 0;
        private double actualprovision;
        private Provision provisionObservered;
        private static SoundPlayer _instance = null;
        private static readonly object padlock = new object();

        private SoundPlayer()
        {
            
        }

        public static SoundPlayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SoundPlayer();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetObserveredAction(Provision p)
        {
            this.provisionObservered = p;
        }

        public void PlaySound()
        {
            SystemSounds.Asterisk.Play();
        }

        public void updateData()
        {
            actualprovision = provisionObservered.provision;
            if (lastProvision != actualprovision)
            {
                lastProvision = actualprovision;
                PlaySound();
                Console.WriteLine("Object Get New Provision: {0}", actualprovision);
            }else
                Console.WriteLine("Provision not change: {0}", actualprovision);

        }
    }
}
