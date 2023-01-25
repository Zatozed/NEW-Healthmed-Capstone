﻿using System;
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
                cmd = new MySqlCommand("select p_id , product_code, product_name, classification, dosage, med_type,unit_cost,unit_price, in_stock_qty,reorder_point, safety_stock_per_week, avg_weekly_movement,max_weekly_movement, avg_lead_time, max_lead_time, remarks from tbl_products",
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
                cmd = new MySqlCommand("select sup_id,supplier_name,sup_description,email_ad,contact_num,address,lead_time from tbl_suppliers;",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            return dt;
        }

        public DataTable ShowSales() 
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select transaction_num, product_code, item_description, qty, unit_cost, unit_price, vat_exempt, discount, total_cost, total_sales, transac_date, cashier from tbl_sales", con);
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
                cmd = new MySqlCommand("select product_code , product_name, classification, dosage, med_type, unit_cost, unit_price, in_stock_qty from tbl_products where product_code like '%" + s + "%' or product_name like '%" + s + "%' or classification like '%" + s + "%'",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);

            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            return dt;
        }

        public void InsertToSales(string transac_num, string prod_code, string itm_des, string qty, string unit_cost, string unit_price, string vat_exempt, string distount, string total_cost, string total_sales, string transac_date, string cashier)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("insert into tbl_sales(transaction_num, product_code, item_description, qty, unit_cost, unit_price, vat_exempt, discount, total_cost, total_sales, transac_date, cashier)"
                    + "values(@t_num, @p_code, @itm_des, @qty, @cost, @price, @v_exmpt, @discount, @t_cost, @t_sales, @t_date, @chashier)", con);

                cmd.Parameters.AddWithValue("@t_num", transac_num);
                cmd.Parameters.AddWithValue("@p_code", prod_code);
                cmd.Parameters.AddWithValue("@itm_des", itm_des);
                cmd.Parameters.AddWithValue("@qty", qty);

                cmd.Parameters.AddWithValue("@cost", unit_cost);
                cmd.Parameters.AddWithValue("@price", unit_price);
                cmd.Parameters.AddWithValue("@v_exmpt", vat_exempt);
                cmd.Parameters.AddWithValue("@discount", distount);

                cmd.Parameters.AddWithValue("@t_cost", total_cost);
                cmd.Parameters.AddWithValue("@t_sales", total_sales);
                cmd.Parameters.AddWithValue("@t_date", transac_date);
                cmd.Parameters.AddWithValue("@chashier", cashier);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
        }
        public string GenereateTransacNum()
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            string transNo;
            int count;
            string transacNum = "";
            try
            {
                con.Open();
                cmd = new MySqlCommand("Select transaction_num from tbl_sales where transaction_num  like '" + date + "%' order by transaction_num DESC LIMIT 1", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transNo = dr.GetString("transaction_num");
                    count = int.Parse(transNo.Substring(8, 4));
                    transacNum = date + "000" + (count + 1);
                }
                else
                {
                    transNo = date + "0001";
                    transacNum = transNo;
                }
                dr.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return transacNum;
        }

        public bool isEnough(string P_code, int qty)
        {
            bool isEnough = true;

            try
            {
                con.Open();
                cmd = new MySqlCommand("select in_stock_qty from tbl_products where product_code = '"+ P_code +"'", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                int in_st = dr.GetInt32("in_stock_qty");
                if (qty > in_st)
                    isEnough = false;
                else
                    isEnough = true;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isEnough;
        }
    }


}
