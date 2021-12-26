using ScrapingApartments.Data.Provider;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;

namespace ScrapingApartments.Model
{
    public static class DataManager
    {
        public static IHttpClientFactory HttpClientFactory;

        public static ConcurrentQueue<string> Proxies { get; set; } = new ConcurrentQueue<string>();

        public static BlockingCollection<string> Logs { get; set; } = new BlockingCollection<string>();

        public static ConcurrentQueue<Uri> ApartmentPagesUrls { get; set; } = new ConcurrentQueue<Uri>();

        public static ConcurrentQueue<Uri> ApartmentLinksUrls { get; set; } = new ConcurrentQueue<Uri>();

        public static List<Apartment> Apartments { get; set; } = new List<Apartment>();

        public static List<string> AlreadyScrappedUrls { get; set; } = new List<string>();
    }
}
