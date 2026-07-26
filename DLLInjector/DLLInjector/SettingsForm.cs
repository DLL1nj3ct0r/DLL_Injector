namespace DLLInjector
{
    public partial class SettingsForm : Form
    {
        private readonly MainForm mainForm;

        public SettingsForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            bool dark = Properties.Settings.Default.Theme != "light";
            lblThemeStatus.Text = dark ? "Current: Dark" : "Current: Light";
            lblThemeStatus.ForeColor = dark ? Color.FromArgb(0, 210, 255) : Color.FromArgb(0, 130, 190);

            string bgPath = Properties.Settings.Default.BackgroundImage;
            if (!string.IsNullOrEmpty(bgPath) && File.Exists(bgPath))
                lblBgStatus.Text = $"Active: {Path.GetFileName(bgPath)}";
            else
                lblBgStatus.Text = "No background set";

            txtUpdateUrl.Text = Properties.Settings.Default.UpdateUrl;
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.UpdateUrl))
                lblUpdateStatus.Text = "Update checks enabled.";
            else
                lblUpdateStatus.Text = "Update checks disabled. Paste a URL above to enable.";
        }

        private void btnDark_Click(object? sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "dark";
            Properties.Settings.Default.Save();
            lblThemeStatus.Text = "Current: Dark";
            lblThemeStatus.ForeColor = Color.FromArgb(0, 210, 255);
            mainForm.RefreshTheme();
        }

        private void btnLight_Click(object? sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "light";
            Properties.Settings.Default.Save();
            lblThemeStatus.Text = "Current: Light";
            lblThemeStatus.ForeColor = Color.FromArgb(0, 130, 190);
            mainForm.RefreshTheme();
        }

        private void btnImportPng_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Title = "Select Background Image";
            dialog.Filter = "Images (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.BackgroundImage = dialog.FileName;
                Properties.Settings.Default.Save();
                lblBgStatus.Text = $"Active: {Path.GetFileName(dialog.FileName)}";
                mainForm.RefreshTheme();
            }
        }

        private void btnClearBg_Click(object? sender, EventArgs e)
        {
            Properties.Settings.Default.BackgroundImage = "";
            Properties.Settings.Default.Save();
            lblBgStatus.Text = "No background set";
            mainForm.RefreshTheme();
        }

        private void btnSaveUpdateUrl_Click(object? sender, EventArgs e)
        {
            Properties.Settings.Default.UpdateUrl = txtUpdateUrl.Text.Trim();
            Properties.Settings.Default.Save();

            if (!string.IsNullOrWhiteSpace(txtUpdateUrl.Text))
                lblUpdateStatus.Text = "Update checks enabled. URL saved.";
            else
                lblUpdateStatus.Text = "Update checks disabled. Paste a URL above to enable.";

            MessageBox.Show("Update URL saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
