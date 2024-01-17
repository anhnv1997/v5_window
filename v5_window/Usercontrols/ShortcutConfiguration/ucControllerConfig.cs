using iParkingv5.Objects.Configs;
using iParkingv5_window.Usercontrols.ShortcutConfiguration;
using iParkingv6.Objects.Datas;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucControllerConfig : UserControl
    {
        #region Properties
        private List<ControllerInLane> bdks = new List<ControllerInLane>();
        private string laneId = string.Empty;
        #endregion End Properties

        #region Forms
        public ucControllerConfig(List<ControllerInLane> bdks, string laneId)
        {
            InitializeComponent();
            this.bdks = bdks;
            this.AutoScroll = true;
            this.Load += UcControllerConfig_Load;
            this.laneId = laneId;   
        }
        private void UcControllerConfig_Load(object? sender, EventArgs e)
        {
            foreach (ControllerInLane controllerInLane in bdks)
            {
                if (controllerInLane.barriers.Length > 0)
                {
                    ucControllerConfigItem ucItem = new ucControllerConfigItem(controllerInLane, this.laneId);
                    this.Controls.Add(ucItem);
                    ucItem.Dock = DockStyle.Top;
                }
            }
        }
        #endregion End Forms

        #region Public Function
        public List<ControllerShortcutConfig> GetShortcutConfig()
        {
            List<ControllerShortcutConfig> shortcuts = new List<ControllerShortcutConfig>();
            foreach (ucControllerConfigItem item in this.Controls)
            {
                shortcuts.Add(item.GetConfig());
            }
            return shortcuts;
        }
        #endregion End Public Function
    }
}
