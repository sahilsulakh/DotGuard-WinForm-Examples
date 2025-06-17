using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotGuard.Core;                            // <<<--- MUST USE FOR DOTGUARD TO WORK

namespace YourWorkspaceName                    // <<<--- REPLACE WITH YOUR ACTUAL NAMESPACE
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new DotGuardConfig
            {
                // 🔔 Discord Alert Settings
                DiscordWebhookUrl = "your-webhook-url-here",
                AdditionalWebhooks = new[] { "backup-webhook-url" }, // Optional

                // 🛡️ Protection Features
                EnableAntiDebug = true,         // Block debuggers
                EnableAntiTamper = true,        // Prevent file tampering
                EnableAdvancedTamper = true,    // Extra tamper protection
                EnableAntiInjection = true,     // Block code injection
                EnableAntiMemoryEdit = true,    // Prevent memory editing
                EnableAntiVirtualization = true, // Detect VMs (optional)
                EnableAntiSandbox = true,       // Detect analysis environments
                EnableAntiHooking = true,       // Prevent API hooking
                EnableAntiHollowing = true,     // Block process tampering
                EnableAntiEmulation = true,     // Prevent automated analysis

                // 📝 Logging & History
                EnableLocalHistory = false,      // Keep local logs
            
                // ⚙️ Performance Settings
                ScanIntervalMs = 1000,         // Check every 1 seconds

                // Assembly Whitelist Settings
               //AssemblyWhitelist = new[] { /* your SHA-256 hashes here */ },

                // 🎨 User Experience
                //LicenseKey = "your-license-key", // Optional
                Language = "en",               // Change for other languages
                EnableUserFeedback = true,     // Show messages to user
                ViolationMessage = "Security Alert: Unauthorized activity detected!" // Custom message
                };
               // 🚀 Start Protection
               GuardEngine.Initialize(config);
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new Form1());
        }
    }
}
