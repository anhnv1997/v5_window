using IPaking.Ultility;
using iParking.ConfigurationManager.UserControls;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using Kztek.Scale_net6.Objects;
using Kztek.Tool;
using Kztek.Tools;

namespace iParking.ConfigurationManager.Forms.SystemForms
{
    public partial class frmConnectionConfig : Form
    {
        #region Properties
        ucEinvoiceConfig ucEInvoice;
        ucServerConfig ucServer;
        ucAppOptions ucAppOptions;
        ucLprConnection ucLprConnection;
        ucDatabaseConnection ucDatabaseConnection;
        ucScaleConfig ucScaleConfig;
        ucThirdParty ucThirdParty;
        ucOEM ucOEM;
        #endregion End Properties

        #region Forms
        public frmConnectionConfig()
        {
            InitializeComponent();
            this.Load += FrmConnectionConfig_Load;
        }
        private void FrmConnectionConfig_Load(object? sender, EventArgs e)
        {
            AddTabDatabaseConfig();
            AddTabEInvoiceConfig();
            AddTabServerConfig();
            AddTabOptionConfig();
            AddTabLprConfig();
            //AddTabScaleConfig();
            AddTabThirdParty();
            AddTabOEM();

            this.Size = new Size(Properties.Settings.Default.prefer_width, Properties.Settings.Default.prefer_height);
            this.SizeChanged += FrmConnectionConfig_SizeChanged;
        }

