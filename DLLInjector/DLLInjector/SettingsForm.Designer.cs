namespace DLLInjector
{
    partial class SettingsForm
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
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.panelContent = new Panel();
            this.lblTheme = new Label();
            this.btnDark = new Button();
            this.btnLight = new Button();
            this.lblThemeStatus = new Label();
            this.lblBg = new Label();
            this.btnImportPng = new Button();
            this.lblBgStatus = new Label();
            this.btnClearBg = new Button();
            this.lblUpdate = new Label();
            this.txtUpdateUrl = new TextBox();
            this.lblUpdateStatus = new Label();
            this.btnSaveUpdateUrl = new Button();
            this.btnClose = new Button();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(460, 56);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Text = "Settings";

            // panelContent
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            this.panelContent.Controls.Add(this.lblTheme);
            this.panelContent.Controls.Add(this.btnDark);
            this.panelContent.Controls.Add(this.btnLight);
            this.panelContent.Controls.Add(this.lblThemeStatus);
            this.panelContent.Controls.Add(this.lblBg);
            this.panelContent.Controls.Add(this.btnImportPng);
            this.panelContent.Controls.Add(this.btnClearBg);
            this.panelContent.Controls.Add(this.lblBgStatus);
            this.panelContent.Controls.Add(this.lblUpdate);
            this.panelContent.Controls.Add(this.txtUpdateUrl);
            this.panelContent.Controls.Add(this.btnSaveUpdateUrl);
            this.panelContent.Controls.Add(this.lblUpdateStatus);
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.Padding = new Padding(20);
            this.panelContent.Size = new System.Drawing.Size(460, 350);

            // lblTheme
            this.lblTheme.AutoSize = true;
            this.lblTheme.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTheme.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.lblTheme.Location = new System.Drawing.Point(20, 20);
            this.lblTheme.Text = "THEME";

            // btnDark
            this.btnDark.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.btnDark.FlatStyle = FlatStyle.Flat;
            this.btnDark.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnDark.FlatAppearance.BorderSize = 2;
            this.btnDark.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDark.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnDark.Location = new System.Drawing.Point(20, 50);
            this.btnDark.Size = new System.Drawing.Size(120, 36);
            this.btnDark.Text = "Dark";
            this.btnDark.Cursor = Cursors.Hand;
            this.btnDark.Click += new EventHandler(this.btnDark_Click);

            // btnLight
            this.btnLight.BackColor = System.Drawing.Color.FromArgb(230, 232, 236);
            this.btnLight.FlatStyle = FlatStyle.Flat;
            this.btnLight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(190, 190, 200);
            this.btnLight.FlatAppearance.BorderSize = 1;
            this.btnLight.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLight.ForeColor = System.Drawing.Color.FromArgb(30, 30, 40);
            this.btnLight.Location = new System.Drawing.Point(150, 50);
            this.btnLight.Size = new System.Drawing.Size(120, 36);
            this.btnLight.Text = "Light";
            this.btnLight.Cursor = Cursors.Hand;
            this.btnLight.Click += new EventHandler(this.btnLight_Click);

            // lblThemeStatus
            this.lblThemeStatus.AutoSize = true;
            this.lblThemeStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThemeStatus.ForeColor = System.Drawing.Color.FromArgb(0, 200, 120);
            this.lblThemeStatus.Location = new System.Drawing.Point(280, 60);
            this.lblThemeStatus.Text = "";

            // lblBg
            this.lblBg.AutoSize = true;
            this.lblBg.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblBg.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.lblBg.Location = new System.Drawing.Point(20, 110);
            this.lblBg.Text = "BACKGROUND IMAGE";

            // btnImportPng
            this.btnImportPng.BackColor = System.Drawing.Color.FromArgb(0, 140, 200);
            this.btnImportPng.FlatStyle = FlatStyle.Flat;
            this.btnImportPng.FlatAppearance.BorderSize = 0;
            this.btnImportPng.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnImportPng.ForeColor = System.Drawing.Color.White;
            this.btnImportPng.Location = new System.Drawing.Point(20, 140);
            this.btnImportPng.Size = new System.Drawing.Size(160, 36);
            this.btnImportPng.Text = "Import PNG";
            this.btnImportPng.Cursor = Cursors.Hand;
            this.btnImportPng.Click += new EventHandler(this.btnImportPng_Click);

            // btnClearBg
            this.btnClearBg.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnClearBg.FlatStyle = FlatStyle.Flat;
            this.btnClearBg.FlatAppearance.BorderSize = 0;
            this.btnClearBg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearBg.ForeColor = System.Drawing.Color.White;
            this.btnClearBg.Location = new System.Drawing.Point(190, 140);
            this.btnClearBg.Size = new System.Drawing.Size(100, 36);
            this.btnClearBg.Text = "Clear BG";
            this.btnClearBg.Cursor = Cursors.Hand;
            this.btnClearBg.Click += new EventHandler(this.btnClearBg_Click);

            // lblBgStatus
            this.lblBgStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBgStatus.ForeColor = System.Drawing.Color.FromArgb(120, 120, 140);
            this.lblBgStatus.Location = new System.Drawing.Point(20, 185);
            this.lblBgStatus.Size = new System.Drawing.Size(400, 20);
            this.lblBgStatus.Text = "No background set";

            // lblUpdate
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.lblUpdate.Location = new System.Drawing.Point(20, 220);
            this.lblUpdate.Text = "UPDATE URL (version.json)";

            // txtUpdateUrl
            this.txtUpdateUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtUpdateUrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.txtUpdateUrl.BorderStyle = BorderStyle.FixedSingle;
            this.txtUpdateUrl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtUpdateUrl.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.txtUpdateUrl.Location = new System.Drawing.Point(20, 248);
            this.txtUpdateUrl.Size = new System.Drawing.Size(330, 25);
            this.txtUpdateUrl.PlaceholderText = "  Paste URL to your version.json file...";

            // btnSaveUpdateUrl
            this.btnSaveUpdateUrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSaveUpdateUrl.BackColor = System.Drawing.Color.FromArgb(0, 140, 200);
            this.btnSaveUpdateUrl.FlatStyle = FlatStyle.Flat;
            this.btnSaveUpdateUrl.FlatAppearance.BorderSize = 0;
            this.btnSaveUpdateUrl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnSaveUpdateUrl.ForeColor = System.Drawing.Color.White;
            this.btnSaveUpdateUrl.Location = new System.Drawing.Point(360, 247);
            this.btnSaveUpdateUrl.Size = new System.Drawing.Size(80, 27);
            this.btnSaveUpdateUrl.Text = "Save";
            this.btnSaveUpdateUrl.Cursor = Cursors.Hand;
            this.btnSaveUpdateUrl.Click += new EventHandler(this.btnSaveUpdateUrl_Click);

            // lblUpdateStatus
            this.lblUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUpdateStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblUpdateStatus.Location = new System.Drawing.Point(20, 280);
            this.lblUpdateStatus.Size = new System.Drawing.Size(420, 50);
            this.lblUpdateStatus.Text = "Host a version.json file anywhere (Google Drive, Dropbox, any web host)\nand paste the direct link above. Leave empty to disable update checks.";

            // btnClose
            this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(26, 26, 36);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.btnClose.Location = new System.Drawing.Point(340, 360);
            this.btnClose.Size = new System.Drawing.Size(100, 36);
            this.btnClose.Text = "Close";
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // SettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ClientSize = new System.Drawing.Size(460, 410);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Panel panelContent;
        private Label lblTheme;
        private Button btnDark;
        private Button btnLight;
        private Label lblThemeStatus;
        private Label lblBg;
        private Button btnImportPng;
        private Button btnClearBg;
        private Label lblBgStatus;
        private Label lblUpdate;
        private TextBox txtUpdateUrl;
        private Button btnSaveUpdateUrl;
        private Label lblUpdateStatus;
        private Button btnClose;
    }
}
