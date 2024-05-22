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
        private string detectedPlate;
        private string identityIdIn;
        private string laneId;
        private List<string> fileKeys;
        private string datetimeIn;
        private long charge = 0;
        public string updatePlate;
        public RegisteredVehicle registeredVehicle;
        #region Forms
        public frmConfirmOut(string detectedPlate, string errorMessage, string plateIn, string identityIdIn,
                            string laneId, List<string> fileKeys, DateTime? datetimeIn, bool isDisplayQuestion = true, long charge = 0, RegisteredVehicle registeredV = null)
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

            this.detectedPlate = detectedPlate;
            this.plateIn = plateIn;
            this.identityIdIn = identityIdIn;
            this.laneId = laneId;
            this.fileKeys = fileKeys;
            this.datetimeIn = datetimeIn?.ToString() ?? "";
            this.charge = charge;
            this.registeredVehicle = registeredV;
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

            ShowInfo(this.detectedPlate, this.laneId, this.datetimeIn, this.plateIn, this.identityIdIn);
            this.ActiveControl = btnOk;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            updatePlate = dgvEventInData.Rows[3].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion End Forms
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private List<string>? eventInFileKeys;
        private DateTime dateTime;
        private bool v5;
        private long v6;

        public async void ShowInfo(string detectedPlate, string laneIdIn, string datetimeIn, string plateIn, string identityIdIn)
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
                    dgvEventInData.Rows.Add("Thời gian ra", DateTime.Now.ToString());
                    dgvEventInData.Rows.Add("Mã định danh", identityIn?.Code);
                    dgvEventInData.Rows.Add("Biển số vào", plateIn);
                    dgvEventInData.Rows.Add("Biển số Ra", detectedPlate);
                    if (identityGroupIn != null)
                    {
                        dgvEventInData.Rows.Add("Nhóm", identityGroupIn.Name);
                        dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
                        dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    if (vehicleTypeIn != null)
                    {
                        dgvEventInData.Rows.Add("Loại phương tiện", VehicleType.GetDisplayStr(vehicleTypeIn.Type));
                    }

                    //if (this.charge > 0)
                    {
                        dgvEventInData.Rows.Add("Phí gửi xe", TextFormatingTool.GetMoneyFormat(this.charge.ToString()));
                    }
                    if (identityIn != null)
                    {
                        dgvEventInData.Rows.Add("Mã định danh", identityIn.Name + "-" + identityIn.Code);
                    }
                    if (registeredVehicle?.Customer != null)
                    {
                        dgvEventInData.Rows.Add("Khách hàng", registeredVehicle?.Customer.Name + " " + registeredVehicle?.Customer.Address);
                        dgvEventInData.Rows.Add("SĐT", registeredVehicle?.Customer.PhoneNumber);
                    }

                    dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
                    dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;

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
                        picOverview.Image = defaultImg;
                    });
                }
                else
                {
                    this.Invoke(() =>
                    {
                        picOverview.Image = defaultImg;
                        picVehicle.Image = defaultImg;
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
            pic.Image = defaultImg;
        }
    }
}
