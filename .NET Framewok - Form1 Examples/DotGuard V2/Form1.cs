// DotGuard V2 Protected Windows Forms Application
// Implements comprehensive security protection using DotGuard Core

using DotGuard.Core;
using DotGuard.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace YourWorkspaceName
{
    /// Main form with DotGuard security protection
    public partial class Form1 : Form
    {
        // Tracks DotGuard initialization status
        private bool isDotGuardInitialized = false;

        public Form1()
        {
            // Initialize DotGuard security first
            InitializeDotGuard();
            InitializeComponent();
        }

        /// Initialize DotGuard security protection
        private void InitializeDotGuard()
        {
            try
            {
                var config = new DotGuardConfig
                {
                    // Discord webhook for security alerts
                    //DiscordWebhookUrl = "YOUR_DISCORD_WEBHOOK_URL",     // IMPORTANT ⚠️ Replace with your actual webhook URL otheriwse DotGuard v2 will not work.
                                                                          //  You can also comment DiscordWebhookUrl for the proper working of DotGuard v2.

                    EnableUserFeedback = true,
                    ViolationMessage = "🚨 Security Alert: Unauthorized activity detected!",

                    // Core protection modules
                    EnableAntiDebug = true,
                    EnableAntiTamper = true,
                    EnableAntiInjection = false,          // <<<--- Temporary set to false during development or permanent production use if causing issues
                    EnableAntiMemoryEdit = true,
                    EnableAntiVirtualization = true,
                    EnableAntiSandbox = true,
                    EnableAntiTimingAttack = false,     // <<<--- Temporary set to false during development or permanent production use if causing issues
                    EnableAntiDump = true,
                    EnableAntiDeobfuscation = true,
                    EnableAntiHooking = true,
                    EnableAntiHollowing = true,
                    EnableAntiEmulation = true,

                    // Performance settings
                    ScanIntervalMs = 3000,
                    MaxConcurrentChecks = 5,
                    EnableAdaptiveScanning = true,

                    // Logging settings
                    MinimumLogLevel = LogLevel.Info,
                    EnableConsoleLogging = true,
                    EnableFileLogging = true,
                    EnableEncryptedLogging = true,
                    MaxLogFileSizeMB = 10,
                    MaxLogFiles = 5,

                    // Advanced features
                    EnableSelfHealing = true,          // <-- This feature is in testing phase! It will not work completely.
                    EnableLocalHistory = true,
                    EnableAnalytics = true,

                    // --- Super Wild Advanced Protections ---
                    EnableAntiScreenshot = true,
                    EnableAntiClipboardHijack = true,
                    EnableAntiKeylogger = false,          // <<<--- Temporary set to false during development or permanent production use if causing issues
                    EnableAntiRAT = false,                 // <<<--- Temporary set to false during development or permanent production use if causing issues
                    EnableAntiProcessInjection = true,
                    EnableAntiMemoryDumpTools = false,          // <<<--- Temporary set to false during development or permanent production use if causing issues
                    EnableAntiDeepApiHooking = true,
                    EnableAntiDeepVM = true,
                    EnableAntiNetworkSniffer = true,
                    EnableAntiProxyVPN = true,
                    EnableAntiRemoteDesktop = true,
                    EnableAntiFileSystemMonitor = true,
                    EnableAntiRegistryMonitor = true,
                    EnableAntiCloudSandbox = true,
                    EnableAntiProcessDoppelganging = true,
                    EnableAntiTokenManipulation = true,
                    EnableAntiParentPidSpoofing = true,
                    EnableAntiEnvVarTampering = true,
                    EnableAntiFilelessMalware = true,
                    EnableAntiReflectiveDllInjection = true,
                };

                GuardEngine.Initialize(config);
                isDotGuardInitialized = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize DotGuard: {ex.Message}",
                    "Security Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Cleanup DotGuard on form closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isDotGuardInitialized)
            {
                try
                {
                    GuardEngine.StopAsync().Wait();
                }
                catch (Exception ex)
                {
                    // Log error if needed
                }
            }
            base.OnFormClosing(e);
        }
    }
}
