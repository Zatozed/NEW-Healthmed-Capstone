namespace NEW_Healthmed_Capstone.Reports
{
    partial class ProductReportViewer
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
            this.crtProduct = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtProduct
            // 
            this.crtProduct.ActiveViewIndex = -1;
            this.crtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtProduct.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtProduct.Location = new System.Drawing.Point(0, 0);
            this.crtProduct.Name = "crtProduct";
            this.crtProduct.Size = new System.Drawing.Size(928, 450);
            this.crtProduct.TabIndex = 0;
            this.crtProduct.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ProductReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 450);
            this.Controls.Add(this.crtProduct);
            this.Name = "ProductReportViewer";
            this.Text = "ProductReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtProduct;
    }
}