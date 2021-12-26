using ScrapingApartments.Model;
using System.Collections.Generic;

namespace ApartmentPricePrediction.Data
{
    public class DataManager
    {
        public static AlgorithmType AlgorithmType { get; set; }

        public static IEnumerable<Apartment> Apartments { get; set; }

        public static double AverageErorr { get; set; }
    }
}
