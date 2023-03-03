namespace NEW_Healthmed_Capstone.Reports
{
    partial class CashRegReportGenerator
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.dgvCashReg = new System.Windows.Forms.DataGridView();
            this.colCashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbStarting = new System.Windows.Forms.Label();
            this.lbEnding = new System.Windows.Forms.Label();
            this.lbEdPlusCo = new System.Windows.Forms.Label();
            this.lbDifPlusCo = new System.Windows.Forms.Label();
            this.lbDif = new System.Windows.Forms.Label();
            this.lbTotalCashOut = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashReg)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.dt1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbUsers, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvCashReg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbStarting, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbEnding, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbEdPlusCo, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbDifPlusCo, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbDif, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbTotalCashOut, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerate, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 623);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dt1
            // 
            this.dt1.CustomFormat = "yyyy-MM-dd";
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1.Location = new System.Drawing.Point(697, 4);
            this.dt1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(331, 24);
            this.dt1.TabIndex = 0;
            this.dt1.ValueChanged += new System.EventHandler(this.dt1_ValueChanged);
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(5, 4);
            this.cbUsers.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(199, 26);
            this.cbUsers.TabIndex = 1;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
            // 
            // dgvCashReg
            // 
            this.dgvCashReg.AllowUserToAddRows = false;
            this.dgvCashReg.AllowUserToDeleteRows = false;
            this.dgvCashReg.AllowUserToOrderColumns = true;
            this.dgvCashReg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashReg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCashier,
            this.colAction,
            this.colAmount,
            this.colDate});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCashReg, 3);
            this.dgvCashReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashReg.Location = new System.Drawing.Point(5, 35);
            this.dgvCashReg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvCashReg.Name = "dgvCashReg";
            this.dgvCashReg.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgvCashReg, 2);
            this.dgvCashReg.Size = new System.Drawing.Size(1030, 490);
            this.dgvCashReg.TabIndex = 2;
            // 
            // colCashier
            // 
            this.colCashier.DataPropertyName = "cashier";
            this.colCashier.HeaderText = "Cashier";
            this.colCashier.Name = "colCashier";
            this.colCashier.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.DataPropertyName = "cashier_action";
            this.colAction.HeaderText = "Action";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "cash_amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "action_date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // lbStarting
            // 
            this.lbStarting.AutoSize = true;
            this.lbStarting.Location = new System.Drawing.Point(5, 529);
            this.lbStarting.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbStarting.Name = "lbStarting";
            this.lbStarting.Size = new System.Drawing.Size(76, 18);
            this.lbStarting.TabIndex = 5;
            this.lbStarting.Text = "Starting: ";
            // 
            // lbEnding
            // 
            this.lbEnding.AutoSize = true;
            this.lbEnding.Location = new System.Drawing.Point(5, 560);
            this.lbEnding.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbEnding.Name = "lbEnding";
            this.lbEnding.Size = new System.Drawing.Size(69, 18);
            this.lbEnding.TabIndex = 7;
            this.lbEnding.Text = "Ending: ";
            // 
            // lbEdPlusCo
            // 
            this.lbEdPlusCo.AutoSize = true;
            this.lbEdPlusCo.Location = new System.Drawing.Point(5, 591);
            this.lbEdPlusCo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbEdPlusCo.Name = "lbEdPlusCo";
            this.lbEdPlusCo.Size = new System.Drawing.Size(150, 18);
            this.lbEdPlusCo.TabIndex = 4;
            this.lbEdPlusCo.Text = "Ending + Cash Out";
            // 
            // lbDifPlusCo
            // 
            this.lbDifPlusCo.AutoSize = true;
            this.lbDifPlusCo.Location = new System.Drawing.Point(351, 591);
            this.lbDifPlusCo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbDifPlusCo.Name = "lbDifPlusCo";
            this.lbDifPlusCo.Size = new System.Drawing.Size(201, 18);
            this.lbDifPlusCo.TabIndex = 6;
            this.lbDifPlusCo.Text = "Difference with Cash Out:";
            // 
            // lbDif
            // 
            this.lbDif.AutoSize = true;
            this.lbDif.Location = new System.Drawing.Point(351, 560);
            this.lbDif.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbDif.Name = "lbDif";
            this.lbDif.Size = new System.Drawing.Size(90, 18);
            this.lbDif.TabIndex = 8;
            this.lbDif.Text = "Difference:";
            // 
            // lbTotalCashOut
            // 
            this.lbTotalCashOut.AutoSize = true;
            this.lbTotalCashOut.Location = new System.Drawing.Point(351, 529);
            this.lbTotalCashOut.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTotalCashOut.Name = "lbTotalCashOut";
            this.lbTotalCashOut.Size = new System.Drawing.Size(132, 18);
            this.lbTotalCashOut.TabIndex = 3;
            this.lbTotalCashOut.Text = "Total Cash Out: ";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerate.Location = new System.Drawing.Point(697, 533);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(338, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // CashRegReportGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 623);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(1056, 662);
            this.Name = "CashRegReportGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Register Report Generator";
            this.Load += new System.EventHandler(this.CashRegReportGenerator_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashReg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.DataGridView dgvCashReg;
        private System.Windows.Forms.Label lbTotalCashOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.Label lbDif;
        private System.Windows.Forms.Label lbEdPlusCo;
        private System.Windows.Forms.Label lbDifPlusCo;
        private System.Windows.Forms.Label lbStarting;
        private System.Windows.Forms.Label lbEnding;
        private System.Windows.Forms.Button btnGenerate;
    }
}