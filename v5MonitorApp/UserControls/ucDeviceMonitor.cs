using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using v5MonitorApp.Objects;

namespace v5MonitorApp.UserControls
{
    public partial class ucDeviceMonitor<T> : UserControl where T : Control
    {
        ucGridview<T> uc;
        public ucDeviceMonitor(List<T> children, int maxCrossAxisExtent, double childAspectRatio, int crossAxisSpacing, int mainAxisSpacing, int padding = 10)
        {
            InitializeComponent();
            uc = new ucGridview<T>(children, maxCrossAxisExtent, childAspectRatio, crossAxisSpacing, mainAxisSpacing, padding);
            panelGridView.Controls.Add(uc);
            uc.onMonitorDeviceNewMessageEvent += Uc_onMonitorDeviceNewMessageEvent;
            uc.Dock = DockStyle.Fill;
            panelGridView.AutoScroll = true;
            chbAutoSize.CheckedChanged += ChbAutoSize_CheckedChanged;
        }

        private void ChbAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAutoSize.Checked)
            {
                if (dgvAbnormalStatus.PreferredSize.Height < Screen.PrimaryScreen.Bounds.Height - 300)
                {
                    dgvAbnormalStatus.Height = dgvAbnormalStatus.PreferredSize.Height;
                }
                else
                {
                    dgvAbnormalStatus.Height = Screen.PrimaryScreen.Bounds.Height - 300;
                }
            }
            else
            {
                dgvAbnormalStatus.Height = 300;
            }
        }
        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            dgvAbnormalStatus.DefaultCellStyle.Font = new Font(dgvAbnormalStatus.DefaultCellStyle.Font.Name, (int)numFontSize.Value, dgvAbnormalStatus.DefaultCellStyle.Font.Style);
            dgvAbnormalStatus.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAbnormalStatus.DefaultCellStyle.Font.Name, (int)numFontSize.Value + 4, FontStyle.Bold);
        }

        public void PollingStart()
        {
            uc.PollingStart();
        }
        public void PollingStop()
        {
            uc.PollingStop();
        }
        private void Uc_onMonitorDeviceNewMessageEvent(object sender, DeviceMessageEventArgs deviceMessageEventArgs)
        {
            dgvAbnormalStatus?.Invoke(new Action(() =>
            {
                string id = deviceMessageEventArgs.DeviceId;
                if (!deviceMessageEventArgs.IsNormal)
                {
                    bool isValid = false;
                    foreach (DataGridViewRow row in dgvAbnormalStatus.Rows)
                    {
                        string checkID = row.Cells[0].Value.ToString();
                        if (checkID == id)
                        {
                            //Cập nhật nội dung
                            row.Cells[row.Cells.Count - 1].Value = deviceMessageEventArgs.Message;
                            row.Cells[2].Value = deviceMessageEventArgs.NotiTime.ToString("HH:mm:ss");
                            isValid = true;
                            break;
                        }
                    }
                    //Thêm mới nếu chưa có
                    if (!isValid)
                    {
                        dgvAbnormalStatus.Rows.Add(id,
                                                   dgvAbnormalStatus.Rows.Count + 1,
                                                   deviceMessageEventArgs.NotiTime.ToString("HH:mm:ss"),
                                                   deviceMessageEventArgs.DeviceName,
                                                   deviceMessageEventArgs.Message);
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvAbnormalStatus.Rows)
                    {
                        string checkID = row.Cells[0].Value.ToString();
                        if (checkID == id)
                        {
                            dgvAbnormalStatus.Rows.Remove(row);
                            break;
                        }
                    }
                }
                if (chbAutoSize.Checked)
                {
                    dgvAbnormalStatus.Height = dgvAbnormalStatus.PreferredSize.Height;
                }
                uc.Focus();
            }));
        }

        private void chbDIsplayGridview_CheckedChanged(object sender, EventArgs e)
        {
            dgvAbnormalStatus.Visible = chbDIsplayGridview.Checked;
        }
    }
}