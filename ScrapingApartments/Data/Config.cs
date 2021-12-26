using System;

namespace ScrapingApartments.Data
{
    public static class Config
    {
        public static readonly Uri BaseUrl = new Uri("https://www.halooglasi.com/");

        public const int ApartmentsNeeded = 45000;
    }
}
