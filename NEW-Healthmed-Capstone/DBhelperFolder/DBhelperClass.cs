using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;

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

        public ArrayList SupplierList()
        {
            ArrayList l = new ArrayList();

            con.Open();
            cmd = new MySqlCommand("select distinct supplier_name from tbl_suppliers;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l.Add(dr.GetString(0));
            }
            con.Close();

            return l;
        }

        public string GetSupAd(string supAdd) 
        {
            string sa;

            con.Open();
            cmd = new MySqlCommand("select distinct address from tbl_suppliers where supplier_name = '"+supAdd+"'", con);
            sa = cmd.ExecuteScalar().ToString();
            con.Close();

            return sa;
        }
        public string GetSupContactNum(string SupConNum) 
        {
            string scn;

            con.Open();
            cmd = new MySqlCommand("select distinct contact_num from tbl_suppliers where supplier_name = '"+SupConNum+"'", con);
            scn = cmd.ExecuteScalar().ToString();
            con.Close();

            return scn;
        }
        public string GetSupEmailAd(string EmailAd) 
        {
            string ea;

            con.Open();
            cmd = new MySqlCommand("select distinct email_ad from tbl_suppliers where supplier_name = '"+EmailAd+"'", con);
            ea= cmd.ExecuteScalar().ToString();
            con.Close();

            return ea;
        }

        public ArrayList AutoComplete()
        {
            ArrayList lt = new ArrayList();

            con.Open();
            cmd = new MySqlCommand("select distinct discount_name from tbl_discount;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct discount_percent from tbl_discount;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct product_code from tbl_products;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct product_name from tbl_products;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct classification from tbl_products;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct dosage from tbl_products;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct med_type from tbl_products;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct supplier_name from tbl_suppliers;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct sup_description from tbl_suppliers;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct address from tbl_suppliers;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct contact_num from tbl_suppliers;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();

            con.Open();
            cmd = new MySqlCommand("select distinct email_ad from tbl_suppliers;", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lt.Add(dr.GetString(0));
            }
            con.Close();


            return lt;
        }
        public DataTable ShowProductMasterList()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("Select p_id, product_code, product_name, classification, dosage, med_type, unit_cost, unit_price, in_stock_qty,reorder_point, safety_stock_per_week, remarks from tbl_products;",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }

        public DataTable ShowProductToOrder()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select\r\np.product_code ,\r\np.product_name,\r\np.classification,\r\np.dosage,\r\np.med_type,\r\np.unit_cost,\r\np.unit_price,\r\np.in_stock_qty,\r\ns.supplier_name\r\nfrom tbl_products as p\r\ninner join tbl_product_supplier on p.p_id = tbl_product_supplier.product_id\r\ninner join tbl_suppliers as s on s.sup_id = tbl_product_supplier.supplier_id\r\nwhere p.in_stock_qty <= p.reorder_point;",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }

        public DataTable ShowProductToOrder(string supName)
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select\r\np.product_code ,\r\np.product_name,\r\np.classification,\r\np.dosage,\r\np.med_type,\r\np.unit_cost,\r\np.unit_price,\r\np.in_stock_qty,\r\ns.supplier_name\r\nfrom tbl_products as p\r\ninner join tbl_product_supplier on p.p_id = tbl_product_supplier.product_id\r\ninner join tbl_suppliers as s on s.sup_id = tbl_product_supplier.supplier_id\r\nwhere s.supplier_name = '"+supName+"' and p.in_stock_qty <= p.reorder_point;",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }

        public DataTable ShowProductList()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select product_code , product_name, classification, dosage, med_type, unit_cost, unit_price, in_stock_qty from tbl_products where in_stock_qty != 0",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }
        public DataTable ShowProductList1() //REFRESH FOR PRODUCT LIST AND PRODUCT LIST RELATION SUPPLIER
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select p_id, product_code , product_name, classification, dosage, med_type,unit_cost, unit_price from tbl_products",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }
        public DataTable ShowProductList1(string s) //File maintenance Search Product List in relation Product and supplier
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select p_id, product_code , product_name, classification, dosage, med_type from tbl_products where (product_code like '%" + s + "%' or product_name like '%" + s + "%' or classification like '%" + s + "%') and in_stock_qty != 0",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }
        public DataTable SearchRelation(string s, string a)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select p.product_code, p.product_name,p.classification,p.dosage,p.med_type,p.unit_cost,p.unit_price,p.in_stock_qty,s.supplier_name from tbl_products as p inner join tbl_product_supplier on p.p_id = tbl_product_supplier.product_id inner join tbl_suppliers as s on s.sup_id = tbl_product_supplier.supplier_id WHERE (product_code like '%" + s + "%' AND supplier_name ='" + a + "')",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }
        public DataTable ShowProductList(string s)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select product_code , product_name, classification, dosage, med_type, unit_cost, unit_price, in_stock_qty from tbl_products where (product_code like '%" + s + "%' or product_name like '%" + s + "%' or classification like '%" + s + "%') and in_stock_qty != 0",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);

            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            return dt;
        }

        public DataTable ShowProductSupplier()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select\r\np.product_code ,\r\np.product_name,\r\np.classification,\r\np.dosage,\r\np.med_type,\r\np.unit_cost,\r\np.unit_price,\r\np.in_stock_qty,\r\ns.supplier_name\r\nfrom tbl_products as p\r\ninner join tbl_product_supplier on p.p_id = tbl_product_supplier.product_id\r\ninner join tbl_suppliers as s on s.sup_id = tbl_product_supplier.supplier_id;",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }

        public DataTable ShowProductSupplier(string supName)
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select\r\np.product_code ,\r\np.product_name,\r\np.classification,\r\np.dosage,\r\np.med_type,\r\np.unit_cost,\r\np.unit_price,\r\np.in_stock_qty,\r\ns.supplier_name\r\nfrom tbl_products as p\r\ninner join tbl_product_supplier on p.p_id = tbl_product_supplier.product_id\r\ninner join tbl_suppliers as s on s.sup_id = tbl_product_supplier.supplier_id where s.supplier_name = '"+ supName +"'",
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
        public DataTable showProductRelation() //P Relation S
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select p.product_code ,p.product_name,p.classification,p.dosage,p.med_type,p.unit_cost,p.unit_price,p.in_stock_qty,s.supplier_name from tbl_products as p inner join tbl_product_supplier on p.p_id = tbl_product_supplier.product_id inner join tbl_suppliers as s on s.sup_id = tbl_product_supplier.supplier_id;;",
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
        public DataTable ShowSales(string TransacNum)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd = new MySqlCommand("select transaction_num, product_code, item_description, qty, unit_cost, unit_price, vat_exempt, discount, total_cost, total_sales, transac_date, cashier from tbl_sales where transaction_num like '"+TransacNum+"'", con);
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

        public void InsertToPo(
            string poNum, string prodCode, string prodName, string orQty, string reQty,
            string unitCost, string discount, string total, string totalDiscount, string poDate,
            string poGeneBy, string hmAd, string hmConNum, string hmEmail,
            string reName, string reAdd, string reConNum, string reEmail, 
            string sup, string supAdd, string supConNum, string supEmail, string remarks)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("insert into tbl_po(po_num, product_code, product_description, ordered_qty, received_qty, unit_cost, discount, total, total_discount, po_date, po_generated_by, hm_address, hm_contact_num, hm_email, receiver_name, re_address, re_contact_num, re_email, supplier, sup_address, sup_contact_num, sup_email, remarks)"+
                    "values(@poNum, @prodCode, @prodName, @orQty, @reQty, @unitCost, @discount, @total, @totalDiscount, @poDate, @poGeneBy, @hmAd, @hmConNum, @hmEmail, @reName, @reAdd, @reConNum, @reEmail, @sup, @supAdd, @supConNum, @supEmail, @remarks)", con);

                cmd.Parameters.AddWithValue("@poNum", poNum);
                cmd.Parameters.AddWithValue("@prodCode", prodCode);
                cmd.Parameters.AddWithValue("@prodName", prodName);
                cmd.Parameters.AddWithValue("@orQty", orQty);
                cmd.Parameters.AddWithValue("@reQty", reQty);

                cmd.Parameters.AddWithValue("@unitCost", unitCost);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@totalDiscount", totalDiscount);
                cmd.Parameters.AddWithValue("@poDate", poDate);

                cmd.Parameters.AddWithValue("@poGeneBy", poGeneBy);
                cmd.Parameters.AddWithValue("@hmAd", hmAd);
                cmd.Parameters.AddWithValue("@hmConNum", hmConNum);
                cmd.Parameters.AddWithValue("@hmEmail", hmEmail);
                cmd.Parameters.AddWithValue("@reName", reName);

                cmd.Parameters.AddWithValue("@reAdd", reAdd);
                cmd.Parameters.AddWithValue("@reConNum", reConNum);
                cmd.Parameters.AddWithValue("@reEmail", reEmail);
                cmd.Parameters.AddWithValue("@sup", sup);
                cmd.Parameters.AddWithValue("@supAdd", supAdd);

                cmd.Parameters.AddWithValue("@supConNum", supConNum);
                cmd.Parameters.AddWithValue("@supEmail", supEmail);
                cmd.Parameters.AddWithValue("@remarks", remarks);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            // update pending from ordered
            try
            {
                con.Open();
                cmd = new MySqlCommand("update tbl_po set pending_qty = ordered_qty where product_code = '"+ prodCode+"'", con);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
        }
        public void DelAtPoList(string i)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("delete from tbl_po where po_id = "+i, con);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
        }
        public void UpdateInStockQty(string i, string pCode)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("update tbl_products set in_stock_qty = (in_stock_qty - "+i+") where product_code = '"+pCode+"'", con);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
        }
        public void InsertToSales(string transac_num, string prod_code, string itm_des, string qty, string unit_cost, string unit_price,
            string vat_exempt, string distount, string total_cost, string total_sales, string transac_date, string cashier)
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

        public void InsertToRpo(
            string poNum,
            string prodCode,
            string prodDes,
            string reQty, 
            string sup, 
            string date_re, 
            string re_by, 
            string remarks)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("insert into tbl_rpo(po_num, product_code, product_des, received_qty, supplier, date_received, received_by, remarks)"+
                    "values(@poNum, @prodCode, @prodDes, @reQty, @sup, @date_re, @re_by, @remarks)", con);

                cmd.Parameters.AddWithValue("@poNum", poNum);
                cmd.Parameters.AddWithValue("@prodCode", prodCode);
                cmd.Parameters.AddWithValue("@prodDes", prodDes);
                cmd.Parameters.AddWithValue("@reQty", reQty);

                cmd.Parameters.AddWithValue("@sup", sup);
                cmd.Parameters.AddWithValue("@date_re", date_re);
                cmd.Parameters.AddWithValue("@re_by", re_by);
                cmd.Parameters.AddWithValue("@remarks", remarks);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            //                                  update received qty
            try
            {
                con.Open();
                cmd = new MySqlCommand("update tbl_po set received_qty = received_qty + "+ reQty +" where product_code = '"+ prodCode +"'", con);


                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            //                                  update pending
            try
            {
                con.Open();
                cmd = new MySqlCommand("update tbl_po set pending_qty = ordered_qty - received_qty where product_code = '"+prodCode+"'", con);


                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
            //                                  update in stock
            try
            {
                con.Open();
                cmd = new MySqlCommand("update tbl_products set in_stock_qty = in_stock_qty + "+reQty+" where product_code = '"+prodCode+"'", con);


                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
        }
        public void InsertToExpiry(
            string prodCode,
            string prodDes,
            string lot,
            string expiry_date
            )
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("insert into tbl_expiry_monitoring(product_code, product_des, lot, expiry_date) "+
                    "values(@prodCode, @prodDes, @lot, @expiry_date)", con);

                cmd.Parameters.AddWithValue("@prodCode", prodCode);
                cmd.Parameters.AddWithValue("@prodDes", prodDes);
                cmd.Parameters.AddWithValue("@lot", lot);
                cmd.Parameters.AddWithValue("@expiry_date", expiry_date);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }
        }
        public string GeneratePoNum()
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            string PoNum = "";
            string supPoNum;
            int count;

            try
            {
                con.Open();
                cmd = new MySqlCommand("Select po_num from tbl_po where po_num  like '%" + date + "%' order by cast(po_num as unsigned) DESC LIMIT 1", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    PoNum = dr.GetString("po_num");
                    count = int.Parse(PoNum.Substring(8, PoNum.Length - 8));
                    PoNum = date + "" + (count + 1);
                }
                else
                {
                    supPoNum = date + "1";
                    PoNum = supPoNum;
                }
                dr.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }

            return PoNum;
        }
        public DataTable ShowPoList() 
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select po_id, po_num from tbl_po where received_qty = 0",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }
        public DataTable ShowPoList(string poNum)
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select * from tbl_po where po_num = '"+ poNum +"'",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }

        public DataTable ShowBackOrder()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select po_id, po_num from tbl_po where ((select(sum(pending_qty)) != 0)) and received_qty != 0",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
        }

        public DataTable ShowExpiry()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select * from tbl_expiry_monitoring order by expiry_date asc",
                con);
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException sql) { MessageBox.Show(sql.Message.ToString()); }
            finally { con.Close(); }

            return dt;
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
                cmd = new MySqlCommand("Select transaction_num from tbl_sales where transaction_num like '%"+date+"%' order by cast(transaction_num as unsigned) DESC limit 1;", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transNo = dr.GetString("transaction_num");
                    count = int.Parse(transNo.Substring(8, transNo.Length -8 ));
                    transacNum = date + "" + (count + 1);
                }
                else
                {
                    transNo = date + "1";
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
