using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool.TextFormatingTools;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirmOut : Form
    {
        //Thông tin sự kiện vào
        private string plateIn;
        private string identityIdIn;
        private string laneId;
        private List<string> fileKeys;
        private string datetimeIn;
        private long charge = 0;
        #region Forms
        public frmConfirmOut(string errorMessage, string plateIn, string identityIdIn, string laneId, List<string> fileKeys, DateTime? datetimeIn, bool isDisplayQuestion = true, long charge = 0)
        {
            InitializeComponent();
            this.Text = "Xác nhận xe ra khỏi bãi";
            if (isDisplayQuestion)
            {
                lblMessage.Text = errorMessage + "\r\nBạn có xác nhận cho xe ra khỏi bãi?";
            }
            else
            {
                lblMessage.Text = errorMessage;
            }
            lblMessage.Size = lblMessage.PreferredSize;

            this.plateIn = plateIn;
            this.identityIdIn = identityIdIn;
            this.laneId = laneId;
            this.fileKeys = fileKeys;
            this.datetimeIn = datetimeIn?.ToString() ?? "";
            this.charge = charge;
            btnOk.Focus();
            //this.Size = new Size(lblMessage.Width, lblMessage.Height + panelAction.Height + 100);
            this.Load += FrmConfirm_Load;
        }

        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            btnCancel1.InitControl(BtnCancel1_Click);
            btnOk.InitControl(BtnOk_Click);

            lblMessage.Padding = new Padding(StaticPool.baseSize);
            lblMessage.Height = lblMessage.PreferredSize.Height;

            panelAction.Height = btnCancel1.Height + StaticPool.baseSize * 3;
            btnCancel1.Location = new Point(panelAction.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk.Location = new Point(btnCancel1.Location.X - btnOk.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);

            this.Visible = false;

            ShowInfo(this.laneId, this.datetimeIn, this.plateIn, this.identityIdIn);
            this.ActiveControl = btnOk;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion End Forms

        public async void ShowInfo(string laneIdIn, string datetimeIn, string plateIn, string identityIdIn)
        {
            try
            {
                this.SuspendLayout();

                Lane? laneIn = await KzParkingApiHelper.GetLaneByIdAsync(laneIdIn);
                Identity? identityIn = await KzParkingApiHelper.GetIdentityById(identityIdIn);
                IdentityGroup? identityGroupIn = null;
                VehicleType? vehicleTypeIn = null;
                if (identityIn != null)
                {
                    identityGroupIn = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identityIn.IdentityGroupId.ToString());
                    if (identityGroupIn != null)
                    {
                        vehicleTypeIn = await KzParkingApiHelper.GetVehicleTypeById(identityGroupIn.VehicleTypeId.ToString());
                    }
                }

                dgvEventInData?.Invoke(new Action(() =>
                {
                    dgvEventInData.Rows.Clear();
                    dgvEventInData.Rows.Add("Thời gian vào", datetimeIn);
                    dgvEventInData.Rows.Add("Mã định danh", identityIn?.Code);
                    dgvEventInData.Rows.Add("Biển số nhận diện", plateIn);
                    if (identityGroupIn != null)
                    {
                        dgvEventInData.Rows.Add("Nhóm", identityGroupIn.Name);
                    }
                    if (vehicleTypeIn != null)
                    {
                        dgvEventInData.Rows.Add("Loại phương tiện", VehicleType.GetDisplayStr(vehicleTypeIn.Type));
                    }
                    if (this.charge > 0)
                    {
                        dgvEventInData.Rows.Add("Phí gửi xe", TextFormatingTool.GetMoneyFormat(this.charge.ToString()));
                    }
                }));
                if (this.fileKeys?.Count >= 2)
                {
                    string displayOverviewInPath = await MinioHelper.GetImage(this.fileKeys[0]);
                    string vehicleInPath = await MinioHelper.GetImage(this.fileKeys[1]);
                    Task task1 = ShowImage(this.fileKeys[0], picOverview);
                    Task task2 = ShowImage(this.fileKeys[1], picVehicle);
                    await Task.WhenAll(task1, task2);
                }
                else if (this.fileKeys?.Count > 0)
                {
                    await ShowImage(this.fileKeys[0], picOverview);
                    this.Invoke(() =>
                    {
                        picOverview.Image = Properties.Resources.defaultImage;
                    });
                }
                else
                {
                    this.Invoke(() =>
                    {
                        picOverview.Image = Properties.Resources.defaultImage;
                        picVehicle.Image = Properties.Resources.defaultImage;
                    });
                }

                this.BringToFront();
                this.ResumeLayout();
            }
            catch (Exception)
            {
            }
        }
        private async Task ShowImage(string fileKey, PictureBox pic)
        {
            if (!string.IsNullOrEmpty(fileKey))
            {
                string displayPath = await MinioHelper.GetImage(fileKey);
                if (!string.IsNullOrEmpty(displayPath))
                {
                    pic.LoadAsync(displayPath);
                    return;
                }
            }
            pic.Image = Properties.Resources.defaultImage;
        }
    }
}
