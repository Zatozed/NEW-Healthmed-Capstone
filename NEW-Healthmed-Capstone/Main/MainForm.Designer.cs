namespace NEW_Healthmed_Capstone.Main
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFilemaintenance = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvExpiry = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colExpiryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaysL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeleteExpiry = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiry)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnFilemaintenance);
            this.panel1.Controls.Add(this.btnInventory);
            this.panel1.Controls.Add(this.btnPOS);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 730);
            this.panel1.TabIndex = 0;
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.btnReports.Location = new System.Drawing.Point(0, 320);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(248, 59);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "REPORTS";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.button1.Location = new System.Drawing.Point(0, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "USER SETTINGS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFilemaintenance
            // 
            this.btnFilemaintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilemaintenance.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.btnFilemaintenance.Location = new System.Drawing.Point(0, 261);
            this.btnFilemaintenance.Name = "btnFilemaintenance";
            this.btnFilemaintenance.Size = new System.Drawing.Size(248, 59);
            this.btnFilemaintenance.TabIndex = 1;
            this.btnFilemaintenance.Text = "FILE MAINTENANCE";
            this.btnFilemaintenance.UseVisualStyleBackColor = true;
            this.btnFilemaintenance.Click += new System.EventHandler(this.btnFilemaintenance_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.btnInventory.Location = new System.Drawing.Point(0, 202);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(248, 59);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "INVENTORY";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPOS.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.btnPOS.Location = new System.Drawing.Point(0, 143);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(248, 59);
            this.btnPOS.TabIndex = 4;
            this.btnPOS.Text = "POS";
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbRole);
            this.panel2.Controls.Add(this.lbUser);
            this.panel2.Controls.Add(this.lbTime);
            this.panel2.Controls.Add(this.lbDate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 143);
            this.panel2.TabIndex = 0;
            // 
            // lbRole
            // 
            this.lbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.lbRole.Location = new System.Drawing.Point(107, 107);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(36, 24);
            this.lbRole.TabIndex = 7;
            this.lbRole.Text = "role";
            // 
            // lbUser
            // 
            this.lbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.lbUser.Location = new System.Drawing.Point(107, 83);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(39, 24);
            this.lbUser.TabIndex = 6;
            this.lbUser.Text = "user";
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 15F);
            this.lbTime.Location = new System.Drawing.Point(87, 52);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(44, 25);
            this.lbTime.TabIndex = 5;
            this.lbTime.Text = "time";
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F);
            this.lbDate.Location = new System.Drawing.Point(65, 22);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(135, 30);
            this.lbDate.TabIndex = 4;
            this.lbDate.Text = "DD/MM/YYYY";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.label4.Location = new System.Drawing.Point(16, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "ROLE:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F);
            this.label3.Location = new System.Drawing.Point(16, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "USER:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(252, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 730);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvExpiry);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 296);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1114, 430);
            this.panel5.TabIndex = 1;
            // 
            // dgvExpiry
            // 
            this.dgvExpiry.AllowUserToAddRows = false;
            this.dgvExpiry.AllowUserToDeleteRows = false;
            this.dgvExpiry.AllowUserToOrderColumns = true;
            this.dgvExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpiry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpiry.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpiry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpiry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpiry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExpiryID,
            this.colProductCode,
            this.colDescription,
            this.colLotNo,
            this.colExpiry,
            this.colDaysL,
            this.colDeleteExpiry});
            this.dgvExpiry.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpiry.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExpiry.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvExpiry.Location = new System.Drawing.Point(4, 24);
            this.dgvExpiry.Name = "dgvExpiry";
            this.dgvExpiry.ReadOnly = true;
            this.dgvExpiry.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvExpiry.Size = new System.Drawing.Size(1100, 396);
            this.dgvExpiry.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1114, 296);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1114, 296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // colExpiryID
            // 
            this.colExpiryID.DataPropertyName = "e_id";
            this.colExpiryID.HeaderText = "ID";
            this.colExpiryID.Name = "colExpiryID";
            this.colExpiryID.ReadOnly = true;
            this.colExpiryID.Visible = false;
            // 
            // colProductCode
            // 
            this.colProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colProductCode.DataPropertyName = "product_code";
            this.colProductCode.HeaderText = "Product Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            this.colProductCode.Width = 115;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "product_des";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colLotNo
            // 
            this.colLotNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLotNo.DataPropertyName = "lot";
            this.colLotNo.HeaderText = "Lot #";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            this.colLotNo.Width = 53;
            // 
            // colExpiry
            // 
            this.colExpiry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colExpiry.DataPropertyName = "expiry_date";
            this.colExpiry.HeaderText = "Expiry";
            this.colExpiry.Name = "colExpiry";
            this.colExpiry.ReadOnly = true;
            this.colExpiry.Width = 75;
            // 
            // colDaysL
            // 
            this.colDaysL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDaysL.HeaderText = "Days Left";
            this.colDaysL.Name = "colDaysL";
            this.colDaysL.ReadOnly = true;
            this.colDaysL.Width = 89;
            // 
            // colDeleteExpiry
            // 
            this.colDeleteExpiry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDeleteExpiry.HeaderText = "";
            this.colDeleteExpiry.Name = "colDeleteExpiry";
            this.colDeleteExpiry.ReadOnly = true;
            this.colDeleteExpiry.Text = "Delete";
            this.colDeleteExpiry.UseColumnTextForButtonValue = true;
            this.colDeleteExpiry.Visible = false;
            this.colDeleteExpiry.Width = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 730);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiry)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Button btnFilemaintenance;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnReports;
        public System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvExpiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaysL;
        private System.Windows.Forms.DataGridViewButtonColumn colDeleteExpiry;
    }
}