        private void FrmConnectionConfig_SizeChanged(object? sender, EventArgs e)
        {
            Properties.Settings.Default.prefer_width = this.Size.Width;
            Properties.Settings.Default.prefer_height = this.Size.Height;
            Properties.Settings.Default.Save();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool isEnableDevelopeMode = (keyData & Keys.Control) == Keys.Control &&
                                 (keyData & Keys.Shift) == Keys.Shift &&
                                 (keyData & Keys.KeyCode) == Keys.E;
            bool isDisEnableDevelopeMode = (keyData & Keys.Control) == Keys.Control &&
                                (keyData & Keys.Shift) == Keys.Shift &&
                                (keyData & Keys.KeyCode) == Keys.D;
            if (isEnableDevelopeMode)
            {
                ucAppOptions.DisplayDevelopMode(true);
                return true;
            }
            else if (isDisEnableDevelopeMode)
            {
                ucAppOptions.DisplayDevelopMode(false);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion End Forms

        #region Controls In Form
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEInvoiceConfig();
            SaveServerConfig();
            SaveLprConfig();
            SaveOptionConfig();
            SaveDatabaseConfig();
            //SaveScaleConfig();
            SaveThirdPartyConfig();
            SaveOEMConfig();
            MessageBox.Show("Lưu cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion End Controls In Form

        #region Private Function
        private void AddTabDatabaseConfig()
        {
            TabPage tabDatabaseConfig = new TabPage();
            tabDatabaseConfig.Text = "Database";
            tabControl1.TabPages.Add(tabDatabaseConfig);
            tabDatabaseConfig.BackColor = SystemColors.ButtonHighlight;

            SQLConn? sqlconf = null;
            FileXML.ReadXMLSQLConn(PathManagement.databaseConfigPath, ref sqlconf);

            ucDatabaseConnection = new ucDatabaseConnection(sqlconf);

            tabDatabaseConfig.Controls.Add(ucDatabaseConnection);
            ucDatabaseConnection.Dock = DockStyle.Fill;
            tabDatabaseConfig.AutoScroll = true;
            ucDatabaseConnection.Dock = DockStyle.None;
        }
        private void AddTabEInvoiceConfig()
        {
            TabPage tabEinvoice = new TabPage();
            tabEinvoice.Text = "Hóa đơn điện tử";
            tabControl1.TabPages.Add(tabEinvoice);
            tabEinvoice.BackColor = SystemColors.ButtonHighlight;

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
            tabOption.BackColor = SystemColors.ButtonHighlight;

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
            tabServerConfig.BackColor = SystemColors.ButtonHighlight;

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
            tabLprConfig.BackColor = SystemColors.ButtonHighlight;

            LprConfig? lprConfig = NewtonSoftHelper<LprConfig>.DeserializeObjectFromPath(PathManagement.lprConfigPath) ?? new LprConfig();
            ucLprConnection = new ucLprConnection(lprConfig);
            tabLprConfig.Controls.Add(ucLprConnection);
            ucLprConnection.Dock = DockStyle.Fill;
            tabLprConfig.AutoScroll = true;
            ucLprConnection.Dock = DockStyle.None;
        }
        private void AddTabScaleConfig()
        {
            TabPage tabScaleConfig = new TabPage();
            tabScaleConfig.Text = "Thiết bị cân";
            tabControl1.TabPages.Add(tabScaleConfig);
            tabScaleConfig.BackColor = SystemColors.ButtonHighlight;

            ScaleConfig? scaleConfig = NewtonSoftHelper<ScaleConfig>.DeserializeObjectFromPath(PathManagement.scaleConfigPath) ?? new ScaleConfig();

            ucScaleConfig = new ucScaleConfig(scaleConfig);

            tabScaleConfig.Controls.Add(ucScaleConfig);
            ucScaleConfig.Dock = DockStyle.Fill;
            tabScaleConfig.AutoScroll = true;
            ucScaleConfig.Dock = DockStyle.None;
        }
        private void AddTabThirdParty()
        {
            TabPage tabThirdParty = new TabPage();
            tabThirdParty.Text = "Tích hợp hệ thống thứ 3";
            tabControl1.TabPages.Add(tabThirdParty);
            tabThirdParty.BackColor = SystemColors.ButtonHighlight;

            ThirdPartyConfig? thirdPartyConfig = NewtonSoftHelper<ThirdPartyConfig>.DeserializeObjectFromPath(PathManagement.thirtPartyConfigPath) ?? new ThirdPartyConfig();

            ucThirdParty = new ucThirdParty(thirdPartyConfig);

            tabThirdParty.Controls.Add(ucThirdParty);
            ucThirdParty.Dock = DockStyle.Fill;
            tabThirdParty.AutoScroll = true;
            ucThirdParty.Dock = DockStyle.None;
        }
        private void AddTabOEM()
        {
            TabPage tabOEM = new TabPage();
            tabOEM.Text = "OEM";
            tabControl1.TabPages.Add(tabOEM);
            tabOEM.BackColor = SystemColors.ButtonHighlight;

            OEMConfig? oemConfig = NewtonSoftHelper<OEMConfig>.DeserializeObjectFromPath(PathManagement.oemConfigPath) ?? new OEMConfig();

            ucOEM = new ucOEM(oemConfig);

            tabOEM.Controls.Add(ucOEM);
            ucOEM.Dock = DockStyle.Fill;
            tabOEM.AutoScroll = true;
            ucOEM.Dock = DockStyle.None;
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
        private void SaveDatabaseConfig()
        {
            SQLConn sqlConfig = ucDatabaseConnection.GetSqlConfig();
            if (sqlConfig != null)
            {
                FileXML.WriteXMLSQLConn(PathManagement.databaseConfigPath, sqlConfig);
            }
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
        private void SaveScaleConfig()
        {
            NewtonSoftHelper<ScaleConfig>.SaveConfig(ucScaleConfig.GetScaleConfig(), PathManagement.scaleConfigPath);
        }
        private void SaveThirdPartyConfig()
        {
            NewtonSoftHelper<ThirdPartyConfig>.SaveConfig(ucThirdParty.GetServerConfig(), PathManagement.thirtPartyConfigPath);
        }
        private void SaveOEMConfig()
        {
            NewtonSoftHelper<OEMConfig>.SaveConfig(ucOEM.GetConfig(), PathManagement.oemConfigPath);
        }
        #endregion End Private Function

        #region Public Function
        #endregion End Public Function
    }
}
