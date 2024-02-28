using iParkingv5_window.Usercontrols;
using iParkingv5_window.Usercontrols.LaneConfiguration;
using iParkingv6.Objects.Datas;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmLaneSetting : Form
    {
        
        #region Properties
        private List<Led> leds = new List<Led>();
        private List<Camera> cameras = new List<Camera>();
        private List<ControllerInLane> bdks = new List<ControllerInLane>();
        private string laneId = string.Empty;
        private bool isLaneIn = false;
        #endregion End Properties

        #region Forms
        public frmLaneSetting(string laneId, List<Led> leds, List<Camera> cameras, List<ControllerInLane> bdks, bool isLaneIn)
        {
            InitializeComponent();
            this.leds = leds;
            this.cameras = cameras;
            this.laneId = laneId;
            this.bdks = bdks;
            this.isLaneIn = isLaneIn;
            this.Load += FrmLaneSetting_Load;
        }

        private void FrmLaneSetting_Load(object? sender, EventArgs e)
        {
            ucLedDisplaySetting uc = new ucLedDisplaySetting(this.laneId, leds);
            tabLedConfig.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;

            ucCameraConfig ucCameraConfig = new ucCameraConfig(this.cameras, this.laneId);
            tabCameraConfig.Controls.Add(ucCameraConfig);
            ucCameraConfig.Dock = DockStyle.Fill;

            ucShortcutConfig ucLaneShortcutConfig = new ucShortcutConfig(this.laneId, this.bdks, this.isLaneIn);
            tabShortcut.Controls.Add(ucLaneShortcutConfig);
            ucLaneShortcutConfig.Dock = DockStyle.Fill;

            ucLaneDirectionConfig ucLaneDirectionConfig = new ucLaneDirectionConfig(this.laneId);
            tabDisplayConfig.Controls.Add(ucLaneDirectionConfig);
            ucLaneDirectionConfig.Dock = DockStyle.Fill;
        }
        #endregion End Forms
    }
}
