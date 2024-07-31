using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.Devices;
using iParkingv5.Objects.ScaleObjects;
using Kztek.Tool.TextFormatingTools;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmScaleManual : Form
    {
        #region Properties
        private string eventInId;
        private string plateNumber;
        private List<string> imageKeys = new List<string>();
        #endregion

        #region Forms
        public frmScaleManual(string eventInId, string plateNumber, List<string> imageKeys)
        {
            InitializeComponent();
            this.eventInId = eventInId;
            this.plateNumber = plateNumber;
            this.imageKeys = imageKeys;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            this.Load += FrmScaleManual_Load;
        }
        private async void FrmScaleManual_Load(object? sender, EventArgs e)
        {
            dtpScaleTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            await loadWeighingType();
            loadLaneType();
        }
        #endregion

        #region Controls In Form
        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            string weightFormId = ((ListItem)cbGoodsType.SelectedItem)?.Name ?? "";
            if (string.IsNullOrEmpty(weightFormId))
            {
                MessageBox.Show("Hãy chọn loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string laneId = ((ListItem)cbLane.SelectedItem)?.Name ?? "";
            if (string.IsNullOrEmpty(weightFormId))
            {
                MessageBox.Show("Hãy chọn làn cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int weight = (int)numScale.Value;
            bool isConfirm = true;
            if (weight <= 0)
            {
                isConfirm = MessageBox.Show("Trọng lượng < 0, bạn có xác nhận lưu thông tin", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
            }
            if (!isConfirm)
            {
                return;
            }
            LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, StaticPool.user_name + $" Cân thủ công cho phương tiện: " +
                $"                                      {this.plateNumber},  EventId: {this.eventInId}, Scale: {weight}, LaneId: {laneId}, Time: {dtpScaleTime.Value}");
            var WeighingActionDetail = await KzScaleApiHelper.CreateScaleEvent(this.plateNumber ?? "", this.eventInId ?? "",
                                                                                weight, weightFormId,
                                                                                StaticPool.userId, StaticPool.user_name, this.imageKeys, "", laneId,
                                                                                dtpScaleTime.Value.AddHours(-7));
            if (WeighingActionDetail != null && WeighingActionDetail.Id != Guid.Empty.ToString() && !string.IsNullOrEmpty(WeighingActionDetail.Id))
            {
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Thêm thông tin không thành công, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void CbGoodsType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (this.weighingTypes != null)
            {
                foreach (var item in this.weighingTypes)
                {
                    if (item.Name == cbGoodsType.Text)
                    {
                        lblScaleFee.Text = TextFormatingTool.GetMoneyFormat(item.Price.ToString());
                    }
                }
            }
        }
        #endregion

        #region Private Function
        List<WeighingType> weighingTypes = new List<WeighingType>();
        private async Task loadWeighingType()
        {
            try
            {
                weighingTypes = await KzScaleApiHelper.GetWeighingForms();
                if (weighingTypes != null)
                {

                    foreach (var item in weighingTypes)
                    {
                        ListItem li = new ListItem()
                        {
                            Name = item.Id,
                            Value = item.Name,
                        };
                        if (item.Price == 0)
                        {
                            cbGoodsType.Items.Insert(0, li);
                        }
                        else
                            cbGoodsType.Items.Add(li);
                    }
                    cbGoodsType.DisplayMember = "Value";
                    cbGoodsType.SelectedIndexChanged += CbGoodsType_SelectedIndexChanged;
                    if (cbGoodsType.Items.Count > 0)
                    {
                        cbGoodsType.SelectedIndex = cbGoodsType.FindString("Xuất");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void loadLaneType()
        {
            foreach (Lane lane in StaticPool.lanes)
            {
                ListItem item = new ListItem()
                {
                    Name = lane.id,
                    Value = lane.name,
                };
                cbLane.Items.Add(item);
            }
            cbLane.DisplayMember = "Value";
            cbLane.ValueMember = "Name";
            if (cbLane.Items.Count > 0)
            {
                cbLane.SelectedIndex = 0;
            }
        }
        #endregion
    }
}
