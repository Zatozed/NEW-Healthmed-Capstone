using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.login
{
    public partial class Configure : Form
    {
        DBhelperClass dbh = new DBhelperClass();

        private MySqlConnection mysqlCon;
        private MySqlDataAdapter dataAdapter;
        private MySqlCommand cmd;
        private MySqlConnectionStringBuilder mysqlConStrBldr;
        private MySqlDataReader dr;
        public Configure()
        {
            InitializeComponent();
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
        private int ConTester()
        {
            int i = 0;

            openCon();
            cmd = new MySqlCommand("select 1", mysqlCon);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                i = dr.GetInt32(0);
            closeCon();

            return i;
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
            Properties.Settings.Default.S_Hostname = textBoxHostName.Text;
            Properties.Settings.Default.S_Port = textBoxPort.Text;
            Properties.Settings.Default.S_Username = textBoxUserName.Text;
            Properties.Settings.Default.S_Password = textBoxPassword.Text;
            Properties.Settings.Default.S_dbName = textBoxDbName.Text;
            Properties.Settings.Default.S_ConBuild = "server = " + textBoxHostName.Text + "; userid = " + textBoxUserName.Text + "; password = " + textBoxPassword.Text + "; database = " + textBoxDbName.Text;
            Properties.Settings.Default.Save();

            try
            {
                if (ConTester() == 1) 
                {
                    MessageBox.Show("Connected");
                    this.Close();
                }
                else 
                {
                    //Form1 f1 = new Form1();
                    //f1.ShowDialog();
                }
            }
            catch(MySqlException) 
            { MessageBox.Show("Invalid Connection"); }
}

    }
}
