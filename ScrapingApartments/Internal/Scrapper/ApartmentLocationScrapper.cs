using ScrapingApartments.Data.Provider;
using ScrapingApartments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScrapingApartments.Internal.Scrapper
{
    public static class ApartmentLocationScrapper
    {
        public static async Task ScrapeAsync()
        {
            var scrappedLocations = new Dictionary<int, double>();
            using var context = new ApartmentContext();
            var i = 0;
            //var apartments = context.Apartments.Where(x => x.City.ToLower() == "beograd" && x.DistanceFromCentre == 10000).OrderBy(x => x.MicroLocation).ToList();
            var apartments = context.Apartments.Where(x => x.City.ToLower() == "beograd" && x.ApartmentType == Model.Type.ApartmentType.Flat && x.ActionType == Model.Type.ActionType.Buy).OrderBy(x => x.MicroLocation).ToList();
            foreach (var apartment in apartments)
            {
                Console.WriteLine($"{++i} / {apartments.Count()}");
                var hash = apartment.Location.GetHashCode() + apartment.MicroLocation.GetHashCode();

                if (scrappedLocations.TryGetValue(hash, out var distance))
                {
                    apartment.DistanceFromCentre = distance;
                }
                else
                {
                    var client = DataManager.HttpClientFactory.CreateClient("PostmanRuntime/7.26.8");

                    var searchString = $"Beograd {apartment.Location} {apartment.MicroLocation}".Replace(" ", "%20");

                    //var message = new HttpRequestMessage();
                    //message.Headers.Add("referer", $"https://nominatim.openstreetmap.org/ui/search.html?q={searchString}");
                    //message.RequestUri = new Uri($"https://nominatim.openstreetmap.org/search.php?q={searchString}&polygon_geojson=1&format=jsonv2");

                    //var response = await client.SendAsync(message);
                    //var content = await response.Content.ReadAsAsync<IEnumerable<NominatimResponse>>();

                    //if (!content.Any())
                    //{
                        //await Task.Delay(2000);
                        var searchStringLocation = $"Beograd {apartment.Location}".Replace(" ", "%20");

                        var messageLocation = new HttpRequestMessage();
                        messageLocation.Headers.Add("referer", "https://nominatim.openstreetmap.org/ui/search.html?q={searchStringLocation}");
                        messageLocation.RequestUri = new Uri($"https://nominatim.openstreetmap.org/search.php?q={searchStringLocation}&polygon_geojson=1&format=jsonv2");

                        var responseLocation = await client.SendAsync(messageLocation);
                        var contentLocation = await responseLocation.Content.ReadAsAsync<IEnumerable<NominatimResponse>>();

                        if (!contentLocation.Any())
                        {
                            apartment.DistanceFromCentre = 10000;
                            scrappedLocations.Add(hash, apartment.DistanceFromCentre.Value);
                        }
                        else
                        {
                            apartment.DistanceFromCentre = GetDistance(contentLocation.First().Lon, contentLocation.First().Lat);
                            scrappedLocations.Add(hash, apartment.DistanceFromCentre.Value);
                        }
                    //}
                    //else
                    //{
                    //    apartment.DistanceFromCentre = GetDistance(content.First().Lon, content.First().Lat);
                    //    scrappedLocations.Add(hash, apartment.DistanceFromCentre.Value);
                    //}
                    await Task.Delay(2000);
                }

                context.SaveChanges();
            }
        }

        private static double GetDistance(double longitude, double latitude, double otherLongitude = 20.4568974, double otherLatitude = 44.8178131)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
