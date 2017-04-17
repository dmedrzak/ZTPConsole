using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Observer
{
    public interface IObservered
    {
        double provision { get; set; }
        void addObserver(IObserver o);
        void deleteObserver(IObserver o);
        void NotifyObservers();
    }
}
