using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Reports
{
    public partial class SalesReport : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        public SalesReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            dgvSales.DataSource = dbh.ShowSales();
        }
    }
}
