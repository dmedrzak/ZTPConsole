using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.Singleton;

namespace Gielda.Decorator
{
    public abstract class ActionDecorator :Action
    {
    }

    public class Provision : ActionDecorator
    {
        private new Action action;
        public Provision(Action action)
        {
            this.action = action;
        }
        public override double Price()
        {
            return action.Price() + 0.2;
        }
    }

    public class ExchangeUSD : Action
    {
        private new Action action;
        public ExchangeUSD(Action action)
        {
            this.action = action;
        }

        public override double Price()
        {
            CurrentExchangeRates.ConvertPlnToUSD(2);
            return action.Price();
        }
    }
}
