using IPaking.Ultility;
using iParking.ConfigurationManager.UserControls;
using iParkingv5.Lpr.Objects;
using iParkingv5.Objects.Configs;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParking.ConfigurationManager.Forms.SystemForms
{
    public partial class frmConnectionConfig : Form
    {
        #region Properties
        ucEinvoiceConfig ucEInvoice;
        ucServerConfig ucServer;
        ucAppOptions ucAppOptions;
        ucLprConnection ucLprConnection;
        #endregion End Properties

        #region Forms
        public frmConnectionConfig()
        {
            InitializeComponent();
            this.Load += FrmConnectionConfig_Load;
        }

        private void FrmConnectionConfig_Load(object? sender, EventArgs e)
        {
            AddTabEInvoiceConfig();
            AddTabServerConfig();
            AddTabOptionConfig();
            AddTabLprConfig();
            this.Size = new Size(Properties.Settings.Default.prefer_width, Properties.Settings.Default.prefer_height);
            this.SizeChanged += FrmConnectionConfig_SizeChanged;
        }

        private void FrmConnectionConfig_SizeChanged(object? sender, EventArgs e)
        {
            Properties.Settings.Default.prefer_width = this.Size.Width;
            Properties.Settings.Default.prefer_height = this.Size.Height;
            Properties.Settings.Default.Save();
        }
        #endregion End Forms

        #region Controls In Form
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEInvoiceConfig();
            SaveServerConfig();
            SaveLprConfig();
            SaveOptionConfig();
            MessageBox.Show("Lưu cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion End Controls In Form

        #region Private Function
        private void AddTabEInvoiceConfig()
        {
            TabPage tabEinvoice = new TabPage();
            tabEinvoice.Text = "Hóa đơn điện tử";
            tabControl1.TabPages.Add(tabEinvoice);

            EInvoiceConfig? einvoiceCOnfig = NewtonSoftHelper<EInvoiceConfig>.DeserializeObjectFromPath(PathManagement.einvoiceConfigPath) ?? new EInvoiceConfig();

            ucEInvoice = new ucEinvoiceConfig(einvoiceCOnfig);
            tabEinvoice.Controls.Add(ucEInvoice);
            ucEInvoice.Dock = DockStyle.Fill;
            tabEinvoice.AutoScroll = true;
            ucEInvoice.Dock = DockStyle.None;
        }
        private void AddTabOptionConfig()
        {
            TabPage tabOption = new TabPage();
            tabOption.Text = "Tùy chọn";
            tabControl1.TabPages.Add(tabOption);

            AppOption? appOption = NewtonSoftHelper<AppOption>.DeserializeObjectFromPath(PathManagement.appOptionConfigPath) ?? new AppOption();

            ucAppOptions = new ucAppOptions(appOption);
            tabOption.Controls.Add(ucAppOptions);
            ucAppOptions.Dock = DockStyle.Fill;
            tabOption.AutoScroll = true;
            ucAppOptions.Dock = DockStyle.None;
        }
        private void AddTabServerConfig()
        {
            TabPage tabServerConfig = new TabPage();
            tabServerConfig.Text = "Server";
            tabControl1.TabPages.Add(tabServerConfig);

            ServerConfig? serverConfig = NewtonSoftHelper<ServerConfig>.DeserializeObjectFromPath(PathManagement.serverConfigPath);
            ucServer = new ucServerConfig(serverConfig);
            tabServerConfig.Controls.Add(ucServer);
            ucServer.Dock = DockStyle.Fill;
            tabServerConfig.AutoScroll = true;
            ucServer.Dock = DockStyle.None;
        }
        private void AddTabLprConfig()
        {
            TabPage tabLprConfig = new TabPage();
            tabLprConfig.Text = "Nhận dạng biển số";
            tabControl1.TabPages.Add(tabLprConfig);

            LprConfig? lprConfig = NewtonSoftHelper<LprConfig>.DeserializeObjectFromPath(PathManagement.lprConfigPath)?? new LprConfig();
            ucLprConnection = new ucLprConnection(lprConfig);
            tabLprConfig.Controls.Add(ucLprConnection);
            ucLprConnection.Dock = DockStyle.Fill;
            tabLprConfig.AutoScroll = true;
            ucLprConnection.Dock = DockStyle.None;
        }
        private void SaveEInvoiceConfig()
        {
            NewtonSoftHelper<EInvoiceConfig>.SaveConfig(ucEInvoice.GetEInvoiceConfig(), PathManagement.einvoiceConfigPath);
        }
        private void SaveLprConfig()
        {
            NewtonSoftHelper<LprConfig>.SaveConfig(ucLprConnection.GetConfig(), PathManagement.lprConfigPath);
        }
        private void SaveOptionConfig()
        {
            NewtonSoftHelper<AppOption>.SaveConfig(ucAppOptions.GetAppOptionConfig(), PathManagement.appOptionConfigPath);
        }
        private void SaveServerConfig()
        {
            string directory = LogHelper.SaveLogFolder + $"/configs/app/";
            string configPath = directory + "server.txt";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(configPath))
            {
                using (File.Create(configPath)) { }
            }

            using (StreamWriter writer = new StreamWriter(configPath, false))
            {
                try
                {
                    string value = Newtonsoft.Json.JsonConvert.SerializeObject(ucServer.GetServerConfig());
                    writer.WriteLine(value);
                    writer.Dispose();
                }
                catch
                {
                }
            }
        }
        #endregion End Private Function

        #region Public Function

        #endregion End Public Function


    }
}
