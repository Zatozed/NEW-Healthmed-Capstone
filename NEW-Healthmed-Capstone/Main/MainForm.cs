using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.DBhelperFolder;
using NEW_Healthmed_Capstone.file_maintenance;
using NEW_Healthmed_Capstone.Inv;
using NEW_Healthmed_Capstone.Point_of_Sale;
using NEW_Healthmed_Capstone.Reports;
using NEW_Healthmed_Capstone.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Main
{
    public partial class MainForm : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        public MainForm()
        {
            InitializeComponent();
            timer1.Start();
        }
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private MySqlConnectionStringBuilder mysqlConStrBldr;
        private MySqlConnection mysqlCon;

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvExpiry.DataSource = dbh.ShowExpiry();

            var dateNow = DateTime.Now;

            foreach (DataGridViewRow r in dgvExpiry.Rows)
            {
                var dateDif = Convert.ToDateTime(r.Cells["colExpiry"].Value) - dateNow;
                r.Cells["colDaysL"].Value = dateDif.Days;
            }

            MaximizeBox = false;

            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                openCon();
                cmd = new MySqlCommand("SELECT * FROM tbl_users WHERE userName = @user ", mysqlCon);
                cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.Login_Username);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string getfirstName = dr.GetString("firstName");
                    string getLastName = dr.GetString("lastName");
                    string getUser = getfirstName + " " + getLastName;
                    string getRoleID = dr.GetString("userRoleID");
                    lbUser.Text = getUser;
                    closeCon();

                    openCon();
                    cmd = new MySqlCommand("SELECT * FROM tbl_userrole Where userRoleID = @ID", mysqlCon);
                    cmd.Parameters.AddWithValue("@ID", getRoleID);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string getRole = dr.GetString("roleName");

                        lbRole.Text = getRole;
                        if (getRoleID == "2")
                        {
                            btnInventory.Visible = false;
                            btnFilemaintenance.Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show("Something went wrong"); }
            finally { closeCon(); }

        }
        private void openCon()
        {
            mysqlConStrBldr = new MySqlConnectionStringBuilder(Properties.Settings.Default.S_ConBuild);
            mysqlCon = new MySqlConnection(mysqlConStrBldr.ConnectionString);
            mysqlCon.Open();
        }

        private void closeCon()
        {
            mysqlConStrBldr = new MySqlConnectionStringBuilder(Properties.Settings.Default.S_ConBuild);
            mysqlCon = new MySqlConnection(mysqlConStrBldr.ConnectionString);
            mysqlCon.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnFilemaintenance_Click(object sender, EventArgs e)
        {
            FileMaintenance fileMain = new FileMaintenance();
            fileMain.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSettings userSet = new UserSettings();
            userSet.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
           InventoryMenu im = new InventoryMenu();
            im.ShowDialog();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            //POS1 pos1 = new POS1();
            //pos1.ShowDialog();

            POS pos = new POS();
            pos.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsMenu menu = new ReportsMenu();
            menu.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
