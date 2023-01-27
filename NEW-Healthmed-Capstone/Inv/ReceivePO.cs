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
            dgvPoList.DataSource = dbh.ShowPoList();
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


            dgvPoList.DataSource = dbh.ShowPoList();
        }
    }
}
