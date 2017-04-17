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
            double normalPrice = action.Price();
            double provision = 0.2;
            Logger.Instance.AppendLoggerMessage($"Provision added to {action.action.Name}. Normal Price: {normalPrice}, Provision: {provision}, Summary Price:{normalPrice+provision}");
            return normalPrice + provision;
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
