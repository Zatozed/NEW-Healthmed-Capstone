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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPo = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnPo);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 504);
            this.panel1.TabIndex = 5;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F);
            this.lbDate.Location = new System.Drawing.Point(36, 47);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(135, 30);
            this.lbDate.TabIndex = 4;
            this.lbDate.Text = "DD/MM/YYYY";
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 15F);
            this.lbTime.Location = new System.Drawing.Point(58, 77);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(44, 25);
            this.lbTime.TabIndex = 5;
            this.lbTime.Text = "time";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbTime);
            this.panel2.Controls.Add(this.lbDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 143);
            this.panel2.TabIndex = 5;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.btnHome.Location = new System.Drawing.Point(0, 143);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(203, 60);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "HOME";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnPo
            // 
            this.btnPo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPo.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.btnPo.Location = new System.Drawing.Point(0, 203);
            this.btnPo.Name = "btnPo";
            this.btnPo.Size = new System.Drawing.Size(203, 60);
            this.btnPo.TabIndex = 6;
            this.btnPo.Text = "PURCHASE ORDER";
            this.btnPo.UseVisualStyleBackColor = true;
            this.btnPo.Click += new System.EventHandler(this.btnPo_Click_1);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.button4.Location = new System.Drawing.Point(0, 263);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(203, 60);
            this.button4.TabIndex = 7;
            this.button4.Text = "RECEIVING";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.button5.Location = new System.Drawing.Point(0, 323);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(203, 60);
            this.button5.TabIndex = 8;
            this.button5.Text = "STOCK ADJUSTMENT";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InventoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventoryPanel.Location = new System.Drawing.Point(207, 0);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(751, 504);
            this.InventoryPanel.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.inventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnPo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Timer timer1;
    }
}