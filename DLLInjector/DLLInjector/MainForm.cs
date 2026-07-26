namespace DLLInjector
{
    public partial class MainForm : Form
    {
        private int selectedProcessId = -1;
        private string selectedProcessName = "";
        private PictureBox? bgBox;
        private float baseFontSize;

        public MainForm()
        {
            InitializeComponent();
            baseFontSize = this.Font.Size;
            ApplyTheme();
            ApplyBackgroundImage();
            initialized = true;
            Log("DLL1nj3ct0r ready. Select a DLL file and target process to begin.");
        }

        public void ShowUpdateButton()
        {
            btnUpdate.Visible = true;
            btnUpdate.BringToFront();
        }

        private bool initialized;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!initialized || ClientSize.Width <= 0) return;
            float scale = Math.Max(0.6f, Math.Min(2.5f, ClientSize.Width / 600f));
            ScaleControls(this.Controls, scale);
        }

        private void ScaleControls(Control.ControlCollection controls, float scale)
        {
            foreach (Control c in controls)
            {
                if (c is Label lbl && baseFontSize > 0)
                    lbl.Font = new Font(lbl.Font.FontFamily, Math.Max(1, baseFontSize * scale * (lbl == lblTitle ? 1.8f : lbl == lblSubtitle ? 0.8f : lbl == lblDllPath || lbl == lblTargetProcess || lbl == lblStatus ? 0.9f : 1f)));
                else if (c is Button btn && btn == btnInject && baseFontSize > 0)
                    btn.Font = new Font(btn.Font.FontFamily, Math.Max(1, 13f * scale));
                else if (c is TextBox && c != txtLog && baseFontSize > 0)
                    c.Font = new Font(c.Font.FontFamily, Math.Max(1, 9.5f * scale));
                else if (c is TextBox log && baseFontSize > 0)
                    log.Font = new Font("Cascadia Mono", Math.Max(1, 9f * scale));

                if (c.HasChildren)
                    ScaleControls(c.Controls, scale);
            }
        }

        private void ApplyTheme()
        {
            bool dark = Properties.Settings.Default.Theme != "light";

            Color bg = dark ? Color.FromArgb(18, 18, 24) : Color.FromArgb(240, 242, 245);
            Color panelBg = dark ? Color.FromArgb(22, 22, 30) : Color.FromArgb(230, 232, 236);
            Color inputBg = dark ? Color.FromArgb(30, 30, 42) : Color.White;
            Color logBg = dark ? Color.FromArgb(14, 14, 20) : Color.FromArgb(250, 250, 252);
            Color textMain = dark ? Color.FromArgb(200, 200, 210) : Color.FromArgb(30, 30, 40);
            Color textDim = dark ? Color.FromArgb(100, 100, 120) : Color.FromArgb(120, 120, 130);
            Color textSection = dark ? Color.FromArgb(160, 160, 180) : Color.FromArgb(80, 80, 100);
            Color accent = Color.FromArgb(0, 210, 255);
            Color btnBg = dark ? Color.FromArgb(26, 26, 36) : Color.FromArgb(220, 224, 230);
            Color border = dark ? Color.FromArgb(50, 50, 70) : Color.FromArgb(190, 190, 200);
            Color greenBtn = Color.FromArgb(0, 200, 80);
            Color cyanBtn = dark ? Color.FromArgb(0, 140, 200) : Color.FromArgb(0, 130, 190);
            Color logText = dark ? Color.FromArgb(0, 200, 120) : Color.FromArgb(0, 140, 80);

            this.BackColor = bg;
            panelTop.BackColor = bg;
            panelDll.BackColor = panelBg;
            panelTarget.BackColor = panelBg;
            panelStatus.BackColor = bg;
            btnInject.BackColor = greenBtn;

            lblTitle.ForeColor = accent;
            lblSubtitle.ForeColor = textDim;
            lblDllPath.ForeColor = textSection;
            lblTargetProcess.ForeColor = textSection;
            lblStatus.ForeColor = textDim;

            txtDllPath.BackColor = inputBg;
            txtDllPath.ForeColor = textMain;
            txtDllPath.BorderStyle = BorderStyle.FixedSingle;
            txtTargetProcess.BackColor = inputBg;
            txtTargetProcess.ForeColor = textMain;
            txtTargetProcess.BorderStyle = BorderStyle.FixedSingle;

            txtLog.BackColor = logBg;
            txtLog.ForeColor = logText;
            txtLog.BorderStyle = BorderStyle.FixedSingle;

            foreach (var btn in new[] { btnSelectApp, btnSelectProcess })
            {
                btn.BackColor = btnBg;
                btn.ForeColor = accent;
                btn.FlatAppearance.BorderColor = border;
            }
            btnBrowseDll.BackColor = cyanBtn;
            btnBrowseDll.ForeColor = Color.White;
            btnBrowseDll.FlatAppearance.BorderSize = 0;
            btnSettings.BackColor = btnBg;
            btnSettings.ForeColor = textDim;
            btnSettings.FlatAppearance.BorderColor = border;
        }

        private void ApplyBackgroundImage()
        {
            string path = Properties.Settings.Default.BackgroundImage;
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                if (bgBox == null)
                {
                    bgBox = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        WaitOnLoad = false
                    };
                    this.Controls.Add(bgBox);
                    bgBox.SendToBack();
                    panelTop.BringToFront();
                    panelDll.BringToFront();
                    panelTarget.BringToFront();
                    btnInject.BringToFront();
                    panelStatus.BringToFront();
                    btnSettings.BringToFront();
                }
                try
                {
                    var oldImg = bgBox.Image;
                    bgBox.Image = new Bitmap(path);
                    oldImg?.Dispose();
                    bgBox.Visible = true;
                }
                catch { bgBox.Visible = false; }
            }
            else if (bgBox != null)
            {
                bgBox.Visible = false;
            }
        }

        public void RefreshTheme()
        {
            ApplyTheme();
            ApplyBackgroundImage();
        }

        private void btnBrowseDll_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Title = "Select DLL File";
            dialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDllPath.Text = dialog.FileName;
                Log($"DLL selected: {dialog.FileName}");
            }
        }

        private void btnSelectApp_Click(object? sender, EventArgs e) => OpenProcessSelector();
        private void btnSelectProcess_Click(object? sender, EventArgs e) => OpenProcessSelector();

        private void OpenProcessSelector()
        {
            using var processForm = new ProcessListForm();
            if (processForm.ShowDialog() == DialogResult.OK && processForm.SelectedProcess != null)
            {
                selectedProcessId = processForm.SelectedProcess.ProcessId;
                selectedProcessName = processForm.SelectedProcess.ProcessName;
                txtTargetProcess.Text = processForm.SelectedProcess.DisplayName;
                Log($"Target process: {selectedProcessName} (PID: {selectedProcessId})");
            }
        }

        private async void btnInject_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDllPath.Text))
            {
                MessageBox.Show("Please select a DLL file first.", "No DLL Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectedProcessId == -1)
            {
                MessageBox.Show("Please select a target process first.", "No Target Process", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnInject.Enabled = false;
            btnInject.Text = "INJECTING...";
            Log($"Injecting into {selectedProcessName} (PID: {selectedProcessId})...");

            string injectionError = "";
            bool success = await Task.Run(() => Injector.Inject(selectedProcessId, txtDllPath.Text, out injectionError));

            if (success)
            {
                Log("DLL injected successfully!");
                MessageBox.Show("DLL injected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Log($"Injection failed: {injectionError}");
                MessageBox.Show($"Injection failed:\n\n{injectionError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnInject.Enabled = true;
            btnInject.Text = "INJECT";
        }

        private void btnSettings_Click(object? sender, EventArgs e)
        {
            using var settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();
        }

        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnUpdate.Text = "Updating...";

            var info = await UpdateChecker.CheckForUpdateAsync();
            if (info != null)
            {
                bool success = await Updater.DownloadAndUpdateAsync(info.DownloadUrl, info.Changelog);
                if (!success)
                {
                    MessageBox.Show("Update failed. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnUpdate.Enabled = true;
                    btnUpdate.Text = "Update Available";
                }
            }
            else
            {
                MessageBox.Show("No update available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Visible = false;
            }
        }

        private void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            txtLog.AppendText($"[{timestamp}] {message}\r\n");
        }
    }
}
