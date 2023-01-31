using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEW_Healthmed_Capstone.login;
using NEW_Healthmed_Capstone.Main;

namespace NEW_Healthmed_Capstone.User
{
    public partial class UserSettings : Form
    {

        public UserSettings()
        {
            InitializeComponent();
        }
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private MySqlConnectionStringBuilder mysqlConStrBldr;
        private MySqlConnection mysqlCon;

        private void UserSettings_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            openCon();
            cmd = new MySqlCommand("SELECT * FROM tbl_users WHERE userName = @user ", mysqlCon);
            cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.Login_Username);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string getRoleID = dr.GetString("userRoleID");
                closeCon();
                if (getRoleID == "2")
                {
                    btnUserList.Visible = false;
                    btnInfo.Location = new Point(147, 164);
                    btnRegister.Visible = false;
                    btnLogout.Location = new Point(147, 223);
                }
            }
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
        public void userInformation()
        {
            lbUsername.Text = Properties.Settings.Default.Login_Username;
            string info = lbUsername.Text;

            openCon();
            cmd = new MySqlCommand("select * from tbl_Users where userName = @Info", mysqlCon);
            cmd.Parameters.AddWithValue("@Info", info);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                string firstName = dr.GetString("firstName");
                string lastName = dr.GetString("lastName");
                string contactNum = dr.GetString("contactNum");
                string email = dr.GetString("email");

                lbFirstname.Text = firstName;
                lbLastname.Text = lastName;
                lbContactNum.Text = contactNum;
                lbEmail.Text = email;

            }
            closeCon();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            userInformation();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            userList userL = new userList();
            userL.ShowDialog();
        }
    }
}
