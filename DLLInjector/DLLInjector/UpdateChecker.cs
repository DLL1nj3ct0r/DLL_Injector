using System.Net.Http;
using System.Text.Json;

namespace DLLInjector
{
    public static class UpdateChecker
    {
        public const string CurrentVersion = "1.0.0";

        public static async Task<UpdateInfo?> CheckForUpdateAsync()
        {
            string url = Properties.Settings.Default.UpdateUrl;
            if (string.IsNullOrWhiteSpace(url))
                return null;

            try
            {
                using var http = new HttpClient();
                http.Timeout = TimeSpan.FromSeconds(8);
                string json = await http.GetStringAsync(url);

                var info = JsonSerializer.Deserialize<UpdateInfo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (info == null || string.IsNullOrEmpty(info.Version))
                    return null;

                if (IsNewer(info.Version, CurrentVersion))
                    return info;

                return null;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsNewer(string remoteVersion, string localVersion)
        {
            try
            {
                var remote = Version.Parse(remoteVersion);
                var local = Version.Parse(localVersion);
                return remote > local;
            }
            catch
            {
                return false;
            }
        }
    }

    public class UpdateInfo
    {
        public string Version { get; set; } = "";
        public string DownloadUrl { get; set; } = "";
        public string Changelog { get; set; } = "";
    }
}
