namespace NEW_Healthmed_Capstone.Reports
{
    partial class RPOReportViewer
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
            this.crtViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtViewer
            // 
            this.crtViewer.ActiveViewIndex = -1;
            this.crtViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtViewer.Location = new System.Drawing.Point(0, 0);
            this.crtViewer.Name = "crtViewer";
            this.crtViewer.Size = new System.Drawing.Size(800, 450);
            this.crtViewer.TabIndex = 0;
            this.crtViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RPOReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtViewer);
            this.Name = "RPOReportViewer";
            this.Text = "RPOReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtViewer;
    }
}