using iParkingv5.Objects.Datas.Devices;
using Kztek.Tools;
using System.Reflection;
using v5MonitorApp.UserControls;

namespace v5MonitorApp
{
    public partial class Form1 : Form
    {
        #region Constructor
        ucDeviceMonitor<ucPCMonitor> ucPcMonitor;
        private List<Computer> computers = new List<Computer>();
        #endregion End Constructor

        #region Forms
        public Form1(List<Computer> computers)
        {
            InitializeComponent();
            this.computers = computers;
            this.Text = "IMonitor v" + Assembly.GetExecutingAssembly().GetName().Version!.ToString();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await StartMonitor();
        }
        #endregion End Forms

        #region Controls In Form

        #endregion End Controls In Form

        #region Private Function
        private async Task StartMonitor()
        {
            List<ucPCMonitor> ucs = new List<ucPCMonitor>();
            foreach (Computer computer in this.computers.OrderBy(e=>e.Name).OrderBy(e =>e.Name.Length).ToList())
            {
                ucPCMonitor uc = new ucPCMonitor(computer);
                ucs.Add(uc);
            }
            ucPcMonitor = new ucDeviceMonitor<ucPCMonitor>(ucs, 125, 1.75, 20, 20, 20);
            this.Controls.Add(ucPcMonitor);
            ucPcMonitor.PollingStart();
            ucPcMonitor.Dock = DockStyle.Fill;
        }

        #endregion End Private Function

        #region Public Function

        #endregion End Public Function

        private void timerClearLog_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerClearLog.Stop();
                DateTime before15Day = DateTime.Now.AddDays(-1 * 15);
                string path = Path.Combine(LogHelper.SaveLogFolder, $"logs/{before15Day.Year}/{before15Day.Month}/{before15Day.Day}");
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                this.timerClearLog.Start();
            }
            catch (Exception ex)
            {
                //LogHelper.Logger_SystemError(ex.Message, LogHelper.SaveLogFolder);
            }
        }
    }
}
