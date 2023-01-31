namespace NEW_Healthmed_Capstone.Inv
{
    partial class StockAdjustment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGVStockUdjustment = new System.Windows.Forms.DataGridView();
            this.productID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewUnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSafetyStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStockUdjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ProductSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1771, 93);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14F);
            this.label1.Location = new System.Drawing.Point(46, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search:";
            // 
            // ProductSearch
            // 
            this.ProductSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductSearch.Location = new System.Drawing.Point(43, 54);
            this.ProductSearch.Name = "ProductSearch";
            this.ProductSearch.Size = new System.Drawing.Size(226, 29);
            this.ProductSearch.TabIndex = 10;
            this.ProductSearch.TextChanged += new System.EventHandler(this.RefStockUdjust_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGVStockUdjustment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1771, 357);
            this.panel2.TabIndex = 1;
            // 
            // DGVStockUdjustment
            // 
            this.DGVStockUdjustment.AllowUserToAddRows = false;
            this.DGVStockUdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVStockUdjustment.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGVStockUdjustment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStockUdjustment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVStockUdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStockUdjustment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productID,
            this.colProductCode,
            this.colProductName,
            this.colClassification,
            this.colDosage,
            this.colMedType,
            this.colCost,
            this.colNewUnitCost,
            this.colPrice,
            this.colNewUnitPrice,
            this.colInStock,
            this.colNewInStock,
            this.colReOrder,
            this.colSafetyStock,
            this.colRemark,
            this.colNewRemarks,
            this.colUpdate});
            this.DGVStockUdjustment.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVStockUdjustment.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStockUdjustment.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DGVStockUdjustment.Location = new System.Drawing.Point(12, 15);
            this.DGVStockUdjustment.Name = "DGVStockUdjustment";
            this.DGVStockUdjustment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStockUdjustment.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVStockUdjustment.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVStockUdjustment.Size = new System.Drawing.Size(1756, 339);
            this.DGVStockUdjustment.TabIndex = 19;
            this.DGVStockUdjustment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVStockUdjustment_CellContentClick);
            // 
            // productID
            // 
            this.productID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.productID.DataPropertyName = "p_id";
            this.productID.HeaderText = "ID";
            this.productID.Name = "productID";
            this.productID.ReadOnly = true;
            this.productID.Visible = false;
            this.productID.Width = 47;
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
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            this.colDosage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDosage.DataPropertyName = "dosage";
            this.colDosage.HeaderText = "Dosage";
            this.colDosage.Name = "colDosage";
            this.colDosage.ReadOnly = true;
            this.colDosage.Width = 87;
            // 
            // colMedType
            // 
            this.colMedType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMedType.DataPropertyName = "med_type";
            this.colMedType.HeaderText = "Type";
            this.colMedType.Name = "colMedType";
            this.colMedType.ReadOnly = true;
            this.colMedType.Width = 68;
            // 
            // colCost
            // 
            this.colCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCost.DataPropertyName = "unit_cost";
            this.colCost.HeaderText = "Unit Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            this.colCost.Width = 87;
            // 
            // colNewUnitCost
            // 
            this.colNewUnitCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNewUnitCost.HeaderText = "New Unit Cost";
            this.colNewUnitCost.Name = "colNewUnitCost";
            this.colNewUnitCost.Width = 117;
            // 
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrice.DataPropertyName = "unit_price";
            this.colPrice.HeaderText = "Unit Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 91;
            // 
            // colNewUnitPrice
            // 
            this.colNewUnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNewUnitPrice.HeaderText = "New Unit Price";
            this.colNewUnitPrice.Name = "colNewUnitPrice";
            this.colNewUnitPrice.Width = 122;
            // 
            // colInStock
            // 
            this.colInStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colInStock.DataPropertyName = "in_stock_qty";
            this.colInStock.HeaderText = "In Stock Qty.";
            this.colInStock.Name = "colInStock";
            this.colInStock.ReadOnly = true;
            this.colInStock.Width = 108;
            // 
            // colNewInStock
            // 
            this.colNewInStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNewInStock.HeaderText = "New In Stock Qty.";
            this.colNewInStock.Name = "colNewInStock";
            this.colNewInStock.Width = 115;
            // 
            // colReOrder
            // 
            this.colReOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colReOrder.DataPropertyName = "reorder_point";
            this.colReOrder.HeaderText = "Reorder point";
            this.colReOrder.Name = "colReOrder";
            this.colReOrder.ReadOnly = true;
            this.colReOrder.Width = 116;
            // 
            // colSafetyStock
            // 
            this.colSafetyStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSafetyStock.DataPropertyName = "safety_stock_per_week";
            this.colSafetyStock.HeaderText = "Safety Stock per week";
            this.colSafetyStock.Name = "colSafetyStock";
            this.colSafetyStock.ReadOnly = true;
            this.colSafetyStock.Width = 137;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRemark.DataPropertyName = "remarks";
            this.colRemark.HeaderText = "Remarks";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 94;
            // 
            // colNewRemarks
            // 
            this.colNewRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNewRemarks.HeaderText = "New Remarks";
            this.colNewRemarks.Name = "colNewRemarks";
            this.colNewRemarks.Width = 117;
            // 
            // colUpdate
            // 
            this.colUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUpdate.HeaderText = "";
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.Text = "Update";
            this.colUpdate.UseColumnTextForButtonValue = true;
            this.colUpdate.Width = 5;
            // 
            // StockAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1771, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StockAdjustment";
            this.Text = "StockAdjustment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockAdjustment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVStockUdjustment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DGVStockUdjustment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProductSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn productID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewUnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSafetyStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewRemarks;
        private System.Windows.Forms.DataGridViewButtonColumn colUpdate;
    }
}