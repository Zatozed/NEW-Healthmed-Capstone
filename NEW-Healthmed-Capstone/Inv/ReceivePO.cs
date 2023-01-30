using CrystalDecisions.CrystalReports.Engine;
using NEW_Healthmed_Capstone.CrystalReportsFolder;
using NEW_Healthmed_Capstone.DatePicker;
using NEW_Healthmed_Capstone.DBhelperFolder;
using NEW_Healthmed_Capstone.Reports;
using System;
using System.Data;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.FieldOptions.Types;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class ReceivePO : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        public ReceivePO()
        {
            InitializeComponent();
        }
        private void DgvToDt()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("Product Code", typeof(string));
            dt.Columns.Add("Product Description", typeof(string));
            dt.Columns.Add("Pending Quantity", typeof(string));
            dt.Columns.Add("Ordered Quantity", typeof(string));
            dt.Columns.Add("Received Quantity", typeof(string));
            dt.Columns.Add("Expiry Date", typeof(string));
            dt.Columns.Add("Lot #", typeof(string));

            foreach (DataGridViewRow r in dgvToReceive.Rows)
            {
                dt.Rows.Add(r.Cells["colProductCode"].Value.ToString(),
                    r.Cells["colProductDes"].Value.ToString(),
                    r.Cells["colReQty"].Value.ToString(),
                    r.Cells["colPendingQty"].Value.ToString(),
                    r.Cells["colOrderedQty"].Value.ToString(),
                    r.Cells["colExpiryDate"].Value.ToString(),
                    r.Cells["colLot"].Value.ToString()
                    );
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("ReceivePO.xml");

            RPOReport rPO = new RPOReport();
            RPOReportViewer rPOV = new RPOReportViewer();

            rPO.SetDataSource(ds);
            rPOV.crtViewer.ReportSource= rPO;

            TextObject toGe = (TextObject)rPO.ReportDefinition.Sections["Section5"].ReportObjects["toGeneratedBy"];
            toGe.Text = Properties.Settings.Default.Fname_Lname;

            rPOV.crtViewer.Refresh();
            rPOV.Show();
        }
        private void tbPOnum_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                dgvToReceive.DataSource = dbh.ShowPoList(tbPOnum.Text.ToString());

                tbHmdAdress.Text = dgvToReceive.Rows[0].Cells["colHmAd"].Value.ToString();
                tbHmdContactNum.Text = dgvToReceive.Rows[0].Cells["colHmConNum"].Value.ToString();
                tbHmdEmail.Text = dgvToReceive.Rows[0].Cells["colHmEmail"].Value.ToString();

                tbSup.Text = dgvToReceive.Rows[0].Cells["colSupplier"].Value.ToString();
                tbSupAddress.Text = dgvToReceive.Rows[0].Cells["colSupAd"].Value.ToString();
                tbSupContactNum.Text = dgvToReceive.Rows[0].Cells["colSupConNum"].Value.ToString();
                tbSupEmail.Text = dgvToReceive.Rows[0].Cells["colSupEmail"].Value.ToString();

                tbReName.Text = dgvToReceive.Rows[0].Cells["colReName"].Value.ToString();
                tbReAd.Text = dgvToReceive.Rows[0].Cells["colReAd"].Value.ToString();
                tbReNum.Text = dgvToReceive.Rows[0].Cells["colReConNum"].Value.ToString();
                tbReEmail.Text = dgvToReceive.Rows[0].Cells["colReEmail"].Value.ToString();
            }
            catch(Exception E) { MessageBox.Show(E.ToString()); }

            
        }

        private void ReceivePO_Load(object sender, EventArgs e)
        {
            dgvToReceive.AutoGenerateColumns = false;

            dgvPoList.DataSource = dbh.ShowPoList();

            dgvBackOrder.DataSource = dbh.ShowBackOrder();

            tbDateNow.Text = DateTime.Now.ToString("yyyy-MM-dd");

            
        }

        private void dgvPoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPoList.Columns[e.ColumnIndex].Name.Equals("colAddS"))
            {
                tbPOnum.Text = dgvPoList.Rows[e.RowIndex].Cells["colPoNumS"].Value.ToString();
                
            }
        }

        private void btnRe_Click(object sender, EventArgs e)
        {
            bool res = false;
            foreach (DataGridViewRow r in dgvToReceive.Rows)
            {
                if (r.Cells["colExpiryDate"].Value.ToString().Equals("Set Expiry")||
                    r.Cells["colReQty"].Value == null||
                    r.Cells["colReQty"].Value.ToString().Equals("") ||
                    r.Cells["colLot"].Value == null ||
                    r.Cells["colLot"].Value.ToString().Equals("")
                    )
                {
                    res = true;
                }
            }

            if (dgvToReceive.Rows.Count == 0 ||
                tbHmdAdress.Text.Equals("") ||
                tbHmdContactNum.Text.Equals("") ||
                tbHmdEmail.Text.Equals("") ||
                tbReAd.Text.Equals("") ||
                tbReEmail.Text.Equals("") ||
                tbReName.Text.Equals("") ||
                tbReNum.Text.Equals("") ||
                tbSup.Text.Equals("") ||
                tbSupAddress.Text.Equals("") ||
                tbSupContactNum.Text.Equals("") ||
                tbSupEmail.Text.Equals("") ||
                res == true
                )
            {
                MessageBox.Show("Make Sure All Field Are Filled");
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Receive These Product/s?", "Save", buttons);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow r in dgvToReceive.Rows)
                    {
                        dbh.InsertToRpo
                            (
                                r.Cells["colPOnum"].Value.ToString(),
                                r.Cells["colProductCode"].Value.ToString(),
                                r.Cells["colProductDes"].Value.ToString(),
                                r.Cells["colReQty"].Value.ToString(),

                                tbSup.Text.ToString(),
                                tbDateNow.Text.ToString(),
                                tbReName.Text.ToString(),
                                tbRemarks.Text.ToString()
                            );
                        dbh.InsertToExpiry
                            (
                                r.Cells["colProductCode"].Value.ToString(),
                                r.Cells["colProductDes"].Value.ToString(),
                                r.Cells["colLot"].Value.ToString(),
                                r.Cells["colExpiryDate"].Value.ToString()
                            );
                    }

                    dgvPoList.DataSource = dbh.ShowPoList();
                    dgvBackOrder.DataSource = dbh.ShowBackOrder();
                    //dgvToReceive.Rows.Clear();
                    DgvToDt();
                }

                dgvBackOrder.DataSource = dbh.ShowBackOrder();
                dgvPoList.DataSource = dbh.ShowPoList();
            }
            
        }

        private void dgvToReceive_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach(DataGridViewRow r in dgvToReceive.Rows) 
            {
                r.Cells["colExpiryDate"].Value = "Set Expiry";
            }
        }

        private void dgvBackOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBackOrder.Columns[e.ColumnIndex].Name.Equals("colAddBo"))
            {
                tbPOnum.Text = dgvBackOrder.Rows[e.RowIndex].Cells["colPoNumBo"].Value.ToString();

            }
        }

        private void dgvToReceive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvToReceive.Columns[e.ColumnIndex].Name.Equals("colExpiryDate"))
            {
                ExpirySetter dp = new ExpirySetter();
                dp.ShowDialog();

                dgvToReceive.Rows[e.RowIndex].Cells["colExpiryDate"].Value = Properties.Settings.Default.ExpiryDate;
            }
        }

        private void dgvToReceive_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            
            try
            {
                //if (Double.TryParse(dgvToReceive.Rows[e.RowIndex].Cells["colReQty"].Value.ToString(), out double r) == false && dgvToReceive.Rows[e.RowIndex].Cells["colReQty"] != null)
                //{
                //    MessageBox.Show("This Field Only Accepts Number");
                //}
            }
            catch (Exception cn) { }
        }


        private void dgvToReceive_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvToReceive.Columns[e.ColumnIndex].Name.Equals("colReQty")) 
            {
                //if (Double.TryParse(dgvToReceive.Rows[e.RowIndex].Cells["colReQty"].Value.ToString(), out double r))
                //{
                //    MessageBox.Show("This Field Only Accepts Number");
                //}
            }
            
        }
    }
}
