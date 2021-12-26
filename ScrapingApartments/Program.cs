using Microsoft.Extensions.DependencyInjection;
using ScrapingApartments.Data.Provider;
using ScrapingApartments.Internal.Scrapper;
using ScrapingApartments.Model;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScrapingApartments
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var startTime = DateTime.Now;
            Console.WriteLine($"Program starting at: {startTime:MM.dd HH:mm:ss}");

            DataManager.HttpClientFactory = new ServiceCollection()
               .AddHttpClient()
               .BuildServiceProvider()
               .GetService<IHttpClientFactory>();

            await ProxyScrapper.ScrapeProxiesAsync();

            if (false)
            {
                await ApartmentPagesScrapper.GetApartmentPagesAsync();
                await ApartmentLinksScrapper.GetApartmentLinksAsync();
            }
            else
            {
                var links = File.ReadAllLines("apartments.txt").Distinct();
                DataManager.ApartmentLinksUrls = new ConcurrentQueue<Uri>(links.Select(x => new Uri(x)).Distinct());
            }

            using (var context = new ApartmentContext())
            {
                DataManager.Apartments = context.Apartments.ToList();
            }

            //DataManager.AlreadyScrappedUrls = DataManager.Apartments.Select(x => x.Link).ToList();

            //await ApartmentsScrapper.GetApartmentsAsync();

            await ApartmentLocationScrapper.ScrapeAsync();

            File.WriteAllLines("logs.txt", DataManager.Logs);

            var endTime = DateTime.Now;
            Console.WriteLine($"Program ending at: {endTime:MM.dd HH:mm:ss}");
            Console.WriteLine($"Time elapsed: {endTime - startTime}");
        }
    }
}
