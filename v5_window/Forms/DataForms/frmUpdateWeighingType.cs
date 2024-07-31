using iParkingv5.ApiManager.KzScaleApis;
using iParkingv5.Objects;
using iParkingv5.Objects.Databases;
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
    public partial class frmUpdateWeighingType : Form
    {
        #region Properties
        private string id;
        #endregion

        #region Forms
        public frmUpdateWeighingType(string weighingActionID, string currentWeighingType)
        {
            InitializeComponent();
            this.id = weighingActionID;
            lblCurrentWeighingType.Text = currentWeighingType;
            this.Load += FrmUpdateWeighingType_Load;
        }

        private async void FrmUpdateWeighingType_Load(object? sender, EventArgs e)
        {
            await loadWeighingType();
        }
        #endregion

        #region Controls In Form
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string weightFormId = ((ListItem)cbWeighingType.SelectedItem)?.Name ?? "";
            if (string.IsNullOrEmpty(weightFormId))
            if (string.IsNullOrEmpty(weightFormId))
            {
                MessageBox.Show("Hãy chọn loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, StaticPool.user_name + $" Cập nhật loại hàng từ: " +
            $"                                      {lblCurrentWeighingType.Text} Sang {cbWeighingType.Text}");


            var response = await KzScaleApiHelper.UpdateWeighingActionDetailById(this.id, weightFormId);

            if (response == null)
            {
                MessageBox.Show("Gặp lỗi khi cập nhật thông tin lên hệ thống, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
                            cbWeighingType.Items.Insert(0, li);
                        }
                        else
                            cbWeighingType.Items.Add(li);
                    }
                    cbWeighingType.DisplayMember = "Value";
                    if (cbWeighingType.Items.Count > 0)
                    {
                        cbWeighingType.SelectedIndex = cbWeighingType.FindString("Xuất");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Public Function

        #endregion
    }
}
