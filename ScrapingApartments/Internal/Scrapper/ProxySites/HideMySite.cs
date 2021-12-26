using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScrapingApartments.Internal.Scrapper.Proxy.Internal
{
    public static class HideMySite
    {
        #region Consts

        private const int ping = 1000;

        private static readonly string Url = $"https://hidemy.name/en/proxy-list/?maxtime={ping}&type=hs#list";

        #endregion

        public static async Task<IEnumerable<string>> GetProxiesAsync()
        {
            Console.WriteLine($"Getting proxies from {Url}...");

            var client = new RestClient();
            IRestRequest request = new RestRequest(Url, Method.GET);

            var res = (await client.ExecuteAsync<string>(request)).Content;

            var pattern = @"<tr><td>([\d.]+)</td><td>(\d+)</td>";
            var matches = Regex.Matches(res, pattern);

            return matches.Select(x=>$"{x.Groups[1]}:{x.Groups[2]}");
        }
    }
}
