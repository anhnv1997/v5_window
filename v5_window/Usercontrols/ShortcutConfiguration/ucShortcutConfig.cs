using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5_window.Usercontrols.ShortcutConfiguration;
using iParkingv6.Objects.Datas;
using Kztek.Tool;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucShortcutConfig : UserControl
    {
        #region Properties
        private string laneId;
        private List<ControllerInLane> bdks;
        private bool isLaneIn = true;
        ucLaneInShortcutConfig? ucLaneInConfig;
        ucLaneOutShortcutConfig? ucLaneOutConfig;
        ucControllerConfig? ucControllerConfig;
        #endregion End Properties

        #region Forms
        public ucShortcutConfig(string laneId, List<ControllerInLane> bdks, bool isLaneIn = true)
        {
            InitializeComponent();
            this.laneId = laneId;
            this.bdks = bdks;
            this.isLaneIn = isLaneIn;
            this.Load += UcShortcutConfig_Load;
        }

        private void UcShortcutConfig_Load(object? sender, EventArgs e)
        {
            this.Padding = new Padding(StaticPool.baseSize);
            this.AutoScroll = true;
            if (this.isLaneIn)
            {
                ucLaneInConfig = new ucLaneInShortcutConfig(this.laneId);
                this.Controls.Add(ucLaneInConfig);
                ucLaneInConfig.Dock = DockStyle.Top;
            }
            else
            {
                ucLaneOutConfig = new ucLaneOutShortcutConfig(this.laneId);
                this.Controls.Add(ucLaneOutConfig);
                ucLaneOutConfig.Dock = DockStyle.Top;
            }
            ucControllerConfig = new ucControllerConfig(this.bdks, this.laneId);
            this.Controls.Add(ucControllerConfig);
            ucControllerConfig.Dock = DockStyle.Fill;
            ucControllerConfig.BringToFront();
            panelActions.BringToFront();
            btnOk1.InitControl(btnSaveConfig_Click);
            panelActions.Height = StaticPool.baseSize * 3 + btnOk1.Height;
            btnOk1.Location = new Point(panelActions.Width - btnOk1.Width,
                                        StaticPool.baseSize);
        }
        #endregion End Forms

        #region Controls In Form
        private void btnSaveConfig_Click(object? sender, EventArgs e)
        {
            if (this.isLaneIn)
            {
                SaveLaneInShortcutConfig();
            }
            else
            {
                SaveLaneOutShortcutConfig();
            }
            SaveControllerShortcutConfig();
            MessageBox.Show("Lưu cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion End Controls In Form

        #region Private Funciton
        private void SaveLaneInShortcutConfig()
        {
            NewtonSoftHelper<LaneInShortcutConfig>.SaveConfig(ucLaneInConfig?.ShortcutConfig, PathManagement.laneShortcutConfigPath(laneId));
        }
        private void SaveLaneOutShortcutConfig()
        {
            NewtonSoftHelper<LaneOutShortcutConfig>.SaveConfig(ucLaneOutConfig?.ShortcutConfig, PathManagement.laneShortcutConfigPath(laneId));
        }
        private void SaveControllerShortcutConfig()
        {
            NewtonSoftHelper<List<ControllerShortcutConfig>>.SaveConfig(ucControllerConfig?.GetShortcutConfig(),
                PathManagement.laneControllerShortcutConfigPath(laneId));
        }
        #endregion End Private Function
    }
}
