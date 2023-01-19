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

namespace NEW_Healthmed_Capstone.User
{
    public partial class userList : Form
    {
        public userList()
        {
            InitializeComponent();
        }

        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private MySqlConnectionStringBuilder mysqlConStrBldr;
        private MySqlConnection mysqlCon;

        private void userList_Load(object sender, EventArgs e)
        {
            MaximizeBox= false;
            MinimizeBox= false;

            showUserList();
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
        private void showUserList()
        {
            try
            {
                openCon();
                cmd = new MySqlCommand("select userid, username, firstname, lastname, passcode, contactnum, email, tbl_userrole.roleName, tbl_user_status.statusName \r\nfrom tbl_users\r\ninner join tbl_userrole on tbl_users.userRoleID = tbl_userrole.userRoleID\r\ninner join tbl_user_status on tbl_users.status = tbl_user_status.statusID\r\nwhere tbl_users.isArchive = 0;", mysqlCon);
                dr = cmd.ExecuteReader();
                this.dgvUserList.Rows.Clear();
                while (dr.Read())
                {
                    dgvUserList.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()
                        , dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message.ToString()); }
            finally
            {
                dr.Close();
                dr.Dispose();
                closeCon();
            }
        }
        private void EditAtUser(int rowIndex)
        {
            try
            {
                string userID = Convert.ToString(dgvUserList.Rows[rowIndex].Cells["colUserID"].Value);

                openCon();
                cmd = new MySqlCommand("Select * from tbl_users Where userID = @userID limit 1", mysqlCon);
                cmd.Parameters.AddWithValue("@userID", userID);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string userName = dr.GetString("userName");
                    string firstName = dr.GetString("firstName");
                    string lastName = dr.GetString("lastName");
                    string passCode = dr.GetString("passcode");
                    string contactNum = dr.GetString("contactNum");
                    string email = dr.GetString("email");
                    string UserRoleID = dr.GetString("userRoleID");

                    openCon();
                    cmd = new MySqlCommand("Select * from tbl_userrole Where userRoleID = @userRoleID limit 1", mysqlCon);
                    cmd.Parameters.AddWithValue("@userRoleID", UserRoleID);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string Role = dr.GetString("roleName");

                        editUser eUser = new editUser(userID, userName, firstName, lastName, passCode, contactNum, email, Role);
                        eUser.ShowDialog();

                    }
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message.ToString()); }
            finally { closeCon(); showUserList(); }
        }
        private void deactAccount(int rowIndex)
        {
            try
            {
                string userID = Convert.ToString(dgvUserList.Rows[rowIndex].Cells["colUserID"].Value);

                openCon();
                cmd = new MySqlCommand("Select * from tbl_users Where userID = @userID limit 1", mysqlCon);
                cmd.Parameters.AddWithValue("@userID", userID);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string statusID = dr.GetString("status");

                    if (statusID == "1")
                    {
                        openCon();
                        cmd = new MySqlCommand("UPDATE tbl_users SET status ='2' WHERE userID = @userID", mysqlCon);
                        cmd.Parameters.AddWithValue("@userID", userID);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Account deactivated");
                        }
                        closeCon();
                        showUserList();
                    }
                    if (statusID == "2")
                    {
                        openCon();
                        cmd = new MySqlCommand("UPDATE tbl_users SET status ='1' WHERE userID = @userID", mysqlCon);
                        cmd.Parameters.AddWithValue("@userID", userID);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Account Activated");
                        }
                        closeCon();
                        showUserList();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { closeCon(); showUserList(); }
        }
        private void deleteAccount(int rowIndex)
        {
            try
            {
                string userID = Convert.ToString(dgvUserList.Rows[rowIndex].Cells["colUserID"].Value);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Do you wish to Delete this Account? ", "Confirm", buttons);
                if (result == DialogResult.Yes)
                {
                    openCon();
                    cmd = new MySqlCommand("UPDATE tbl_users SET isArchive ='1' WHERE userID = @userID", mysqlCon);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Account Deleted");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { closeCon(); showUserList(); }
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUserList.Columns[e.ColumnIndex].Name == "colEdit")
            {
                if (dgvUserList.Columns[1].Name.ToString().Equals("colUsername"))
                {
                    EditAtUser(e.RowIndex);
                }
            }
            if (dgvUserList.Columns[e.ColumnIndex].Name == "colDeact")
            {
                if (dgvUserList.Columns[1].Name.ToString().Equals("colUsername"))
                {
                    deactAccount(e.RowIndex);
                }
            }
            if (dgvUserList.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (dgvUserList.Columns[1].Name.ToString().Equals("colUsername"))
                {
                    deleteAccount(e.RowIndex);
                }
            }
        }
    }
}
