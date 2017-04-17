using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gielda.Models
{
    public class ActionModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public double MaximumPrice { get; set; }
        public double OpenPrice { get; set; }
        public double MinPrice { get; set; }
        public double Tko { get; set; }
        public string TradingVolume { get; set; }
    }
}
