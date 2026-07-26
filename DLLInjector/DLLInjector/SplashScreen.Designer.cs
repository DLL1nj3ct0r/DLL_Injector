namespace DLLInjector
{
    partial class SplashScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblPercent = new Label();
            this.lblStatus = new Label();
            this.progressBar = new ProgressBar();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblTitle.Location = new System.Drawing.Point(0, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 44);
            this.lblTitle.Text = "DLL1nj3ct0r";
            this.lblTitle.Anchor = AnchorStyles.None;

            // lblPercent
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI Light", 28F);
            this.lblPercent.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblPercent.Location = new System.Drawing.Point(0, 200);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(300, 50);
            this.lblPercent.Text = "0%";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPercent.Anchor = AnchorStyles.None;

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(50, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 6);
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.progressBar.Anchor = AnchorStyles.None;

            // lblStatus
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblStatus.Location = new System.Drawing.Point(0, 280);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 20);
            this.lblStatus.Text = "Initializing...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Anchor = AnchorStyles.None;

            // SplashScreen
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "SplashScreen";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle;
        private Label lblPercent;
        private Label lblStatus;
        private ProgressBar progressBar;
    }
}
