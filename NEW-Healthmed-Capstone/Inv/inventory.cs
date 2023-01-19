using NEW_Healthmed_Capstone.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone.Inv
{
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Close();
            
        }

        private void btnPo_Click_1(object sender, EventArgs e)
        {
            Purchase_Order po = new Purchase_Order();
            bool IsOpen = false;

            //prevent opening Purchase_Order multiple times
            foreach (Form f in Application.OpenForms)
            {
                //Checks if Purchase_Order is already Open
                if (f.Text == "Purchase_Order")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            //Open Purchase_Order 
            if (IsOpen == false)
            {
                po.TopLevel = false;
                InventoryPanel.Controls.Add(po);
                po.BringToFront();
                po.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
