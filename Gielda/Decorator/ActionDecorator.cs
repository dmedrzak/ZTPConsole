using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Decorator
{
    public abstract class ActionDecorator :Action
    {
    }

    public class Provision : ActionDecorator
    {
        private Action action;

        public Provision(Action action)
        {
            this.action = action;
        }

        public override string Price()
        {
            return action.Price() + "Provision 0,2$";
        }
    }
}
