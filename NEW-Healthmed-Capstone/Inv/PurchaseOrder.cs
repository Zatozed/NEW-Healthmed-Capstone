using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class PurchaseOrder : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        //private List<string> l = new List<string>();
        private ArrayList l = new ArrayList();
        private AutoCompleteStringCollection src;
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void GenereateAutoCompleteSrc()
        {
            src = new AutoCompleteStringCollection();
            foreach (string s in l) 
            {
                src.Add(s);
            }

            cbSup.AutoCompleteCustomSource = src;

            tbReAddress.AutoCompleteCustomSource = src;
            tbReContactNum.AutoCompleteCustomSource = src;
            tbReEmail.AutoCompleteCustomSource = src;
            tbReName.AutoCompleteCustomSource = src;
            tbRemarks.AutoCompleteCustomSource = src;

            tbSupAddress.AutoCompleteCustomSource = src;
            tbSupContactNum.AutoCompleteCustomSource = src;
            tbSupEmail.AutoCompleteCustomSource = src;

            tbHmdAdress.AutoCompleteCustomSource = src;
            tbHmdContactNum.AutoCompleteCustomSource = src;
            tbHmdEmail.AutoCompleteCustomSource = src;
        }

        private void FillCbSup()
        {
            cbSup.Items.Clear();
            cbSup.Items.Add("Select");
            cbSup.Items.AddRange(dbh.SupplierList().ToArray());
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            l = dbh.AutoComplete();

            GenereateAutoCompleteSrc();

            FillCbSup();

            dgvOtherProds.DataSource = dbh.ShowProductSupplier();

            if(cbSup.Text.ToString().Equals("") || cbSup.Text == null)

            dgvReOrderList.DataSource = dbh.ShowProductToOrder();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
        }

        private void dgvDrugs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReOrderList.Columns[e.ColumnIndex].Name.Equals("colAdd")) 
            {
                if (dgvOrders.RowCount != 0)
                {
                    // same product
                    int matchCount = 0;
                    foreach (DataGridViewRow r in dgvOrders.Rows)
                    {
                        if (dgvReOrderList.Rows[e.RowIndex].Cells["colProdCode"].Value.ToString().Equals(r.Cells["colProductCode"].Value.ToString())) // if match ++ count
                            matchCount++;
                    }
                    if (matchCount == 0) //if no match found
                    {
                        dgvOrders.Rows.Add("",
                            "",
                            dgvReOrderList.Rows[e.RowIndex].Cells["colProdCode"].Value,
                            dgvReOrderList.Rows[e.RowIndex].Cells["colProdName"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colClass"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colDosage"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colType"].Value
                            );
                    }
                    else
                        MessageBox.Show("Item Alreadty in Orders");

                }
                else // if no value
                {
                    dgvOrders.Rows.Add("",
                            "",
                            dgvReOrderList.Rows[e.RowIndex].Cells["colProdCode"].Value,
                            dgvReOrderList.Rows[e.RowIndex].Cells["colProdName"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colClass"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colDosage"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colType"].Value
                            );
                }
            }
        }

        private void cbSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReOrderList.DataSource= dbh.ShowProductToOrder(cbSup.Text.ToString());
        }
    }
}
