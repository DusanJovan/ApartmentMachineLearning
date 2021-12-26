using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingApartments.Internal.Scrapper.ProxySites
{
    public static  class ProxyListSite
    {
        #region Consts

        private const string Url = "https://raw.githubusercontent.com/clarketm/proxy-list/master/proxy-list-raw.txt";

        #endregion

        public static async Task<IEnumerable<string>> GetProxiesAsync()
        {
            Console.WriteLine($"Getting proxies from {Url}...");

            var client = new RestClient();
            IRestRequest request = new RestRequest(Url, Method.GET);

            return (await client.ExecuteAsync<string>(request)).Content.Split("\n");
        }
    }
}
