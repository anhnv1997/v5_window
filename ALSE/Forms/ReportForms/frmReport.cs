using iParkingv5.Objects;
using IPGS.Controls.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSE
{
    public partial class frmReport : Form
    {
        #region FOrms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnSearch.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public frmReport()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
            cbEventType.SelectedIndex = cbEventStatus.SelectedIndex = 0;
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        }
        #endregion

        #region Controls In Form
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStartTime.Value > dtpEndTime.Value)
            {
                MessageBox.Show("Thời gian tìm kiếm Không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvData.Rows.Clear();
            string cmd = CreateCmd();
            DataTable dtData = null;
            await Task.Run(() =>
            {
                dtData = StaticPool.mdb.FillData(cmd);
            });
            if (dtData != null)
            {
                foreach (DataRow dr in dtData.Rows)
                {
                    string eventTime = dr["event_time"].ToString();
                    string cardNumber = dr["card_number"].ToString();
                    string customer = dr["customer_name"].ToString();
                    string eventType = dr["reader"].ToString() == "1" ? "VÀO" : "RA";
                    string eventStatus = (dr["is_valid"].ToString() == "1" || dr["is_valid"].ToString().ToLower() == "true") ?
                                                "Hợp Lệ" : "Không Lợp Lệ";
                    dgvData.Invoke(new Action(() =>
                    {
                        dgvData.Rows.Add(dgvData.RowCount + 1, eventTime, cardNumber, customer, eventType, eventStatus);
                    }));
                }
            }
        }
        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region private function
        private string CreateCmd()
        {
            string baseCmd = "SELECT * from tblEvent where";
            string condition = $" (event_time between '{dtpStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss")}' and '{dtpEndTime.Value.ToString("yyyy/MM/dd HH:mm:ss")}')";
            string order = " ORDER BY event_time DESC";
            if (!string.IsNullOrEmpty(txtCardNumber.Text))
            {
                condition += $" AND card_number LIKE '%{txtCardNumber.Text.ToUpper().Trim()}%'";
            }
            if (cbEventType.SelectedIndex != 0)
            {
                condition += $" AND reader = {cbEventType.SelectedIndex}";
            }
            if (cbEventStatus.SelectedIndex == 1)
            {
                condition += $" AND is_valid = 1";
            }
            else if (cbEventStatus.SelectedIndex == 2)
            {
                condition += $" AND is_valid = 0";
            }
            return baseCmd + condition + order;
        }
        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count ==0)
            {
                MessageBox.Show("Danh sách sự kiện trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExcelTools.CreatReportFile(dgvData, "Báo cáo sự kiện vào ra");
        }
    }
}
