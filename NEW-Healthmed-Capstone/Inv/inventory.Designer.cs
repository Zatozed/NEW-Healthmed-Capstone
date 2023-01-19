namespace NEW_Healthmed_Capstone.Inv
{
    partial class inventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnProductMList = new System.Windows.Forms.Button();
            this.BtnStockAdujustment = new System.Windows.Forms.Button();
            this.BtnReceiving = new System.Windows.Forms.Button();
            this.BtnPO = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventoryPanel.Location = new System.Drawing.Point(207, 0);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(751, 504);
            this.InventoryPanel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.BtnProductMList);
            this.panel1.Controls.Add(this.BtnStockAdujustment);
            this.panel1.Controls.Add(this.BtnReceiving);
            this.panel1.Controls.Add(this.BtnPO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 504);
            this.panel1.TabIndex = 5;
            // 
            // BtnProductMList
            // 
            this.BtnProductMList.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProductMList.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.BtnProductMList.Location = new System.Drawing.Point(0, 180);
            this.BtnProductMList.Name = "BtnProductMList";
            this.BtnProductMList.Size = new System.Drawing.Size(203, 60);
            this.BtnProductMList.TabIndex = 4;
            this.BtnProductMList.Text = "PRODUCT MASTER LIST";
            this.BtnProductMList.UseVisualStyleBackColor = true;
            // 
            // BtnStockAdujustment
            // 
            this.BtnStockAdujustment.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnStockAdujustment.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.BtnStockAdujustment.Location = new System.Drawing.Point(0, 120);
            this.BtnStockAdujustment.Name = "BtnStockAdujustment";
            this.BtnStockAdujustment.Size = new System.Drawing.Size(203, 60);
            this.BtnStockAdujustment.TabIndex = 3;
            this.BtnStockAdujustment.Text = "STOCK ADJUSTMENT";
            this.BtnStockAdujustment.UseVisualStyleBackColor = true;
            // 
            // BtnReceiving
            // 
            this.BtnReceiving.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReceiving.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.BtnReceiving.Location = new System.Drawing.Point(0, 60);
            this.BtnReceiving.Name = "BtnReceiving";
            this.BtnReceiving.Size = new System.Drawing.Size(203, 60);
            this.BtnReceiving.TabIndex = 2;
            this.BtnReceiving.Text = "RECEIVING";
            this.BtnReceiving.UseVisualStyleBackColor = true;
            // 
            // BtnPO
            // 
            this.BtnPO.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPO.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.BtnPO.Location = new System.Drawing.Point(0, 0);
            this.BtnPO.Name = "BtnPO";
            this.BtnPO.Size = new System.Drawing.Size(203, 60);
            this.BtnPO.TabIndex = 1;
            this.BtnPO.Text = "PURCHASE ORDER";
            this.BtnPO.UseVisualStyleBackColor = true;
            // 
            // inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 504);
            this.Controls.Add(this.InventoryPanel);
            this.Controls.Add(this.panel1);
            this.Name = "inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "inventory";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnProductMList;
        private System.Windows.Forms.Button BtnStockAdujustment;
        private System.Windows.Forms.Button BtnReceiving;
        private System.Windows.Forms.Button BtnPO;
    }
}