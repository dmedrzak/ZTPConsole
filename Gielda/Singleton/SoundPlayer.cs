using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Singleton
{
    public sealed class SoundPlayer
    {
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

        public void PlaySound()
        {
            SystemSounds.Asterisk.Play();
        }
    }
}
