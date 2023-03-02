using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Reports
{
    public partial class CashRegReportGenerator : Form
    {
        DBhelperClass dbh = new DBhelperClass();

        double cash_out_total;
        double starting;
        double ending;
        double ending_plus_cash_out;
        public CashRegReportGenerator()
        {
            InitializeComponent();
        }
        private void fillCbUsers()
        {
            cbUsers.Items.Clear();
            foreach(string user in dbh.Users())
            {
                cbUsers.Items.Add(user);
            }
        }
        private void CashRegReportGenerator_Load(object sender, EventArgs e)
        {
            fillCbUsers();

            dgvCashReg.AutoGenerateColumns = false;
        }
        private void GetEdCash()
        {
            ending = 0;

            if (dgvCashReg.Rows != null)
            {
                foreach (DataGridViewRow r in dgvCashReg.Rows)
                {
                    if (r.Cells["colAction"].Value.ToString().Equals("Ending"))
                    {
                        ending = Convert.ToDouble(r.Cells["colAmount"].Value);
                    }
                }
            }
        }

        private void ComputeEndingPlusCashOut()
        {
            ending_plus_cash_out = ending + cash_out_total;
        }

        private void ComputeTotalCashOut()
        {
            cash_out_total = 0;

            if (dgvCashReg.Rows != null)
            {
                foreach (DataGridViewRow r in dgvCashReg.Rows)
                {
                    if (r.Cells["colAction"].Value.ToString().Equals("Cash Out"))
                    {
                        cash_out_total += Convert.ToDouble(r.Cells["colAmount"].Value);
                    }
                }
            }
            MessageBox.Show(cash_out_total.ToString());
        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            dgvCashReg.DataSource = dbh.ShowCashReg(cbUsers.Text, dt1.Value.ToString("yyyy-MM-dd"));
            ComputeTotalCashOut();
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCashReg.DataSource = dbh.ShowCashReg(cbUsers.Text, dt1.Value.ToString("yyyy-MM-dd"));
            ComputeTotalCashOut();
        }
    }
}
