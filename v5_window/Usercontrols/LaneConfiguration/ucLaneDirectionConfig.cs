using IPaking.Ultility;
using iPakrkingv5.Controls.Controls.Buttons;
using iParkingv5.Objects.Configs;
using Kztek.Tool;
using static iParkingv5.Objects.Configs.LaneDirectionConfig;

namespace iParkingv5_window.Usercontrols.LaneConfiguration
{
    public partial class ucLaneDirectionConfig : UserControl
    {
        #region Properties
        private string laneId = string.Empty;
        #endregion End Properties

        #region Forms
        public ucLaneDirectionConfig(string laneId)
        {
            InitializeComponent();
            this.laneId = laneId;
            this.Load += UcLaneDirectionConfig_Load;
        }

        private void UcLaneDirectionConfig_Load(object? sender, EventArgs e)
        {
            CreateUI();
            LaneDirectionConfig laneDirectionConfig = NewtonSoftHelper<LaneDirectionConfig>.DeserializeObjectFromPath(PathManagement.appLaneDirectionConfigPath(this.laneId)) ?? LaneDirectionConfig.CreateDefault();
            chbIsDisplayTitle.Checked = laneDirectionConfig.IsDisplayTitle;
            chbIsDisplayLastEvent.Checked = laneDirectionConfig.IsDisplayLastEvent;

            cbDisplayDirection.SelectedIndex = (int)laneDirectionConfig.displayDirection;
            cbCameraDirection.SelectedIndex = (int)laneDirectionConfig.cameraDirection;
            cbPicDiection.SelectedIndex = (int)laneDirectionConfig.picDirection;
            cbCameraPicDirection.SelectedIndex = (int)laneDirectionConfig.cameraPicDirection;
            cbEventDirection.SelectedIndex = (int)laneDirectionConfig.eventDirection;
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnOk_Click(object? sender, EventArgs e)
        {
            LaneDirectionConfig laneDirectionConfig = new LaneDirectionConfig()
            {
                IsDisplayLastEvent = chbIsDisplayLastEvent.Checked,
                IsDisplayTitle = chbIsDisplayTitle.Checked,
                displayDirection = (EmDisplayDirection)cbDisplayDirection.SelectedIndex,
                cameraDirection = (EmCameraDirection)cbCameraDirection.SelectedIndex,
                picDirection = (EmPicDirection)cbPicDiection.SelectedIndex,
                cameraPicDirection = (EmCameraPicFunction)cbCameraPicDirection.SelectedIndex,
                eventDirection = (EmEventDirection)cbEventDirection.SelectedIndex,
            };
            bool isSaveSuccess = NewtonSoftHelper<LaneDirectionConfig>.SaveConfig(laneDirectionConfig, PathManagement.appLaneDirectionConfigPath(this.laneId));
            if (!isSaveSuccess)
            {
                MessageBox.Show("Lưu thông tin cấu hình thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Lưu thông tin cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion End Controls In Form

        #region Private Function
        private void CreateUI()
        {
            BtnOk btnOk = new BtnOk();
            btnOk.InitControl(BtnOk_Click);

            lblDisplayDirection.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            lblCameraDirection.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            lblPicDirection.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            lblCameraPicDirection.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);

            cbDisplayDirection.Location = new Point(lblDisplayDirection.Location.X + lblCameraPicDirection.Width + TextManagement.ROOT_SIZE,
                                                    lblDisplayDirection.Location.Y + (lblDisplayDirection.Height - cbDisplayDirection.Height) / 2);
            cbCameraDirection.Location = new Point(cbDisplayDirection.Location.X, cbDisplayDirection.Location.Y + cbDisplayDirection.Height + TextManagement.ROOT_SIZE);
            cbPicDiection.Location = new Point(cbCameraDirection.Location.X, cbCameraDirection.Location.Y + cbCameraDirection.Height + TextManagement.ROOT_SIZE);
            cbCameraPicDirection.Location = new Point(cbPicDiection.Location.X, cbPicDiection.Location.Y + cbPicDiection.Height + TextManagement.ROOT_SIZE);
            cbEventDirection.Location = new Point(cbCameraPicDirection.Location.X, cbCameraPicDirection.Location.Y + cbCameraPicDirection.Height + TextManagement.ROOT_SIZE);
            
            chbIsDisplayTitle.Location = new Point(cbEventDirection.Location.X, cbEventDirection.Location.Y + cbEventDirection.Height + TextManagement.ROOT_SIZE);
            chbIsDisplayLastEvent.Location = new Point(chbIsDisplayTitle.Location.X, chbIsDisplayTitle.Location.Y + chbIsDisplayTitle.Height + TextManagement.ROOT_SIZE);


            cbDisplayDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCameraDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPicDiection.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCameraPicDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEventDirection.DropDownStyle = ComboBoxStyle.DropDownList;

            lblCameraDirection.Location = new Point(lblDisplayDirection.Location.X, cbCameraDirection.Location.Y + (cbCameraDirection.Height - lblCameraDirection.Height) / 2);
            lblPicDirection.Location = new Point(lblDisplayDirection.Location.X, cbPicDiection.Location.Y + (cbPicDiection.Height - lblPicDirection.Height) / 2);
            lblCameraPicDirection.Location = new Point(lblDisplayDirection.Location.X, cbCameraPicDirection.Location.Y + (cbCameraPicDirection.Height - lblCameraPicDirection.Height) / 2);
            lblEventDirection.Location = new Point(lblCameraPicDirection.Location.X, cbEventDirection.Location.Y + (cbEventDirection.Height - lblEventDirection.Height) / 2);


            btnOk.Location = new Point(chbIsDisplayLastEvent.Location.X + chbIsDisplayLastEvent.Width - btnOk.Width,
                                      chbIsDisplayLastEvent.Location.Y + chbIsDisplayLastEvent.Height + TextManagement.ROOT_SIZE);
            btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Controls.Add(btnOk);
        }
        #endregion End Private Function

        #region Public Function

        #endregion End Public Function
    }
}
