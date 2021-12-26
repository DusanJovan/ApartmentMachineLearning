using ApartmentPricePrediction.Data.Model;
using ApartmentPricePrediction.Data.Type;
using ApartmentPricePrediction.Model.Type;
using ScrapingApartments.Model;
using System;

namespace ApartmentPricePrediction.KnnClassificationPackage
{
    public static class KnnClassification
    {
        public static KnnResultModel EuclidianDistance(Apartment oldApartment, Apartment newApartment)
        {
            var distance = 0.0;

            distance += Math.Sqrt(Math.Sqrt(Math.Abs(oldApartment.ApartmentArea.Value * oldApartment.ApartmentArea.Value - newApartment.ApartmentArea.Value * newApartment.ApartmentArea.Value)));

            distance += Math.Sqrt(Math.Abs(oldApartment.DistanceFromCentre.Value * oldApartment.DistanceFromCentre.Value - newApartment.DistanceFromCentre.Value * newApartment.DistanceFromCentre.Value)) / 2000;
            distance += Math.Sqrt(Math.Abs(oldApartment.AverageMicroLocationPrice * oldApartment.AverageMicroLocationPrice - newApartment.AverageMicroLocationPrice * newApartment.AverageMicroLocationPrice)) / 2000;
            //distance += Math.Sqrt(Math.Abs(oldApartment.AverageStoryPrice * oldApartment.AverageStoryPrice - newApartment.AverageStoryPrice * newApartment.AverageStoryPrice)) / 2000;
            distance += Math.Sqrt(Math.Abs(oldApartment.AverageHeatPrice * oldApartment.AverageHeatPrice - newApartment.AverageHeatPrice * newApartment.AverageHeatPrice)) / 2000;
            distance += Math.Sqrt(Math.Abs(oldApartment.AverageMicroLocationPrice * oldApartment.AverageMicroLocationPrice - newApartment.AverageMicroLocationPrice * newApartment.AverageMicroLocationPrice)) / 2000;

            distance += Math.Sqrt(Math.Abs(Math.Pow(int.Parse(oldApartment.Story), 2) - Math.Pow(int.Parse(newApartment.Story), 2))) / 10;
            distance += Math.Sqrt(Math.Abs(Math.Pow(int.Parse(oldApartment.StoryTotal), 2) - Math.Pow(int.Parse(newApartment.StoryTotal), 2))) / 10;
            distance += Math.Sqrt(Math.Abs(Math.Pow(oldApartment.RoomCount.Value, 2) - Math.Pow(newApartment.RoomCount.Value, 2)));

            distance += Math.Abs((oldApartment.Parking ? 1 : 0) - (newApartment.Parking ? 1 : 0));
            distance += Math.Abs((oldApartment.HasTeraceOrLoggiaOrBalcony ? 1 : 0) - (newApartment.HasTeraceOrLoggiaOrBalcony ? 1 : 0));
            distance += Math.Abs((oldApartment.Registered ? 1 : 0) - (newApartment.Registered ? 1 : 0));
            distance += Math.Abs((oldApartment.YearType == YearType.New ? 1 : 0) - (newApartment.YearType == YearType.New ? 1 : 0));

            return new KnnResultModel()
            {
                Distance = distance,
                Price = oldApartment.Price.Value,
                Class = GetClass(oldApartment.Price.Value),
                Apartment = oldApartment
            };
        }

        public static KnnResultModel ManhattanDistance(Apartment oldApartment, Apartment newApartment)
        {
            var distance = 0.0;

            distance += Math.Sqrt(Math.Abs(oldApartment.ApartmentArea.Value - newApartment.ApartmentArea.Value));
            distance += Math.Abs(oldApartment.DistanceFromCentre.Value - newApartment.DistanceFromCentre.Value) / 2000;
            distance += Math.Abs(oldApartment.AverageMicroLocationPrice - newApartment.AverageMicroLocationPrice) / 2000;
            //distance += Math.Abs(oldApartment.AverageStoryPrice - newApartment.AverageStoryPrice) / 2000;
            distance += Math.Abs(oldApartment.AverageHeatPrice - newApartment.AverageHeatPrice) / 2000;
            distance += Math.Abs(oldApartment.AverageMicroLocationPrice - newApartment.AverageMicroLocationPrice) / 2000;

            distance += Math.Abs(int.Parse(oldApartment.Story) - int.Parse(newApartment.Story)) / 10;
            distance += Math.Abs(int.Parse(oldApartment.StoryTotal) - int.Parse(newApartment.StoryTotal)) / 10;
            distance += Math.Abs(oldApartment.RoomCount.Value - newApartment.RoomCount.Value);

            distance += Math.Abs((oldApartment.Parking ? 1 : 0) - (newApartment.Parking ? 1 : 0));
            distance += Math.Abs((oldApartment.HasTeraceOrLoggiaOrBalcony ? 1 : 0) - (newApartment.HasTeraceOrLoggiaOrBalcony ? 1 : 0));
            distance += Math.Abs((oldApartment.Registered ? 1 : 0) - (newApartment.Registered ? 1 : 0));
            distance += Math.Abs((oldApartment.YearType == YearType.New ? 1 : 0) - (newApartment.YearType == YearType.New ? 1 : 0));

            return new KnnResultModel()
            {
                Distance = distance,
                Price = oldApartment.Price.Value,
                Class = GetClass(oldApartment.Price.Value)
            };
        }

        private static ApartmentClass GetClass(double price)
        {
            if (price <= 50000) return ApartmentClass.Under50;
            if (price <= 100000) return ApartmentClass.Under100;
            if (price <= 150000) return ApartmentClass.Under150;
            if (price <= 200000) return ApartmentClass.Under200;
            else return ApartmentClass.Over200;
        }
    }
}
