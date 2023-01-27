using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.DatePicker
{
    public partial class ExpirySetter : Form
    {
        public ExpirySetter()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExpiryDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            this.Close();
        }
    }
}
