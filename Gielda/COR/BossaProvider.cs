using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gielda.Models;

namespace Gielda.COR
{
    public class BossaProvider : ActionProvider
    {
        private string url = @"http://bossa.pl/pub/metastock/mstock/sesjaall/sesjaall.prn";
        public BossaProvider(string actionName)
        {
            this.ProviderName = "Bossa";
            this.DownloadActionName = actionName;
        }
        public override void DoTask(TasksToDo task)
        {
            //ActionModel model = new ActionModel();
            if (task == TasksToDo.DownloadSingleAction)
            {
                try
                {
                     actionModel = GetSingleAction(DownloadActionName);
                }
                catch (Exception)
                {
                    NextProvider.DoTask(task);
                }
                
                if (actionModel.Name != null)
                {
                    Console.WriteLine($"Information downloaded from {ProviderName}");
                    Console.WriteLine($"Action name: {actionModel.Name} Date: {actionModel.Date} Maximum Price: {actionModel.MaximumPrice} Open Price: {actionModel.OpenPrice} Close Price: {actionModel.MinPrice} TKO: {actionModel.Tko} Trading Volume: {actionModel.TradingVolume}");
                }
                else
                {
                    Console.WriteLine($"ERROR - {ProviderName} - dont have any information about this action or server not response");
                    NextProvider.DoTask(task);
                }
   
            }
            else if (NextProvider != null)
            {
                NextProvider.DoTask(task);
            }
        }

        public ActionModel GetSingleAction(string actionName)
        {
            var result = (new WebClient().DownloadString(url));
            string[] allActions = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var singleAction in allActions)
            {
                if (singleAction.StartsWith(actionName))
                {
                    return ConvertFromStringToModel(singleAction);                   
                }
            }
            return new ActionModel();
        }

        public ActionModel ConvertFromStringToModel(string input)
        {
            string[] action = input.Split(new string[] {","}, StringSplitOptions.None);
            ActionModel model = new ActionModel
            {
                Name = action[0],
                Date = action[1],
                MaximumPrice = Convert.ToDouble(action[2]),
                OpenPrice = Convert.ToDouble(action[3]),
                MinPrice = Convert.ToDouble(action[4]),
                Tko = Convert.ToDouble(action[5]),
                TradingVolume = action[6]
                
            };
            return model;
        }
    }
}
