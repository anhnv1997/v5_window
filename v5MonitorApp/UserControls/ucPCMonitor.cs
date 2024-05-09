using iPakrkingv5.Controls.Controls.Labels;
using iParkingv6.Objects.Datas;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using v5MonitorApp.Forms.DataForms;
using v5MonitorApp.Objects;

namespace v5MonitorApp.UserControls
{
    public partial class ucPCMonitor : UserControl, IDeviceMonitor
    {
        #region Constructor
        private Computer Computer;
        private CancellationTokenSource ctsUpdateKioskStatus;
        public event OnMonitorDeviceNewMessageEventHandler onMonitorDeviceNewMessageEvent;
        //0 mất kết nối, 1 có kết nối
        public enum EmDeviceStatus
        {
            Disconnect,
            OK
        }
        private EmDeviceStatus currentStatus = EmDeviceStatus.OK;
        #endregion End Constructor

        #region Forms
        public ucPCMonitor(Computer computer)
        {
            InitializeComponent();
            this.Computer = computer;
            toolTip1.SetToolTip(this, this.Computer.Name + " -OK" + "\r\n Kích đúp chuột phải để mở tính năng bổ sung");
            lblResult1.Message = this.Computer.Name;
            lblResult1.Text = "";
            lblResult1.MessageColor = Color.DarkGreen;
            lblResult1.Refresh();
            this.DoubleClick += UcPCMonitor_DoubleClick;
        }

        private void UcPCMonitor_DoubleClick(object? sender, EventArgs e)
        {
            PollingStop();
            (new frmPcDetail(this.Computer)).ShowDialog();
            PollingStart();
        }

        #endregion End Forms

        #region Controls In Form

        #endregion End Controls In Form

        #region Private Function
        private async Task UpdateStatusPolling(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    IPAddress[] ipAddressList = Dns.GetHostAddresses(this.Computer.IpAddress);
                    IPAddress ipAddress = null;
                    foreach (var ip in ipAddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork) // IPv4
                        {
                            Ping pingSender = new Ping();
                            PingReply reply = await pingSender.SendPingAsync(ip);

                            if (reply.Status == IPStatus.Success)
                            {
                                ipAddress = ip;
                                break;
                            }
                        }
                    }

                    if (ipAddress != null)
                    {
                        var LocalPort = 100;
                        var localEndPoint = new IPEndPoint(ipAddress, LocalPort);
                        var client = new TcpClient();
                        await client.ConnectAsync(localEndPoint);
                        if (client.Connected)
                        {
                            UpdateDeviceConnected();
                            client.Close();
                            client.Dispose();
                        }
                        else
                        {
                            updateDeviceDisconnected("Invalid Socket Connection");
                        }
                    }
                    else
                    {
                        updateDeviceDisconnected("Invalid Ip Address");
                    }
                }
                catch (Exception ex)
                {
                    updateDeviceDisconnected("Socket Connection Error: " + ex.Message);
                }
                finally
                {
                    await Task.Delay(15000);
                }
            }
        }
        private void updateDeviceDisconnected(string errorMessage)
        {
            this.Invoke(new Action(() =>
            {
                if (currentStatus == EmDeviceStatus.OK)
                {
                    currentStatus = EmDeviceStatus.Disconnect;
                    this.BackgroundImage = Properties.Resources.pc_error_64;
                    SetToolTip("Mất Kết Nối Thiết Bị, Bấm chuột phải để mở tính năng bổ sung");
                    onMonitorDeviceNewMessageEvent?.Invoke(this, new DeviceMessageEventArgs()
                    {
                        NotiTime = DateTime.Now,
                        DeviceId = this.Computer.Id,
                        DeviceName = this.Computer.Name,
                        IpAddress = this.Computer.IpAddress,
                        IsNormal = false,
                        Message = "Mất Kết Nối Thiết Bị " + errorMessage,
                    });
                    lblResult1.MessageColor = Color.DarkRed;
                    lblResult1.Refresh();
                }
            }));
        }
        private void UpdateDeviceConnected()
        {
            this.Invoke(new Action(() =>
            {
                if (currentStatus != EmDeviceStatus.OK)
                {
                    currentStatus = EmDeviceStatus.OK;
                    this.BackColor = SystemColors.Control;
                    SetToolTip("OK, Bấm chuột phải để mở tính năng bổ sung");
                    onMonitorDeviceNewMessageEvent?.Invoke(this, new DeviceMessageEventArgs()
                    {
                        NotiTime = DateTime.Now,
                        DeviceId = this.Computer.Id,
                        DeviceName = this.Computer.Name,
                        IpAddress = this.Computer.Name,
                        IsNormal = true,
                        Message = "",
                    });
                    this.BackgroundImage = Properties.Resources.pc_info_64;
                    lblResult1.MessageColor = Color.DarkGreen;
                    lblResult1.Refresh();
                }
            }));
        }
        public void SetToolTip(string message)
        {
            string toolTipMesssage = "Tên: " + this.Computer.Name + "\r\nTrạng Thái: " + message;
            toolTip1.SetToolTip(this, toolTipMesssage);
        }
        #endregion End Private Function

        #region Public Function
        public void PollingStart()
        {
            ctsUpdateKioskStatus = new CancellationTokenSource();
            Task.Run(() => UpdateStatusPolling(ctsUpdateKioskStatus.Token));
        }

        public void PollingStop()
        {
            ctsUpdateKioskStatus?.Cancel();
        }
        #endregion End Public Function
    }
}
