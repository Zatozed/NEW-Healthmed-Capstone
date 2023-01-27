using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.CrystalReportsFolder;
using NEW_Healthmed_Capstone.DBhelperFolder;
using NEW_Healthmed_Capstone.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Reports
{
    public partial class ReportsMenu : Form
    {
        public ReportsMenu()
        {
            InitializeComponent();
        }

        private DBhelperClass dbh = new DBhelperClass();
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        private void btnSales_Click(object sender, EventArgs e)
        {
            SalesReportGenerator sr = new SalesReportGenerator();
            sr.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ReportProducts();
        }
        private void ReportProducts()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("Product Code", typeof(string));
            dt.Columns.Add("Product Name", typeof(string));
            dt.Columns.Add("Classification ", typeof(string));
            dt.Columns.Add("Dosage", typeof(string));
            dt.Columns.Add("Med Type", typeof(string));

            dbh.OpenCon();
            cmd = new MySqlCommand("SELECT * FROM tbl_products;", dbh.conn());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(
                dr.GetString("product_code"),
                dr.GetString("product_name"),
                dr.GetString("classification"),
                dr.GetString("dosage"),
                dr.GetString("med_type"));
            }
            dbh.CloseCon();
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("ProductReport.xml");

            ProductReportViewer prv = new ProductReportViewer();
            ProductReport rptPR = new ProductReport();

            dbh.OpenCon();
            cmd = new MySqlCommand("SELECT * FROM tbl_users WHERE userName = @user ", dbh.conn());
            cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.Login_Username);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextObject User = (TextObject)rptPR.ReportDefinition.Sections["Section5"].ReportObjects["User"];
                User.Text = dr.GetString("firstName") + " " + dr.GetString("lastName");
            }

            dbh.CloseCon();

            rptPR.SetDataSource(ds);
            prv.crtProduct.ReportSource = rptPR;

            prv.Refresh();
            prv.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ReportSupplier();
        }
        private void ReportSupplier()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("Supplier Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Address ", typeof(string));
            dt.Columns.Add("Contact #", typeof(string));
            dt.Columns.Add("Email Address", typeof(string));
            dt.Columns.Add("Lead Time", typeof(string));

            dbh.OpenCon();
            cmd = new MySqlCommand("SELECT * FROM tbl_suppliers;", dbh.conn());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(
                dr.GetString("supplier_name"),
                dr.GetString("sup_description"),
                dr.GetString("address"),
                dr.GetString("contact_num"),
                dr.GetString("email_ad"),
                dr.GetString("lead_time"));
            }
            dbh.CloseCon();
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("SupplierReport.xml");

            SupplierReportViewer srv = new SupplierReportViewer();
            SupplierReport rptSP = new SupplierReport();
            

            dbh.OpenCon();
            cmd = new MySqlCommand("SELECT * FROM tbl_users WHERE userName = @user ", dbh.conn());
            cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.Login_Username);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextObject User = (TextObject)rptSP.ReportDefinition.Sections["Section5"].ReportObjects["User"];
                User.Text = dr.GetString("firstName") + " " + dr.GetString("lastName");
            }

            dbh.CloseCon();

            rptSP.SetDataSource(ds);
            srv.crtSupplier.ReportSource = rptSP;

            srv.Refresh();
            srv.Show();
        }
    }
}
