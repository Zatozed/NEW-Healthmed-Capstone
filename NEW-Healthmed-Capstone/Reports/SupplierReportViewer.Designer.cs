namespace NEW_Healthmed_Capstone.Reports
{
    partial class SupplierReportViewer
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
            this.crtSupplier = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtSupplier
            // 
            this.crtSupplier.ActiveViewIndex = -1;
            this.crtSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtSupplier.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtSupplier.Location = new System.Drawing.Point(0, 0);
            this.crtSupplier.Name = "crtSupplier";
            this.crtSupplier.Size = new System.Drawing.Size(800, 450);
            this.crtSupplier.TabIndex = 0;
            this.crtSupplier.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // SupplierReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtSupplier);
            this.Name = "SupplierReportViewer";
            this.Text = "SupplierReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtSupplier;
    }
}