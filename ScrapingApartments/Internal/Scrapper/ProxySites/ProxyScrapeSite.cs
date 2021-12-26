using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapingApartments.Internal.Scrapper.Proxy.Internal
{
    public static class ProxyScrapeSite
    {
        #region Consts

        private const string Url = "https://api.proxyscrape.com/v2/?request=getproxies&protocol=http&timeout=1000&country=all&ssl=all&anonymity=all&simplified=true";

        #endregion

        public static async Task<IEnumerable<string>> GetProxiesAsync()
        {
            Console.WriteLine($"Getting proxies from {Url}...");

            var client = new RestClient();
            IRestRequest request = new RestRequest(Url, Method.GET);

            return (await client.ExecuteAsync<string>(request)).Content.Split("\r\n");
        }
    }
}
