using System.Diagnostics;
using System.Net.Http;

namespace DLLInjector
{
    public static class Updater
    {
        private const string UpdatedFlagFile = "dll1nj3ct0r_updated";

        public static bool WasJustUpdated()
        {
            string flag = Path.Combine(Path.GetTempPath(), UpdatedFlagFile);
            return File.Exists(flag);
        }

        public static void ClearUpdateFlag()
        {
            string flag = Path.Combine(Path.GetTempPath(), UpdatedFlagFile);
            try { File.Delete(flag); } catch { }
        }

        public static string GetLastChangelog()
        {
            string file = Path.Combine(Path.GetTempPath(), "dll1nj3ct0r_changelog.txt");
            if (File.Exists(file))
            {
                string text = File.ReadAllText(file);
                try { File.Delete(file); } catch { }
                return text;
            }
            return "";
        }

        public static async Task<bool> DownloadAndUpdateAsync(string downloadUrl, string changelog)
        {
            try
            {
                string exePath = Environment.ProcessPath ?? "";
                if (string.IsNullOrEmpty(exePath)) return false;

                string tempDir = Path.GetTempPath();
                string newExe = Path.Combine(tempDir, "DLL1nj3ct0r_new.exe");
                string oldExe = exePath + ".old";

                using var http = new HttpClient();
                http.Timeout = TimeSpan.FromMinutes(5);
                var bytes = await http.GetByteArrayAsync(downloadUrl);
                await File.WriteAllBytesAsync(newExe, bytes);

                if (File.Exists(oldExe))
                    try { File.Delete(oldExe); } catch { }

                File.Move(exePath, oldExe);
                File.Move(newExe, exePath);

                File.WriteAllText(Path.Combine(tempDir, UpdatedFlagFile), "");

                string changelogFile = Path.Combine(Path.GetTempPath(), "dll1nj3ct0r_changelog.txt");
                File.WriteAllText(changelogFile, changelog);

                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });

                Environment.Exit(0);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
