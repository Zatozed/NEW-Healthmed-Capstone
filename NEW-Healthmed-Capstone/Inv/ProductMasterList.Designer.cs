namespace NEW_Healthmed_Capstone.Inv
{
    partial class ProductMasterList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductSearch = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.dgvProductMasterList = new System.Windows.Forms.DataGridView();
            this.productID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSafetyStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMasterList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ProductSearch);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.dgvProductMasterList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 613);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14F);
            this.label1.Location = new System.Drawing.Point(57, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search:";
            // 
            // ProductSearch
            // 
            this.ProductSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductSearch.Location = new System.Drawing.Point(57, 62);
            this.ProductSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProductSearch.Name = "ProductSearch";
            this.ProductSearch.Size = new System.Drawing.Size(337, 29);
            this.ProductSearch.TabIndex = 13;
            this.ProductSearch.TextChanged += new System.EventHandler(this.RefStockUdjust_TextChanged);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14F);
            this.btnReport.Location = new System.Drawing.Point(1029, 554);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(322, 44);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "Preview";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dgvProductMasterList
            // 
            this.dgvProductMasterList.AllowUserToAddRows = false;
            this.dgvProductMasterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductMasterList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProductMasterList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductMasterList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductMasterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductMasterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productID,
            this.colProductCode,
            this.colProductName,
            this.colClassification,
            this.colDosage,
            this.colMedType,
            this.colCost,
            this.colPrice,
            this.colInStock,
            this.colReOrder,
            this.colSafetyStock,
            this.colRemark});
            this.dgvProductMasterList.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductMasterList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductMasterList.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvProductMasterList.Location = new System.Drawing.Point(4, 105);
            this.dgvProductMasterList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductMasterList.Name = "dgvProductMasterList";
            this.dgvProductMasterList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProductMasterList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductMasterList.Size = new System.Drawing.Size(1360, 442);
            this.dgvProductMasterList.TabIndex = 9;
            // 
            // productID
            // 
            this.productID.DataPropertyName = "p_id";
            this.productID.HeaderText = "ID";
            this.productID.Name = "productID";
            this.productID.Visible = false;
            // 
            // colProductCode
            // 
            this.colProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProductCode.DataPropertyName = "product_code";
            this.colProductCode.HeaderText = "Product Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            this.colProductCode.Width = 115;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProductName.DataPropertyName = "product_name";
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 119;
            // 
            // colClassification
            // 
            this.colClassification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClassification.DataPropertyName = "classification";
            this.colClassification.HeaderText = "Classification";
            this.colClassification.Name = "colClassification";
            this.colClassification.ReadOnly = true;
            // 
            // colDosage
            // 
            this.colDosage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDosage.DataPropertyName = "dosage";
            this.colDosage.HeaderText = "Dosage";
            this.colDosage.Name = "colDosage";
            this.colDosage.ReadOnly = true;
            this.colDosage.Width = 87;
            // 
            // colMedType
            // 
            this.colMedType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMedType.DataPropertyName = "med_type";
            this.colMedType.HeaderText = "Type";
            this.colMedType.Name = "colMedType";
            this.colMedType.ReadOnly = true;
            this.colMedType.Width = 68;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "unit_cost";
            this.colCost.HeaderText = "Unit Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "unit_price";
            this.colPrice.HeaderText = "Unit Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colInStock
            // 
            this.colInStock.DataPropertyName = "in_stock_qty";
            this.colInStock.HeaderText = "In Stock Qty.";
            this.colInStock.Name = "colInStock";
            this.colInStock.ReadOnly = true;
            // 
            // colReOrder
            // 
            this.colReOrder.DataPropertyName = "reorder_point";
            this.colReOrder.HeaderText = "Reorder point";
            this.colReOrder.Name = "colReOrder";
            this.colReOrder.ReadOnly = true;
            // 
            // colSafetyStock
            // 
            this.colSafetyStock.DataPropertyName = "safety_stock_per_week";
            this.colSafetyStock.HeaderText = "Safety Stock per week";
            this.colSafetyStock.Name = "colSafetyStock";
            this.colSafetyStock.ReadOnly = true;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemark.DataPropertyName = "remarks";
            this.colRemark.HeaderText = "Remarks";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            // 
            // ProductMasterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 613);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductMasterList";
            this.Text = "ProductMasterList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductMasterList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductMasterList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView dgvProductMasterList;
        private System.Windows.Forms.TextBox ProductSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSafetyStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
    }
}