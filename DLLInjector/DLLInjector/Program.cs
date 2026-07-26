namespace DLLInjector
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (Updater.WasJustUpdated())
            {
                string changelog = Updater.GetLastChangelog();
                Updater.ClearUpdateFlag();

                var postUpdateForm = new MainForm();
                Application.Run(postUpdateForm);

                string msg = "DLL1nj3ct0r has been updated successfully!\n\n" +
                             $"Updated to version {UpdateChecker.CurrentVersion}.\n";

                if (!string.IsNullOrEmpty(changelog))
                    msg += $"\nWhat's new:\n{changelog}";

                MessageBox.Show(msg, "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var splash = new SplashScreen();
            splash.Show();

            UpdateInfo? updateInfo = null;
            RunSplashLoading(splash, info => updateInfo = info);

            bool firstRun = Properties.Settings.Default.FirstRun;
            if (firstRun)
            {
                CreateDesktopShortcut();

                splash.Close();
                splash.Dispose();

                var welcomeResult = MessageBox.Show(
                    "Welcome to DLL1nj3ct0r!\n\n" +
                    "This tool is intended for legitimate software development, " +
                    "testing, and debugging purposes only.\n\n" +
                    "Please do NOT use this tool for:\n" +
                    "  - Exploiting software vulnerabilities\n" +
                    "  - Cheating in games or competitive applications\n" +
                    "  - Any malicious or illegal activities\n\n" +
                    "By clicking OK, you acknowledge that you will use this tool " +
                    "responsibly and only for lawful purposes.",
                    "Welcome - DLL1nj3ct0r",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (welcomeResult != DialogResult.OK)
                    return;

                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                splash.Close();
                splash.Dispose();
            }

            var mainForm = new MainForm();

            if (updateInfo != null)
            {
                mainForm.ShowUpdateButton();
                mainForm.Show();
                var result = MessageBox.Show(
                    $"A new version is available!\n\n" +
                    $"Current version: {UpdateChecker.CurrentVersion}\n" +
                    $"Latest version: {updateInfo.Version}\n\n" +
                    $"Changes:\n{updateInfo.Changelog}\n\n" +
                    "Would you like to update now?",
                    "Update Available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    bool dlResult = Updater.DownloadAndUpdateAsync(updateInfo.DownloadUrl, updateInfo.Changelog).GetAwaiter().GetResult();
                    if (!dlResult)
                    {
                        MessageBox.Show("Update failed. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
            }

            Application.Run(mainForm);
        }

        private static void RunSplashLoading(SplashScreen splash, Action<UpdateInfo?> onCheckComplete)
        {
            UpdateInfo? updateResult = null;
            bool updateChecked = false;

            var steps = new (int percent, string status, int delay)[]
            {
                (5,   "Loading resources...",          80),
                (15,  "Loading settings...",           60),
                (25,  "Checking for updates...",       100),
                (40,  "Initializing modules...",       70),
                (55,  "Loading process list...",       80),
                (68,  "Preparing injection engine...", 70),
                (78,  "Loading UI components...",      60),
                (88,  "Configuring theme...",          60),
                (95,  "Finalizing...",                 80),
                (100, "Ready!",                        200),
            };

            var updateTask = Task.Run(async () =>
            {
                try { return await UpdateChecker.CheckForUpdateAsync(); }
                catch { return null; }
            });

            foreach (var (percent, status, delay) in steps)
            {
                splash.SetProgress(percent, status);
                Thread.Sleep(delay);
                Application.DoEvents();

                if (!updateChecked && percent >= 30 && updateTask.IsCompleted)
                {
                    updateResult = updateTask.Result;
                    updateChecked = true;
                }
            }

            if (!updateChecked)
            {
                try { updateResult = updateTask.GetAwaiter().GetResult(); }
                catch { }
            }

            onCheckComplete(updateResult);
        }

        private static void CreateDesktopShortcut()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string exePath = Environment.ProcessPath ?? "";

                if (string.IsNullOrEmpty(exePath)) return;

                string lnkPath = Path.Combine(desktopPath, "DLL1nj3ct0r.lnk");
                string workDir = Path.GetDirectoryName(exePath) ?? "";

                string scriptPath = Path.Combine(Path.GetTempPath(), "create_shortcut.ps1");
                File.WriteAllText(scriptPath,
                    $"$ws = New-Object -ComObject WScript.Shell\n" +
                    $"$sc = $ws.CreateShortcut('{lnkPath.Replace("'", "''")}')\n" +
                    $"$sc.TargetPath = '{exePath.Replace("'", "''")}'\n" +
                    $"$sc.WorkingDirectory = '{workDir.Replace("'", "''")}'\n" +
                    $"$sc.Description = 'DLL1nj3ct0r'\n" +
                    $"$sc.Save()\n");

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -NonInteractive -ExecutionPolicy Bypass -File \"{scriptPath}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                };
                var proc = System.Diagnostics.Process.Start(psi);
                proc?.WaitForExit(5000);

                try { File.Delete(scriptPath); } catch { }
            }
            catch
            {
            }
        }
    }
}
