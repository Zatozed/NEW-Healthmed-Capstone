using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.file_maintenance;
using NEW_Healthmed_Capstone.login;
using NEW_Healthmed_Capstone.Main;

namespace NEW_Healthmed_Capstone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private MySqlConnectionStringBuilder mysqlConStrBldr;
        private MySqlConnection mysqlCon;

        int countdown = 0;
        int attempts = 0;

        private void Login_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;

            textBoxUserName.Text = Properties.Settings.Default.Login_Username;

            //Disable configure label if it is connected to the database
            try
            {
                openCon();
                if (mysqlCon != null)
                {
                    labelConfigure.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Not Connected"); }
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

        public void logIn()
        {
            try
            {
                openCon();

                cmd = new MySqlCommand("select firstName, lastName, status from tbl_users where BINARY userName =@Username AND BINARY passcode = @Password", mysqlCon);//ADmin admin
                cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
                cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string status = dr.GetString("status");

                        if (status == "1")
                        {
                            Properties.Settings.Default.Fname_Lname = dr["firstName"].ToString() + " " + dr["lastName"].ToString();

                            MainForm main = new MainForm();
                            main.Show();
                            this.Hide();
                        }
                        else if (status == "2")
                        {
                            MessageBox.Show("This Account is Deactivated");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password");

                    attempts += 1;

                    if (attempts == 5)
                    {
                        MessageBox.Show("Many Attempts failed wait for 30 seconds to login again");

                        lbCooldown.Visible = true;
                        countdown = 30;
                        timer1.Start();
                        buttonLogin.Enabled = false;
                    }

                }
                closeCon();
            }

            catch (Exception exc)
            {
                MessageBox.Show("error");
                MessageBox.Show("Something went wrong with the LogIn Module");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            logIn();
        }
        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
            if (e.KeyCode == Keys.Tab)
            {
                textBoxPassword.Focus();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
            if (e.KeyCode == Keys.Tab)
            {
                buttonLogin.Focus();
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void buttonLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                textBoxUserName.Focus();
            }
        }
        private void labelConfigure_Click(object sender, EventArgs e)
        {
            Configure configure = new Configure();
            configure.ShowDialog();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lbCooldown.Text = "Please wait for " + countdown--.ToString();
            if (countdown < 0)
            {
                lbCooldown.Visible = false;
                buttonLogin.Enabled = true;
                timer1.Stop();
            }
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Login_Username = textBoxUserName.Text;
            Properties.Settings.Default.Save();
        }
    }
}
