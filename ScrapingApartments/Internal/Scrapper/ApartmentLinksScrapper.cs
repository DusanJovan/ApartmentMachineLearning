using HtmlAgilityPack;
using ScrapingApartments.Data;
using ScrapingApartments.Model;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ScrapingApartments.Internal.Scrapper
{
    public class ApartmentLinksScrapper
    {
        public static async Task GetApartmentLinksAsync()
        {
            var actions = new ActionBlock<string>[1];

            for (var i = 0; i < actions.Length; i++)
            {
                actions[i] = new ActionBlock<string>(async proxy => await ScrapeApartmentLinks(proxy));
                DataManager.Proxies.TryDequeue(out var proxy);
                actions[i].Post(proxy);
            }

            foreach (var actionBlock in actions)
            {
                actionBlock.Complete();
                await actionBlock.Completion;
            }

            File.WriteAllLines("apartments.txt", DataManager.ApartmentLinksUrls.Select(x => x.AbsoluteUri));
        }

        #region Private

        private static async Task ScrapeApartmentLinks(string proxy)
        {
            while (DataManager.ApartmentLinksUrls.Count < Config.ApartmentsNeeded)
            {
                try
                {
                    DataManager.ApartmentPagesUrls.TryDequeue(out var endpoint);
                    var html = await HttpMethods.RequestThrowProxyAsync(endpoint, proxy);

                    var webLoader = new HtmlDocument();
                    webLoader.LoadHtml(html);

                    var links = webLoader.DocumentNode.SelectNodes("//a[@class='a-images']").Select(x => x.GetAttributeValue("href", ""));

                    foreach (var link in links)
                        DataManager.ApartmentLinksUrls.Enqueue(new Uri($"{Config.BaseUrl}{link}"));

                    Console.WriteLine(DataManager.ApartmentLinksUrls.Count);
                }
                catch (Exception) { continue; }
            }
        }

        #endregion
    }
}
