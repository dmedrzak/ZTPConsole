using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gielda.Builder;
using Gielda.COR;
using Gielda.Decorator;
using Gielda.Singleton;

namespace Gielda
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chain of responsibility
            string actionToDownload = "08 OCTAVA";
            ActionProvider bossa = new BossaProvider(actionToDownload);
            ActionProvider onet = new OnetProvider(actionToDownload);
            bossa.SetNextActionProvider(onet);
            bossa.DoTask(TasksToDo.DownloadSingleAction);

            //Decorator Provision
            DownloadedAction da = new DownloadedAction(onet.actionModel);
            Provision provisionDecorator = new Provision(da);
            Console.WriteLine($"TKO with Provision: {provisionDecorator.Price()} PLN");

            //Exchange Rate
            Console.WriteLine($"Today exchange rate: {CurrentExchangeRates.UsdRate()}");
            Console.WriteLine($"TKO with Provision: {CurrentExchangeRates.ConvertPlnToUSD(provisionDecorator.Price())} USD");


            //BUILDER
            PostmanCompanyOne postmanCompanyOne = new PostmanCompanyOne();
            //POSTMAN CONFIGURE SETTINGS
            postmanCompanyOne.SetPort(587);
            postmanCompanyOne.SetHost(@"smtp.poczta.onet.pl");
            postmanCompanyOne.SetTimeOut(5000);
            postmanCompanyOne.SetDeliveryMethod();
            postmanCompanyOne.SetDefaultCredential();
            postmanCompanyOne.SetUserSettingsCredential("ztpgielda@onet.pl", "Daniel123");
            postmanCompanyOne.SetMailFrom(@"ztpgielda@onet.pl");
            postmanCompanyOne.SetMailTo(@"dmedrzak93@gmail.com");
            postmanCompanyOne.SetSubject($"ZTP-GIELDA Ceny Akcji {actionToDownload}");
            postmanCompanyOne.SetMailBody($"Nazwa Akcji: {actionToDownload}\r\n" +
                                          $"Cena Akcji bez prowizji: {onet.actionModel.Tko} \r\n" +
                                          $"Cena Akcji z prowizją: {provisionDecorator.Price()} \r\n" +
                                          $"Dzisiejsza cena Dolara: {CurrentExchangeRates.UsdRate()} \r\n" +
                                          $"Cena po przeliczeniu PLN-USD: {CurrentExchangeRates.ConvertPlnToUSD(provisionDecorator.Price())}");
            //DIRECTOR
            EmailDirector director = new EmailDirector(postmanCompanyOne);
            director.SendMail();



        }
    }
}
