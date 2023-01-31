using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class PettyCash : Form
    {

        private double totalC1 = 0;
        private double totalC5 = 0;
        private double totalC10 = 0;
        private double totalC25 = 0;

        private double totalP1 = 0;
        private double totalP5 = 0;
        private double totalP10 = 0;
        private double totalP20 = 0;

        private double totalP50 = 0;
        private double totalP100 = 0;
        private double totalP200 = 0;
        private double totalP500 = 0;
        private double totalP1000 = 0;

        private double total = 0;
        public PettyCash()
        {
            InitializeComponent();
        }

        private void ComputeTotal() 
        {
            total = totalC1 + totalC5 + totalC10 + totalC25 +
                totalP1 + totalP5 + totalP10 + totalP20 +
                totalP50 + totalP100 + totalP200 + totalP500 +
                totalP1000;

            lbTotal.Text = total.ToString("0.00");
        }

        private void nCent1_ValueChanged(object sender, EventArgs e)
        {
            totalC1 = (Double)nCent1.Value * 0.01;
            ComputeTotal();
        }

        private void nCents5_ValueChanged(object sender, EventArgs e)
        {
            totalC5 = (Double)nCents5.Value * 0.05;
            ComputeTotal();
        }

        private void nCents10_ValueChanged(object sender, EventArgs e)
        {
            totalC10 = (Double)nCents10.Value * 0.10;
            ComputeTotal();
        }

        private void nCents25_ValueChanged(object sender, EventArgs e)
        {
            totalC25 = (Double)nCents25.Value * 0.25;
            ComputeTotal();
        }

        private void nPeso1_ValueChanged(object sender, EventArgs e)
        {
            totalP1 = (Double)nPeso1.Value * 1;
            ComputeTotal();
        }

        private void nPeso5_ValueChanged(object sender, EventArgs e)
        {
            totalP5 = (Double)nPeso5.Value * 5;
            ComputeTotal();
        }

        private void nPeso10_ValueChanged(object sender, EventArgs e)
        {
            totalP10 = (Double)nPeso10.Value * 10;
            ComputeTotal();
        }

        private void nPeso20_ValueChanged(object sender, EventArgs e)
        {
            totalP20 = (Double)nPeso20.Value * 20;
            ComputeTotal();
        }

        private void nPeso50_ValueChanged(object sender, EventArgs e)
        {
            totalP50 = (Double)nPeso50.Value * 50;
            ComputeTotal();
        }

        private void nPeso100_ValueChanged(object sender, EventArgs e)
        {
            totalP100 = (Double)nPeso100.Value * 100;
            ComputeTotal();
        }

        private void nPeso200_ValueChanged(object sender, EventArgs e)
        {
            totalP200 = (Double)nPeso200.Value * 200;
            ComputeTotal();
        }

        private void nPeso500_ValueChanged(object sender, EventArgs e)
        {
            totalP500 = (Double)nPeso500.Value * 500;
            ComputeTotal();
        }

        private void nPeso1000_ValueChanged(object sender, EventArgs e)
        {
            totalP1000 = (Double)nPeso1000.Value * 1000;
            ComputeTotal();
        }
    }
}
