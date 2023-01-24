using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Reports
{
    public partial class ReportsMenu : Form
    {
        public ReportsMenu()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SalesReport sr = new SalesReport();
            sr.ShowDialog();
        }
    }
}
