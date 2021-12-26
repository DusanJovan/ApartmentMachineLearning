using ApartmentPricePrediction.Data.Type;
using ScrapingApartments.Model;

namespace ApartmentPricePrediction.Data.Model
{
    public class KnnResultModel
    {
        public double Distance { get; set; }

        public double Price { get; set; }

        public ApartmentClass Class { get; set; }

        public Apartment Apartment { get; set; }
    }

    public class KnnClassCounter
    {
        public ApartmentClass Class { get; set; }

        public int Count { get; set; }
    }
}
