using ApartmentPricePrediction.Data;
using ApartmentPricePrediction.Data.Model;
using ApartmentPricePrediction.Data.Type;
using ApartmentPricePrediction.KnnClassificationPackage;
using ApartmentPricePrediction.LinearRegressionPackage;
using ApartmentPricePrediction.Model.Type;
using ScrapingApartments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace ApartmentPricePrediction
{
    public partial class KNearestAlgorithmInput : Form
    {
        public KNearestAlgorithmInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prediction.Text = "";
            if (
                KParameter.Text == null ||
                distanceFunction.SelectedItem == null ||
                municipality.SelectedItem == null ||
                microLocation.SelectedItem == null ||
                area.Text == null ||
                yearType.SelectedItem == null ||
                roomCount.Text == null ||
                story.Text == null ||
                heatType.SelectedItem == null
            )
            {
                return;
            }

            var kparameter = 0;
            if (!int.TryParse(KParameter.Text, out kparameter))
            {
                return;
            }

            var areaValue = 0.0;
            if (!double.TryParse(area.Text, out areaValue))
            {
                return;
            }

            var roomCountValue = 0.0;
            if (!double.TryParse(roomCount.Text, out roomCountValue))
            {
                return;
            }

            var storyValue = 0;
            if (!int.TryParse(story.Text, out storyValue))
            {
                return;
            }

            var storyTotalValue = 0;
            if (!int.TryParse(storyTotal.Text, out storyTotalValue))
            {
                return;
            }

            var apartmentAvgPrice = DataManager.Apartments.Average(x => x.Price);
            var newApartment = new Apartment()
            {
                ApartmentArea = areaValue,
                AverageHeatPrice = DataManager.Apartments.First(x => x.HeatType == (string)heatType.SelectedItem).AverageHeatPrice,
                AverageMicroLocationPrice = DataManager.Apartments.First(x => x.Location == (string)municipality.SelectedItem && x.MicroLocation == (string)microLocation.SelectedItem).AverageMicroLocationPrice,
                AverageStoryPrice = DataManager.Apartments.FirstOrDefault(x => x.Story == story.Text)?.AverageMicroLocationPrice ?? apartmentAvgPrice.Value,
                DistanceFromCentre = DataManager.Apartments.First(x => x.Location == (string)municipality.SelectedItem && x.MicroLocation == (string)microLocation.SelectedItem).DistanceFromCentre,
                IsLastStory = storyTotalValue == storyValue,
                Parking = (bool)parking.SelectedItem,
                HasTeraceOrLoggiaOrBalcony = (bool)Terrace.SelectedItem,
                Registered = (bool)registrered.SelectedItem,
                YearType = (YearType)yearType.SelectedItem,
                Story = story.Text,
                StoryTotal = storyTotal.Text,
                RoomCount = double.Parse(roomCount.Text),   
            };

            IEnumerable<KnnResultModel> distances = null;
            if ((DistanceAlgorithm)distanceFunction.SelectedItem == DistanceAlgorithm.Euclidean)
            {
                distances = DataManager.Apartments.Select(x => KnnClassification.EuclidianDistance(x, newApartment));
            }
            else
            {
                distances = DataManager.Apartments.Select(x => KnnClassification.ManhattanDistance(x, newApartment));
            }

            var kApartments = distances.OrderBy(x => x.Distance).Take(kparameter);
            prediction.Text = kApartments.Average(x => x.Price).ToString();

            var classification = ApartmentClass.Under50;
            for (var i = kparameter; i > 0; i--)
            {
                var apartCounters = kApartments.Take(i).GroupBy(value => value.Class).OrderByDescending(group => group.Count());
                if (apartCounters.First().Count() == apartCounters.ElementAt(1).Count()) continue;

                classification = apartCounters.First().First().Class;
                break;
            }
            classPrediction.Text = classification.ToString();
        }

        private void SetInitialData()
        {
            var k = Math.Ceiling(Math.Sqrt(DataManager.Apartments.Count()));
            if (k % 2 == 0) k++;
            KParameter.Text = k.ToString();

            distanceFunction.Items.Add(DistanceAlgorithm.Euclidean);
            distanceFunction.Items.Add(DistanceAlgorithm.Manhattan);
            distanceFunction.SelectedIndex = 0;

            foreach (var location in DataManager.Apartments.Select(x => x.Location).Distinct().OrderBy(x => x))
            {
                municipality.Items.Add(location);
            }
            municipality.SelectedIndex = 0;

            //var selectedMunicipality = (string)municipality.SelectedItem;
            //foreach (var location in DataManager.Apartments.Where(x => x.Location == selectedMunicipality).Select(x => x.MicroLocation).Distinct().OrderBy(x => x))
            //{
            //    microLocation.Items.Add(location);
            //}
            microLocation.SelectedIndex = 0;

            yearType.Items.Add(YearType.New);
            yearType.Items.Add(YearType.Old);
            yearType.SelectedIndex = 0;

            foreach (var heat in DataManager.Apartments.Select(x => x.HeatType).Distinct())
            {
                heatType.Items.Add(heat);
            }
            heatType.SelectedIndex = 0;

            Terrace.Items.Add(true);
            Terrace.Items.Add(false);
            Terrace.SelectedIndex = 0;

            parking.Items.Add(true);
            parking.Items.Add(false);
            parking.SelectedIndex = 0;

            registrered.Items.Add(true);
            registrered.Items.Add(false);
            registrered.SelectedIndex = 0;
        }

        private void municipality_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (var i = microLocation.Items.Count; i > 0; i--)
            {
                microLocation.Items.RemoveAt(i - 1);
            }

            var selectedMunicipality = (string)municipality.SelectedItem;
            foreach (var location in DataManager.Apartments.Where(x => x.Location == selectedMunicipality).Select(x => x.MicroLocation).Distinct().OrderBy(x => x))
            {
                microLocation.Items.Add(location);
            }
            microLocation.SelectedIndex = 0;
        }

        private void KNearestAlgorithmInput_Load(object sender, EventArgs e)
        {
            SetInitialData();
        }
    }
}
