namespace NEW_Healthmed_Capstone.Reports
{
    partial class CashRegReportViewer
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
            this.crtCashRegReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtCashRegReport
            // 
            this.crtCashRegReport.ActiveViewIndex = -1;
            this.crtCashRegReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtCashRegReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtCashRegReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtCashRegReport.Location = new System.Drawing.Point(0, 0);
            this.crtCashRegReport.Name = "crtCashRegReport";
            this.crtCashRegReport.Size = new System.Drawing.Size(800, 450);
            this.crtCashRegReport.TabIndex = 0;
            this.crtCashRegReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CashRegReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtCashRegReport);
            this.Name = "CashRegReportViewer";
            this.Text = "CashRegReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtCashRegReport;
    }
}