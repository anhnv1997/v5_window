using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.Objects;
using iParkingv5_window.Forms.DataForms;
using iParkingv6.Objects.Datas;
using Kztek.Tool;

namespace iParkingv5_window.Forms.SystemForms
{
    public partial class frmSelectLaneMode : Form
    {
        #region Properties
        BtnOk? btnOk;
        int waitTimes = 0;
        #endregion End Properties

        #region Forms
        public frmSelectLaneMode()
        {
            InitializeComponent();
            this.Load += FrmSelectLaneMode_Load;
        }
        private void FrmSelectLaneMode_Load(object? sender, EventArgs e)
        {
            btnOk = new BtnOk();

            this.Controls.Add(btnOk);
            btnOk.InitControl(BtnOk_Click);

            lblTitle.Font = new Font(lblTitle.Font.Name, TextManagement.ROOT_SIZE * 2, FontStyle.Bold);
            lblTitle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);

            chbSelectAll.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + TextManagement.ROOT_SIZE);

            btnOk.Location = new Point(this.DisplayRectangle.Width - btnOk.Width - TextManagement.ROOT_SIZE,
                                       this.DisplayRectangle.Height - btnOk.Height - TextManagement.ROOT_SIZE);
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            panelActiveLanes.Location = new Point(lblTitle.Location.X, chbSelectAll.Location.Y + chbSelectAll.Height + TextManagement.ROOT_SIZE);
            panelActiveLanes.Width = this.DisplayRectangle.Width - TextManagement.ROOT_SIZE * 2;
            panelActiveLanes.Height = btnOk.Location.Y - panelActiveLanes.Location.Y - TextManagement.ROOT_SIZE;
            panelActiveLanes.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            panelActiveLanes.AutoScroll = true;

           List<string> activeLaneIds = NewtonSoftHelper<List<string>>.DeserializeObjectFromPath(PathManagement.appActiveLaneConfigPath()) ?? new List<string>();
            for (int i = 0; i < StaticPool.lanes.Count; i++)
            {
                CheckBox chb = new CheckBox();
                chb.Name = StaticPool.lanes[i].id;
                chb.Text = StaticPool.lanes[i].name;
                panelActiveLanes.Controls.Add(chb);
                chb.Location = new Point(0, (chb.Height + TextManagement.ROOT_SIZE) * i);
                chb.AutoSize = true;
                chb.Click += Chb_Click;
                if (activeLaneIds.Contains(chb.Name))
                {
                    chb.Checked = true;
                }
            }
            chbSelectAll.Click += ChbSelectAll_Click;
            chbSelectAll.CheckedChanged += ChbSelectAll_CheckedChanged;

            lblStatus.Location = new Point(lblTitle.Location.X,
                                           btnOk.Location.Y + (btnOk.Height - lblStatus.Height) / 2);
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.ActiveControl = btnOk;
            btnOk.Focus();
            this.KeyDown += FrmSelectLaneMode_KeyDown;

        }
        private void FrmSelectLaneMode_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnOk_Click(null, null);
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void ChbSelectAll_CheckedChanged(object? sender, EventArgs e)
        {
            timer1.Enabled = false;
            lblStatus.Visible = false;
            foreach (CheckBox item in panelActiveLanes.Controls)
            {
                item.Checked = chbSelectAll.Checked;
            }
        }
        private void ChbSelectAll_Click(object? sender, EventArgs e)
        {
            timer1.Enabled = false;
            lblStatus.Visible = false;
        }
        private void Chb_Click(object? sender, EventArgs e)
        {
            timer1.Enabled = false;
            lblStatus.Visible = false;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            timer1.Enabled = false;
            lblStatus.Visible = false;

            List<Lane> lanes = new List<Lane>();
            List<string> activeLaneIds = new List<string>();
            for (int i = 0; i < panelActiveLanes.Controls.Count; i++)
            {
                CheckBox? chb = panelActiveLanes.Controls[i] as CheckBox;
                if (chb == null)
                {
                    continue;
                }
                if (!chb.Checked) { continue; }
                string laneId = chb.Name;
                activeLaneIds.Add(laneId);
            }
            if (activeLaneIds.Count == 0)
            {
                MessageBox.Show("Hãy chọn làn hoạt động", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (var lane in StaticPool.lanes)
            {
                if (activeLaneIds.Contains(lane.id))
                {
                    lanes.Add(lane);
                }
            }
            NewtonSoftHelper<List<string>>.SaveConfig(activeLaneIds, PathManagement.appActiveLaneConfigPath());

            activeLaneIds.Clear();
            frmMain frm = new(lanes)
            {
                Owner = this.Owner
            };
            frm.Show();
            this.Close();
            GC.Collect();
        }
        #endregion End Controls In Form

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            waitTimes++;
            if (waitTimes >= 10)
            {
                timer1.Enabled = false;
                lblStatus.Visible = false;
                btnOk.PerformClick();
            }
            else
            {
                lblStatus.Text = $"Tự động mở giao diện phần mềm sau {10 - waitTimes} s";
            }
        }
        #endregion End Timer
    }
}
