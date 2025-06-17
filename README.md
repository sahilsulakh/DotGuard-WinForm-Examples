# 🛡️ DotGuard

Welcome to DotGuard! 🎉 Your ultimate security companion for .NET Framework applications. Let's make your app super-secure against tampering, hacking, and unauthorized analysis! 

DotGuard is a comprehensive, lightweight security solution designed specifically for .NET Framework applications. It provides real-time protection against reverse engineering, debugging, tampering, and other security threats while offering powerful monitoring capabilities through Discord integration.

## ✨ What Makes DotGuard Special

### 🔒 Powerful Protection Features
- 🚫 **Anti-Debug Shield** - Detects and blocks unauthorized debuggers using both managed and native techniques
- 💾 **Memory Protection** - Prevents memory editing and manipulation of your application's runtime data
- 🛑 **Injection Guard** - Actively monitors and blocks malicious code injection attempts
- 🔐 **Tamper Protection** - Validates assembly integrity using SHA-256 hashing to ensure your files remain unmodified
- 🖥️ **VM Detection** - Identifies when your application is running in virtual machine environments
- ⚡ **Sandbox Detection** - Detects analysis environments by monitoring processes and environment variables
- 🎯 **Process Protection** - Guards against advanced attacks like process hollowing and API hooking
- 🔍 **Anti-Emulation** - Prevents automated analysis by detecting emulation environments

### 📊 Smart Monitoring
- 🤖 **Discord Alerts** - Real-time webhook notifications with detailed violation reports sent directly to your Discord server
- 📸 **Screenshots** - Automatic screen capture when violations occur, providing visual evidence of tampering attempts
- 🌍 **IP Tracking** - Geolocation tracking to identify the origin of security violations
- 💻 **System Info** - Comprehensive hardware fingerprinting and environment analysis for threat intelligence
- 📝 **Local Logs** - Encrypted local violation history for forensic analysis and auditing (optional)

### 🎯 Developer Friendly
- ⚡ **Super Fast and Lightweight** - Minimal performance impact with optimized background scanning and intelligent resource usage
- 🛠️ **Easy to Integrate** - Simple NuGet package installation with a clean API for configuration
- 🔧 **Highly Configurable** - Fine-grained control over which protection features to enable and how they behave
- 🎮 **Debug Mode Aware** - Automatically disables protections during development to avoid interfering with debugging
- 🧩 **Modular Architecture** - Use only the protection features you need for your specific application requirements

## 🔧 Technical Architecture

DotGuard employs a multi-layered security approach to protect your .NET applications:

- **Core Engine** - The central GuardEngine coordinates all protection mechanisms and runs periodic security checks
- **Protection Modules** - Individual specialized modules for each type of protection (anti-debug, anti-tamper, etc.)
- **Monitoring System** - Real-time violation detection with configurable reporting options
- **Configuration API** - Flexible DotGuardConfig class for customizing protection behavior

The protection system runs in a separate background thread to minimize performance impact on your application while continuously monitoring for security threats. When a violation is detected, DotGuard can take configurable actions including sending alerts, logging details, and terminating the application if necessary.

## 🚀 Complete Setup Guide

### Step 1: Install DotGuard 📦
```powershell
# Using Package Manager Console in Visual Studio
Install-Package DotGuard

# OR using .NET CLI
dotnet add package DotGuard
```

