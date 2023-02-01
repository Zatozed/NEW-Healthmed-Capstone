using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class CashRegister : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        public CashRegister()
        {
            InitializeComponent();
        }

        private void CashRegister_Load(object sender, EventArgs e)
        {
            lbDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
