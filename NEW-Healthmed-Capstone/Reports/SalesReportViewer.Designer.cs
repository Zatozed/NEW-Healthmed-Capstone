namespace NEW_Healthmed_Capstone.Reports
{
    partial class SalesReportViewer
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
            this.crtSalesReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SalesReport1 = new NEW_Healthmed_Capstone.CrystalReportsFolder.SalesReport();
            this.SuspendLayout();
            // 
            // crtSalesReport
            // 
            this.crtSalesReport.ActiveViewIndex = -1;
            this.crtSalesReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtSalesReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtSalesReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtSalesReport.Location = new System.Drawing.Point(0, 0);
            this.crtSalesReport.Name = "crtSalesReport";
            this.crtSalesReport.ReportSource = this.SalesReport1;
            this.crtSalesReport.Size = new System.Drawing.Size(800, 450);
            this.crtSalesReport.TabIndex = 0;
            // 
            // SalesReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtSalesReport);
            this.Name = "SalesReportViewer";
            this.Text = "SalesReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtSalesReport;
        private CrystalReportsFolder.SalesReport SalesReport1;
    }
}