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
        public string MaximumPrice { get; set; }
        public string OpenPrice { get; set; }
        public string MinPrice { get; set; }
        public string Tko { get; set; }
        public string TradingVolume { get; set; }
    }
}
