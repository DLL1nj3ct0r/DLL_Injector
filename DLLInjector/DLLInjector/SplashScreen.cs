namespace DLLInjector
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public void SetProgress(int percent, string status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(() => SetProgress(percent, status));
                return;
            }

            progressBar.Value = Math.Min(100, Math.Max(0, percent));
            lblPercent.Text = $"{percent}%";
            lblStatus.Text = status;
        }
    }
}
