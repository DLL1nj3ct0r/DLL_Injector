# DLL1nj3ct0r

A modern Windows DLL injection tool with a clean UI, theme support, and auto-updates.

## Features

- **DLL Injection** — Inject custom DLL files into running processes using `CreateRemoteThread` + `LoadLibraryA`
- **Process Selector** — Browse and search all running processes by name, PID, window title, or path
- **Dark / Light Theme** — Toggle between dark and light mode from Settings
- **Custom Background** — Import any PNG/JPG image as a background
- **Resizable Window** — Drag to resize, text scales proportionally
- **Splash Loading Screen** — Animated loading screen with progress bar on startup
- **Auto-Update** — Checks a remote `version.json` for updates during splash screen
- **Desktop Shortcut** — Automatically created on first launch

## How to Build

Requires [.NET 10 SDK](https://dotnet.microsoft.com/download) installed.

```bash
dotnet build DLLInjector\DLLInjector.sln
```

Or publish a standalone `.exe`:

```bash
dotnet publish DLLInjector\DLLInjector.sln -c Release
```

The executable will be in:
```
DLLInjector\DLLInjector\bin\Release\net10.0-windows\win-x64\publish\
```

## How to Use

1. Run `DLL1nj3ct0r.exe`
2. Click **Browse** to select a `.dll` file
3. Click **Select Application** (top-right) to pick a target process
4. Click **INJECT**
5. Run as Administrator if injecting into elevated processes

## Settings

Open Settings (bottom-right) to configure:

| Setting | Description |
|---------|-------------|
| Theme | Switch between Dark and Light mode |
| Background Image | Import a PNG/JPG as the app background |
| Clear BG | Remove the background image |
| Update URL | Paste a link to your `version.json` to enable auto-updates |

## Auto-Updates

The app checks for updates during the splash screen if an Update URL is configured in Settings.

Host a `version.json` file anywhere (Google Drive, Dropbox, any web host) with this format:

```json
{
  "version": "1.1.0",
  "downloadUrl": "https://example.com/DLL1nj3ct0r.exe",
  "changelog": "- Added feature X\n- Fixed bug Y\n- Improved Z"
}
```

When an update is available:
- A dialog shows the new version and changelog
- An **Update Available** button appears in the bottom-left corner
- Clicking it downloads the new version, replaces the old exe, and relaunches
- After relaunch, a message shows the update is complete with the changelog

Leave the URL empty to disable update checks.

## Project Structure

```
DLLInjector/
├── DLLInjector.sln
└── DLLInjector/
    ├── DLLInjector.csproj
    ├── Program.cs               # Entry point, splash, welcome, shortcut
    ├── MainForm.cs              # Main UI logic, theme, resize
    ├── MainForm.Designer.cs     # Main form layout
    ├── ProcessListForm.cs       # Process selector logic
    ├── ProcessListForm.Designer.cs
    ├── SettingsForm.cs          # Settings UI logic
    ├── SettingsForm.Designer.cs
    ├── SplashScreen.cs          # Splash screen logic
    ├── SplashScreen.Designer.cs
    ├── Injector.cs              # Core injection via Windows API
    ├── UpdateChecker.cs         # Remote version check
    ├── Updater.cs               # Self-replace update mechanism
    └── Properties/
        ├── Settings.settings
        └── Settings.Designer.cs
```

## Tech Stack

- C# / .NET 10 / Windows Forms
- P/Invoke (`kernel32.dll`) for DLL injection
- WScript.Shell COM for desktop shortcuts
- `HttpClient` for update checks and downloads
- `System.Text.Json` for parsing version info
