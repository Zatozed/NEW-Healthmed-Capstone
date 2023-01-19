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
                // if dgv has values
                if (dgvCart.RowCount != 0)
                {
                    // same product
                    int matchCount = 0;
                    foreach (DataGridViewRow r in dgvCart.Rows)
                    {
                        if (dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value.ToString().Equals(r.Cells["colProdCodeCart"].Value.ToString())) // if match ++ count
                            matchCount++;
                    }
                    if (matchCount == 0)
                    {
                        dgvCart.Rows.Add(dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value.ToString(),
                            dgvDrugs.Rows[e.RowIndex].Cells["colProdName"].Value.ToString() + " " + dgvDrugs.Rows[e.RowIndex].Cells["colDosage"].Value.ToString(),
                            "1",
                            dgvDrugs.Rows[e.RowIndex].Cells["colUnitCost"].Value.ToString(),
                            dgvDrugs.Rows[e.RowIndex].Cells["colUnitPrice"].Value.ToString()
                            );
                    }
                    else
                        MessageBox.Show("Item Alreadty in Cart");
                    
                }
                else // if no value
                {
                    dgvCart.Rows.Add(dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value.ToString(),
                        dgvDrugs.Rows[e.RowIndex].Cells["colProdName"].Value.ToString() + " " + dgvDrugs.Rows[e.RowIndex].Cells["colDosage"].Value.ToString(),
                        "1",
                        dgvDrugs.Rows[e.RowIndex].Cells["colUnitCost"].Value.ToString(),
                        dgvDrugs.Rows[e.RowIndex].Cells["colUnitPrice"].Value.ToString()
                        );
                }
            }
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name.Equals("colMinus1") )
            {
                dgvCart.Rows[e.RowIndex].Cells["colQtyCart"].Value = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["colQtyCart"].Value.ToString()) - 1;
                if (Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["colQtyCart"].Value.ToString()) <= 0)
                {
                    dgvCart.Rows.RemoveAt(e.RowIndex);
                }
            }
            else if (dgvCart.Columns[e.ColumnIndex].Name.Equals("colPlus1")) 
            {
                dgvCart.Rows[e.RowIndex].Cells["colQtyCart"].Value = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["colQtyCart"].Value.ToString()) + 1;
            }
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
