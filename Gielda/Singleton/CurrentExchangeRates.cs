using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Gielda.Singleton
{
    public class CurrentExchangeRates
    {
        private static string url = @"http://www.nbp.pl/Kursy/KursyA.html";
        private static double usd;

        private static void DownloadDollarsExchangeRate()
        {
            var html = DownloadHtml();
            
            HtmlNode node = html.DocumentNode.SelectSingleNode("//tr[3]/td[@class='bgt2 right'][2]");
            usd = Convert.ToDouble(node.InnerText);
        }

        private static HtmlDocument DownloadHtml()
        {
            var pageContent = (new WebClient().DownloadString(url));
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageContent);
            return htmlDocument;
        }

        public static double ConvertPlnToUSD(double pln)
        {
            DownloadDollarsExchangeRate();
            return pln*usd;
        }

        public static double UsdRate()
        {
            DownloadDollarsExchangeRate();
            return usd;
        }
    }
}
