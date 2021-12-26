using ScrapingApartments.Common;
using ScrapingApartments.Data;
using ScrapingApartments.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ScrapingApartments.Internal.Scrapper
{
    public class ApartmentPagesScrapper
    {
        #region Consts

        private static readonly List<string> ApartmentTypeUrls = new List<string>() { "nekretnine/prodaja-stanova", "nekretnine/izdavanje-stanova", "nekretnine/prodaja-kuca", "nekretnine/izdavanje-kuca" };

        #endregion

        public static async Task GetApartmentPagesAsync()
        {
            var pages = new List<Uri>();
            for (var i = 0; i < ApartmentTypeUrls.Count; i++)
            {
                var availableProxy = DataManager.Proxies.TryDequeue(out var proxy);
                if (!availableProxy) { Thread.Sleep(3000); continue; }

                var endpoint = ApartmentTypeUrls.ElementAt(i);
                var html = await HttpMethods.RequestThrowProxyAsync(new Uri($"{Config.BaseUrl}/{endpoint}"), proxy);

                var pattern = @".TotalPages.:(\d+)";
                var match = Regex.Match(html, pattern);

                var numOfPages = int.Parse(match.Groups[1].Value);

                for (var j = i; j < numOfPages; j++)
                    pages.Add(new Uri(Config.BaseUrl, $"{endpoint}?page={j}"));
            }

            var shuffledPages = pages.Randomize();
            DataManager.ApartmentPagesUrls = new ConcurrentQueue<Uri>(shuffledPages);
        }
    }
}
