using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.Device_service;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols.ControllerConfiguration
{
    public partial class ucControllerCardFormat : UserControl
    {
        #region Properties
        private List<ControllerInLane> controllerInLanes = new List<ControllerInLane>();
        private string laneId;
        private ControllerInLane settingController = default;
        private List<ucControllerReaderCardFormat> controllerReaderCardFormats = new List<ucControllerReaderCardFormat>();
        #endregion

        #region Forms
        public ucControllerCardFormat(List<ControllerInLane> bdks, string laneId)
        {
            InitializeComponent();
            this.controllerInLanes = bdks;
            this.laneId = laneId;
            this.Load += UcControllerReaderFormat_Load;
        }

        private void UcControllerReaderFormat_Load(object? sender, EventArgs e)
        {
            foreach (var item in this.controllerInLanes)
            {
                var bdk = StaticPool.bdks.FirstOrDefault(e => e.Id.ToLower() == item.controlUnitId.ToLower());
                if (bdk != null)
                {
                    ListItem controllerItem = new ListItem();
                    controllerItem.Name = bdk.Id;
                    controllerItem.Value = bdk.Name;
                    cbController.Items.Add(controllerItem);
                }
            }
            cbController.DisplayMember = "Value";
            cbController.ValueMember = "Name";
            cbController.SelectedIndex = cbController.Items.Count > 0 ? 0 : -1;
        }
        #endregion

        #region Controls In Form
        private void cbController_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controllerReaderCardFormats.Clear();
            foreach (ucControllerReaderCardFormat item in panelConfigs.Controls)
            {
                item.Dispose();
            }
            panelConfigs.Controls.Clear();
            settingController = this.controllerInLanes[cbController.SelectedIndex];
            for (int i = 0; i < settingController.readers.Length; i++)
            {
                var configPath = PathManagement.laneControllerReaderConfigPath(this.laneId, settingController.controlUnitId, settingController.readers[i]);
                var oldConfig = NewtonSoftHelper<CardFormatConfig>.DeserializeObjectFromPath(configPath) ??
                                new CardFormatConfig()
                                {
                                    ReaderIndex = settingController.readers[i],
                                    InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                                    OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                                    OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Toi_Gian,
                                };
                ucControllerReaderCardFormat uc = new ucControllerReaderCardFormat(oldConfig);
                panelConfigs.Controls.Add(uc);
                uc.Dock = DockStyle.Top;
                uc.SendToBack();
                this.controllerReaderCardFormats.Add(uc);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaveSuccess = true;
            foreach (var item in this.controllerReaderCardFormats)
            {
                var newConfig = item.GetNewConfig();
                bool result = NewtonSoftHelper<CardFormatConfig>.SaveConfig(newConfig, PathManagement.laneControllerReaderConfigPath(this.laneId, settingController.controlUnitId, newConfig.ReaderIndex));
                if (!result)
                {
                    isSaveSuccess = false;
                }
            }
            if (!isSaveSuccess)
            {
                MessageBox.Show("Lưu thông tin cấu hình thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Lưu thông tin cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Private Function

        #endregion

        #region Public Function

        #endregion
    }
}
