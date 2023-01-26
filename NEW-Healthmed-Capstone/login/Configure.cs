using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.login
{
    public partial class Configure : Form
    {
        public Configure()
        {
            InitializeComponent();
        }

        private void Configure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.S_Hostname = textBoxHostName.Text;
            Properties.Settings.Default.S_Port = textBoxPort.Text;
            Properties.Settings.Default.S_Username = textBoxUserName.Text;
            Properties.Settings.Default.S_Password = textBoxPassword.Text;
            Properties.Settings.Default.S_dbName = textBoxDbName.Text;
            Properties.Settings.Default.S_ConBuild = "server = " + textBoxHostName.Text + "; userid = " + textBoxUserName.Text + "; password = " + textBoxPassword.Text + "; database = " + textBoxDbName.Text;
            Properties.Settings.Default.Save();
        }

        private void Configure_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;

            textBoxHostName.Text = Properties.Settings.Default.S_Hostname;
            textBoxPort.Text = Properties.Settings.Default.S_Port;
            textBoxUserName.Text = Properties.Settings.Default.S_Username;
            textBoxPassword.Text = Properties.Settings.Default.S_Password;
            textBoxDbName.Text = Properties.Settings.Default.S_dbName;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
