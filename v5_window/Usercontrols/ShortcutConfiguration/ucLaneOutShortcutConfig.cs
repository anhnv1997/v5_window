using IPaking.Ultility;
using iParkingv5.Objects.Configs;
using iParkingv5_window.Forms.DataForms;
using Kztek.Tool;
using Kztek.Tools;

namespace iParkingv5_window.Usercontrols.ShortcutConfiguration
{
    public partial class ucLaneOutShortcutConfig : UserControl
    {
        #region Properties
        private string laneId;
        public LaneOutShortcutConfig? ShortcutConfig { get; set; }
        #endregion End Properties

        #region Forms
        public ucLaneOutShortcutConfig(string laneId)
        {
            InitializeComponent();
            this.laneId = laneId;
            this.Load += UcLaneOutShortcutConfig_Load;
        }

        private void UcLaneOutShortcutConfig_Load(object? sender, EventArgs e)
        {
            this.ShortcutConfig = NewtonSoftHelper<LaneOutShortcutConfig>.DeserializeObjectFromPath(PathManagement.laneShortcutConfigPath(laneId))
                                       ?? new LaneOutShortcutConfig();


            lblConfirmPlateKey.Text = ((Keys)ShortcutConfig.ConfirmPlateKey).ToString();
            lblWriteOutKey.Text = ((Keys)ShortcutConfig.WriteOut).ToString();
            lblReserveLaneKey.Text = ((Keys)ShortcutConfig.ReverseLane).ToString();
            lblReSnapshotLaneKey.Text = ((Keys)ShortcutConfig.ReSnapshotKey).ToString();
            lblPrintKey.Text = ((Keys)ShortcutConfig.PrintKey).ToString();

            picChangeConfirmPlateKey.InitControl(PicChangeConfirmPlateKey_Click);
            picWriteOut.InitControl(PicChangeWriteOutKey_Click);
            picReserveLane.InitControl(PicChangeReserverLane_Click);
            picReSnapshot.InitControl(PicReSnapshot_Click);
            picPrint.InitControl(PicPrint_Click);
        }

        #endregion End Forms

        #region Controls In Form
        private void PicChangeConfirmPlateKey_Click(object? sender, EventArgs e)
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
        private void PicChangeWriteOutKey_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.WriteOut = (int)frm.KeySet;
                lblWriteOutKey.Text = ((Keys)ShortcutConfig.WriteOut).ToString();
            }
        }
        private void PicChangeReserverLane_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.ReverseLane = (int)frm.KeySet;
                lblReserveLaneKey.Text = ((Keys)ShortcutConfig.ReverseLane).ToString();
            }
        }
        private void PicReSnapshot_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.ReSnapshotKey = (int)frm.KeySet;
                lblReSnapshotLaneKey.Text = ((Keys)ShortcutConfig.ReSnapshotKey).ToString();
            }
            frm.Dispose();
        }

        private void PicPrint_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.PrintKey = (int)frm.KeySet;
                lblPrintKey.Text = ((Keys)ShortcutConfig.PrintKey).ToString();
            }
            frm.Dispose();
        }
        #endregion End Controls In Form
    }
}
