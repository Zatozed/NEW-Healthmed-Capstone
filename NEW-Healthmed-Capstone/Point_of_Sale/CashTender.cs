using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class CashTender : Form
    {
        private double total, change, cash;
        public CashTender(double _total)
        {
            InitializeComponent();
            tbTotal.Text = _total.ToString("0.00");
            total = _total;
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Cash = cash.ToString("0.00");
            Properties.Settings.Default.Change = tbChange.Text;
            this.Close();
        }

        private void CashTender_Load(object sender, EventArgs e)
        {
            tbCash.Text = "0";
        }

        private void tbCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        
        private void tbCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cash = Convert.ToDouble(tbCash.Text);
                change = cash - total;
                tbChange.Text = change.ToString("0.00");

                if (change <= -1)
                {
                    btnDone.Enabled = false;
                    Properties.Settings.Default.isPayed = false;
                }
                else
                {
                    btnDone.Enabled = true;
                    Properties.Settings.Default.isPayed= true;
                } 

            }
            catch (Exception mat) 
            {
                btnDone.Enabled = false;
                Properties.Settings.Default.isPayed = false;
            }
            finally {  }
        }
    }
}
