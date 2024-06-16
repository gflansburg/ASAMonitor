using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;
using IniParser;
using IniParser.Model;

namespace ASAMonitor
{
    public partial class ASAMonitorForm : Form
    {
        static public ASAMonitorForm Instance { get; private set; }

        public ASAMonitorForm()
        {
            InitializeComponent();
            Utilities.Mods = Utilities.GetMods();
            Instance = this;
        }

        public bool ServerRunning
        {
            get
            {
                bool running = false;
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        running = (lblStatus.Text == "Online");
                    });
                }
                catch (Exception)
                {
                }
                return running;
            }
        }

        private static DateTime? startTime = null;
        private void timer1_Tick(object sender, EventArgs e)
        {
            List<NativeMethods.WindowTitle> windows = NativeMethods.FindWindowsStartsWithText("Server Console (ArkAscendedServer)", "FConsoleWindow").ToList();
            if (windows == null || windows.Count > 0)
            {
                lblStatus.Text = "Online";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                startTime = null;
                lblRetry.Visible = false;
                lblRemaining.Visible = false;
            }
            else
            {
                lblStatus.Text = "Offline";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblRetry.Visible = true;
                lblRemaining.Visible = true;
                if (Paused)
                {
                    startTime = DateTime.Now;
                }
                else if (startTime == null || (DateTime.Now - startTime.Value).TotalSeconds >= 150)
                {
                    if (!Paused)
                    {
                        startTime = DateTime.Now;
                        StartServer();
                    }
                }
                TimeSpan timeRemaining = new TimeSpan(0, 5, 0) - (DateTime.Now - startTime.Value);
                lblRemaining.Text = timeRemaining.ToMinimalReadableString();
            }
            if ((DateTime.Now - Utilities.ModLoadTime).TotalHours >= 24)
            {
                Utilities.Mods = Utilities.GetMods();
            }
        }

        public static bool KillServer()
        {
            List<NativeMethods.WindowTitle> windows = NativeMethods.FindWindowsStartsWithText("Server Console (ArkAscendedServer)", "FConsoleWindow").ToList();
            if (windows == null || windows.Count > 0)
            {
                Process process = Process.GetProcessById(windows[0].ProcessId);
                process.Kill();
                return true;
            }
            return false;
        }

        public static void RestartServer()
        {
            if (KillServer() && Paused)
            {
                startTime = DateTime.Now;
                StartServer();
            }
        }

        private WebServer webServer;
        protected CancellationTokenSource serverSource;

        private void StartWebServer()
        {
            try
            {
                serverSource = new CancellationTokenSource();
                webServer = new WebServer(ConfigurationSettings.ServerPort);
                webServer.RegisterModule(new WebApiModule());
                webServer.Module<WebApiModule>().RegisterController<WebController>();
                webServer.RegisterModule(new ResourceFilesModule(Assembly.GetExecutingAssembly(), Utilities.GetEmbededResourcePath));
#pragma warning disable 4014
                webServer.RunAsync(serverSource.Token);
#pragma warning restore 4014

            }
            catch (Exception)
            {
                btnPause.Visible = false;
                lblRetry.Visible = false;
                lblRemaining.Visible = false;
                timer1.Enabled = false;
                lblStatus.Text = string.Format("Port {0} already in use!", ConfigurationSettings.ServerPort);
                lblStatus.ForeColor = Color.Red;
                ShowWindow();
                return;
            }
        }

        private static void StartServer()
        {
            ASAConfig config = ConfigurationSettings.ASAConfig;
            string filename = string.Format("{0}\\ASA Start.bat", Utilities.GetExecutingDirectory());
            string mods = config.Mods != null && config.Mods.Count > 0 ? string.Format("-mods={0}", string.Join(",", config.Mods)) : string.Empty;
            string data = (string.Format(ASAMonitor.Properties.Resources.BatchCmd, ConfigurationSettings.SteamCmdPath, ConfigurationSettings.ASAServerPath, config.NoBattleEye ? "-NoBattlEye" : string.Empty, config.WinLiveMaxPlayers, config.ForceAllowCaveFlyers ? "-ForceAllowCaveFlyers" : string.Empty, mods, config.Map)).Replace("  ", " ");
            System.IO.File.WriteAllText(filename, data);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = string.Format("/c \"{0}\"", filename);
            startInfo.WorkingDirectory = Path.GetDirectoryName(filename);
            Process.Start(startInfo);
        }

        private void ShowWindow()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
            BringToFront();
            Focus();
            Activate();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == NativeMethods.WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == NativeMethods.SC_MINIMIZE)
                {
                    // Caption bar minimize button
                    m.Result = IntPtr.Zero;
                    Hide();
                    return;
                }
                else if (m.WParam.ToInt32() == NativeMethods.SC_CLOSE)
                {
                    // Caption bar close button
                    m.Result = IntPtr.Zero;
                    Hide();
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool Paused { get; private set; } = false;

        private void btnPause_Click(object sender, EventArgs e)
        {
            PauseServer(!Paused);
        }

        public void PauseServer(bool pause)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    ASAConfig config = ConfigurationSettings.ASAConfig;
                    if (pause)
                    {
                        config.Paused = Paused = true;
                        btnPause.Text = "Resume";
                    }
                    else
                    {
                        config.Paused = Paused = false;
                        btnPause.Text = "Pause";
                        startTime = null;
                    }
                    ConfigurationSettings.SaveConfig(config);
                });
            }
            catch (Exception)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Paused = ConfigurationSettings.ASAConfig.Paused;
            StartWebServer();
        }
    }
}
