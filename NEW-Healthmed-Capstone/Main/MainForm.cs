using MySql.Data.MySqlClient;
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
            MaximizeBox = false;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;

            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;

            label9.Parent = pictureBox1;
            label9.BackColor = Color.Transparent;

            label10.Parent = pictureBox1;
            label10.BackColor = Color.Transparent;

            label11.Parent = pictureBox1;
            label11.BackColor = Color.Transparent;

            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                openCon();
                cmd = new MySqlCommand("SELECT * FROM tbl_users", mysqlCon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string getfirstName = dr.GetString("firstName");
                    string getLastName = dr.GetString("lastName");
                    string getUser = getfirstName + " " + getLastName;
                    string getRoleID = dr.GetString("userRoleID");
                    lbUser.Text = getUser;

                    openCon();
                    cmd = new MySqlCommand("SELECT * FROM tbl_userrole Where userRoleID = @ID", mysqlCon);
                    cmd.Parameters.AddWithValue("@ID", getRoleID);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string getRole = dr.GetString("roleName");
                        lbRole.Text = getRole;
                    }
                }

            }
            catch (Exception ex) { }
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
           inventory inv = new inventory();
           inv.Show();
           this.Close();
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
    }
}
