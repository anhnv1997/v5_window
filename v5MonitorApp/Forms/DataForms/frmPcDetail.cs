using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kztek.Tool.NetworkTools;
using System.Net.NetworkInformation;
using iParkingv5.Objects.Datas.Devices;

namespace v5MonitorApp.Forms.DataForms
{
    public partial class frmPcDetail : Form
    {
        #region Constructor
        private Computer Computer;
        #endregion End Constructor

        #region Forms
        public frmPcDetail(Computer computer)
        {
            InitializeComponent();
            this.Computer = computer;
            lblResult1.Message = this.Computer.IpAddress;
            lblResult1.MessageColor = Color.Black;
            lblResult1.Text = "";

            toolTipBtnCheckVersion.SetToolTip(btnGetVersion, "Bấm để lấy thông tin phiên bản phần mềm đang sử dụng");
            toolTipBtnCheckForUpdate.SetToolTip(btnCheckForUpdate, "Bấm để kiểm tra thông tin bản cập nhật");
            toolTipBtnRestart.SetToolTip(btnRestart, "Bấm để ra lệnh khởi động lại phần mềm");
            toolTipBtnClean.SetToolTip(btnClear, "Bấm để ra lệnh dọn dẹp dữ liệu (log và các bản update cũ)");
            toolTipBtnSupport.SetToolTip(btnSupport, "Bấm để tải log hệ thống");

            this.Load += FrmPcDetail_Load;
        }

        private async void FrmPcDetail_Load(object? sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(this.Computer.IpAddress);
                var ip = IPAddress.Parse(this.Computer.IpAddress);
                var LocalPort = 100;
                var localEndPoint = new IPEndPoint(ip, LocalPort);
                var client = new TcpClient();
                await client.ConnectAsync(localEndPoint);
                if (client.Connected)
                {
                    UpdateConnectStatus();
                    client.Close();
                    client.Dispose();
                }
                else
                {
                    UpdateDisconnectStatus();
                }
                //}
                //else
                //{
                //    UpdateDisconnectStatus();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateDisconnectStatus();
            }
            finally
            {
                await Task.Delay(15000);
            }
        }
        #endregion End Forms

        #region Controls In Form
        private async void btnGetVersion_Click(object sender, EventArgs e)
        {
            btnGetVersion.Enabled = false;
            try
            {
                await SendCmd("GetVersion?/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateDisconnectStatus();
            }
            finally
            {
                btnGetVersion.Enabled = true;
            }
        }

        private async void btnCheckForUpdate_Click(object sender, EventArgs e)
        {
            btnCheckForUpdate.Enabled = false;
            try
            {
                await SendCmd("CheckUpdate?/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateDisconnectStatus();
            }
            finally
            {
                btnCheckForUpdate.Enabled = true;
            }
        }

        private async void btnRestart_Click(object sender, EventArgs e)
        {
            btnRestart.Enabled = false;
            try
            {
                await SendCmd("RestartSoftware?/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateDisconnectStatus();
            }
            finally
            {
                btnRestart.Enabled = true;
            }
        }

        private async void btnSupport_Click(object sender, EventArgs e)
        {
            btnSupport.Enabled = false;
            try
            {
                await SendCmd($"Support?/{DateTime.Now}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateDisconnectStatus();
            }
            finally
            {
                btnSupport.Enabled = true;
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            btnClear.Enabled = false;
            try
            {
                await SendCmd($"ClearLog?/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UpdateDisconnectStatus();
            }
            finally
            {
                btnClear.Enabled = true;
            }
        }
        #endregion End Controls In form

        #region Private Function
        private async Task SendCmd(string cmd)
        {
            var ip = IPAddress.Parse(this.Computer.IpAddress);
            var LocalPort = 100;
            var localEndPoint = new IPEndPoint(ip, LocalPort);
            var client = new TcpClient();
            await client.ConnectAsync(localEndPoint);
            if (client.Connected)
            {
                lblResult1.Message = this.Computer.IpAddress;
                // Get a network stream for sending and receiving data
                using (NetworkStream stream = client.GetStream())
                {
                    // Message to send
                    string message = cmd;
                    // Convert the message to bytes
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    // Send the data
                    stream.Write(data, 0, data.Length);

                    // Receive response
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    UpdateConnectStatus();
                    MessageBox.Show(response);
                }

                client.Close();
                client.Dispose();
                //}
                //else
                //{
                //    UpdateDisconnectStatus();
                //}
            }
            else
            {
                UpdateDisconnectStatus();
            }
        }
        private void UpdateDisconnectStatus()
        {
            this.Invoke(new Action(() =>
            {
                lblResult1.Message = this.Computer.IpAddress + " - Mất kết nối";
                lblResult1.MessageColor = Color.DarkRed;
                lblResult1.Refresh();
            }));
        }
        private void UpdateConnectStatus()
        {
            this.Invoke(new Action(() =>
            {
                lblResult1.Message = this.Computer.IpAddress;
                lblResult1.MessageColor = Color.DarkGreen;
                lblResult1.Refresh();
            }));
        }
        #endregion End Private Function

        #region Public Function

        #endregion End Public Function       


    }
}
