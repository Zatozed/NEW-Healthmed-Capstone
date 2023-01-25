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

            dgvDiscount.DataSource = dbh.ShowDiscountList();
            dgvSupplier.DataSource = dbh.showSupplierList();
            dgvProducts.DataSource = dbh.ShowProductList();
        }
        private void InsertToDiscount()
        { 
                try
                {
                    dbh.OpenCon();
                    cmd = new MySqlCommand("SELECT * FROM tbl_discount Where discount_name = @discountName", dbh.conn());
                    cmd.Parameters.AddWithValue("@discountName", tbDiscountName.Text.Trim());
                    dr = cmd.ExecuteReader();
                    if (string.IsNullOrEmpty(tbDiscountName.Text) == false && string.IsNullOrEmpty(tbDiscountPercent.Text) == false)
                    {
                        dbh.CloseCon();

                        dbh.OpenCon();
                        cmd = new MySqlCommand("insert into tbl_discount(discount_name, discount_percent) values(@dname, @dp)", dbh.conn());
                        cmd.Parameters.AddWithValue("@dname", tbDiscountName.Text.Trim());
                        cmd.Parameters.AddWithValue("@dp", tbDiscountPercent.Text);
                        cmd.ExecuteNonQuery();
                        dbh.CloseCon();
                        MessageBox.Show("Discount Inserted!");
                        dgvDiscount.DataSource = dbh.ShowDiscountList();

                        tbDiscountName.Clear();
                        tbDiscountPercent.Value = 0;
                    
                    }
                    if (string.IsNullOrEmpty(tbDiscountName.Text) == true)
                    {
                        errorProvider1.SetError(this.tbDiscountName, "Please Fill Discount Name");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }
                    if (string.IsNullOrEmpty(tbDiscountPercent.Text) == true)
                    {
                        errorProvider2.SetError(this.tbDiscountPercent, "Please Fill Discount Percent");
                    }
                    else
                    {
                        errorProvider2.Clear();
                    }
            }
                    catch (MySqlException sqlE) { MessageBox.Show("Discount Already Exist"); }
                    finally { dbh.CloseCon(); }
        }
        private void btnDiscountConfirm_Click(object sender, EventArgs e)
        {
            InsertToDiscount();
        }

        private void dgvDiscount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
            //UPDATE DISCOUNT
            if (dgvDiscount.Columns[e.ColumnIndex].Name == "colUpdateDiscount")
            {

                try
                {
                   if (string.IsNullOrEmpty(Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscountName"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscount"].Value)) == false)
                    {
                    dbh.CloseCon();
                    dbh.OpenCon();
                    cmd = new MySqlCommand("UPDATE tbl_discount SET discount_name = @discountName, discount_percent = @discount WHERE ID = @ID", dbh.conn());
                    cmd.Parameters.AddWithValue("@discountName", Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscountName"].Value).Trim());
                    cmd.Parameters.AddWithValue("@discount", Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscount"].Value));
                    cmd.Parameters.AddWithValue("@ID", Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["ID"].Value));
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
                    if (string.IsNullOrEmpty(Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscountName"].Value)) == true)
                    {
                        MessageBox.Show("PLease Fill Discount Name");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["colDiscount"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Discount Percent");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally { dbh.CloseCon(); }
            }
            //DELETE DISCOUNT
            if (dgvDiscount.Columns[e.ColumnIndex].Name == "colDeleteDiscount")
            {
                string discountID = Convert.ToString(dgvDiscount.Rows[e.RowIndex].Cells["ID"].Value);
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Do you want to delete this Discount?", "Delete", buttons);
                if (result == DialogResult.Yes)
                {
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
        }
        private void tbDiscountName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDiscountName.Text) == true)
            {
                errorProvider1.SetError(this.tbDiscountName, "Please Fill Discount Name");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void tbDiscountPercent_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDiscountPercent.Text) == true)
            {
                errorProvider2.SetError(this.tbDiscountPercent, "Please Fill Discount Percent");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
        //=========================================================== SUPPLIER =======================================================================================================
        private void insertSupplier()
        {

                try
                {
                    dbh.OpenCon();
                    cmd = new MySqlCommand("SELECT * FROM tbl_suppliers Where supplier_name = @supplierName", dbh.conn());
                    cmd.Parameters.AddWithValue("@supplierName", tbSupplierName.Text.Trim());
                    dr = cmd.ExecuteReader();

                if (string.IsNullOrEmpty(tbSupplierName.Text) == false && string.IsNullOrEmpty(tbDescription.Text) == false && string.IsNullOrEmpty(tbEmail.Text) == false && string.IsNullOrEmpty(tbContact.Text) == false && string.IsNullOrEmpty(tbAddress.Text) == false && string.IsNullOrEmpty(tbLeadTime.Text) == false)
                {
                        dbh.CloseCon();

                        dbh.OpenCon();
                        cmd = new MySqlCommand("insert into tbl_suppliers(supplier_name,sup_description,email_ad,contact_num,address,lead_time) values(@supplierName, @Description,@email,@contact,@address,@LeadTime)", dbh.conn());
                        cmd.Parameters.AddWithValue("@supplierName", tbSupplierName.Text);
                        cmd.Parameters.AddWithValue("@Description", tbDescription.Text);
                        cmd.Parameters.AddWithValue("@email", tbEmail.Text);
                        cmd.Parameters.AddWithValue("@contact", tbContact.Text);
                        cmd.Parameters.AddWithValue("@address", tbAddress.Text);
                        cmd.Parameters.AddWithValue("@LeadTime", tbLeadTime.Text);
                         cmd.ExecuteNonQuery();
                        dbh.CloseCon();
                        MessageBox.Show("Supplier Inserted");
                        dgvSupplier.DataSource = dbh.showSupplierList();

                    tbSupplierName.Clear();
                    tbDescription.Clear();
                    tbEmail.Clear();
                    tbContact.Clear();
                    tbAddress.Clear();
                    tbLeadTime.Value = 0;
                    }
                if (string.IsNullOrEmpty(tbSupplierName.Text) == true)
                {
                    errorProvider3.SetError(this.tbSupplierName, "Please Fill Supplier Name");
                }
                else
                {
                    errorProvider3.Clear();
                }
                if (string.IsNullOrEmpty(tbDescription.Text) == true)
                {
                    errorProvider4.SetError(this.tbDescription, "Please Fill Description");
                }
                else
                {
                    errorProvider4.Clear();
                }
                if (string.IsNullOrEmpty(tbEmail.Text) == true)
                {
                    errorProvider5.SetError(this.tbEmail, "Please Fill Email");
                }
                else
                {
                    errorProvider5.Clear();
                }
                if (string.IsNullOrEmpty(tbContact.Text) == true)
                {
                    errorProvider6.SetError(this.tbContact, "Please Fill Contact #");
                }
                else
                {
                    errorProvider6.Clear();
                }
                if (string.IsNullOrEmpty(tbAddress.Text) == true)
                {
                    errorProvider7.SetError(this.tbAddress, "Please Fill Address");
                }
                else
                {
                    errorProvider7.Clear();
                }
                if (string.IsNullOrEmpty(tbLeadTime.Text) == true)
                {
                    errorProvider8.SetError(this.tbLeadTime, "Please Fill Lead Time");
                }
                else
                {
                    errorProvider8.Clear();
                }

            }
                catch (MySqlException sqlE) { MessageBox.Show("Supplier Already Exist!"); }
                finally { dbh.CloseCon(); }
        }      
        private void btnSupConfirm_Click_1(object sender, EventArgs e)
        {
            insertSupplier();
        }

        private void dgvSupplier_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //UPDATE SUPPLIER
            if (dgvSupplier.Columns[e.ColumnIndex].Name == "colUpdateSupplier")
            {
                try
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["supplierName"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["desc"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Email"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Contact_Number"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["LeadTime"].Value)) == false)
                    {
                        dbh.CloseCon();
                        dbh.OpenCon();
                        cmd = new MySqlCommand("UPDATE tbl_suppliers SET supplier_name = @supplier, sup_description = @desc, address = @address, contact_num = @contact, email_ad = @email, lead_time = @leadTime WHERE sup_id = @ID", dbh.conn());
                        cmd.Parameters.AddWithValue("@supplier", Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["supplierName"].Value).Trim());
                        cmd.Parameters.AddWithValue("@desc", Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["desc"].Value));
                        cmd.Parameters.AddWithValue("@address", Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value));
                        cmd.Parameters.AddWithValue("@contact", Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Contact_Number"].Value));
                        cmd.Parameters.AddWithValue("@email", Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Email"].Value));
                        cmd.Parameters.AddWithValue("@leadTime", Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["LeadTime"].Value));
                        cmd.Parameters.AddWithValue("@ID", Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["S_ID"].Value));
                        cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("SUPPLIER UPDATED");
                            dbh.CloseCon();
                            dgvSupplier.DataSource = dbh.showSupplierList();
                        }
                        else
                        {
                            MessageBox.Show("Not Updated");
                        }
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["supplierName"].Value)) == true)
                    {
                        MessageBox.Show("PLease Fill Supplier Name");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["desc"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Description");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Email"].Value)) == true)
                    {
                        MessageBox.Show("PLease Fill Email");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Contact_Number"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Contact #");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value)) == true)
                    {
                        MessageBox.Show("PLease Fill Address");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["LeadTime"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Lead Time");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Supplier Already Exist!");
                }
                finally { dbh.CloseCon(); }
            }
            //DELETE SUPPLIER
            if (dgvSupplier.Columns[e.ColumnIndex].Name == "colDeleteSupplier")
            {
                string supplierID = Convert.ToString(dgvSupplier.Rows[e.RowIndex].Cells["S_ID"].Value);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Do you want to delete this Supplier?", "Delete", buttons);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dbh.OpenCon();
                        cmd = new MySqlCommand("DELETE FROM tbl_suppliers WHERE sup_id = @ID", dbh.conn());
                        cmd.Parameters.AddWithValue("@ID", supplierID);
                        cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("FAILED DELETED");
                        }
                        else
                        {
                            MessageBox.Show("DELETED");
                            dbh.CloseCon();
                            dgvSupplier.DataSource = dbh.showSupplierList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { dbh.CloseCon(); }
                }
            }
        }

        private void tbSupplierName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSupplierName.Text) == true)
            {
                errorProvider3.SetError(this.tbSupplierName, "Please Fill Supplier Name");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void tbContact_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbContact.Text) == true)
            {
                errorProvider6.SetError(this.tbContact, "Please Fill Contact #");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void tbDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDescription.Text) == true)
            {
                errorProvider4.SetError(this.tbDescription, "Please Fill Description");
            }
            else
            {
                errorProvider4.Clear();

            }
        }
            private void tbAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddress.Text) == true)
            {
                errorProvider7.SetError(this.tbAddress, "Please Fill Address");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text) == true)
            {
                errorProvider5.SetError(this.tbEmail, "Please Fill Email");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void tbLeadTime_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLeadTime.Text) == true)
            {
                errorProvider8.SetError(this.tbLeadTime, "Please Fill Lead Time");
            }
            else
            {
                errorProvider8.Clear();
            }
        }
        //================================================= Product =========================================================================
        private void InsertToProduct()
        {
            try
            {
                dbh.OpenCon();
                cmd = new MySqlCommand("SELECT * FROM tbl_products Where product_code = @productCode", dbh.conn());
                cmd.Parameters.AddWithValue("@productCode", tbProductCode.Text.Trim());
                dr = cmd.ExecuteReader();
                if (string.IsNullOrEmpty(tbProductCode.Text) == false && string.IsNullOrEmpty(tbProductName.Text) == false && string.IsNullOrEmpty(tbClassification.Text) == false && string.IsNullOrEmpty(tbDosage.Text) == false && string.IsNullOrEmpty(tbType.Text) == false && string.IsNullOrEmpty(tbUnitCost.Text) == false && string.IsNullOrEmpty(tbUnitPrice.Text) == false)
                {
                    dbh.CloseCon();

                    dbh.OpenCon();
                    cmd = new MySqlCommand("insert into tbl_products(product_code, product_name,classification,dosage,med_type,unit_cost,unit_price) values(@pCode, @pName, @classification, @dosage, @type,@cost,@price)", dbh.conn());
                    cmd.Parameters.AddWithValue("@pCode", tbProductCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@pName", tbProductName.Text);
                    cmd.Parameters.AddWithValue("@classification", tbClassification.Text);
                    cmd.Parameters.AddWithValue("@dosage", tbDosage.Text);
                    cmd.Parameters.AddWithValue("@type", tbType.Text);
                    cmd.Parameters.AddWithValue("@cost", tbUnitCost.Text);
                    cmd.Parameters.AddWithValue("@price", tbUnitPrice.Text);
                    cmd.ExecuteNonQuery();
                    dbh.CloseCon();
                    MessageBox.Show("Product Inserted!");
                    dgvProducts.DataSource = dbh.ShowProductList();

                    tbProductCode.Clear();
                    tbProductName.Clear();
                    tbClassification.Clear();
                    tbDosage.Clear();
                    tbType.Clear();
                    tbUnitCost.Clear();
                    tbUnitPrice.Clear();
                }
                if (string.IsNullOrEmpty(tbProductCode.Text) == true)
                {
                    errorProvider9.SetError(this.tbProductCode, "Please Fill Product Code");
                }
                else
                {
                    errorProvider9.Clear();
                }
                if (string.IsNullOrEmpty(tbProductName.Text) == true)
                {
                    errorProvider10.SetError(this.tbProductName, "Please Fill Product Name");
                }
                else
                {
                    errorProvider10.Clear();
                }
                if (string.IsNullOrEmpty(tbClassification.Text) == true)
                {
                    errorProvider11.SetError(this.tbClassification, "Please Fill Classification");
                }
                else
                {
                    errorProvider11.Clear();
                }
                if (string.IsNullOrEmpty(tbDosage.Text) == true)
                {
                    errorProvider12.SetError(this.tbDosage, "Please Fill Dosage #");
                }
                else
                {
                    errorProvider12.Clear();
                }
                if (string.IsNullOrEmpty(tbType.Text) == true)
                {
                    errorProvider13.SetError(this.tbType, "Please Fill Type");
                }
                else
                {
                    errorProvider13.Clear();
                }
                if (string.IsNullOrEmpty(tbUnitCost.Text) == true)
                {
                    errorProvider14.SetError(this.tbUnitCost, "Please Fill Unit Cost");
                }
                else
                {
                    errorProvider14.Clear();
                }
                if (string.IsNullOrEmpty(tbUnitPrice.Text) == true)
                {
                    errorProvider15.SetError(this.tbUnitPrice, "Please Fill Unit Price");
                }
                else
                {
                    errorProvider15.Clear();
                }

            }
            catch (MySqlException sqlE) { MessageBox.Show("Product Already Exist"); }
            finally { dbh.CloseCon(); }
        }
        private void btnProdConfirm_Click(object sender, EventArgs e)
        {
            InsertToProduct();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //UPDATE PRODUCT
            if (dgvProducts.Columns[e.ColumnIndex].Name == "colUpdateProduct")
            {
                try
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["ProductCode"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Product_Name"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Classification"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Dosage"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Type"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["UnitCost"].Value)) == false && string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["unitPrice"].Value)) == false)
                    {
                        dbh.CloseCon();
                        dbh.OpenCon();
                        cmd = new MySqlCommand("UPDATE tbl_products SET product_code = @pcode, product_name = @pName, classification = @classification, dosage = @dosage, med_type = @type, unit_cost = @unitCOst, unit_price =@unitPrice WHERE p_id = @ID", dbh.conn());
                        cmd.Parameters.AddWithValue("@pcode", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["ProductCode"].Value));
                        cmd.Parameters.AddWithValue("@pName", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Product_Name"].Value).Trim());
                        cmd.Parameters.AddWithValue("@classification", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Classification"].Value));
                        cmd.Parameters.AddWithValue("@dosage", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Dosage"].Value));
                        cmd.Parameters.AddWithValue("@type", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Type"].Value));
                        cmd.Parameters.AddWithValue("@unitCOst", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["UnitCost"].Value));
                        cmd.Parameters.AddWithValue("@unitPrice", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["unitPrice"].Value));
                        cmd.Parameters.AddWithValue("@ID", Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["p_ID"].Value));
                        cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("PRODUCT UPDATED");
                            dbh.CloseCon();
                            dgvProducts.DataSource = dbh.ShowProductList();
                        }
                        else
                        {
                            MessageBox.Show("Not Updated");
                        }
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["ProductCode"].Value)) == true)
                    {
                        MessageBox.Show("PLease Fill Product Code");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Product_Name"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Product Name");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Classification"].Value)) == true)
                    {
                        MessageBox.Show("PLease Fill Classification");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Dosage"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Dosage");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["Type"].Value)) == true)
                    {
                        MessageBox.Show("PLease Fill Type");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["UnitCost"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Unit Cost");
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["unitPrice"].Value)) == true)
                    {
                        MessageBox.Show("Please Fill Unit Price");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally { dbh.CloseCon(); }
            }
            //DELETE Product
            if (dgvProducts.Columns[e.ColumnIndex].Name == "colDeleteProduct")
            {
                string productID = Convert.ToString(dgvProducts.Rows[e.RowIndex].Cells["p_ID"].Value);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Do you want to delete this Supplier?", "Delete", buttons);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dbh.OpenCon();
                        cmd = new MySqlCommand("DELETE FROM tbl_products WHERE p_id = @ID", dbh.conn());
                        cmd.Parameters.AddWithValue("@ID", productID);
                        cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("FAILED DELETED");
                        }
                        else
                        {
                            MessageBox.Show("DELETED");
                            dbh.CloseCon();
                            dgvProducts.DataSource = dbh.ShowProductList();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { dbh.CloseCon(); }
                }
            }
        }
    }

}
