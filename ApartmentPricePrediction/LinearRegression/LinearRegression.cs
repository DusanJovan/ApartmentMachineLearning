using ApartmentPricePrediction.Data;
using ApartmentPricePrediction.Model.Type;
using ScrapingApartments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ApartmentPricePrediction.LinearRegressionPackage
{
    public class LinearRegression
    {
        public static double alpha = 0.1;

        public static double epochs = 10;

        #region weights

        public static double W0 { get; set; } = 1;

        public static double WDistance { get; set; } = -1;

        public static double WArea { get; set; } = 1;

        public static double WRoom { get; set; } = 1;

        public static double WStory { get; set; } = 1;

        public static double WStoryTotal { get; set; } = 1;

        public static double WYear { get; set; } = 1;

        public static double WMicroLocationPrice { get; set; } = 1;

        public static double WHeatPrice { get; set; } = 1;

        public static double WParking { get; set; } = 1;

        public static double WTerrace { get; set; } = 1;

        public static double WRegistered { get; set; } = 1;

        #endregion

        public static void SetWeights()
        {

            var apartments = DataManager.Apartments.OrderBy(x => x.Price);

            var area = apartments.Average(x => x.ApartmentArea);
            var DistanceFromCentre = apartments.Average(x => x.DistanceFromCentre);
            var AverageHeatPrice = apartments.Average(x => x.AverageHeatPrice);
            var AverageMicroLocationPrice = apartments.Average(x => x.AverageMicroLocationPrice);
            var AverageStoryPrice = apartments.Average(x => x.AverageStoryPrice);
            var RoomCount = apartments.Average(x => x.RoomCount);
            var Story = apartments.Average(x => double.Parse(x.Story));
            var StoryTotal = apartments.Average(x => double.Parse(x.StoryTotal));
            var storyPrice = apartments.Average(x => x.AverageStoryPrice);
            foreach (var apartment in apartments)
            {
                apartment.ApartmentArea /= area;
                apartment.DistanceFromCentre /= DistanceFromCentre;
                apartment.AverageHeatPrice /= AverageHeatPrice;
                apartment.AverageMicroLocationPrice /= AverageMicroLocationPrice;
                apartment.AverageStoryPrice /= AverageStoryPrice;
                apartment.RoomCount /= RoomCount;
                apartment.Story = (double.Parse(apartment.Story) / Story).ToString();
                apartment.StoryTotal = (double.Parse(apartment.StoryTotal) / StoryTotal).ToString();
                apartment.AverageStoryPrice /= storyPrice;
            }

            var train = apartments.Where((_, i) => !new int[] { 2, 5, 8 }.Contains(i % 10));
            var test = apartments.Where((_, i) => new int[] { 2, 5, 8 }.Contains(i % 10));

            double oldError;
            double newError;
            int i = 0;
            do
            {
                i++;
                var count = train.Count();
                var new_w0 = W0 - alpha * train.Average(x => HeuristicDifference(x));
                var new_warea = WArea - alpha * train.Average(x => HeuristicDifference(x) * x.ApartmentArea.Value);
                var new_wdistance = WDistance + alpha * train.Average(x => HeuristicDifference(x) * x.DistanceFromCentre.Value);
                var new_wstory = WStory - alpha * train.Average(x => HeuristicDifference(x) * double.Parse(x.Story));
                var new_wstory_total = WStoryTotal - alpha * train.Average(x => HeuristicDifference(x) * double.Parse(x.StoryTotal));
                var new_wroom = WRoom - alpha * train.Average(x => HeuristicDifference(x) * double.Parse(x.Story));
                var new_wheat = WHeatPrice - alpha * train.Average(x => HeuristicDifference(x) * x.AverageHeatPrice);
                var new_wlocation = WMicroLocationPrice - alpha * train.Average(x => HeuristicDifference(x) * x.AverageMicroLocationPrice);
                var new_wparking = WParking - alpha * train.Average(x => HeuristicDifference(x) * (x.Parking ? 1 : 0));
                var new_wregistered = WRegistered - alpha * train.Average(x => HeuristicDifference(x) * (x.Registered ? 1 : 0));
                var new_wterrace = WTerrace - alpha * train.Average(x => HeuristicDifference(x) * (x.Terrace ? 1 : 0));
                var new_wyear = WYear - alpha * train.Average(x => HeuristicDifference(x) * (x.YearType == YearType.New ? 1 : 0));

                oldError = AverageErrorInTestData(test);

                W0 = new_w0;
                WArea = new_warea;
                WDistance = new_wdistance;
                WStory = new_wstory;
                WStoryTotal = new_wstory_total;
                WRoom = new_wroom;
                WHeatPrice = new_wheat;
                WMicroLocationPrice = new_wlocation;
                WParking = new_wparking;
                WRegistered = new_wregistered;
                WTerrace = new_wterrace;
                WYear = new_wyear;

                newError = AverageErrorInTestData(test);

                File.AppendAllText("./nesto", $"{newError} - {oldError} - {1 - newError / oldError}\n");
            } while (i < 3 || oldError > newError + 0.1);

            WArea /= area.Value;
            WDistance /= DistanceFromCentre.Value;
            WHeatPrice /= AverageHeatPrice;
            WMicroLocationPrice /= AverageMicroLocationPrice;
            WStory /= Story;
            WStoryTotal /= StoryTotal;
            WRoom /= RoomCount.Value;
             
            foreach (var apartment in apartments)
            {
                apartment.ApartmentArea *= area;
                apartment.DistanceFromCentre *= DistanceFromCentre;
                apartment.AverageHeatPrice *= AverageHeatPrice;
                apartment.AverageMicroLocationPrice *= AverageMicroLocationPrice;
                apartment.AverageStoryPrice *= AverageStoryPrice;
                apartment.RoomCount *= RoomCount;
                apartment.Story = (double.Parse(apartment.Story) * Story).ToString();
                apartment.StoryTotal = (double.Parse(apartment.StoryTotal) * StoryTotal).ToString();
                apartment.AverageStoryPrice *= storyPrice;
            }
        }

        public static double HeuristicDifference(Apartment apartment)
        {
            return HeuristicFunction(apartment) - apartment.Price.Value;
        }

        public static double Error(Apartment apartment) => Math.Abs(HeuristicDifference(apartment));

        public static double AverageErrorInTestData(IEnumerable<Apartment> apartments)
        {
            var errorSum = apartments.Sum(apartment => Error(apartment));

            return errorSum / apartments.Count();
        }

        public static double HeuristicFunction(Apartment apartment)
        {
            return
                W0 +
                WArea * apartment.ApartmentArea.Value +
                WDistance * apartment.DistanceFromCentre.Value +
                WStory * double.Parse(apartment.Story) +
                WStoryTotal * double.Parse(apartment.StoryTotal) +
                WRoom * apartment.RoomCount.Value +
                WHeatPrice * apartment.AverageHeatPrice +
                WMicroLocationPrice * apartment.AverageMicroLocationPrice +
                WParking * (apartment.Parking ? 1 : 0) +
                WRegistered * (apartment.Registered ? 1 : 0) +
                WTerrace * (apartment.HasTeraceOrLoggiaOrBalcony ? 1 : 0) +
                WYear * (apartment.YearType == YearType.New ? 1 : 0);
        }
    }
}
