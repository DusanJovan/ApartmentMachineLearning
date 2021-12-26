using ScrapingApartments.Model.Type;
using System.ComponentModel.DataAnnotations;

namespace ScrapingApartments.Model
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }

        public string Link { get; set; }

        public ApartmentType ApartmentType { get; set; }

        public ActionType ActionType { get; set; }

        public YearType YearType { get; set; }

        public double? Price { get; set; }

        public double? ApartmentArea { get; set; }

        public double? YardArea { get; set; }

        public string? City { get; set; }

        public string? Location { get; set; }

        public string? MicroLocation { get; set; }

        public double? DistanceFromCentre { get; set; }

        public double? RoomCount { get; set; }

        public string? Story { get; set; }

        public string? StoryTotal { get; set; }

        public string? HeatType { get; set; }

        public bool Registered { get; set; }

        public bool Parking { get; set; }

        public bool Elevator { get; set; }

        public bool Terrace { get; set; }

        public bool Balcony { get; set; }

        public bool Loggia { get; set; }

        public double AverageStoryPrice { get; set; }

        public double AverageMicroLocationPrice { get; set; }

        public double AverageHeatPrice { get; set; }

        public bool IsLastStory { get; set; }

        public bool HasTeraceOrLoggiaOrBalcony { get; set; }
    }
}
