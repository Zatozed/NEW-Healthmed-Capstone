namespace NEW_Healthmed_Capstone.Reports
{
    partial class Resibo
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
            this.crvResibo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvResibo
            // 
            this.crvResibo.ActiveViewIndex = -1;
            this.crvResibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvResibo.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvResibo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvResibo.Location = new System.Drawing.Point(0, 0);
            this.crvResibo.Name = "crvResibo";
            this.crvResibo.Size = new System.Drawing.Size(800, 450);
            this.crvResibo.TabIndex = 0;
            this.crvResibo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Resibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvResibo);
            this.Name = "Resibo";
            this.Text = "Resibo";
            this.ResumeLayout(false);

        }

        #endregion
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvResibo;
    }
}