using ApartmentPricePrediction.Data;
using ApartmentPricePrediction.Model.Type;
using ScrapingApartments.Data.Provider;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ApartmentPricePrediction
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new InputAlgorithm());

            DataManager.Apartments = new ApartmentContext().Apartments.OrderBy(x => x.Price);

            //for (var i = 0; i < Math.Ceiling((double)DataManager.Apartments.Count() / 10); i++)
            //{
            //    var nextTenElements = DataManager.Apartments.Skip(i * 10).Take(10).OrderBy(x => new Random().Next());

            //    DataManager.ApartmentsLearning = nextTenElements.Take(7);
            //    DataManager.ApartmentsTesting = nextTenElements.Skip(7).Take(3);
            //}

            if (DataManager.AlgorithmType == AlgorithmType.Linear)
                Application.Run(new LinearRegressionInput());
            else
                Application.Run(new KNearestAlgorithmInput());
        }
    }
}
