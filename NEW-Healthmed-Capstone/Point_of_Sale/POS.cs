using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class POS : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        public POS()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbTime.Text = DateTime.Now.ToString("hh:mm tt");
            //dgvDrugs.AutoGenerateColumns = false;
            dgvDrugs.DataSource = dbh.ShowProductList();
            //dgvDrugs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // if tab name tabPharmaDrugs
            // else if tab name non drugs
        }

        private void dgvDrugs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDrugs.Columns[e.ColumnIndex].Name.Equals("colAdd"))
            {

                dgvCart.Rows.Add(dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value.ToString(),
                    dgvDrugs.Rows[e.RowIndex].Cells["colProdName"].Value.ToString()+" "+ dgvDrugs.Rows[e.RowIndex].Cells["colDosage"].Value.ToString()
                    );

                MessageBox.Show("add");
            }
        }
    }
}
