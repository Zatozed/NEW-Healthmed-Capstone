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
    public partial class InventoryMenu : Form
    {
        public InventoryMenu()
        {
            InitializeComponent();
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            PurchaseOrder po = new PurchaseOrder();
            po.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockAdjustment sa = new StockAdjustment();
            sa.ShowDialog();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ProductMasterList pml = new ProductMasterList();
            pml.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReceivePO rpo = new ReceivePO();
            rpo.ShowDialog();
        }
    }
}
