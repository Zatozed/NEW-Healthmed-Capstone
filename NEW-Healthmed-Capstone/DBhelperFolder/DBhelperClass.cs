using System;
using System.Collections.Generic;
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
                cmd = new MySqlCommand("select product_code , product_name, classification, dosage, med_type, unit_cost, unit_price, available_qty, in_stock_qty from tbl_products",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            return dt;
        }

        public List<String> GetDiscountNames()
        {
            List<String> list = new List<String>();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select discount_name from tbl_discount",
                con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(dr.GetString(0));
                }

            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            return list;
        }
        public double GetDiscountValue(string discount_name)
        {
            double dis = 0;

            try
            {
                con.Open();
                cmd = new MySqlCommand("select discount_percent from tbl_discount where discount_name = @dname",
                con);
                cmd.Parameters.AddWithValue("@dname", discount_name);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dis = dr.GetDouble(0);
                }

            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dis / 100;
        }
    }


}
