using ScrapingApartments.Model;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ScrapingApartments.Internal.Scrapper
{
    public static class HttpMethods
    {
        public static async Task<string> RequestThrowProxyAsync(Uri url, string proxy)
        {
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    using var client = DataManager.HttpClientFactory.CreateClient(proxy);
                    //client.Timeout = TimeSpan.FromSeconds(3);

                    var response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        DataManager.Proxies.Enqueue(proxy);
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception e)
                {

                }
            }

            Thread.Sleep(60000);
            return null;
        }
    }
}
