using IPaking.Ultility;
using iParkingv5.Objects.Configs;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;

namespace iParkingv5_window.Usercontrols.ShortcutConfiguration
{
    public partial class ucControllerConfigItem : UserControl
    {
        #region Properties
        private ControllerInLane controllerInLane;
        private string laneId;
        #endregion End Properties

        #region Forms
        public ucControllerConfigItem(ControllerInLane controllerInLane, string laneId)
        {
            InitializeComponent();
            this.controllerInLane = controllerInLane;
            this.laneId = laneId;
            this.Load += UcControllerConfigItem_Load;
        }

        private void UcControllerConfigItem_Load(object? sender, EventArgs e)
        {
            lblControllerName.Text = this.controllerInLane.controlUnitId;

            List<ControllerShortcutConfig>? controllerShortcutConfigs = NewtonSoftHelper<List<ControllerShortcutConfig>>.
                DeserializeObjectFromPath(PathManagement.laneControllerShortcutConfigPath(
                                                    this.laneId));
            if (controllerShortcutConfigs == null)
            {
                foreach (var item in this.controllerInLane.barriers)
                {
                    ucControllerConfigBarrieItem ucBarrieItem = new ucControllerConfigBarrieItem(item, null);
                    this.Controls.Add(ucBarrieItem);
                    ucBarrieItem.Dock = DockStyle.Top;
                    ucBarrieItem.BringToFront();
                }
            }
            else
            {
                bool isFound = false;
                foreach (var item in controllerShortcutConfigs)
                {
                    if (item.ControllerId == this.controllerInLane.controlUnitId)
                    {
                        isFound = true;
                        foreach (var barrieItem in this.controllerInLane.barriers)
                        {
                            ucControllerConfigBarrieItem ucBarrieItem = new(barrieItem,
                                                                            item.KeySetByRelays.ContainsKey(barrieItem) ?
                                                                            (Keys)item.KeySetByRelays[barrieItem] :
                                                                            null);
                            this.Controls.Add(ucBarrieItem);
                            ucBarrieItem.Dock = DockStyle.Top;
                            ucBarrieItem.BringToFront();
                        }
                        break;
                    }
                }
                if (!isFound)
                {
                    foreach (var item in this.controllerInLane.barriers)
                    {
                        ucControllerConfigBarrieItem ucBarrieItem = new ucControllerConfigBarrieItem(item, null);
                        this.Controls.Add(ucBarrieItem);
                        ucBarrieItem.Dock = DockStyle.Top;
                        ucBarrieItem.BringToFront();
                    }
                }
            }

        }
        #endregion

        #region Public Function
        public ControllerShortcutConfig GetConfig()
        {
            var newConfig = new ControllerShortcutConfig();
            newConfig.ControllerId = this.controllerInLane.controlUnitId;
            newConfig.KeySetByRelays = new Dictionary<int, int>();

            foreach (var item in this.Controls)
            {
                if (item is ucControllerConfigBarrieItem)
                {
                    ucControllerConfigBarrieItem? _temp = item as ucControllerConfigBarrieItem;
                    if (_temp != null)
                    {
                        if (_temp.keySet != null)
                        {
                            newConfig.KeySetByRelays.Add(_temp.barrieIndex, (int)_temp.keySet);
                        }
                    }
                }
            }
            return newConfig;
        }
        #endregion

    }
}
