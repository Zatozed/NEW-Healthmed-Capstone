using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class PurchaseOrder : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            dgvDrugs.DataSource = dbh.ShowProductSupplier();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
        }

        private void dgvDrugs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDrugs.Columns[e.ColumnIndex].Name.Equals("colAdd")) 
            {
                if (dgvOrders.RowCount != 0)
                {
                    // same product
                    int matchCount = 0;
                    foreach (DataGridViewRow r in dgvOrders.Rows)
                    {
                        if (dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value.ToString().Equals(r.Cells["colProductCode"].Value.ToString())) // if match ++ count
                            matchCount++;
                    }
                    if (matchCount == 0) //if no match found
                    {
                        dgvOrders.Rows.Add("",
                            "",
                            dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value,
                            dgvDrugs.Rows[e.RowIndex].Cells["colProdName"].Value + " " + dgvDrugs.Rows[e.RowIndex].Cells["colClass"].Value + " " + dgvDrugs.Rows[e.RowIndex].Cells["colDosage"].Value + " " + dgvDrugs.Rows[e.RowIndex].Cells["colType"].Value
                            );
                    }
                    else
                        MessageBox.Show("Item Alreadty in Orders");

                }
                else // if no value
                {
                    dgvOrders.Rows.Add("",
                            "",
                            dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value,
                            dgvDrugs.Rows[e.RowIndex].Cells["colProdName"].Value + " " + dgvDrugs.Rows[e.RowIndex].Cells["colClass"].Value + " " + dgvDrugs.Rows[e.RowIndex].Cells["colDosage"].Value + " " + dgvDrugs.Rows[e.RowIndex].Cells["colType"].Value
                            );
                }
            }
        }

    }
}
