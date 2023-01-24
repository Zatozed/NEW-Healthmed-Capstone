using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class CashTender : Form
    {
        private double total, change, cash;

        private void btnDone_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Cash = tbCash.Text;
            Properties.Settings.Default.Change = tbChange.Text;
            this.Close();
        }

        public CashTender(double _total)
        {
            InitializeComponent();
            tbTotal.Text = _total.ToString();
            total= _total;
        }
        private void tbCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cash = Convert.ToDouble(tbCash.Text);
                change = cash - total;
                tbChange.Text = change.ToString();
            }
            catch (Exception mat) { }
            finally { }
        }
    }
}
