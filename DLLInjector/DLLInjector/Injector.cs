using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DLLInjector
{
    public static class Injector
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

        const uint PROCESS_CREATE_THREAD = 0x0002;
        const uint PROCESS_QUERY_INFORMATION = 0x0400;
        const uint PROCESS_VM_OPERATION = 0x0008;
        const uint PROCESS_VM_WRITE = 0x0020;
        const uint PROCESS_VM_READ = 0x0010;
        const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        const uint MEM_COMMIT = 0x1000;
        const uint MEM_RESERVE = 0x2000;
        const uint MEM_RELEASE = 0x8000;

        const uint PAGE_READWRITE = 0x04;
        const uint PAGE_EXECUTE_READWRITE = 0x40;

        const uint INFINITE = 0xFFFFFFFF;

        public static bool Inject(int processId, string dllPath, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!File.Exists(dllPath))
            {
                errorMessage = "DLL file not found.";
                return false;
            }

            string fullPath = Path.GetFullPath(dllPath);
            byte[] dllPathBytes = System.Text.Encoding.ASCII.GetBytes(fullPath + '\0');

            IntPtr hProcess = OpenProcess(
                PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ,
                false,
                processId);

            if (hProcess == IntPtr.Zero)
            {
                errorMessage = $"Failed to open process (ID: {processId}). Error: {Marshal.GetLastWin32Error()}. Try running as administrator.";
                return false;
            }

            try
            {
                IntPtr allocAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)dllPathBytes.Length, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
                if (allocAddress == IntPtr.Zero)
                {
                    errorMessage = $"Failed to allocate memory in target process. Error: {Marshal.GetLastWin32Error()}";
                    return false;
                }

                if (!WriteProcessMemory(hProcess, allocAddress, dllPathBytes, (uint)dllPathBytes.Length, out int bytesWritten))
                {
                    VirtualFreeEx(hProcess, allocAddress, 0, MEM_RELEASE);
                    errorMessage = $"Failed to write DLL path to target process memory. Error: {Marshal.GetLastWin32Error()}";
                    return false;
                }

                IntPtr kernel32Handle = GetModuleHandle("kernel32.dll");
                if (kernel32Handle == IntPtr.Zero)
                {
                    VirtualFreeEx(hProcess, allocAddress, 0, MEM_RELEASE);
                    errorMessage = "Failed to get handle to kernel32.dll.";
                    return false;
                }

                IntPtr loadLibraryAddr = GetProcAddress(kernel32Handle, "LoadLibraryA");
                if (loadLibraryAddr == IntPtr.Zero)
                {
                    VirtualFreeEx(hProcess, allocAddress, 0, MEM_RELEASE);
                    errorMessage = "Failed to get address of LoadLibraryA.";
                    return false;
                }

                IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, allocAddress, 0, out _);
                if (hThread == IntPtr.Zero)
                {
                    VirtualFreeEx(hProcess, allocAddress, 0, MEM_RELEASE);
                    errorMessage = $"Failed to create remote thread. Error: {Marshal.GetLastWin32Error()}. The target process may have security protections.";
                    return false;
                }

                WaitForSingleObject(hThread, INFINITE);

                VirtualFreeEx(hProcess, allocAddress, 0, MEM_RELEASE);
                CloseHandle(hThread);

                return true;
            }
            finally
            {
                CloseHandle(hProcess);
            }
        }

        public static List<ProcessEntry> GetRunningProcesses()
        {
            var processes = new List<ProcessEntry>();
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    if (!string.IsNullOrEmpty(process.MainWindowTitle) || process.Id != 0)
                    {
                        processes.Add(new ProcessEntry
                        {
                            ProcessId = process.Id,
                            ProcessName = process.ProcessName,
                            Title = process.MainWindowTitle,
                            Path = GetProcessPath(process.Id)
                        });
                    }
                }
                catch
                {
                    processes.Add(new ProcessEntry
                    {
                        ProcessId = process.Id,
                        ProcessName = process.ProcessName,
                        Title = "",
                        Path = ""
                    });
                }
            }
            return processes.OrderBy(p => p.ProcessName).ToList();
        }

        private static string GetProcessPath(int processId)
        {
            try
            {
                using var process = Process.GetProcessById(processId);
                return process.MainModule?.FileName ?? "";
            }
            catch
            {
                return "";
            }
        }
    }

    public class ProcessEntry
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; } = "";
        public string Title { get; set; } = "";
        public string Path { get; set; } = "";

        public string DisplayName
        {
            get
            {
                string display = $"{ProcessName} (PID: {ProcessId})";
                if (!string.IsNullOrEmpty(Path))
                    display += $" - {Path}";
                return display;
            }
        }
    }
}
