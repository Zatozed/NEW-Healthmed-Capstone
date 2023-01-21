using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
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

namespace NEW_Healthmed_Capstone.file_maintenance
{
    public partial class FileMaintenance : Form
    {
        private DBhelperClass dbh = new DBhelperClass();
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        public FileMaintenance()
        {
            InitializeComponent();
        }

        private void FileMaintenance_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;

            dgvDiscount.DataSource = dbh.ShowDiscountList();
            dgvSupplier.DataSource = dbh.showSupplierList();
        }
        private void InsertToDiscount()
        {
            for (int i = 0; i < dgvDiscount.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dgvDiscount.Rows[i];
                try
                {
                    dbh.OpenCon();
                    cmd = new MySqlCommand("SELECT * FROM tbl_discount Where discount_name = @discountName", dbh.conn());
                    cmd.Parameters.AddWithValue("@discountName", row.Cells["colDiscountName"].Value.ToString());
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)//checks if it is exist
                    {
                        MessageBox.Show(row.Cells["colDiscountName"].Value.ToString());
                    }
                    else //if not exist insert
                    {
                        dbh.CloseCon();

                        dbh.OpenCon();
                        cmd = new MySqlCommand("insert into tbl_discount(discount_name, discount_percent) values(@dname, @dp)", dbh.conn());
                        cmd.Parameters.AddWithValue("@dname", row.Cells["colDiscountName"].Value.ToString());
                        cmd.Parameters.AddWithValue("@dp", row.Cells["colDiscount"].Value.ToString());
                        cmd.ExecuteNonQuery();
                        dbh.CloseCon();
                        MessageBox.Show("Discount Inserted");
                        
                    }

                }
                    catch (MySqlException sqlE) { MessageBox.Show(sqlE.Message.ToString()); }
                    finally { dbh.CloseCon(); }
                }
            //dgvDiscount.DataSource = dbh.ShowDiscountList();
        }
        private void btnDiscountConfirm_Click(object sender, EventArgs e)
        {
            InsertToDiscount();
        }

        private void dgvDiscount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //UPDATE DISCOUNT
            if(dgvDiscount.Columns[e.ColumnIndex].Name == "colUpdateDiscount")
            {
                string discountID = Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["ID"].Value);
                string discountName = Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscountName"].Value);

                try
                {
                    dbh.OpenCon();
                    cmd = new MySqlCommand("SELECT * FROM tbl_discount where discount_name = @discountName", dbh.conn());
                    cmd.Parameters.AddWithValue("@discountName", discountName);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("Discount Name already Exist or haven't change");
                    }
                    else {
                        dbh.CloseCon();
                        dbh.OpenCon();
                        cmd = new MySqlCommand("UPDATE tbl_discount SET discount_name = @discountName, discount_percent = @discount WHERE ID = @ID", dbh.conn());
                        cmd.Parameters.AddWithValue("@discountName", Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscountName"].Value));
                        cmd.Parameters.AddWithValue("@discount", Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscount"].Value));
                        cmd.Parameters.AddWithValue("@ID", discountID);
                        cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("DISCOUNT UPDATED");
                            dbh.CloseCon();
                            dgvDiscount.DataSource = dbh.ShowDiscountList();
                        }
                        else
                        {
                            MessageBox.Show("Not Updated");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { dbh.CloseCon(); }
            }
            //DELETE DISCOUNT
            if (dgvDiscount.Columns[e.ColumnIndex].Name == "colDeleteDiscount")
            {
                string discountID = Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["ID"].Value);

                try
                {
                    dbh.OpenCon();
                    cmd = new MySqlCommand("DELETE FROM tbl_discount WHERE id = @ID", dbh.conn());
                    cmd.Parameters.AddWithValue("@ID", discountID);
                    cmd.ExecuteNonQuery();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("FAILED DELETED");
                    }
                    else
                    {
                        MessageBox.Show("DELETED");
                        dbh.CloseCon();
                        dgvDiscount.DataSource = dbh.ShowDiscountList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { dbh.CloseCon(); }
            }

        }

        private void btnSupConfirm_Click(object sender, EventArgs e)
        {
            insertSupplier();
            dgvSupplier.DataSource = dbh.showSupplierList();
        }
        private void insertSupplier()
        {
            for (int i = 0; i < dgvSupplier.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dgvSupplier.Rows[i];
                try
                {
                    dbh.OpenCon();
                    cmd = new MySqlCommand("SELECT * FROM tbl_suppliers Where supplier_name = @supplierName", dbh.conn());
                    cmd.Parameters.AddWithValue("@supplierName", row.Cells["Supplier_Name"].Value.ToString());
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)//checks if it is exist
                    {
                        MessageBox.Show("Can't be Inserted");
                    }
                    else //if not exist insert
                    {
                        dbh.CloseCon();

                        dbh.OpenCon();
                        cmd = new MySqlCommand("insert into tbl_suppliers(supplier_name,description,email,contactNum,Address,leadTime) values(@supplierName, @Description,@email,@contact,@address,@leadTime)", dbh.conn());
                        cmd.Parameters.AddWithValue("@supplierName", row.Cells["Supplier_Name"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Description", row.Cells["Description"].Value.ToString());
                        cmd.Parameters.AddWithValue("@email", row.Cells["Email"].Value.ToString());
                        cmd.Parameters.AddWithValue("@contact", row.Cells["Contact_Number"].Value.ToString());
                        cmd.Parameters.AddWithValue("@address", row.Cells["Address"].Value.ToString());
                        cmd.Parameters.AddWithValue("@leadTime", row.Cells["Lead_Time"].Value.ToString());
                        cmd.ExecuteNonQuery();
                        dbh.CloseCon();
                        dgvSupplier.DataSource = dbh.showSupplierList();
                        dbh.CloseCon();
                        MessageBox.Show("Supplier Inserted");
                    }

                }
                catch (MySqlException sqlE) { MessageBox.Show(sqlE.Message.ToString()); }
                finally { dbh.CloseCon(); }
            }
        }
    }
}
