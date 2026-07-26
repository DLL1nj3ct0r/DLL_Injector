namespace DLLInjector
{
    partial class MainForm
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
            this.lblSubtitle = new Label();
            this.btnSelectApp = new Button();
            this.panelDll = new Panel();
            this.lblDllPath = new Label();
            this.txtDllPath = new TextBox();
            this.btnBrowseDll = new Button();
            this.panelTarget = new Panel();
            this.lblTargetProcess = new Label();
            this.txtTargetProcess = new TextBox();
            this.btnSelectProcess = new Button();
            this.btnInject = new Button();
            this.panelStatus = new Panel();
            this.lblStatus = new Label();
            this.txtLog = new TextBox();
            this.btnSettings = new Button();
            this.btnUpdate = new Button();
            this.panelTop.SuspendLayout();
            this.panelDll.SuspendLayout();
            this.panelTarget.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblSubtitle);
            this.panelTop.Controls.Add(this.btnSelectApp);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 64);
            this.panelTop.MinimumSize = new System.Drawing.Size(0, 64);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "DLL1nj3ct0r";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblSubtitle.Location = new System.Drawing.Point(22, 38);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "process injection tool";

            // btnSelectApp
            this.btnSelectApp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSelectApp.BackColor = System.Drawing.Color.FromArgb(26, 26, 36);
            this.btnSelectApp.FlatStyle = FlatStyle.Flat;
            this.btnSelectApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnSelectApp.FlatAppearance.BorderSize = 1;
            this.btnSelectApp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectApp.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnSelectApp.Location = new System.Drawing.Point(440, 16);
            this.btnSelectApp.Name = "btnSelectApp";
            this.btnSelectApp.Size = new System.Drawing.Size(140, 34);
            this.btnSelectApp.Text = "Select Application";
            this.btnSelectApp.Cursor = Cursors.Hand;
            this.btnSelectApp.Click += new EventHandler(this.btnSelectApp_Click);

            // panelDll
            this.panelDll.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            this.panelDll.Controls.Add(this.lblDllPath);
            this.panelDll.Controls.Add(this.txtDllPath);
            this.panelDll.Controls.Add(this.btnBrowseDll);
            this.panelDll.Dock = DockStyle.Top;
            this.panelDll.Location = new System.Drawing.Point(0, 64);
            this.panelDll.Name = "panelDll";
            this.panelDll.Padding = new Padding(20, 12, 20, 12);
            this.panelDll.Size = new System.Drawing.Size(600, 72);
            this.panelDll.MinimumSize = new System.Drawing.Size(0, 72);

            // lblDllPath
            this.lblDllPath.AutoSize = true;
            this.lblDllPath.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDllPath.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.lblDllPath.Location = new System.Drawing.Point(20, 12);
            this.lblDllPath.Name = "lblDllPath";
            this.lblDllPath.Text = "DLL FILE";

            // txtDllPath
            this.txtDllPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtDllPath.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.txtDllPath.BorderStyle = BorderStyle.FixedSingle;
            this.txtDllPath.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDllPath.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.txtDllPath.Location = new System.Drawing.Point(20, 34);
            this.txtDllPath.Name = "txtDllPath";
            this.txtDllPath.Size = new System.Drawing.Size(448, 25);
            this.txtDllPath.PlaceholderText = "  Browse to select a .dll file...";

            // btnBrowseDll
            this.btnBrowseDll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnBrowseDll.BackColor = System.Drawing.Color.FromArgb(0, 140, 200);
            this.btnBrowseDll.FlatStyle = FlatStyle.Flat;
            this.btnBrowseDll.FlatAppearance.BorderSize = 0;
            this.btnBrowseDll.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnBrowseDll.ForeColor = System.Drawing.Color.White;
            this.btnBrowseDll.Location = new System.Drawing.Point(480, 32);
            this.btnBrowseDll.Name = "btnBrowseDll";
            this.btnBrowseDll.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseDll.Text = "Browse";
            this.btnBrowseDll.Cursor = Cursors.Hand;
            this.btnBrowseDll.Click += new EventHandler(this.btnBrowseDll_Click);

            // panelTarget
            this.panelTarget.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            this.panelTarget.Controls.Add(this.lblTargetProcess);
            this.panelTarget.Controls.Add(this.txtTargetProcess);
            this.panelTarget.Controls.Add(this.btnSelectProcess);
            this.panelTarget.Dock = DockStyle.Top;
            this.panelTarget.Location = new System.Drawing.Point(0, 136);
            this.panelTarget.Name = "panelTarget";
            this.panelTarget.Padding = new Padding(20, 12, 20, 12);
            this.panelTarget.Size = new System.Drawing.Size(600, 72);
            this.panelTarget.MinimumSize = new System.Drawing.Size(0, 72);

            // lblTargetProcess
            this.lblTargetProcess.AutoSize = true;
            this.lblTargetProcess.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblTargetProcess.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.lblTargetProcess.Location = new System.Drawing.Point(20, 12);
            this.lblTargetProcess.Name = "lblTargetProcess";
            this.lblTargetProcess.Text = "TARGET PROCESS";

            // txtTargetProcess
            this.txtTargetProcess.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtTargetProcess.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.txtTargetProcess.BorderStyle = BorderStyle.FixedSingle;
            this.txtTargetProcess.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTargetProcess.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.txtTargetProcess.Location = new System.Drawing.Point(20, 34);
            this.txtTargetProcess.Name = "txtTargetProcess";
            this.txtTargetProcess.ReadOnly = true;
            this.txtTargetProcess.Size = new System.Drawing.Size(448, 25);
            this.txtTargetProcess.PlaceholderText = "  No process selected...";

            // btnSelectProcess
            this.btnSelectProcess.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSelectProcess.BackColor = System.Drawing.Color.FromArgb(26, 26, 36);
            this.btnSelectProcess.FlatStyle = FlatStyle.Flat;
            this.btnSelectProcess.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnSelectProcess.FlatAppearance.BorderSize = 1;
            this.btnSelectProcess.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectProcess.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnSelectProcess.Location = new System.Drawing.Point(480, 32);
            this.btnSelectProcess.Name = "btnSelectProcess";
            this.btnSelectProcess.Size = new System.Drawing.Size(100, 28);
            this.btnSelectProcess.Text = "Select";
            this.btnSelectProcess.Cursor = Cursors.Hand;
            this.btnSelectProcess.Click += new EventHandler(this.btnSelectProcess_Click);

            // btnInject
            this.btnInject.BackColor = System.Drawing.Color.FromArgb(0, 200, 80);
            this.btnInject.Dock = DockStyle.Top;
            this.btnInject.FlatStyle = FlatStyle.Flat;
            this.btnInject.FlatAppearance.BorderSize = 0;
            this.btnInject.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.btnInject.ForeColor = System.Drawing.Color.White;
            this.btnInject.Location = new System.Drawing.Point(0, 208);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(600, 50);
            this.btnInject.MinimumSize = new System.Drawing.Size(0, 50);
            this.btnInject.Text = "INJECT";
            this.btnInject.Cursor = Cursors.Hand;
            this.btnInject.Click += new EventHandler(this.btnInject_Click);

            // panelStatus
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.panelStatus.Controls.Add(this.txtLog);
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Dock = DockStyle.Fill;
            this.panelStatus.Location = new System.Drawing.Point(0, 258);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Padding = new Padding(20, 12, 20, 15);
            this.panelStatus.Size = new System.Drawing.Size(600, 242);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblStatus.Location = new System.Drawing.Point(20, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "LOG";

            // txtLog
            this.txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(14, 14, 20);
            this.txtLog.BorderStyle = BorderStyle.FixedSingle;
            this.txtLog.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(0, 200, 120);
            this.txtLog.Location = new System.Drawing.Point(20, 32);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(560, 195);

            // btnSettings
            this.btnSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(26, 26, 36);
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnSettings.FlatAppearance.BorderSize = 1;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(120, 120, 140);
            this.btnSettings.Location = new System.Drawing.Point(515, 480);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 28);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Cursor = Cursors.Hand;
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);

            // btnUpdate
            this.btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 160, 220);
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(15, 480);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 28);
            this.btnUpdate.Text = "Update Available";
            this.btnUpdate.Cursor = Cursors.Hand;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnInject);
            this.Controls.Add(this.panelTarget);
            this.Controls.Add(this.panelDll);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "DLL1nj3ct0r";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelDll.ResumeLayout(false);
            this.panelDll.PerformLayout();
            this.panelTarget.ResumeLayout(false);
            this.panelTarget.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnSelectApp;
        private Panel panelDll;
        private Label lblDllPath;
        private TextBox txtDllPath;
        private Button btnBrowseDll;
        private Panel panelTarget;
        private Label lblTargetProcess;
        private TextBox txtTargetProcess;
        private Button btnSelectProcess;
        private Button btnInject;
        private Panel panelStatus;
        private Label lblStatus;
        private TextBox txtLog;
        private Button btnSettings;
        private Button btnUpdate;
    }
}
