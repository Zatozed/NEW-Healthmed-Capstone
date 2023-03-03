using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class StockAdjustment : Form
    {
        public StockAdjustment()
        {
            InitializeComponent();
        }
        private DBhelperClass dbh = new DBhelperClass();
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        private void StockAdjustment_Load(object sender, EventArgs e)
        {
            DGVStockUdjustment.DataSource = dbh.ShowProductMasterList();
        }

        private void BtnUdjustUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void Update()
        {
            for (int i = 0; i < DGVStockUdjustment.Rows.Count; i++)
            {
                MessageBox.Show(Convert.ToString(DGVStockUdjustment.Rows[i].Cells[1]));
            }
        }
        static bool checkValidation(string check)
        {
            int number = 0;
            return int.TryParse(check, out number);
        }

        private void DGVStockUdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double UnitCost = 0;
            double UnitPrice = 0;
            int inStockQTY = 0;

            if (DGVStockUdjustment.Columns[e.ColumnIndex].Name == "colUpdate")
            {
                try
                {
                    if (string.IsNullOrEmpty(Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitCost"].Value)) == false)
                        UnitCost = Convert.ToDouble(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitCost"].Value);

                    if (string.IsNullOrEmpty(Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitPrice"].Value)) == false)
                        UnitPrice = Convert.ToDouble(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitPrice"].Value);

                    if (string.IsNullOrEmpty(Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewInStock"].Value)) == false)
                        inStockQTY = Convert.ToInt32(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewInStock"].Value);

                    if (UnitCost < 0 || UnitPrice < 0 || inStockQTY < 0)
                    {
                        MessageBox.Show("Invalid Input can't add a negative Value");
                    }
                    else
                    { 
                        //====================================Update Unit Cost=====================================
                        if (string.IsNullOrEmpty(Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitCost"].Value)) == false)
                        {
                            double convert = Convert.ToDouble(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitCost"].Value);
                            if (convert < 0)
                            {
                                MessageBox.Show("Invalid Input");
                            }
                            else
                            {
                                dbh.CloseCon();
                                dbh.OpenCon();
                                cmd = new MySqlCommand("UPDATE tbl_products SET unit_cost = @unitCost WHERE p_id = @ID", dbh.conn());
                                cmd.Parameters.AddWithValue("@unitCost", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitCost"].Value));
                                cmd.Parameters.AddWithValue("@ID", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["productID"].Value));
                                cmd.ExecuteNonQuery();
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Unit Cost Updated");
                                    dbh.CloseCon();

                                    DGVStockUdjustment.Rows[e.RowIndex].Cells["colCost"].Value = convert.ToString("0.00");
                                    DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitCost"].Value = "";
                                }
                                else
                                {
                                    MessageBox.Show("Not Updated");
                                }
                            }
                        }
                        //==========================================Update Unit Price=====================================
                        if (string.IsNullOrEmpty(Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitPrice"].Value)) == false)
                        {
                            double convert = Convert.ToDouble(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitPrice"].Value);
                            if (convert < 0)
                            {
                                MessageBox.Show("Invalid Input");
                            }
                            else
                            {
                                dbh.CloseCon();
                                dbh.OpenCon();
                                cmd = new MySqlCommand("UPDATE tbl_products SET unit_price = @unitPrice WHERE p_id = @ID", dbh.conn());
                                cmd.Parameters.AddWithValue("@unitPrice", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitPrice"].Value));
                                cmd.Parameters.AddWithValue("@ID", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["productID"].Value));
                                cmd.ExecuteNonQuery();
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Unit Price Updated");
                                    dbh.CloseCon();

                                    DGVStockUdjustment.Rows[e.RowIndex].Cells["colPrice"].Value = convert.ToString("0.00");
                                    DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewUnitPrice"].Value = "";
                                }
                                else
                                {
                                    MessageBox.Show("Not Updated");
                                }
                            }
                        }
                        //========================================Update In Stock QTY===============================================
                        if (string.IsNullOrEmpty(Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewInStock"].Value)) == false)
                        {
                            int convert = Convert.ToInt32(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewInStock"].Value);
                            if (convert < 0)
                            {
                                MessageBox.Show("Invalid Input");
                            }
                            else
                            {
                                dbh.CloseCon();
                                dbh.OpenCon();
                                cmd = new MySqlCommand("UPDATE tbl_products SET in_stock_qty = @instock WHERE p_id = @ID", dbh.conn());
                                cmd.Parameters.AddWithValue("@instock", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewInStock"].Value));
                                cmd.Parameters.AddWithValue("@ID", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["productID"].Value));
                                cmd.ExecuteNonQuery();
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("In Stock Qty. Updated");
                                    dbh.CloseCon();

                                    DGVStockUdjustment.Rows[e.RowIndex].Cells["colInStock"].Value = convert.ToString();
                                    DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewInStock"].Value = "";
                                }
                                else
                                {
                                    MessageBox.Show("Not Updated");
                                }
                            }
                        }
                        //==========================================Remarks Update===============================================

                        if (string.IsNullOrEmpty(Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewRemarks"].Value)) == false)
                        {
                            dbh.CloseCon();
                            dbh.OpenCon();
                            cmd = new MySqlCommand("UPDATE tbl_products SET remarks = @remarks WHERE p_id = @ID", dbh.conn());
                            cmd.Parameters.AddWithValue("@remarks", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewRemarks"].Value));
                            cmd.Parameters.AddWithValue("@ID", Convert.ToString(DGVStockUdjustment.Rows[e.RowIndex].Cells["productID"].Value));
                            cmd.ExecuteNonQuery();
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Remarks Updated");
                                dbh.CloseCon();

                                DGVStockUdjustment.Rows[e.RowIndex].Cells["colRemark"].Value = DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewRemarks"].Value.ToString();
                                    DGVStockUdjustment.Rows[e.RowIndex].Cells["colNewRemarks"].Value = "";
                             }
                             else
                             {
                                    MessageBox.Show("Not Updated");
                             }
                        }
                    }
                }
                
                catch (FormatException fe)
                {
                    MessageBox.Show("Invalid Input It must be Number ex. 123");
                }

            }
 
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void RefStockUdjust_TextChanged(object sender, EventArgs e)
        {
            if (ProductSearch.Text == null || ProductSearch.Text.ToString().Equals(""))
                DGVStockUdjustment.DataSource = dbh.ShowProductMasterList();
            else
                DGVStockUdjustment.DataSource = dbh.ShowProductMasterList1(ProductSearch.Text);
        }

        private void DGVStockUdjustment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (DGVStockUdjustment.Columns[e.ColumnIndex].Name.Equals("colNewUnitCost")) 
            //{
            //    if (DGVSt) { }
            //}
        }
    }
}
