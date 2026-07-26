namespace DLLInjector
{
    public partial class ProcessListForm : Form
    {
        public ProcessEntry? SelectedProcess { get; private set; }
        private List<ProcessEntry> allProcesses = new();

        public ProcessListForm()
        {
            InitializeComponent();
            ApplyTheme();
            LoadProcesses();
        }

        private void ApplyTheme()
        {
            bool dark = Properties.Settings.Default.Theme != "light";
            Color bg = dark ? Color.FromArgb(18, 18, 24) : Color.FromArgb(240, 242, 245);
            Color panelBg = dark ? Color.FromArgb(22, 22, 30) : Color.FromArgb(230, 232, 236);
            Color listBg = dark ? Color.FromArgb(14, 14, 20) : Color.FromArgb(250, 250, 252);
            Color textMain = dark ? Color.FromArgb(200, 200, 210) : Color.FromArgb(30, 30, 40);
            Color textDim = dark ? Color.FromArgb(100, 100, 120) : Color.FromArgb(120, 120, 130);
            Color accent = Color.FromArgb(0, 210, 255);
            Color btnBg = dark ? Color.FromArgb(26, 26, 36) : Color.FromArgb(220, 224, 230);
            Color border = dark ? Color.FromArgb(50, 50, 70) : Color.FromArgb(190, 190, 200);

            this.BackColor = bg;
            panelHeader.BackColor = bg;
            panelBottom.BackColor = panelBg;
            lvProcesses.BackColor = listBg;
            lvProcesses.ForeColor = textMain;
            txtSearch.BackColor = dark ? Color.FromArgb(30, 30, 42) : Color.White;
            txtSearch.ForeColor = textMain;
            lblTitle.ForeColor = accent;
            lblSearch.ForeColor = textDim;
            btnRefresh.BackColor = btnBg;
            btnRefresh.ForeColor = accent;
            btnRefresh.FlatAppearance.BorderColor = border;
            btnSelect.BackColor = Color.FromArgb(0, 180, 70);
            btnSelect.ForeColor = Color.White;
            btnCancel.BackColor = btnBg;
            btnCancel.ForeColor = textDim;
            btnCancel.FlatAppearance.BorderColor = border;
        }

        private void LoadProcesses()
        {
            lvProcesses.Items.Clear();
            allProcesses = Injector.GetRunningProcesses();
            FilterProcesses();
        }

        private void FilterProcesses()
        {
            lvProcesses.Items.Clear();
            string filter = txtSearch.Text.Trim().ToLower();

            foreach (var proc in allProcesses)
            {
                if (!string.IsNullOrEmpty(filter) &&
                    !proc.ProcessName.ToLower().Contains(filter) &&
                    !proc.Path.ToLower().Contains(filter) &&
                    !proc.Title.ToLower().Contains(filter))
                {
                    continue;
                }

                var item = new ListViewItem(proc.ProcessName);
                item.SubItems.Add(proc.ProcessId.ToString());
                item.SubItems.Add(proc.Title);
                item.SubItems.Add(proc.Path);
                item.Tag = proc;
                lvProcesses.Items.Add(item);
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            FilterProcesses();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void btnSelect_Click(object? sender, EventArgs e)
        {
            SelectCurrentProcess();
        }

        private void lvProcesses_DoubleClick(object? sender, EventArgs e)
        {
            SelectCurrentProcess();
        }

        private void SelectCurrentProcess()
        {
            if (lvProcesses.SelectedItems.Count > 0 && lvProcesses.SelectedItems[0].Tag is ProcessEntry entry)
            {
                SelectedProcess = entry;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a process from the list.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
