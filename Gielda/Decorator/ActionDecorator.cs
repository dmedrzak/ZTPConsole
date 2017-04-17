using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.Observer;
using Gielda.Singleton;

namespace Gielda.Decorator
{
    public abstract class ActionDecorator :Action
    {
    }

    public class Provision : ActionDecorator, IObservered
    {
        private List<IObserver> _observersList = new List<IObserver>();
        private new Action action;
        public double provision { get; set; }      
        public Provision(Action action)
        {
            this.provision = 0.2;
            this.action = action;
        }
        public override double Price()
        {
            double normalPrice = action.Price();           
            Logger.Instance.AppendLoggerMessage($"Provision added to {action.action.Name}. Normal Price: {normalPrice}, Provision: {provision}, Summary Price:{normalPrice+provision}");
            return normalPrice + provision;
        }

        //public void ProvisionObservered(Provision provision)
        //{
        //    this.provision = provision.provision;
        //}
        public void addObserver(IObserver o)
        {
            this._observersList.Add(o);
        }

        public void deleteObserver(IObserver o)
        {
            this._observersList.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var item in _observersList)
            {
                item.updateData();
            }
        }

        public void ChangeProvision(double provision)
        {
            this.provision = provision;
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
