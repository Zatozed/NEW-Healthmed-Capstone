namespace NEW_Healthmed_Capstone.Inv
{
    partial class Purchase_Order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnPOSubmit = new System.Windows.Forms.Button();
            this.DGVPO = new System.Windows.Forms.DataGridView();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnOrderList = new System.Windows.Forms.Button();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPO)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.lbDate);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 82);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnOrderList);
            this.panel2.Controls.Add(this.DGVPO);
            this.panel2.Controls.Add(this.BtnPOSubmit);
            this.panel2.Location = new System.Drawing.Point(1, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 355);
            this.panel2.TabIndex = 1;
            // 
            // BtnPOSubmit
            // 
            this.BtnPOSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPOSubmit.Location = new System.Drawing.Point(825, 309);
            this.BtnPOSubmit.Name = "BtnPOSubmit";
            this.BtnPOSubmit.Size = new System.Drawing.Size(103, 32);
            this.BtnPOSubmit.TabIndex = 2;
            this.BtnPOSubmit.Text = "Submit Order";
            this.BtnPOSubmit.UseVisualStyleBackColor = true;
            // 
            // DGVPO
            // 
            this.DGVPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVPO.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGVPO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGVPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_Name,
            this.Classification,
            this.Dosage,
            this.Type,
            this.Unit_Cost,
            this.Supplier});
            this.DGVPO.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPO.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGVPO.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DGVPO.Location = new System.Drawing.Point(3, 3);
            this.DGVPO.Name = "DGVPO";
            this.DGVPO.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGVPO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVPO.Size = new System.Drawing.Size(925, 300);
            this.DGVPO.TabIndex = 3;
            // 
            // Product_Name
            // 
            this.Product_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_Name.HeaderText = "Product Name";
            this.Product_Name.Name = "Product_Name";
            // 
            // Classification
            // 
            this.Classification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Classification.HeaderText = "Classification";
            this.Classification.Name = "Classification";
            // 
            // Dosage
            // 
            this.Dosage.HeaderText = "Dosage";
            this.Dosage.Name = "Dosage";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Unit_Cost
            // 
            this.Unit_Cost.HeaderText = "Unit Cost";
            this.Unit_Cost.Name = "Unit_Cost";
            // 
            // Supplier
            // 
            this.Supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            // 
            // BtnOrderList
            // 
            this.BtnOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrderList.Location = new System.Drawing.Point(708, 309);
            this.BtnOrderList.Name = "BtnOrderList";
            this.BtnOrderList.Size = new System.Drawing.Size(103, 32);
            this.BtnOrderList.TabIndex = 7;
            this.BtnOrderList.Text = "Order List";
            this.BtnOrderList.UseVisualStyleBackColor = true;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F);
            this.lbDate.Location = new System.Drawing.Point(11, 8);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(135, 30);
            this.lbDate.TabIndex = 7;
            this.lbDate.Text = "DD/MM/YYYY";
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 15F);
            this.lbTime.Location = new System.Drawing.Point(11, 38);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(44, 25);
            this.lbTime.TabIndex = 8;
            this.lbTime.Text = "time";
            // 
            // Purchase_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 440);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Purchase_Order";
            this.Text = "Purchase_Order";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnPOSubmit;
        private System.Windows.Forms.DataGridView DGVPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.Button BtnOrderList;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbTime;
    }
}