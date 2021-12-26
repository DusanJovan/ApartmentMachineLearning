using HtmlAgilityPack;
using ScrapingApartments.Data;
using ScrapingApartments.Data.Provider;
using ScrapingApartments.Model;
using ScrapingApartments.Model.Type;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ScrapingApartments.Internal.Scrapper
{
    public class ApartmentsScrapper
    {

        public static async Task GetApartmentsAsync()
        {
            var actions = new ActionBlock<string>[1];

            for (var i = 0; i < actions.Length; i++)
            {
                actions[i] = new ActionBlock<string>(async proxy => await ScrapeApartment(proxy));
                DataManager.Proxies.TryDequeue(out var proxy);
                actions[i].Post(proxy);
            }

            foreach (var actionBlock in actions)
            {
                actionBlock.Complete();
                await actionBlock.Completion;
            }
        }

        #region Private

        private static async Task ScrapeApartment(string proxy)
        {
            while (DataManager.Apartments.Count < Config.ApartmentsNeeded)
            {
                DataManager.ApartmentLinksUrls.TryDequeue(out var endpoint);
                if (DataManager.AlreadyScrappedUrls.Contains(endpoint.AbsoluteUri))
                {
                    continue;
                }

                var html = await HttpMethods.RequestThrowProxyAsync(endpoint, proxy);

                var apartment = GetApartment(html, endpoint.AbsoluteUri);

                DataManager.Apartments.Add(apartment);
                using (var context = new ApartmentContext())
                {
                    context.Apartments.Add(apartment);
                    context.SaveChanges();
                }
                if (DataManager.Apartments.Count % 50 == 0)
                {
                    Console.WriteLine(DataManager.Apartments.Count);
                }
            }
        }

        private static Apartment GetApartment(string html, string url)
        {
            var webLoader = new HtmlDocument();
            webLoader.LoadHtml(html);

            var actionType = url.StartsWith("https://www.halooglasi.com//nekretnine/izdavanje-kuca") || url.StartsWith("https://www.halooglasi.com//nekretnine/izdavanje-stanova") ? ActionType.Rent : ActionType.Buy;
            var apartmentType = url.StartsWith("https://www.halooglasi.com//nekretnine/prodaja-stanova") || url.StartsWith("https://www.halooglasi.com//nekretnine/izdavanje-stanova") ? ApartmentType.Flat : ApartmentType.House;

            var pricePattern = @".price.:([^,]+)";
            var match = Regex.Match(html, pricePattern);
            var priceRegex = match.Success ? match.Groups[1].Value : null;
            double.TryParse(priceRegex, out var price);

            var areaPattern = @".kvadratura_d.:([^,]+)";
            match = Regex.Match(html, areaPattern);
            var areaRegex = match.Success ? match.Groups[1].Value : null;
            double.TryParse(areaRegex, out var apartmentArea);

            var yardPattern = @"""povrsina_placa_d"":([^,]+)";
            match = Regex.Match(html, yardPattern);
            var yardRegex = match.Success ? match.Groups[1].Value : null;
            double.TryParse(yardRegex, out var yardArea);

            var citypattern = @"""grad_s"":""([^""]+)""";
            match = Regex.Match(html, citypattern);
            var city = match.Success ? match.Groups[1].Value : null;

            var locationPattern = @"""lokacija_s"":""([^""]+)""";
            match = Regex.Match(html, locationPattern);
            var location = match.Success ? match.Groups[1].Value : null;

            var yearPattern = @"""tip_objekta_s"":""Novogradnja""";
            match = Regex.Match(html, yearPattern);
            var year = match.Success ? YearType.New : YearType.Old;

            var microLocationPattern = @"""mikrolokacija_s"":""([^""]+)""";
            match = Regex.Match(html, microLocationPattern);
            var microLocation = match.Success ? match.Groups[1].Value : null;

            var roomPattern = @"""broj_soba_s"":""([^""]+)""";
            match = Regex.Match(html, roomPattern);
            var roomRegex = match.Success ? match.Groups[1].Value : null;
            double.TryParse(roomRegex, out var roomCount);

            var storyPattern = @"""sprat_s"":""([^""]+)""";
            match = Regex.Match(html, storyPattern);
            var story = match.Success ? match.Groups[1].Value : null;

            var storyTotalPattern = @"""sprat_od_s"":""([^""]+)""";
            match = Regex.Match(html, storyTotalPattern);
            var storyTotal = match.Success ? match.Groups[1].Value : null;

            var heatPattern = @"""grejanje_s"":""([^""]+)""";
            match = Regex.Match(html, heatPattern);
            var heat = match.Success ? match.Groups[1].Value : null;

            var additionalDataPattern = @"""dodatno_ss"":\[(.+)\]";
            match = Regex.Match(html, additionalDataPattern);
            var additionalData = match.Success ? match.Groups[1].Value : null;

            var otherDataPattern = @"""""ostalo_ss"":\[(.+)\]";
            match = Regex.Match(html, otherDataPattern);
            var otherData = match.Success ? match.Groups[1].Value : null;

            var allData = (otherData + additionalData).ToLower();

            return new Apartment()
            {
                Link = url,
                ApartmentType = apartmentType,
                ActionType = actionType,
                Price = price,
                ApartmentArea = apartmentArea,
                YardArea = yardArea,
                City = city,
                Location = location,
                MicroLocation = microLocation,
                RoomCount = roomCount,
                Story = story,
                StoryTotal = storyTotal,
                HeatType = heat,
                YearType = year,
                Elevator = allData.Contains("lift"),
                Balcony = allData.Contains("francuski balkon"),
                Terrace = allData.Contains("terasa"),
                Loggia = allData.Contains("lođa"),
                Parking = allData.Contains("parking"),
                Registered = allData.Contains("uknjižen")
            };
        }

        #endregion
    }
}
