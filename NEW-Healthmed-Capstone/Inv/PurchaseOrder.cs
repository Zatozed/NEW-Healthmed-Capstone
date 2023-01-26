﻿using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class PurchaseOrder : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        //private List<string> l = new List<string>();
        private ArrayList l = new ArrayList();
        private AutoCompleteStringCollection src;

        private double total, Discount, subtotal;
        public PurchaseOrder()
        {
            InitializeComponent();
        }
        private void ComputeTotal() 
        {
            total = subtotal - Discount;
        }
        private void ComputeSubtotal() 
        {
            if(dgvOrders.Rows.Count != 0) 
            {
                subtotal = 0;
                foreach (DataGridViewRow r in dgvOrders.Rows) 
                {
                    subtotal += Math.Round(Convert.ToDouble(r.Cells["colQty"].Value) * Convert.ToDouble(r.Cells["colUnitCost"].Value), 2);
                }
            }
        }
        private void ComputeSubtotalLessDiscount() 
        {
            if (dgvOrders.Rows.Count != 0)
            {
                Discount = 0;
                foreach (DataGridViewRow r in dgvOrders.Rows)
                {
                    Discount += Math.Round(
                        (Convert.ToDouble(r.Cells["colQty"].Value) * Convert.ToDouble(r.Cells["colUnitCost"].Value)) * Convert.ToDouble(r.Cells["colDiscount"].Value)
                        , 2);
                }
            }
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

            tbPOnum.Text = dbh.GeneratePoNum();

            tbDateNow.Text = DateTime.Now.ToString("yyyy-MM-dd");

            dgvOtherProds.DataSource = dbh.ShowProductSupplier();

            if(cbSup.Text.ToString().Equals("") || cbSup.Text == null)

            dgvReOrderList.DataSource = dbh.ShowProductToOrder();

            dgvPOlist.DataSource = dbh.ShowPoList();

            tbHmdAdress.Text = Properties.Settings.Default.HMDaddress;
            tbHmdContactNum.Text = Properties.Settings.Default.HMDcontactNum;
            tbHmdEmail.Text = Properties.Settings.Default.HMDemail;

            tbReName.Text = Properties.Settings.Default.ReName;
            tbReAddress.Text = Properties.Settings.Default.ReAddress;
            tbReContactNum.Text = Properties.Settings.Default.ReContactNum;
            tbReEmail.Text = Properties.Settings.Default.ReEmail;
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
                            dgvReOrderList.Rows[e.RowIndex].Cells["colProdName"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colClass"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colDosage"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colType"].Value,
                            "0",
                            "0",
                            dgvReOrderList.Rows[e.RowIndex].Cells["colUnitCostRL"].Value
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
                            dgvReOrderList.Rows[e.RowIndex].Cells["colProdName"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colClass"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colDosage"].Value + " " + dgvReOrderList.Rows[e.RowIndex].Cells["colType"].Value,
                            "0",
                            "0",
                            dgvReOrderList.Rows[e.RowIndex].Cells["colUnitCostRL"].Value
                            );
                }
            }
        }

        private void dgvOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ComputeSubtotal();
            tbSubtotal.Text = subtotal.ToString("0.00");

            ComputeSubtotalLessDiscount();
            tbDiscount.Text = Discount.ToString("0.00");

            ComputeTotal();
            tbTotal.Text = total.ToString("0.00");
        }

        private void PropertiesSave() 
        {
            Properties.Settings.Default.HMDaddress = tbHmdAdress.Text.ToString();
            Properties.Settings.Default.HMDcontactNum = tbHmdContactNum.Text.ToString();
            Properties.Settings.Default.HMDemail = tbHmdEmail.Text.ToString();

            Properties.Settings.Default.ReName = tbReName.Text.ToString();
            Properties.Settings.Default.ReAddress = tbReAddress.Text.ToString();
            Properties.Settings.Default.ReContactNum = tbReContactNum.Text.ToString();
            Properties.Settings.Default.ReEmail = tbReEmail.Text.ToString();

            Properties.Settings.Default.Save();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PropertiesSave();

            if (cbSup.Text.ToString().Equals("Select") || cbSup.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select Supplier");
            }
            else
            {
                foreach (DataGridViewRow r in dgvOrders.Rows)
                {
                    dbh.InsertToPo(tbPOnum.Text.ToString(), r.Cells["colProductCode"].Value.ToString(), r.Cells["colProductDes"].Value.ToString(),
                        r.Cells["colQty"].Value.ToString(), r.Cells["colDiscount"].Value.ToString(), r.Cells["colUnitCost"].Value.ToString(),
                        r.Cells["colDiscount"].Value.ToString(), total.ToString("0.00"), Discount.ToString("0.00"),
                        tbDateNow.Text.ToString(), "user", tbReName.Text.ToString(),
                        tbReAddress.Text.ToString(), tbReContactNum.Text.ToString(), tbReEmail.Text.ToString(),
                        cbSup.Text.ToString(), tbSupAddress.Text.ToString(), tbSupContactNum.Text.ToString(),
                        tbSupEmail.Text.ToString(), tbRemarks.Text.ToString()
                    );
                }
                
            }
            dgvPOlist.Rows.Clear();
            dgvPOlist.DataSource = dbh.ShowPoList();
        }

        private void dgvPOlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPOlist.Columns[e.ColumnIndex].Name.Equals("colView")) 
            {
                
            }
            else if (dgvPOlist.Columns[e.ColumnIndex].Name.Equals("colDel"))
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Do you want to delete this?", "Delete", buttons);
                if (result == DialogResult.Yes)
                    dbh.DelAtPoList(e.RowIndex);
            }
        }

        private void cbSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSup.Text.ToString().Equals("Select") || cbSup.Text.ToString().Equals(""))
            {
                tbSupAddress.Clear();
                tbSupContactNum.Clear();
                tbSupEmail.Clear();
            }
            else
            {
                dgvReOrderList.DataSource = dbh.ShowProductToOrder(cbSup.Text.ToString());
                dgvOtherProds.DataSource = dbh.ShowProductSupplier(cbSup.Text.ToString());

                tbSupAddress.Text = dbh.GetSupAd(cbSup.Text.ToString());
                tbSupContactNum.Text = dbh.GetSupContactNum(cbSup.Text.ToString());
                tbSupEmail.Text = dbh.GetSupEmailAd(cbSup.Text.ToString());
            }
            
        }

        private void dgvOtherProds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.RowCount != 0)
            {
                // same product
                int matchCount = 0;
                foreach (DataGridViewRow r in dgvOrders.Rows)
                {
                    if (dgvOtherProds.Rows[e.RowIndex].Cells["colProdCodeO"].Value.ToString().Equals(r.Cells["colProductCode"].Value.ToString())) // if match ++ count
                        matchCount++;
                }
                if (matchCount == 0) //if no match found
                {
                    dgvOrders.Rows.Add("",
                        "",
                        dgvOtherProds.Rows[e.RowIndex].Cells["colProdCodeO"].Value,
                        dgvOtherProds.Rows[e.RowIndex].Cells["colProdNameO"].Value + " " + dgvOtherProds.Rows[e.RowIndex].Cells["colClassO"].Value + " " + dgvOtherProds.Rows[e.RowIndex].Cells["colDosageO"].Value + " " + dgvOtherProds.Rows[e.RowIndex].Cells["colTypeO"].Value,
                        "0",
                        "0",
                        dgvOtherProds.Rows[e.RowIndex].Cells["colUnitCostO"].Value
                        );
                }
                else
                    MessageBox.Show("Item Alreadty in Orders");

            }
            else // if no value
            {
                dgvOrders.Rows.Add("",
                        "",
                        dgvOtherProds.Rows[e.RowIndex].Cells["colProdCodeO"].Value,
                        dgvOtherProds.Rows[e.RowIndex].Cells["colProdNameO"].Value + " " + dgvOtherProds.Rows[e.RowIndex].Cells["colClassO"].Value + " " + dgvOtherProds.Rows[e.RowIndex].Cells["colDosageO"].Value + " " + dgvOtherProds.Rows[e.RowIndex].Cells["colTypeO"].Value,
                        "0",
                        "0",
                        dgvOtherProds.Rows[e.RowIndex].Cells["colUnitCostO"].Value
                        );
            }
        }
    }
}
