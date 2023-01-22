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
        public MySqlConnection conn()
        {
            return con;
        }
        public void OpenCon() { con.Open(); }
        public void CloseCon() { con.Close(); }

        public DataTable ShowProductList() 
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select product_code , product_name, classification, dosage, med_type, unit_cost, unit_price, in_stock_qty from tbl_products",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }
        public DataTable ShowDiscountList()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select id, discount_name, discount_percent from tbl_discount",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }
        public DataTable showSupplierList()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select supplier_id,supplier_name,description,email,contactNum,Address,leadTime from tbl_suppliers;", 
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            return dt;
        }

        public List<string> GetDiscountNames()
        {
            List<string> list = new List<string>();
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
        public string isVatExmpt(string discount_name)
        {
            string s = "";

            try
            {
                con.Open();
                cmd = new MySqlCommand("select vat_exempt from tbl_discount where discount_name = @dname",
                con);
                cmd.Parameters.AddWithValue("@dname", discount_name);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    s = dr.GetString(0);
                }
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return s;
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

        public DataTable SearchProduct(string s)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select product_code , product_name, classification, dosage, med_type, unit_cost, unit_price, in_stock_qty from tbl_products where product_code like '%"+s+"%' or product_name like '%"+s+"%' or classification like '%"+s+"%'",
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
