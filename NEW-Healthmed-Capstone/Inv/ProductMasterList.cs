using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.CrystalReportsFolder;
using NEW_Healthmed_Capstone.DBhelperFolder;
using NEW_Healthmed_Capstone.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class ProductMasterList : Form
    {
        public ProductMasterList()
        {
            InitializeComponent();
        }
        private DBhelperClass dbh = new DBhelperClass();
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private void ProductMasterList_Load(object sender, EventArgs e)
        {
            dgvProductMasterList.DataSource = dbh.ShowProductMasterList();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportProductMasterList();
        }
        private void ReportProductMasterList()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Product Code", typeof(string));
            dt.Columns.Add("Product Name", typeof(string));
            dt.Columns.Add("Classification ", typeof(string));
            dt.Columns.Add("Dosage", typeof(string));
            dt.Columns.Add("Med Type", typeof(string));
            dt.Columns.Add("Unit Cost", typeof(string));
            dt.Columns.Add("Unit Price", typeof(string));
            dt.Columns.Add("In Stock Qty.", typeof(string));
            dt.Columns.Add("Reorder point", typeof(string));
            dt.Columns.Add("Safety Stock per week", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));

            foreach (DataGridViewRow r in dgvProductMasterList.Rows)
            {
                dt.Rows.Add(
                    r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(),
                    r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(),

                    r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString(),
                    r.Cells[6].Value.ToString(),
                    r.Cells[7].Value.ToString(),

                    r.Cells[8].Value.ToString(),
                    r.Cells[9].Value.ToString(),
                    r.Cells[10].Value.ToString(),
                    r.Cells[11].Value.ToString()
                    );
            }

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("ProductMasterListReport.xml");

            ProductMasterListReportViewer pmlrv = new ProductMasterListReportViewer();
            ProductMasterListReport prmlr = new ProductMasterListReport();

            dbh.OpenCon();
            cmd = new MySqlCommand("SELECT * FROM tbl_users WHERE userName = @user ", dbh.conn());
            cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.Login_Username);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextObject User = (TextObject)prmlr.ReportDefinition.Sections["Section5"].ReportObjects["UserBy"];
                User.Text = dr.GetString("firstName") + " " + dr.GetString("lastName");
            }

            dbh.CloseCon();

            prmlr.SetDataSource(ds);
            pmlrv.crtProductMasterList.ReportSource = prmlr;

            pmlrv.Refresh();
            pmlrv.Show();
        }

        private void RefStockUdjust_TextChanged(object sender, EventArgs e)
        {
            if (ProductSearch.Text == null || ProductSearch.Text.ToString().Equals(""))
                dgvProductMasterList.DataSource = dbh.ShowProductMasterList();
            else
                dgvProductMasterList.DataSource = dbh.ShowProductMasterList1(ProductSearch.Text);
        }
    }
}
