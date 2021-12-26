using ApartmentPricePrediction.Data;
using System;
using System.Windows.Forms;

namespace ApartmentPricePrediction
{
    public partial class InputAlgorithm : Form
    {
        public InputAlgorithm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataManager.AlgorithmType = AlgorithmType.Linear;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataManager.AlgorithmType = AlgorithmType.KNearest;
            Close();
        }
    }
}
