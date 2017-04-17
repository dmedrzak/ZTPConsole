using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.Models;

namespace Gielda.Decorator
{
    public abstract class Action
    {
        public ActionModel action { get; set; }
        public abstract string Price();
    }
}
