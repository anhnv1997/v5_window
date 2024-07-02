using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using Kztek.Tool.TextFormatingTools;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5ApiHelper;
using static iParkingv5.Objects.Enums.VehicleType;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirmOut : Form
    {
        //Thông tin sự kiện vào
        private string plateIn;
        private string detectedPlate;
        private string identityIdIn;
        private string laneId;
        private List<ImageData> imageDatas;
        private string datetimeIn;
        private long charge = 0;
        public string updatePlate;
        #region Forms
        public frmConfirmOut(string detectedPlate, string errorMessage, string plateIn, string identityIdIn,
                            string laneId, List<ImageData> fileKeys, DateTime? datetimeIn, bool isDisplayQuestion = true, long charge = 0)
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
            this.imageDatas = fileKeys;
            this.datetimeIn = datetimeIn?.ToString() ?? "";
            this.charge = charge;
            this.updatePlate = detectedPlate;
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
            updatePlate = dgvEventInData.Rows[4].Cells[1].Value.ToString().ToUpper().Replace("-","").Replace(".","");
            if (string.IsNullOrEmpty(updatePlate))
            {
                MessageBox.Show("Biển số ra không được phép để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion End Forms
        public static Image defaultImg = Image.FromFile(frmMain.defaultImagePath);

        private List<string>? eventInFileKeys;
        private DateTime dateTime;

        public async void ShowInfo(string detectedPlate, string laneIdIn, string datetimeIn, string plateIn, string identityIdIn)
        {
            try
            {
                this.SuspendLayout();
                this.updatePlate= detectedPlate;
                //Lane? laneIn = await KzParkingApiHelper.GetLaneByIdAsync(laneIdIn);
                Lane? laneIn = (await  AppData.ApiServer.GetLaneByIdAsync(laneIdIn)).Item1;
                //Identity? identityIn = await KzParkingApiHelper.GetIdentityById(identityIdIn);
                Identity? identityIn = (await  AppData.ApiServer.GetIdentityByIdAsync(identityIdIn)).Item1;
                IdentityGroup? identityGroupIn = null;
                VehicleBaseType  vehicleTypeIn = VehicleBaseType.Car;
                if (identityIn != null)
                {
                    //identityGroupIn = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identityIn.IdentityGroupId.ToString());
                    identityGroupIn = (await  AppData.ApiServer.GetIdentityGroupByIdAsync(identityIn.IdentityGroupId.ToString())).Item1;
                    //if (identityGroupIn != null)
                    //{
                    //    //vehicleTypeIn = await KzParkingApiHelper.GetVehicleTypeById(identityGroupIn.VehicleTypeId.ToString());
                    //    //vehicleTypeIn = (await  AppData.ApiServer.GetVehicleTypeByIdAsync(identityGroupIn.VehicleType.Id.ToString())).Item1;
                    //}
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
                        dgvEventInData.Rows.Add("Loại phương tiện", VehicleType.GetDisplayStr(vehicleTypeIn));
                    }

                    //if (this.charge > 0)
                    {
                        dgvEventInData.Rows.Add("Phí gửi xe", TextFormatingTool.GetMoneyFormat(this.charge.ToString()));
                    }
                    dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.Font = new Font(dgvEventInData.DefaultCellStyle.Font.Name, dgvEventInData.DefaultCellStyle.Font.Size * 2);
                    dgvEventInData.Rows[dgvEventInData.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;

                }));
                if (this.imageDatas?.Count >= 2)
                {
                    Task task1 = ShowImage(this.imageDatas[0]?.Url??"", picOverview);
                    Task task2 = ShowImage(this.imageDatas[1]?.Url??"", picVehicle);
                    await Task.WhenAll(task1, task2);
                }
                else if (this.imageDatas?.Count > 0)
                {
                    await ShowImage(this.imageDatas[0]?.Url??"", picOverview);
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
            try
            {
                if (string.IsNullOrEmpty(fileKey))
                {
                    pic.Image = defaultImg;
                }
                else
                {
                    pic.LoadAsync(fileKey);
                }
            }
            catch (Exception)
            {
                pic.Image = defaultImg;
            }


            //if (!string.IsNullOrEmpty(fileKey))
            //{
            //    string displayPath = await MinioHelper.GetImage(fileKey);
            //    if (!string.IsNullOrEmpty(displayPath))
            //    {
            //        pic.LoadAsync(displayPath);
            //        return;
            //    }
            //}
            //pic.Image = defaultImg;
        }

    }
}
