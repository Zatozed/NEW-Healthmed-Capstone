namespace NEW_Healthmed_Capstone.Reports
{
    partial class PoReportViewer
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
            this.crtPo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtPo
            // 
            this.crtPo.ActiveViewIndex = -1;
            this.crtPo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtPo.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtPo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtPo.Location = new System.Drawing.Point(0, 0);
            this.crtPo.Name = "crtPo";
            this.crtPo.Size = new System.Drawing.Size(800, 450);
            this.crtPo.TabIndex = 0;
            this.crtPo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PoReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtPo);
            this.Name = "PoReportViewer";
            this.Text = "PoReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtPo;
    }
}