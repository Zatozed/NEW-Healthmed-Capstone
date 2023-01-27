namespace NEW_Healthmed_Capstone.Reports
{
    partial class ProductMasterListReportViewer
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
            this.crtProductMasterList = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtProductMasterList
            // 
            this.crtProductMasterList.ActiveViewIndex = -1;
            this.crtProductMasterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtProductMasterList.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtProductMasterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtProductMasterList.Location = new System.Drawing.Point(0, 0);
            this.crtProductMasterList.Name = "crtProductMasterList";
            this.crtProductMasterList.Size = new System.Drawing.Size(800, 450);
            this.crtProductMasterList.TabIndex = 0;
            this.crtProductMasterList.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ProductMasterListReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtProductMasterList);
            this.Name = "ProductMasterListReportViewer";
            this.Text = "ProductMasterListReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtProductMasterList;
    }
}