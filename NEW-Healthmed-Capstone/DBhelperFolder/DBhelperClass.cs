using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NEW_Healthmed_Capstone.DBhelperFolder
{
    internal class DBhelperClass
    {
        private MySqlConnection con;
        private MySqlDataAdapter dataAdapter;
        private MySqlCommand cmd;
        private MySqlConnectionStringBuilder stringBuilder;
        private MySqlDataReader dr;

        public DBhelperClass()
        {
            stringBuilder = new MySqlConnectionStringBuilder(Properties.Settings.Default.S_ConBuild);
            con = new MySqlConnection(stringBuilder.ConnectionString);
        }

        public void TestCon()
        {
            try 
            {
                con.Open();
                cmd = new MySqlCommand("select 1", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("connected");
                }
                dr.Dispose();
                dr.Close();
            }
            catch(MySqlException sql) { MessageBox.Show("Not connected to server"); }
            finally { con.Close(); }
        }

        public DataTable ShowProductList() 
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select product_code, product_name, classification, dosage, med_type, unit_cost, available_qty, in_stock_qty\r\nfrom tbl_products",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            return dt;
        }

    }


}
