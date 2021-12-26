using RestSharp;
using ScrapingApartments.Internal.Scrapper.Proxy.Internal;
using ScrapingApartments.Internal.Scrapper.ProxySites;
using ScrapingApartments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ScrapingApartments.Internal.Scrapper
{
    public static class ProxyScrapper
    {
        private const string CheckUrl = "https://www.halooglasi.com/nekretnine/izdavanje-kuca";

        private static ActionBlock<string>[] ActionBlocks { get; set; }

        public static async Task ScrapeProxiesAsync()
        {
            Console.WriteLine("Getting proxies...");
            var proxies = await GetProxiesAsync();

            Console.WriteLine("Initializing Threads...");
            ActionBlocks = new ActionBlock<string>[proxies.Count()];

            for (var i = 0; i < ActionBlocks.Length; i++)
            {
                ActionBlocks[i] = new ActionBlock<string>(async action => await AddIfAlive(action));
                ActionBlocks[i].Post(proxies.ElementAt(i));
            }

            foreach (var actionBlock in ActionBlocks)
            {
                actionBlock.Complete();
                await actionBlock.Completion;
            }

            Console.WriteLine($"Proxies got. Proxy count = {DataManager.Proxies.Count}\n");
        }

        private static async Task<List<string>> GetProxiesAsync()
        {
            var proxies = new List<string>();

            proxies.AddRange(await ProxyListSite.GetProxiesAsync());
            proxies.AddRange(await ProxyScrapeSite.GetProxiesAsync());
            proxies.AddRange(await FreeProxyListSite.GetProxiesAsync());
            proxies.AddRange(await HideMySite.GetProxiesAsync());

            return proxies.Where(proxy => !string.IsNullOrEmpty(proxy)).Distinct().ToList();
        }

        private static async Task AddIfAlive(string proxy)
        {
            if (await IsAlive(proxy))
            {
                DataManager.Proxies.Enqueue(proxy);
            }
        }

        private static async Task<bool> IsAlive(string proxy)
        {
            try
            {
                using var client = DataManager.HttpClientFactory.CreateClient(proxy);
                client.Timeout = TimeSpan.FromSeconds(15);

                var response = await client.GetAsync(CheckUrl);
                Console.WriteLine($"{proxy} - {response.StatusCode}");
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
