using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Gielda.Models;
using HtmlAgilityPack;
using Xunit;

namespace ZtpGielda_Tests
{
    public class Class1
    {
        private string url = @"http://bossa.pl/pub/metastock/mstock/sesjaall/sesjaall.prn";
        [Fact]
        public void Download_Single_Action_NotNull()
        {
            Assert.True(GetSingleAction());
        }

        [Theory]
        [InlineData(@"http://biznes.onet.pl/gielda/notowania/gpw-rynek-glowny/akcje-wszystkie,101,notowania-gpw-ciagle.html")]
        public void Download_Html_Succesfull(string url)
        {
            var html = DownloadHtml(url);
            bool downloadSuccess = false;
            if (html != null)
            {
                downloadSuccess = true;
            }
            Assert.True(downloadSuccess);

        }

        private bool GetSingleAction()
        {
            var result = (new WebClient().DownloadString(url));
            string[] allActions = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (allActions != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
