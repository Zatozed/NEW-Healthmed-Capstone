using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Reports
{
    public partial class CashRegReportGenerator : Form
    {
        DBhelperClass dbh = new DBhelperClass();

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

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            dgvCashReg.DataSource = dbh.ShowCashReg(cbUsers.Text, dt1.Value.ToString("yyyy-MM-dd"));
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCashReg.DataSource = dbh.ShowCashReg(cbUsers.Text, dt1.Value.ToString("yyyy-MM-dd"));
        }
    }
}
