using IPaking.Ultility;
using iParkingv5.Objects.Configs;
using iParkingv5_window.Forms.DataForms;
using Kztek.Tool;
using Kztek.Tools;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucLaneInShortcutConfig : UserControl
    {
        #region Properties
        private string laneId;
        public LaneInShortcutConfig? ShortcutConfig { get; set; }
        #endregion End Properties

        #region Forms
        public ucLaneInShortcutConfig(string laneId)
        {
            InitializeComponent();
            this.laneId = laneId;
            this.Load += UcLaneInShortcutConfig_Load;
        }

        private void UcLaneInShortcutConfig_Load(object? sender, EventArgs e)
        {
            this.ShortcutConfig = NewtonSoftHelper<LaneInShortcutConfig>.DeserializeObjectFromPath(PathManagement.laneShortcutConfigPath(laneId))
                                        ?? new LaneInShortcutConfig();
            lblConfirmPlateKey.Text = ((Keys)ShortcutConfig.ConfirmPlateKey).ToString();
            lblWriteInKey.Text = ((Keys)ShortcutConfig.WriteIn).ToString();
            lblReserveLaneKey.Text = ((Keys)ShortcutConfig.ReserveLane).ToString();
            picChangeConfirmPlateKey.Init(picChangeConfirmPlateKey_Click);
            btnSetting1.Init(picChangeWriteInKey_Click);
            picReserveLane.Init(picChangeReserverLane_Click);
        }
        #endregion End Forms

        #region Controls In Form

        private void picChangeConfirmPlateKey_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.ConfirmPlateKey = (int)frm.KeySet;
                lblConfirmPlateKey.Text = ((Keys)ShortcutConfig.ConfirmPlateKey).ToString();
            }
            frm.Dispose();
        }
        private void picChangeWriteInKey_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.WriteIn = (int)frm.KeySet;
                lblWriteInKey.Text = ((Keys)ShortcutConfig.WriteIn).ToString();
            }
        }
        private void picChangeReserverLane_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.ReserveLane = (int)frm.KeySet;
                lblReserveLaneKey.Text = ((Keys)ShortcutConfig.ReserveLane).ToString();
            }
        }
        #endregion End Controls In Form
    }
}
