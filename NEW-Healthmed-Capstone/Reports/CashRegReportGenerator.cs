using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.CrystalReportsFolder;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Data;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Reports
{
    public partial class CashRegReportGenerator : Form
    {
        DBhelperClass dbh = new DBhelperClass();

        double cash_out_total;
        double starting;
        double ending;
        double ending_plus_cash_out;
        double dif;
        double dif_with_co;
        public CashRegReportGenerator()
        {
            InitializeComponent();
        }
        private void DgvToDt()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("Action", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("Date", typeof(string));

            foreach (DataGridViewRow r in dgvCashReg.Rows)
            {
                dt.Rows.Add(r.Cells["colAction"].Value.ToString(),
                    r.Cells["colAmount"].Value.ToString(),
                    r.Cells["colDate"].Value.ToString()
                    );
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("CashReg.xml");

            CashReg cr = new CashReg(); // crystal reports
            CashRegReportViewer crrv = new CashRegReportViewer(); // form viewer

            cr.SetDataSource(ds);
            crrv.crtCashRegReport.ReportSource = cr;

            TextObject toGe = (TextObject)cr.ReportDefinition.Sections["Section5"].ReportObjects["toGeBy"];
            toGe.Text = Properties.Settings.Default.Fname_Lname;

            TextObject toCahier = (TextObject)cr.ReportDefinition.Sections["Section5"].ReportObjects["toCashier"];
            toCahier.Text = cbUsers.Text;

            TextObject toSt = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["toSt"];
            toSt.Text = starting.ToString("00.00");

            TextObject toEd = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["toEd"];
            toEd.Text = ending.ToString("00.00");

            TextObject toDif = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["toDif"];
            toDif.Text = dif.ToString("00.00");

            TextObject toTcO = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["toTcO"];
            toTcO.Text = cash_out_total.ToString("00.00");

            TextObject toEdCo = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["toEdCo"];
            toEdCo.Text = ending_plus_cash_out.ToString("00.00");

            TextObject toDifCo = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["toDifCo"];
            toDifCo.Text = dif_with_co.ToString("00.00");

            crrv.crtCashRegReport.Refresh();
            crrv.Show();
        }
        private void fillCbUsers()
        {
            cbUsers.Items.Clear();
            foreach(string user in dbh.Users())
            {
                cbUsers.Items.Add(user);
            }
        }
        private void Difference() 
        {
            dif = ending - starting;
        }
        private void DifferenceWithCashOut() 
        {
            dif_with_co = ending_plus_cash_out - starting;
        }
        private void CashRegReportGenerator_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserRole.Equals("Admin")) 
            {
                fillCbUsers();
            }
            else 
            {
                cbUsers.Items.Clear();
                cbUsers.Items.Add(Properties.Settings.Default.Fname_Lname);
            }
            
            dgvCashReg.AutoGenerateColumns = false;
        }
        private void GetEdCash()
        {
            ending = 0;

            if (dgvCashReg.Rows != null)
            {
                foreach (DataGridViewRow r in dgvCashReg.Rows)
                {
                    if (r.Cells["colAction"].Value.ToString().Equals("Ending"))
                    {
                        ending = Convert.ToDouble(r.Cells["colAmount"].Value);
                    }
                }
            }
        }
        private void GetStartingCash()
        {
            starting = 0;

            if (dgvCashReg.Rows != null)
            {
                foreach (DataGridViewRow r in dgvCashReg.Rows)
                {
                    if (r.Cells["colAction"].Value.ToString().Equals("Starting"))
                    {
                        starting = Convert.ToDouble(r.Cells["colAmount"].Value);
                    }
                }
            }
        }

        private void ComputeEndingPlusCashOut()
        {
            ending_plus_cash_out = ending + cash_out_total;
        }

        private void ComputeTotalCashOut()
        {
            cash_out_total = 0;

            if (dgvCashReg.Rows != null)
            {
                foreach (DataGridViewRow r in dgvCashReg.Rows)
                {
                    if (r.Cells["colAction"].Value.ToString().Equals("Cash Out"))
                    {
                        cash_out_total += Convert.ToDouble(r.Cells["colAmount"].Value);
                    }
                }
            }
        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            dgvCashReg.DataSource = dbh.ShowCashReg(cbUsers.Text, dt1.Value.ToString("yyyy-MM-dd"));

            ComputeTotalCashOut();
            GetEdCash();
            ComputeEndingPlusCashOut();
            GetStartingCash();
            Difference();
            DifferenceWithCashOut();

            lbStarting.Text = "Starting: " + starting.ToString("00.00");
            lbEnding.Text = "Ending: " + ending.ToString("00.00");
            lbEdPlusCo.Text = "Ending + Cash Out: " + ending_plus_cash_out.ToString("00.00");

            lbTotalCashOut.Text = "Total Cash Out: " + cash_out_total.ToString("00.00");
            lbDif.Text = "Difference: " + dif.ToString("00.00");
            lbDifPlusCo.Text = "Difference with Cash Out: " + dif_with_co.ToString("00.00");


        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCashReg.DataSource = dbh.ShowCashReg(cbUsers.Text, dt1.Value.ToString("yyyy-MM-dd"));

            ComputeTotalCashOut();
            GetEdCash();
            ComputeEndingPlusCashOut();
            GetStartingCash();
            Difference();
            DifferenceWithCashOut();

            lbStarting.Text = "Starting: " + starting.ToString("00.00");
            lbEnding.Text = "Ending: " + ending.ToString("00.00");
            lbEdPlusCo.Text = "Ending + Cash Out: " + ending_plus_cash_out.ToString("00.00");

            lbTotalCashOut.Text = "Total Cash Out: " + cash_out_total.ToString("00.00");
            lbDif.Text = "Difference: " + dif.ToString("00.00");
            lbDifPlusCo.Text = "Difference with Cash Out: " + dif_with_co.ToString("00.00");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dgvCashReg.Rows.Count != 0)
            {
                DgvToDt();
            }
            else 
            {
                MessageBox.Show("No Data Present");
            }
        }
    }
}
