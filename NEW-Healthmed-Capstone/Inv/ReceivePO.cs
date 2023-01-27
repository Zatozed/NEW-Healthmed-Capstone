using NEW_Healthmed_Capstone.DatePicker;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class ReceivePO : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        public ReceivePO()
        {
            InitializeComponent();
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
                //DgvToDt();
            }

            dgvBackOrder.DataSource = dbh.ShowBackOrder();
            dgvPoList.DataSource = dbh.ShowPoList();
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
    }
}
