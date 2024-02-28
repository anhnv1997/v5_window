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
            cbDisplayDirection.SelectedIndex = (int)laneDirectionConfig.displayDirection;
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnOk_Click(object? sender, EventArgs e)
        {
            LaneDirectionConfig laneDirectionConfig = new LaneDirectionConfig()
            {
                IsDisplayTitle = chbIsDisplayTitle.Checked,
                displayDirection = (EmDisplayDirection)cbDisplayDirection.SelectedIndex,
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
            LblOk btnOk = new LblOk();
            btnOk.InitControl(BtnOk_Click);

            lblDisplayDirection.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            cbDisplayDirection.Location = new Point(lblDisplayDirection.Location.X + lblDisplayDirection.Width + TextManagement.ROOT_SIZE,
                                                    lblDisplayDirection.Location.Y + (lblDisplayDirection.Height - cbDisplayDirection.Height) / 2);
            cbDisplayDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            chbIsDisplayTitle.Location = new Point(cbDisplayDirection.Location.X, cbDisplayDirection.Location.Y + cbDisplayDirection.Height + TextManagement.ROOT_SIZE);

            btnOk.Location = new Point(cbDisplayDirection.Location.X + cbDisplayDirection.Width - btnOk.Width,
                                      chbIsDisplayTitle.Location.Y + chbIsDisplayTitle.Height + TextManagement.ROOT_SIZE);
            btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Controls.Add(btnOk);
        }
        #endregion End Private Function

        #region Public Function

        #endregion End Public Function
    }
}
