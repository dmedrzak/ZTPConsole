using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.Models;

namespace Gielda.Decorator
{
    public class DownloadedAction : Action
    {
        public DownloadedAction(ActionModel model)
        {
            action = model;
        }

        public override string Price()
        {
            return action.Tko;
        }
    }
}