### Step 2: Set Up Discord Notifications 🔔
1. Create a Discord server (if you don't have one)
2. Create a channel for security alerts
3. Create a webhook:
   - Click ⚙️ channel settings
   - Select 'Integrations'
   - Click 'Create Webhook'
   - Name it (e.g., "DotGuard Alerts")
   - Copy the webhook URL
   
### Step 3: Configure DotGuard 🛠️
```csharp
using DotGuard.Core;

class Program
{
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
            EnableLocalHistory = true,      // Keep local logs
            
            // ⚙️ Performance Settings
            ScanIntervalMs = 1000,         // Check every 5 seconds

            // Assembly Whitelist Settings
            //AssemblyWhitelist = new[] { /* your SHA-256 hashes here */ },

            // 🎨 User Experience
            LicenseKey = "your-license-key",
            Language = "en",               // Change for other languages
            EnableUserFeedback = true,     // Show messages to user
            ViolationMessage = "Security Alert: Unauthorized activity detected!" // Custom message
        };

        // 🚀 Start Protection
        GuardEngine.Initialize(config);

        // Your app code continues here...
    }
}
```

### Step 4: Build & Test 🔨
1. Build your app in Release mode
2. Test all features:
   - Try to attach a debugger (should be blocked)
   - Check if Discord notifications work
   - Verify protection features

## 🎮 Using DotGuard

### Discord Notifications 📱
When someone tries to tamper with your app, you'll get:
- 🚨 Alert with violation type
- ⏰ Time of the attempt
- 🖥️ Machine details
- 📸 Screenshot (if enabled)
- 🌍 IP location
- 🔑 Hardware ID

### Local Logs 📝
Find encrypted logs in your app directory:
- Violation history
- Detailed reports
- System information

### Language Support 🌎
Change `Language` to:
- "en" (English)
- "fr" (French)
- "es" (Spanish)
- "de" (German)
- Many more!

## 🏷️ Assembly Whitelist (Advanced)

Want to make sure only your trusted EXE/DLLs are loaded? Use the Assembly Whitelist!

1. Get the SHA-256 hash of your EXE/DLL:
   - PowerShell:
     ```powershell
     Get-FileHash -Algorithm SHA256 "C:\Path\To\YourAssembly.dll"
     ```
   - Or Command Prompt:
     ```shell
     certutil -hashfile "C:\Path\To\YourAssembly.dll" SHA256
     ```
2. Add the hashes to your config:
   ```csharp
   AssemblyWhitelist = new[] { "A1B2C3D4E5F6..." },
   ```

## 🖥️ .NET Framework Compatibility
- DotGuard is designed for .NET Framework 4.6.1 and above.
- Works with WinForms, WPF, console apps, and Windows services.

## 🧑‍💻 Full WinForms Example
Want to see a full integration? Check out the ready-to-use WinForms example project:
👉 [DotGuard-WinForm-Examples (GitHub)](https://github.com/sahilsulakh/DotGuard-WinForm-Examples.git)

## 🔄 Updating & Uninstalling
- To update: run `Update-Package DotGuard` in NuGet Package Manager Console.
- To uninstall: run `Uninstall-Package DotGuard`.

## 🤝 Contributing & Feedback
- Found a bug or have a feature request? Open an issue or pull request on GitHub!
- We love feedback and contributions from the community.

## 💡 Pro Tips

### For Development 🛠️
- DotGuard knows when you're debugging
- No interference with Visual Studio
- Test in Release mode before publishing

### For Production 🚀
1. Enable all needed protections
2. Set up Discord webhooks
3. Test thoroughly
4. Deploy with confidence!

## ❓ FAQ

### 🤔 Will it slow down my app?
> DotGuard is designed to be lightweight with minimal performance impact. The protection system runs on a separate background thread with configurable scan intervals. The default interval is 5 seconds with randomized timing to prevent detection, and each scan typically takes only milliseconds to complete.

### 📱 Can I use it in any .NET Framework app?
> Yes! DotGuard works with all .NET Framework 4.6.1+ applications including WinForms, WPF, console applications, Windows services, and ASP.NET. It's designed to integrate seamlessly with any .NET Framework project structure.

### 🎮 What about game protection?
> DotGuard is excellent for game protection! It can detect and prevent common game hacking techniques like memory editing, DLL injection, and debugger attachment. The anti-cheat capabilities help maintain fair gameplay by blocking tools commonly used to manipulate game mechanics.

### 🔧 Can I customize the protection?
> Absolutely! Every protection feature can be individually enabled or disabled through the DotGuardConfig class. You can customize violation messages, configure Discord webhooks, set scan intervals, and much more. The API is designed to be flexible while remaining simple to use.

### 🔒 How does the anti-tamper protection work?
> The anti-tamper system uses SHA-256 hashing to verify the integrity of your application's assemblies. You can provide a whitelist of valid assembly hashes, and DotGuard will continuously verify that the running code matches these authorized versions, terminating the application if unauthorized modifications are detected.

### 💻 Does it work with obfuscated code?
> Yes! DotGuard is fully compatible with code obfuscation tools. In fact, using DotGuard alongside code obfuscation provides multiple layers of protection, making your application significantly more secure against reverse engineering attempts.

## 🔐 Security Best Practices

To get the most out of DotGuard, follow these security best practices:

1. **Layer Your Security** - Use DotGuard alongside code obfuscation and strong encryption for sensitive data
2. **Enable All Relevant Protections** - Use as many protection features as appropriate for your application
3. **Configure Discord Webhooks** - Set up real-time monitoring to be alerted of security violations immediately
4. **Use Assembly Whitelisting** - Implement SHA-256 hash verification to ensure only authorized code runs
5. **Regular Updates** - Keep DotGuard updated to benefit from the latest security enhancements
6. **Test Thoroughly** - Verify all protection features are working correctly in your production environment
7. **Custom Violation Messages** - Use clear, non-technical messages for end-users when violations occur

## 🆘 Need Help?

### Got Issues? We're Here! 
- 📧 **Contact Support** - Reach out to our dedicated support team for assistance with implementation or troubleshooting
- 📚 **Documentation** - Comprehensive guides and API documentation available in the wiki
- 🐛 **Bug Reports** - Submit detailed bug reports on GitHub with steps to reproduce
- 💭 **Community Discussions** - Join our community forum to discuss best practices and get help from other developers
- 🔄 **Version Updates** - Subscribe to release notifications to stay informed about security updates

## 🚀 Advanced Usage Scenarios

DotGuard can be adapted for various specialized security needs:

### Enterprise Applications
```csharp
var config = new DotGuardConfig
{
    // Core protections
    EnableAntiDebug = true,
    EnableAntiTamper = true,
    EnableAntiInjection = true,
    
    // Enterprise features
    EnableCloudConfig = true,  // For centralized security management
    AdditionalWebhooks = new[] { "webhook-for-security-team", "webhook-for-it-admins" },
    EnableLocalHistory = true,  // For compliance and auditing
    
    // Custom handling
    ViolationMessage = "Please contact IT security at ext. 555 for assistance."
};
```

### Game Protection
```csharp
var config = new DotGuardConfig
{
    // Anti-cheat focused
    EnableAntiMemoryEdit = true,  // Block memory editors/trainers
    EnableAntiInjection = true,   // Prevent cheat injection
    EnableAntiHooking = true,     // Stop API hooking cheats
    
    // Performance optimized
    ScanIntervalMs = 2000,  // More frequent checks for games
    
    // User experience
    ViolationMessage = "Cheating detected. This incident will be reported."
};
```

### Kiosk/POS Applications
```csharp
var config = new DotGuardConfig
{
    // Physical security focus
    EnableAntiTamper = true,
    EnableAdvancedTamper = true,
    EnableAntiSandbox = false,  // Not needed for kiosk apps
    
    // Monitoring
    DiscordWebhookUrl = "your-webhook",
    EnableUserFeedback = false  // Silent protection for kiosks
};
```

## 📄 License

DotGuard is licensed under the MIT License, allowing you to use it in your projects with confidence!

```
MIT License

Copyright (c) 2025 Agniveer Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

For commercial support and additional features, contact us about our premium support plans.

---

Crafted with ❤️ by Agniveer Corporation
