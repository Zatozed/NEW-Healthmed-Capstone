using CrystalDecisions.CrystalReports.Engine;
using NEW_Healthmed_Capstone.CrystalReportsFolder;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Data;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Reports
{
    public partial class SalesReportGenerator : Form
    {
        private DBhelperClass dbh = new DBhelperClass();

        private double grand_total_cost, grand_total_sales, profit;
        public SalesReportGenerator()
        {
            InitializeComponent();
        }
        private void ComputeProfit()
        {
            foreach (DataGridViewRow r in dgvSales.Rows)
            {
                grand_total_cost += Math.Round(
                    Convert.ToDouble(r.Cells["colTotalCost"].Value)
                    ,2);
            }

            foreach (DataGridViewRow r in dgvSales.Rows)
            {
                grand_total_sales += Math.Round(
                    Convert.ToDouble(r.Cells["colTotalSales"].Value)
                    , 2);
            }
            profit = grand_total_sales - grand_total_cost;
        }
        private void DgvToDt()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("Transaction #", typeof(string));
            dt.Columns.Add("Product Code", typeof(string));
            dt.Columns.Add("Item Description", typeof(string));
            dt.Columns.Add("Qty", typeof(string));

            dt.Columns.Add("Unit Cost", typeof(string));
            dt.Columns.Add("Unit Price", typeof(string));
            dt.Columns.Add("VAT Exempt Sales", typeof(string));
            dt.Columns.Add("Discount", typeof(string));

            dt.Columns.Add("Total Cost", typeof(string));
            dt.Columns.Add("Total Sales", typeof(string));
            dt.Columns.Add("Transaction Date", typeof(string));
            dt.Columns.Add("Cashier", typeof(string));

            foreach (DataGridViewRow r in dgvSales.Rows)
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
            ds.WriteXmlSchema("SalesReport.xml");

            SalesReportViewer srv = new SalesReportViewer();
            SalesReport rptSR = new SalesReport();

            rptSR.SetDataSource(ds);
            srv.crtSalesReport.ReportSource = rptSR;

            TextObject toGTC = (TextObject)rptSR.ReportDefinition.Sections["Section4"].ReportObjects["tbGTC"];
            toGTC.Text = lbGTC.Text;

            TextObject toGTS = (TextObject)rptSR.ReportDefinition.Sections["Section4"].ReportObjects["tbGTS"];
            toGTS.Text = lbGTS.Text;

            TextObject toProfit = (TextObject)rptSR.ReportDefinition.Sections["Section4"].ReportObjects["tbProfit"];
            toProfit.Text = lbProfit.Text;

            srv.Refresh();
            srv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DgvToDt();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            dgvSales.DataSource = dbh.ShowSales();

            ComputeProfit();

            lbGTC.Text = grand_total_cost.ToString();
            lbGTS.Text = grand_total_sales.ToString();
            lbProfit.Text = profit.ToString();
        }

        private void tbTransacNum_TextChanged(object sender, EventArgs e)
        {
            if (tbTransacNum.Text.ToString().Equals(""))
            {
                dgvSales.DataSource = dbh.ShowSales();
            }
            else 
            {
                dgvSales.DataSource = dbh.ShowSales(tbTransacNum.Text);
            }
        }
    }
}
