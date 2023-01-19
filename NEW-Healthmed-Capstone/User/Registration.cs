using MySql.Data.MySqlClient;
using System;
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
            ControlBox= false;
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
        public void register()
        {
            if (textBoxUserName.Text != "" && textBoxFirstName.Text != "" && textBoxLastName.Text != "" && textBoxEmail.Text != "" && textBoxContactNum.Text != "" && textBoxPassword.Text != "" && cbRole.Text != "")
            {
                openCon();
                cmd = new MySqlCommand("Select * from tbl_UserRole Where roleName = @Role", mysqlCon);
                cmd.Parameters.AddWithValue("@Role", cbRole.Text);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string role = dr.GetString("userRoleID");

                    openCon();
                    cmd = new MySqlCommand("insert into tbl_users(userName, firstName, lastName, passcode, contactNum, email, userRoleID) Values(@UserName, @Firstname, @Lastname, @Password, @ContactNum, @Email, @Role)", mysqlCon);
                    cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
                    cmd.Parameters.AddWithValue("@Firstname", textBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@Lastname", textBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@ContactNum", textBoxContactNum.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@Role", role);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Registered");
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                    closeCon();
                }
                closeCon();
            }
            else
            {
                MessageBox.Show("Incomplete registration");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            register();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
