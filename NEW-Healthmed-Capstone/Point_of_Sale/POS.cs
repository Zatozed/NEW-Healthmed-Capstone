using CrystalDecisions.CrystalReports.Engine;
using MySqlX.XDevAPI.Common;
using NEW_Healthmed_Capstone.CrystalReportsFolder;
using NEW_Healthmed_Capstone.CtrHelperFolder;
using NEW_Healthmed_Capstone.DBhelperFolder;
using NEW_Healthmed_Capstone.Reports;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class POS : Form
    {
        private DBhelperClass dbh = new DBhelperClass();
        private ArrayList l = new ArrayList();
        private AutoCompleteStringCollection src;
        private int rowIdx;
        private double subtotal, discount, vatable, vat, vatXmptSale, total;
        public POS()
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
            tbSearch.AutoCompleteCustomSource = src;
        }
        private void DgvToDt()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("Qty", typeof(string));
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Total", typeof(string));

            foreach (DataGridViewRow r in dgvCart.Rows)
            {
                dt.Rows.Add(r.Cells["colQtyCart"].Value.ToString(),
                    r.Cells["colItemCart"].Value.ToString(),
                    r.Cells["colUnitPriceCart"].Value.ToString(),
                    r.Cells["colTotalCart"].Value.ToString());
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("Recbo.xml");

            Resibo rs = new Resibo();
            resibo ctrResibo = new resibo();
            ctrResibo.SetDataSource(ds);
            rs.crvResibo.ReportSource = ctrResibo;

            TextObject toVatable = (TextObject)ctrResibo.ReportDefinition.Sections["Section4"].ReportObjects["toVatable"];
            toVatable.Text = lbVatable.Text.Substring(4);

            TextObject toVat = (TextObject)ctrResibo.ReportDefinition.Sections["Section4"].ReportObjects["toVat"];
            toVat.Text = lbVat.Text.Substring(4);

            TextObject toVatEX = (TextObject)ctrResibo.ReportDefinition.Sections["Section4"].ReportObjects["toVatEx"];
            toVatEX.Text = lbVatExmpt.Text.Substring(4);

            TextObject toAmountDue = (TextObject)ctrResibo.ReportDefinition.Sections["Section4"].ReportObjects["toAmountDue"];
            toAmountDue.Text = lbTotal.Text.Substring(4);

            TextObject toCash = (TextObject)ctrResibo.ReportDefinition.Sections["Section4"].ReportObjects["toCash"];
            toCash.Text = lbCash.Text.Substring(4);

            TextObject toChange = (TextObject)ctrResibo.ReportDefinition.Sections["Section4"].ReportObjects["toChange"];
            toChange.Text = lbChange.Text.Substring(4);

            TextObject toDiscount = (TextObject)ctrResibo.ReportDefinition.Sections["Section4"].ReportObjects["toDiscount"];
            toDiscount.Text = lbDiscount.Text.Substring(4);

            TextObject toCashier = (TextObject)ctrResibo.ReportDefinition.Sections["Section5"].ReportObjects["toCashier"];
            toCashier.Text = lbUser.Text;

            TextObject toTransacNum = (TextObject)ctrResibo.ReportDefinition.Sections["Section5"].ReportObjects["toTransacNum"];
            toTransacNum.Text = lbTransacNum.Text;

            rs.crvResibo.Refresh();
            rs.Show();
        }
        private void Compute()
        {
            foreach (DataGridViewRow r in dgvCart.Rows)
            {
                double qty = Convert.ToDouble(r.Cells["colQtyCart"].Value);
                double price = Convert.ToDouble(r.Cells["colUnitPriceCart"].Value);
                double discount = Convert.ToDouble(r.Cells["colDiscountCart"].Value);

                if (r.Cells["colCBDiscountCart"].Value == null || r.Cells["colCBDiscountCart"].Value.ToString().Equals("")) // if no laman
                {
                    r.Cells["colVatableCart"].Value = (qty * price) / 1.12;
                    r.Cells["colVATCart"].Value = Convert.ToDouble(r.Cells["colVatableCart"].Value) * 0.12;
                    r.Cells["colLessDiscount"].Value = (qty * price) * discount;
                    r.Cells["colTotalCart"].Value = Math.Round((qty * price) - Convert.ToDouble(r.Cells["colLessDiscount"].Value), 2).ToString("0.00");
                }
                else if (dbh.isVatExmpt(r.Cells["colCBDiscountCart"].Value.ToString()).Equals("yes")) // vat exemp = yes
                {
                    r.Cells["colVatableCart"].Value = (qty * price) / 1.12;
                    r.Cells["colVatXCart"].Value = r.Cells["colVatableCart"].Value;
                    r.Cells["colVATCart"].Value = Convert.ToDouble(r.Cells["colVatableCart"].Value) * 0.12;
                    r.Cells["colLessDiscount"].Value = Convert.ToDouble(r.Cells["colVatXCart"].Value) * discount;
                    r.Cells["colTotalCart"].Value = Math.Round(Convert.ToDouble(r.Cells["colVatXCart"].Value) - Convert.ToDouble(r.Cells["colLessDiscount"].Value), 2).ToString("0.00");

                }
                else // if not vat exempt
                {
                    r.Cells["colVatableCart"].Value = (qty * price) / 1.12;
                    r.Cells["colVATCart"].Value = Convert.ToDouble(r.Cells["colVatableCart"].Value) * 0.12;
                    r.Cells["colLessDiscount"].Value = (qty * price) * discount;
                    r.Cells["colTotalCart"].Value = Math.Round((qty * price) - Convert.ToDouble(r.Cells["colLessDiscount"].Value), 2) ;
                }
            }
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
            double d = 0;
            foreach (DataGridViewRow r in dgvCart.Rows) // get total of vatable rows
            {
                d += Convert.ToDouble(r.Cells["colVatableCart"].Value);
            }
            return Math.Round(d, 2);
        }
        private double ComputeVat() 
        {
            double d = 0;
            foreach (DataGridViewRow r in dgvCart.Rows) // get total of vatable rows
            {
                d += Convert.ToDouble(r.Cells["colVATCart"].Value);
            }
            return Math.Round(d, 2);
        }

        private double ComputeVatXmpt()
        {
            double d = 0;
            foreach (DataGridViewRow r in dgvCart.Rows) // get total of vatable rows
            {
                d += Convert.ToDouble(r.Cells["colVatXCart"].Value);
            }
            return Math.Round(d, 2);
        }
        private double ComputeLessDiscount()
        {
            double d = 0;
            foreach (DataGridViewRow r in dgvCart.Rows) // get total of vatable rows
            {
                d += Convert.ToDouble(r.Cells["colLessDiscount"].Value);
            }
            return Math.Round(d, 2);
        }

        private double ComputeTotalAmoutDue() 
        {
            double d = 0;
            foreach (DataGridViewRow r in dgvCart.Rows) // get total of vatable rows
            {
                d += Convert.ToDouble(r.Cells["colTotalCart"].Value);
            }
            return Math.Round(d, 2);
        }
        private void FIllCbDiscount()
        {
            (dgvCart.Columns["colCBDiscountCart"] as DataGridViewComboBoxColumn).Items.Clear();
            (dgvCart.Columns["colCBDiscountCart"] as DataGridViewComboBoxColumn).Items.Add("none");
            foreach (String s in dbh.GetDiscountNames())
            {
                (dgvCart.Columns["colCBDiscountCart"] as DataGridViewComboBoxColumn).Items.Add(s);
            }
            
        }

        private void POS_Load(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbTime.Text = DateTime.Now.ToString("hh:mm tt");
            lbUser.Text = Properties.Settings.Default.Fname_Lname;

            dgvDrugs.DataSource = dbh.ShowProductList();
            
            FIllCbDiscount();

            lbTransacNum.Text = dbh.GenereateTransacNum();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // if tab name tabPharmaDrugs
            if(tbSearch.Text == null || tbSearch.Text.ToString().Equals(""))
                dgvDrugs.DataSource=dbh.ShowProductList();
            else
                dgvDrugs.DataSource = dbh.ShowProductList(tbSearch.Text);

            // else if tab name non drugs
        }

        private void dgvDrugs_CellContentClick(object sender, DataGridViewCellEventArgs e) // products
        {
            if (dgvDrugs.Columns[e.ColumnIndex].Name.Equals("colAdd"))                                              // add to cart button
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
                    if (matchCount == 0) //if no match found
                    {
                        dgvCart.Rows.Add(dgvDrugs.Rows[e.RowIndex].Cells["colProdCode"].Value.ToString(),
                            dgvDrugs.Rows[e.RowIndex].Cells["colProdName"].Value.ToString() + " " + dgvDrugs.Rows[e.RowIndex].Cells["colDosage"].Value.ToString(),
                            "1",
                            dgvDrugs.Rows[e.RowIndex].Cells["colUnitCost"].Value.ToString(),
                            dgvDrugs.Rows[e.RowIndex].Cells["colUnitPrice"].Value.ToString(),
                            "0", "0", "0", "0", "0", "0"
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
                        "0", "0", "0", "0", "0", "0"
                        );
                }
            }
        }
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e) // cart add minus qty
        {
            
        }

        private void dgvCart_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Compute();

            subtotal = ComputeSubTotal();
            lbSubtotal.Text = "Php " + subtotal.ToString("0.00");

            vatable = ComputeVatable();
            lbVatable.Text = "Php " + vatable.ToString("0.00");

            vat = ComputeVat();
            lbVat.Text = "Php " + vat.ToString("0.00");

            vatXmptSale = ComputeVatXmpt();
            lbVatExmpt.Text = "Php " + vatXmptSale.ToString("0.00");

            discount = ComputeLessDiscount();
            lbDiscount.Text = "Php " + discount.ToString("0.00");

            total = ComputeTotalAmoutDue();
            lbTotal.Text = "Php " + total.ToString("0.00");
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            dgvCart.Rows.Clear();
            lbDiscount.Text = "Php 0.00";
            lbSubtotal.Text = "Php 0.00";
            lbTotal.Text = "Php 0.00";
            lbVat.Text = "Php 0.00";
            lbVatable.Text = "Php 0.00";
            lbVatExmpt.Text = "Php 0.00";
            lbTransacNum.Text = dbh.GenereateTransacNum();
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCart.RowCount != 0)
            {
                string prodCode = dgvCart.Rows[e.RowIndex].Cells["colProdCodeCart"].Value.ToString();
                int _qty = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["colQtyCart"].Value);

                if (dbh.isEnough(prodCode, _qty) == false)
                {
                    MessageBox.Show("Insufficient Stock");
                    dgvCart.Rows[e.RowIndex].Cells["colQtyCart"].Value = 1;
                }
                else
                {
                    Compute();

                    subtotal = ComputeSubTotal();
                    lbSubtotal.Text = "Php " + subtotal.ToString("0.00");

                    vatable = ComputeVatable();
                    lbVatable.Text = "Php " + vatable.ToString("0.00");

                    vat = ComputeVat();
                    lbVat.Text = "Php " + vat.ToString();

                    vatXmptSale = ComputeVatXmpt();
                    lbVatExmpt.Text = "Php " + vatXmptSale.ToString("0.00");

                    discount = ComputeLessDiscount();
                    lbDiscount.Text = "Php " + discount.ToString("0.00");

                    total = ComputeTotalAmoutDue();
                    lbTotal.Text = "Php " + total.ToString("0.00");
                }
            }
        }

        private void btnPrintRe_Click(object sender, EventArgs e)
        {
            DgvToDt();
            lbTransacNum.Text = dbh.GenereateTransacNum();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCart.Columns[e.ColumnIndex].Name.Equals("colQtyCart"))
            //MessageBox.Show("");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count != 0)// row has laman
            {
                CashTender ct = new CashTender(total);
                ct.ShowDialog();

                if (Properties.Settings.Default.isPayed == true)
                {
                    foreach (DataGridViewRow r in dgvCart.Rows)
                    {
                        dbh.InsertToSales(
                            lbTransacNum.Text.ToString(),
                            r.Cells["colProdCodeCart"].Value.ToString(),
                            r.Cells["colItemCart"].Value.ToString(),
                            r.Cells["colQtyCart"].Value.ToString(),
                            r.Cells["colUnitCostCart"].Value.ToString(),
                            r.Cells["colUnitPriceCart"].Value.ToString(),
                            r.Cells["colVatXCart"].Value.ToString(),
                            r.Cells["colDiscountCart"].Value.ToString(),
                            Math.Round(Convert.ToDouble(r.Cells["colQtyCart"].Value) * Convert.ToDouble(r.Cells["colUnitCostCart"].Value), 2).ToString(), //total cost
                            r.Cells["colTotalCart"].Value.ToString(),
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                            lbUser.Text.ToString()
                            );

                        dbh.UpdateInStockQty(r.Cells["colQtyCart"].Value.ToString(), r.Cells["colProdCodeCart"].Value.ToString());
                    }
                    MessageBox.Show("Transaction Saved");

                    DgvToDt();
                    lbTransacNum.Text = dbh.GenereateTransacNum();

                    lbCash.Text = "Php: " + Properties.Settings.Default.Cash;
                    lbChange.Text = "Php: " + Properties.Settings.Default.Change;

                    btnPayment.Enabled = false;

                    dgvDrugs.DataSource = dbh.ShowProductList();
                }
                
            }
            else { MessageBox.Show("No Items Added"); }

            lbTransacNum.Text = dbh.GenereateTransacNum();

            
        }

        private void btnNewTransacNum_Click(object sender, EventArgs e)
        {
            lbTransacNum.Text = dbh.GenereateTransacNum();

            dgvCart.Rows.Clear();
            lbDiscount.Text = "Php 0.00";
            lbSubtotal.Text = "Php 0.00";
            lbTotal.Text = "Php 0.00";
            lbVat.Text = "Php 0.00";
            lbVatable.Text = "Php 0.00";
            lbVatExmpt.Text = "Php 0.00";
            btnPayment.Enabled = true;
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e) // add minus qty
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

        }

    }
}
