using ApartmentPricePrediction.Data;
using ApartmentPricePrediction.Data.Type;
using ApartmentPricePrediction.LinearRegressionPackage;
using ApartmentPricePrediction.Model.Type;
using ScrapingApartments.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ApartmentPricePrediction
{
    public partial class LinearRegressionInput : Form
    {
        public LinearRegressionInput()
        {
            InitializeComponent();
        }

        private void SetInitialData()
        {
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
            //microLocation.SelectedIndex = 0;

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

            LinearRegression.SetWeights();

            averageError.Text = DataManager.AverageErorr.ToString();

            weightsLabel.Text = $"W0: {Math.Round(LinearRegression.W0, 2)}, WArea: {Math.Round(LinearRegression.WArea, 2)}, WDistance: {Math.Round(LinearRegression.WDistance, 2)}, WStory: {Math.Round(LinearRegression.WStory, 2)}, WStoryTotal: {Math.Round(LinearRegression.WStoryTotal, 2)}, WRoom: {Math.Round(LinearRegression.WRoom, 2)}\n" +
                $"WHeat: {Math.Round(LinearRegression.WHeatPrice, 2)}, WLocation: {Math.Round(LinearRegression.WMicroLocationPrice, 2)}, WParking: {Math.Round(LinearRegression.WParking, 2)}, WRegistered: {Math.Round(LinearRegression.WRegistered, 2)}, WTerrace: {Math.Round(LinearRegression.WTerrace, 2)}, WYear: {Math.Round(LinearRegression.WYear, 2)}";
        }

        private void LinearRegressionInput_Load(object sender, System.EventArgs e)
        {
            SetInitialData();
        }

        private void municipality_SelectedIndexChanged(object sender, System.EventArgs e)
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            prediction.Text = "";
            if (
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

            if (!double.TryParse(area.Text, out double areaValue))
            {
                return;
            }

            if (!double.TryParse(roomCount.Text, out double roomCountValue))
            {
                return;
            }

            if (!int.TryParse(story.Text, out int storyValue))
            {
                return;
            }

            if (!int.TryParse(storyTotal.Text, out int storyTotalValue))
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
                RoomCount = double.Parse(roomCount.Text)
            };

            prediction.Text = LinearRegression.HeuristicFunction(newApartment).ToString();
        }
    }
}
