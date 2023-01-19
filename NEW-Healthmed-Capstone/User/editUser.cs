using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.User
{
    public partial class editUser : Form
    {
        public editUser(string userID, string userName, string firstName, string lastName, string passCode, string contactNum, string email, string Role)
        {
            InitializeComponent();

            getUserID = userID;
            getUserName = userName;
            getfirstName = firstName;
            getlastName = lastName;
            getpassCode = passCode;
            getcontactNum = contactNum;
            getEmail = email;
            getRole = Role;
        }
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private MySqlConnectionStringBuilder mysqlConStrBldr;
        private MySqlConnection mysqlCon;

        string getUserID;
        string getUserName;
        string getfirstName;
        string getlastName;
        string getpassCode;
        string getcontactNum;
        string getEmail;
        string getRole;

        string emailExpression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        string contactNumExpression = @"^\d{11}$";
        string passExpression = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

        private void editUser_Load(object sender, EventArgs e)
        {
            ControlBox = false;

            tbUsername.Text = getUserName;
            tbFirstName.Text = getfirstName;
            tbLastName.Text = getlastName;
            tbPassword.Text = getpassCode;
            tbContactNum.Text = getcontactNum;
            tbEmail.Text = getEmail;

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
                cbRole.Text = getRole;
            }
            closeCon();
        }

        private void btnSaveUserInfo_Click(object sender, EventArgs e)
        {
            EditUserInfo();
        }
        private void EditUserInfo()
        {
            try
            {
                if (string.IsNullOrEmpty(tbUsername.Text) == false && string.IsNullOrEmpty(tbUsername.Text) == false && string.IsNullOrEmpty(tbLastName.Text) == false && Regex.IsMatch(tbEmail.Text, emailExpression) == true && Regex.IsMatch(tbContactNum.Text, contactNumExpression) == true && Regex.IsMatch(tbPassword.Text, passExpression) == true && tbPassword.Text == tbConfrimPassword.Text && cbRole.SelectedItem != null)
                {

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you want to Edit this Account? ", "Confirm", buttons);
                    if (result == DialogResult.Yes)
                    {

                        openCon();
                        cmd = new MySqlCommand("Select * from tbl_UserRole Where roleName = @Role", mysqlCon);
                        cmd.Parameters.AddWithValue("@Role", cbRole.Text);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string role = dr.GetString("userRoleID");

                            openCon();
                            cmd = new MySqlCommand("Update tbl_users SET userName = @Username, firstName = @firstName, lastName = @lastName, passcode = @password, contactNum = @contactNum, email = @Email, userRoleID = @RoleID Where userID = @ID", mysqlCon);
                            cmd.Parameters.AddWithValue("@Username", tbUsername.Text);
                            cmd.Parameters.AddWithValue("@firstName", tbFirstName.Text);
                            cmd.Parameters.AddWithValue("@lastName", tbLastName.Text);
                            cmd.Parameters.AddWithValue("@password", tbPassword.Text);
                            cmd.Parameters.AddWithValue("@contactNum", tbContactNum.Text);
                            cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
                            cmd.Parameters.AddWithValue("@RoleID", role);
                            cmd.Parameters.AddWithValue("@ID", getUserID);

                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Account Updated");
                                tbUsername.Clear();
                                tbFirstName.Clear();
                                tbLastName.Clear();
                                tbPassword.Clear();
                                tbConfrimPassword.Clear();
                                tbContactNum.Clear();
                                tbEmail.Clear();
                                cbRole.Text = "";
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("ERROR");
                            }
                            closeCon();
                        }
                    }

                    else
                    {
                        if (string.IsNullOrEmpty(tbUsername.Text) == true)
                        {
                            errorProvider1.SetError(this.tbUsername, "Please Fill Username");
                        }
                        else
                        {
                            errorProvider1.Clear();
                        }
                        if (string.IsNullOrEmpty(tbFirstName.Text) == true)
                        {
                            errorProvider2.SetError(this.tbFirstName, "Please Fill First Name");
                        }
                        else
                        {
                            errorProvider2.Clear();
                        }
                        if (string.IsNullOrEmpty(tbLastName.Text) == true)
                        {
                            errorProvider3.SetError(this.tbLastName, "Please Fill Last Name");
                        }
                        else
                        {
                            errorProvider3.Clear();
                        }
                        if (Regex.IsMatch(tbEmail.Text, emailExpression) == false)
                        {
                            errorProvider4.SetError(this.tbEmail, "Please Enter Valid Email");
                        }
                        else
                        {
                            errorProvider4.Clear();
                        }
                        if (Regex.IsMatch(tbContactNum.Text, contactNumExpression) == false)
                        {
                            errorProvider5.SetError(this.tbContactNum, "Please Fill Contact Number");
                        }
                        else
                        {
                            errorProvider5.Clear();
                        }
                        if (Regex.IsMatch(tbPassword.Text, passExpression) == false)
                        {
                            errorProvider6.SetError(this.tbPassword, "Please Enter a Strong Password Ex. !Q1w2e3r4");
                        }
                        else
                        {
                            errorProvider6.Clear();
                        }
                        if (tbPassword.Text != tbConfrimPassword.Text)
                        {
                            errorProvider7.SetError(this.tbConfrimPassword, "Password Mismtach");
                        }
                        else
                        {
                            errorProvider7.Clear();
                        }
                        if (cbRole.SelectedItem == null)
                        {
                            cbRole.Focus();
                            errorProvider8.SetError(this.cbRole, "Select Role");
                        }
                        else
                        {
                            errorProvider8.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorProvider9.SetError(this.tbUsername, "This Username already Taken");
            }
            finally { closeCon(); }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) == true)
            {
                errorProvider1.SetError(this.tbUsername, "Please Fill Username");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetterOrDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbFirstName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFirstName.Text) == true)
            {
                errorProvider2.SetError(this.tbFirstName, "Please Fill First Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLastName.Text) == true)
            {
                errorProvider3.SetError(this.tbLastName, "Please Fill Last Name");
            }
            else
            {
                errorProvider3.Clear();

            }
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbEmail_MouseLeave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(tbEmail.Text, emailExpression) == false)
            {
                errorProvider4.SetError(this.tbEmail, "Please Enter Valid Email");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void tbContactNum_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(tbContactNum.Text, contactNumExpression) == false)
            {
                errorProvider5.SetError(this.tbContactNum, "Please Fill Contact Number");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void tbContactNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(tbPassword.Text, passExpression) == false)
            {
                errorProvider6.SetError(this.tbPassword, "Please Enter a Strong Password Ex. !Q1w2e3r4");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void tbConfrimPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text != tbConfrimPassword.Text)
            {
                errorProvider7.SetError(this.tbConfrimPassword, "Password Mismtach");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void cbRole_Leave(object sender, EventArgs e)
        {
            if (cbRole.SelectedItem == null)
            {

                errorProvider8.SetError(this.cbRole, "Select Role");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
