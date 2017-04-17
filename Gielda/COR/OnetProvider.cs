using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Gielda.Models;
using HtmlAgilityPack;

namespace Gielda.COR
{
    public class OnetProvider : ActionProvider
    {
        private string url;
        public OnetProvider(string actionName)
        {
            this.url =
                @"http://biznes.onet.pl/gielda/notowania/gpw-rynek-glowny/akcje-wszystkie,101,notowania-gpw-ciagle.html";
            this.ProviderName = "Onet";
            this.DownloadActionName = actionName;
        }
        public override void DoTask(TasksToDo task)
        {
            if (task == TasksToDo.DownloadSingleAction)
            {
                HtmlDocument html = DownloadHtml(url);

                var model = GetSingleAction(DownloadActionName, html);
                Console.WriteLine($"Information downloaded from {ProviderName}");
                Console.WriteLine($"Action name: {model.Name} Date: {model.Date} Maximum Price: {model.MaximumPrice} Open Price: {model.OpenPrice} Close Price: {model.MinPrice} TKO: {model.Tko} Trading Volume: {model.TradingVolume}");
                // ParseHtml(html);
                //Console.WriteLine($"Provider Name: {ProviderName} task: {task} Action Name: {DownloadActionName}");
            }
            else if (NextProvider != null)
            {
                NextProvider.DoTask(task);
            }
        }

        private ActionModel GetSingleAction(string name, HtmlDocument html)
        {
            var modelList = ParseHtmlToActionModel(html);
            return actionModel=modelList.FirstOrDefault(x => x.Name == name);

        }

        private List<ActionModel> ParseHtmlToActionModel(HtmlDocument html)
        {
            List<ActionModel> modelList = new List<ActionModel>();
            HtmlNodeCollection tableRows = html.DocumentNode.SelectNodes("//tr");
            for (int i = 2; i < tableRows.Count; i++)
            {
                ActionModel model = new ActionModel();
                HtmlNode tr = tableRows[i];
                HtmlNode[] td = new HtmlNode[8];
                string xpath = tr.XPath + "//td";
                HtmlNodeCollection cellRows = tr.SelectNodes(@xpath);          
                try
                {// \r\n
                    model.Name = cellRows[3].ChildNodes[3].InnerText.Trim();
                    model.MaximumPrice = cellRows[10].InnerText;
                    model.OpenPrice = cellRows[8].InnerText;
                    model.MinPrice = cellRows[9].InnerText;
                    model.TradingVolume = cellRows[11].InnerText;
                    model.Tko = cellRows[4].InnerText.Trim();
                   
                    modelList.Add(model);
                }
                catch (Exception e)
                {
                    
                }
            }
            //HtmlNode[] nodes = html.DocumentNode.SelectNodes("//tr").ToArray();
            return modelList;

        }

        private HtmlDocument DownloadHtml(string url)
        {
            var pageContent = (new WebClient().DownloadString(url));
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageContent);
            return htmlDocument;
        }
    }
}
