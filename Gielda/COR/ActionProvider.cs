using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.Models;

namespace Gielda.COR
{
    public abstract class ActionProvider
    {
        public string ProviderName { get; set; }
        public string DownloadActionName { get; set; }
        public ActionModel actionModel { get; set; }
        protected ActionProvider NextProvider;

        public void SetNextActionProvider(ActionProvider provider)
        {
            this.NextProvider = provider;
        }

        public abstract void DoTask(TasksToDo task);
    }
}
