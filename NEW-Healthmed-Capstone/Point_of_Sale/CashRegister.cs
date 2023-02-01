﻿using MySql.Data.MySqlClient;
using NEW_Healthmed_Capstone.DBhelperFolder;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Point_of_Sale
{
    public partial class CashRegister : Form
    {
        DBhelperClass dbh = new DBhelperClass();
        POS pos = new POS();
        public CashRegister()
        {
            InitializeComponent();
        }

        private void CashRegister_Load(object sender, EventArgs e)
        {
            lbDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt");

            lbBalance.Text = dbh.GetBalance().ToString("00.00");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string datenow = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

            if (comboBox1.Text.Equals("") || comboBox1.Text.Equals("Select"))
            {
                MessageBox.Show("Select Action First");
            }
            else if (tbCash.Text.Equals("") || tbCash.Text == null || !Double.TryParse(tbCash.Text.ToString(), out double amount))
            {
                MessageBox.Show("Amount is blank or invalid");
            }
            else if (tbPass.Text.Equals("") || tbPass.Text == null)
            {
                MessageBox.Show("Password is blank");
            }
            else if (comboBox1.Text.Equals("Cash In"))
            {
                if (dbh.VerifyPass(tbPass.Text))
                {
                    dbh.CashIn(tbCash.Text);

                    dbh.InsertToCash(Properties.Settings.Default.Fname_Lname,
                        comboBox1.Text,
                        tbCash.Text,
                        datenow);

                    MessageBox.Show("Cash In Done");

                    pos.ShowDialog();
                }
            }
            else if (comboBox1.Text.Equals("Cash Out"))
            {
                if (dbh.VerifyPass(tbPass.Text))
                {
                    dbh.CashOut(tbCash.Text);

                    dbh.InsertToCash(Properties.Settings.Default.Fname_Lname,
                        comboBox1.Text,
                        tbCash.Text,
                        datenow);
                    MessageBox.Show("Cash Out Done");
                }
            }
            else if (comboBox1.Text.Equals("Time In"))
            {
                if (dbh.VerifyPass(tbPass.Text))
                {
                    dbh.InsertToCash(Properties.Settings.Default.Fname_Lname,
                    comboBox1.Text,
                    tbCash.Text,
                    datenow);

                    dbh.SetCashVal(tbCash.Text);

                    MessageBox.Show("Time In Success");
                    pos.ShowDialog();
                }

            }
            else if (comboBox1.Text.Equals("Time Out"))
            {
                if (dbh.VerifyPass(tbPass.Text))
                {
                    dbh.InsertToCash(Properties.Settings.Default.Fname_Lname,
                    comboBox1.Text,
                    tbCash.Text,
                    datenow);

                    dbh.SetCashVal("0");

                    MessageBox.Show("Time Out Done");
                }
            }
            else { }

            lbBalance.Text = dbh.GetBalance().ToString("00.00");
        }
    }
}
