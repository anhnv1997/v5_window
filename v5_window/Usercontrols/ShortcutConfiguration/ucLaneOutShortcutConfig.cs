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


            if ((Keys)ShortcutConfig.ConfirmPlateKey != Keys.None)
            {
                lblConfirmPlateKey.Text = ((Keys)ShortcutConfig.ConfirmPlateKey).ToString();
            }
            else
            {
                lblConfirmPlateKey.Text = "Hãy cấu hình phím tắt";
            }
            if ((Keys)ShortcutConfig.WriteOut != Keys.None)
            {
                lblWriteOutKey.Text = ((Keys)ShortcutConfig.WriteOut).ToString();
            }
            else
            {
                lblWriteOutKey.Text = "Hãy cấu hình phím tắt";
            }
            if ((Keys)ShortcutConfig.ReverseLane != Keys.None)
            {
                lblReserveLaneKey.Text = ((Keys)ShortcutConfig.ReverseLane).ToString();
            }
            else
            {
                lblReserveLaneKey.Text = "Hãy cấu hình phím tắt";
            }
            if ((Keys)ShortcutConfig.ReSnapshotKey != Keys.None)
            {
                lblReSnapshotLaneKey.Text = ((Keys)ShortcutConfig.ReSnapshotKey).ToString();
            }
            else
            {
                lblReSnapshotLaneKey.Text = "Hãy cấu hình phím tắt";
            }
            if ((Keys)ShortcutConfig.PrintKey != Keys.None)
            {
                lblPrintKey.Text = ((Keys)ShortcutConfig.PrintKey).ToString();
            }
            else
            {
                lblPrintKey.Text = "Hãy cấu hình phím tắt";
            }

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

                if ( frm.KeySet != Keys.None)
                {
                    lblConfirmPlateKey.Text = ((Keys)ShortcutConfig.ConfirmPlateKey).ToString();
                }
                else
                {
                    lblConfirmPlateKey.Text = "Hãy cấu hình phím tắt";
                }
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
                if (frm.KeySet != Keys.None)
                {
                    lblWriteOutKey.Text = ((Keys)ShortcutConfig.WriteOut).ToString();
                }
                else
                {
                    lblWriteOutKey.Text = "Hãy cấu hình phím tắt";
                }
            }
        }
        private void PicChangeReserverLane_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.ReverseLane = (int)frm.KeySet;
                if (frm.KeySet != Keys.None)
                {
                    lblReserveLaneKey.Text = ((Keys)ShortcutConfig.ReverseLane).ToString();
                }
                else
                {
                    lblReserveLaneKey.Text = "Hãy cấu hình phím tắt";
                }
            }
        }
        private void PicReSnapshot_Click(object? sender, EventArgs e)
        {
            frmSetShortCutKey frm = new frmSetShortCutKey(Keys.Enter);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ShortcutConfig!.ReSnapshotKey = (int)frm.KeySet;
                if (frm.KeySet != Keys.None)
                {
                    lblReSnapshotLaneKey.Text = ((Keys)ShortcutConfig.ReSnapshotKey).ToString();
                }
                else
                {
                    lblReSnapshotLaneKey.Text = "Hãy cấu hình phím tắt";
                }
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
                if (frm.KeySet != Keys.None)
                {
                    lblPrintKey.Text = ((Keys)ShortcutConfig.PrintKey).ToString();
                }
                else
                {
                    lblPrintKey.Text = "Hãy cấu hình phím tắt";
                }
            }
            frm.Dispose();
        }
        #endregion End Controls In Form
    }
}
