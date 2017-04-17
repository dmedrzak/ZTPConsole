using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.COR;
using Gielda.Decorator;

namespace Gielda
{
    class Program
    {
        static void Main(string[] args)
        {
            string actionToDownload = "08 OCTAVA";
            ActionProvider bossa = new BossaProvider(actionToDownload);
            ActionProvider onet = new OnetProvider(actionToDownload);
            bossa.SetNextActionProvider(onet);
            bossa.DoTask(TasksToDo.DownloadSingleAction);

            DownloadedAction da = new DownloadedAction(onet.actionModel);
            Provision provisionDecorator = new Provision(da);
            Console.WriteLine(provisionDecorator.Price());
          //onet.DoTask(TasksToDo.DownloadSingleAction);
        }
    }
}
