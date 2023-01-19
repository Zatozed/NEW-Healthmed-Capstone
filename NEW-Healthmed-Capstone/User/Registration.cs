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

        string emailExpression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        string contactNumExpression = @"^\d{11}$";
        string passExpression = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

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
            try
            {
                if (string.IsNullOrEmpty(textBoxUserName.Text) == false && string.IsNullOrEmpty(textBoxFirstName.Text) == false && string.IsNullOrEmpty(textBoxLastName.Text) == false && Regex.IsMatch(textBoxEmail.Text, emailExpression) == true && Regex.IsMatch(textBoxContactNum.Text, contactNumExpression) == true && Regex.IsMatch(textBoxPassword.Text, passExpression) == true && textBoxPassword.Text == textBoxConfirmPassword.Text && cbRole.SelectedItem != null)
                {

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure you complete your Registration? ", "Confirm", buttons);
                    if (result == DialogResult.Yes)
                    {
                        openCon();
                        cmd = new MySqlCommand("Select count(*) from tbl_users where Username=@Username", mysqlCon);
                        cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            string users = dr.GetString(0);
                            int userID = Int32.Parse(users);

                            if (1 == userID)
                            {
                                errorProvider9.SetError(this.textBoxUserName, "This Username already Exist");
                            }
                            else
                            {
                                errorProvider9.Clear();

                                openCon();
                                cmd = new MySqlCommand("Select * from tbl_UserRole Where roleName = @Role", mysqlCon);
                                cmd.Parameters.AddWithValue("@Role", cbRole.Text);
                                dr = cmd.ExecuteReader();

                                if (dr.Read())
                                {
                                    string role = dr.GetString("userRoleID");

                                    openCon();
                                    cmd = new MySqlCommand("insert into tbl_users(userName, firstName, lastName, passcode, contactNum, email, userRoleID, status) Values(@UserName, @Firstname, @Lastname, @Password, @ContactNum, @Email, @Role, '1')", mysqlCon);
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
                                        textBoxUserName.Clear();
                                        textBoxFirstName.Clear();
                                        textBoxLastName.Clear();
                                        textBoxPassword.Clear();
                                        textBoxConfirmPassword.Clear();
                                        textBoxContactNum.Clear();
                                        textBoxEmail.Clear();
                                        cbRole.Text = "";
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("ERROR");
                                    }
                                    closeCon();
                                }
                                closeCon();
                            }
                        }
                        closeCon();
                    }
                }

                else
                {
                    if (string.IsNullOrEmpty(textBoxUserName.Text) == true)
                    {
                        errorProvider1.SetError(this.textBoxUserName, "Please Fill Username");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }
                    if (string.IsNullOrEmpty(textBoxFirstName.Text) == true)
                    {
                        errorProvider2.SetError(this.textBoxFirstName, "Please Fill First Name");
                    }
                    else
                    {
                        errorProvider2.Clear();
                    }
                    if (string.IsNullOrEmpty(textBoxLastName.Text) == true)
                    {
                        errorProvider3.SetError(this.textBoxLastName, "Please Fill Last Name");
                    }
                    else
                    {
                        errorProvider3.Clear();
                    }
                    if (Regex.IsMatch(textBoxEmail.Text, emailExpression) == false)
                    {
                        errorProvider4.SetError(this.textBoxEmail, "Please Enter Valid Email");
                    }
                    else
                    {
                        errorProvider4.Clear();
                    }
                    if (Regex.IsMatch(textBoxContactNum.Text, contactNumExpression) == false)
                    {
                        errorProvider5.SetError(this.textBoxContactNum, "Please Fill Contact Number");
                    }
                    else
                    {
                        errorProvider5.Clear();
                    }
                    if (Regex.IsMatch(textBoxPassword.Text, passExpression) == false)
                    {
                        errorProvider6.SetError(this.textBoxPassword, "Please Enter a Strong Password Ex. !Q1w2e3r4");
                    }
                    else
                    {
                        errorProvider6.Clear();
                    }
                    if (textBoxPassword.Text != textBoxConfirmPassword.Text)
                    {
                        errorProvider7.SetError(this.textBoxConfirmPassword, "Password Mismtach");
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
            catch (Exception ex)
            {
                errorProvider9.SetError(this.textBoxUserName, "This Username already Exist");
            }
            finally { closeCon(); }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            register();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();
            errorProvider7.Clear();
            errorProvider8.Clear();
            errorProvider9.Clear();
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUserName.Text) == true)
            {
                errorProvider1.SetError(this.textBoxUserName, "Please Fill Username");
            }
            else
            {
                errorProvider1.Clear();
            }
            openCon();
            cmd = new MySqlCommand("Select count(*) from tbl_users where Username=@Username", mysqlCon);
            cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string users = dr.GetString(0);
                int userID = Int32.Parse(users);

                if (1 == userID)
                {
                    errorProvider9.SetError(this.textBoxUserName, "This Username already Exist");
                }
                else
                {
                    errorProvider9.Clear();
                }
            }
            closeCon();
        }

        private void textBoxUserName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFirstName.Text) == true)
            {
                errorProvider2.SetError(this.textBoxFirstName, "Please Fill First Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxEmail.Text, emailExpression) == false)
            {
                errorProvider4.SetError(this.textBoxEmail, "Please Enter Valid Email");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBoxContactNum_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxContactNum.Text, contactNumExpression) == false)
            {
                errorProvider5.SetError(this.textBoxContactNum, "Please Fill Contact Number");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBoxContactNum_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxPassword.Text, passExpression) == false)
            {
                errorProvider6.SetError(this.textBoxPassword, "Please Enter a Strong Password Ex. !Q1w2e3r4");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                errorProvider7.SetError(this.textBoxConfirmPassword, "Password Mismtach");
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

        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLastName.Text) == true)
            {
                errorProvider3.SetError(this.textBoxLastName, "Please Fill Last Name");
            }
            else
            {
                errorProvider3.Clear();
            }
        }
    }
}
