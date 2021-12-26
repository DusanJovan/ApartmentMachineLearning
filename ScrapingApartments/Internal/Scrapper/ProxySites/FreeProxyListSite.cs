using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScrapingApartments.Internal.Scrapper.Proxy.Internal
{
    public static class FreeProxyListSite
    {
        #region Consts

        private const string Url = "https://free-proxy-list.net/";

        #endregion

        public static async Task<IEnumerable<string>> GetProxiesAsync()
        {
            Console.WriteLine($"Getting proxies from {Url}...");

            var webLoader = new HtmlWeb();
            var htmlDoc = await webLoader.LoadFromWebAsync(Url);

            var text = htmlDoc.DocumentNode.SelectSingleNode("//textarea[@class='form-control']").InnerText;

            var pattern = @"\d+\.\d+\.\d+\.\d+:\d+";
            var matches = Regex.Matches(text, pattern);

            return matches.Select(x => x.Groups[0].Value);
        }
    }
}
