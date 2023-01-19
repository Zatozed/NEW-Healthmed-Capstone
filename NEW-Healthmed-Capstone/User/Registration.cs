using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.User
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private MySqlConnectionStringBuilder mysqlConStrBldr;
        private MySqlConnection mysqlCon;

        private void Registration_Load(object sender, EventArgs e)
        {
            try
            {
                openCon();
                fillComboBoxRole();
            }
            catch (Exception exc) { MessageBox.Show("Something went wrong"); }
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
        private void fillComboBoxRole()
        {
            cbRole.Items.Clear();
            openCon();
            cmd = new MySqlCommand("select roleName from tbl_UserRole", mysqlCon);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbRole.Items.Add(dr[0]);
            }
            closeCon();
        }
    }
}
