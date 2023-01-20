using MySqlX.XDevAPI.Common;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class POS : Form
    {
        private DBhelperClass dbh = new DBhelperClass();
        private int rowIdx;
        private double subtotal, vatable, vat, vatxmpt, discount, total;
        public POS()
        {
            InitializeComponent();
        }
        private double ComputeSubTotal()
        {
            double sumResult = 0;
            if (dgvCart.RowCount != 0)
            {
                foreach (DataGridViewRow r in dgvCart.Rows)
                {
                    sumResult += Convert.ToDouble(r.Cells["colQtyCart"].Value) * Convert.ToDouble(r.Cells["colUnitPriceCart"].Value);
                }
            }
            return Math.Round(sumResult, 2);
        }

        private double ComputeVatable()
        {
            // subtotal / 1.12 //12% vat
            return Math.Round((subtotal / 1.12), 2);
        }
        private double ComputeVat() 
        {
            return Math.Round((subtotal - vatable),2);
        }

        private void FIllCbDiscount()
        {
            foreach (String s in dbh.GetDiscountNames())
            {
                (dgvCart.Columns["colCBDiscountCart"] as DataGridViewComboBoxColumn).Items.Add(s);
            }
            
        }

        private void POS_Load(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbTime.Text = DateTime.Now.ToString("hh:mm tt");

            dgvDrugs.DataSource = dbh.ShowProductList();
            
            FIllCbDiscount();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // if tab name tabPharmaDrugs
            // else if tab name non drugs
        }

        private void dgvDrugs_CellContentClick(object sender, DataGridViewCellEventArgs e) // products
        {
            if (dgvDrugs.Columns[e.ColumnIndex].Name.Equals("colAdd")) // add to cart button
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
                            dgvDrugs.Rows[e.RowIndex].Cells["colUnitPrice"].Value.ToString(),
                            "0"
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
                        dgvDrugs.Rows[e.RowIndex].Cells["colUnitPrice"].Value.ToString(),
                        "0"
                        );
                }
            }
        }
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e) // cart add minus qty
        {
            
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            dgvCart.Rows.Clear();
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            subtotal = ComputeSubTotal();
            lbSubtotal.Text = "Php " + subtotal.ToString();

            vatable = ComputeVatable();
            lbVatable.Text = "Php " + vatable.ToString();

            vat = ComputeVat();
            lbVat.Text = "Php " + vat.ToString();
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name.Equals("colCBDiscountCart"))
            {
                rowIdx = e.RowIndex;
            }
            else if (dgvCart.Columns[e.ColumnIndex].Name.Equals("colMinus1"))
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

        private void dgvCart_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                // Remove an existing event-handler, if present, to avoid 
                // adding multiple handlers when the editing control is reused.
                combo.SelectedIndexChanged -=
                    new EventHandler(ComboBox_SelectedIndexChanged);

                // Add the event handler. 
                combo.SelectedIndexChanged +=
                    new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e) //           COMBO BOX EVENT
        {
            dgvCart.Rows[rowIdx].Cells["colDiscountCart"].Value = dbh.GetDiscountValue(((ComboBox)sender).Text); ;
            
            //if (((ComboBox)sender).SelectedItem.Equals("2"))
            
            
        }

    }
}
