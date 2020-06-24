using System;
using System.Windows.Forms;
using TournamentLibrary.Configuration;
using TournamentLibrary.Models;

namespace TournamentUI
{
    public partial class CreatePrizeForm : Form
    {
        private IPrizeRequester requester;

        public CreatePrizeForm(IPrizeRequester prizeRequester)
        {
            requester = prizeRequester;
            InitializeComponent();
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
               PrizeModel prizeModel = new PrizeModel(
                   PlaceNumberValue.Text, 
                   PlaceNameValue.Text, 
                   PrizeAmountValue.Text, 
                   PrizePercentageValue.Text);

               GlobalConfig.Connections.CreatePrize(prizeModel);

               requester.PrizeComplete(prizeModel);
               this.Close();
            }
            else
            {
                MessageBox.Show("Information not complete. Please fill all fields");
            }
        }

        private bool ValidateForm()
        {
            var output = true;
            var placeNumber = 0;
            var placeNumberValid = int.TryParse(PlaceNumberValue.Text, out placeNumber);
            if (placeNumberValid == false)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (PlaceNumberValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;
            bool prizeAmountValid = decimal.TryParse(PrizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(PrizePercentageValue.Text, out prizePercentage);

            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0 || prizePercentage > 100)
            {
                output = false; 
            }

            return output;
        }
    }
}