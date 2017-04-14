using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.COR
{
    public abstract class ActionProvider
    {
        public string ProviderName { get; set; }
        public string DownloadActionName { get; set; }
        protected ActionProvider nextProvider;

        public void SetNextActionProvider(ActionProvider provider)
        {
            this.nextProvider = provider;
        }

        public abstract void DoTask(TasksToDo task);
    }
}
