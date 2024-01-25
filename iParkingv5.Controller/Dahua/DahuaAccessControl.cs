using DahuaLib.DahuaFuntion;
using iParkingv5.Controller.KztekDevices;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using Kztek.Tool.NetworkTools;
using Kztek.Tool.SocketHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static iParkingv5.Objects.Enums.CommunicationTypes;

namespace iParkingv5.Controller.Dahua
{
    public class DahuaAccessControl : IController
    {
        private IntPtr m_LoginID;
        private bool m_IsListen = false;
        private static fDisConnectCallBack? m_DisConnectCallBack;//断线回调
        private static fHaveReConnectCallBack? m_ReConnectCallBack;//重连回调
        public static fMessCallBackEx? m_AlarmCallBack; //报警回调

        const string TimeFormat = "yyyyMMddHHmmss";


        public Bdk ControllerInfo { get; set; }

        public DahuaAccessControl()
        {
            m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
            m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
            m_AlarmCallBack = new fMessCallBackEx(AlarmCallBack);
        }
        #region Event
        public event CardEventHandler? CardEvent;
        public event ControllerErrorEventHandler? ErrorEvent;
        public event InputEventHandler? InputEvent;
        public event ConnectStatusChangeEventHandler? ConnectStatusChangeEvent;
        public event DeviceInfoChangeEventHandler? DeviceInfoChangeEvent;
        public void PollingStart()
        {
            NETClient.SetDVRMessCallBack(m_AlarmCallBack, IntPtr.Zero);

            bool ret = NETClient.StartListen(m_LoginID);
            m_IsListen = true;

        }
        public void PollingStop()
        {
            bool ret = NETClient.StopListen(m_LoginID);
        }
        public void DeleteCardEvent()
        {
        }

        public async Task<bool> OpenDoor(int timeInMilisecond, int relayIndex)
        {
            return false;
        }
        #endregion End Event

        #region: CONNECT
        public async Task<bool> TestConnectionAsync()
        {
            if (CommunicationTypes.IS_TCP((EM_CommunicationType)(this.ControllerInfo.communicationType)))
            {
                if (NetWorkTools.IsPingSuccess(this.ControllerInfo.comport, 500))
                {
                    NET_DEVICEINFO_Ex deviceInfo = new NET_DEVICEINFO_Ex();
                    string ip = this.ControllerInfo.comport;
                    ushort port = ushort.Parse(this.ControllerInfo.baudrate);
                    string username = "admin";
                    string password = "admin";
                    m_LoginID = NETClient.LoginWithHighLevelSecurity(ip, port, username, password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);

                    this.ControllerInfo.isConnect = m_LoginID != IntPtr.Zero;
                    return this.ControllerInfo.isConnect;
                }
            }
            return false;
        }
        public async Task<bool> ConnectAsync()
        {
            return await this.TestConnectionAsync();
        }
        public async Task<bool> DisconnectAsync()
        {
            if (m_IsListen)
            {
                NETClient.StopListen(m_LoginID);
            }
            if (IntPtr.Zero != m_LoginID)
            {
                NETClient.Logout(m_LoginID);
            }

            m_LoginID = IntPtr.Zero;
            return true;
        }
        #endregion: END CONNECT

        #region DATE - TIME
        public async Task<DateTime> GetDateTime()
        {
            return DateTime.MinValue;
        }
        public async Task<bool> SetDateTime(DateTime time)
        {
            return false;
        }
        public async Task<bool> SyncDateTime()
        {
            return await SetDateTime(DateTime.Now);
        }
        #endregion END DATE - TIME

        #region:TCP_IP
        //GET
        public async Task<string> GetIPAsync()
        {
            return string.Empty;
        }
        public async Task<string> GetMacAsync()
        {
            return string.Empty;
        }
        public async Task<string> GetDefaultGatewayAsync()
        {
            return string.Empty;
        }

        public async Task<int> GetPortAsync()
        {
            return 37777;
        }
        public async Task<string> GetComkeyAsync()
        {
            return string.Empty;
        }
        //SET
        public async Task<bool> SetMacAsync(string macAddr)
        {
            return false;
        }
        public async Task<bool> SetNetWorkInforAsync(string ip, string subnetMask, string defaultGateway, string macAddr)
        {
            return false;
        }
        public async Task<bool> SetComKeyAsync(string comKey)
        {
            return false;
        }
        #endregion: END TCP_IP

        #region System
        public async Task<bool> ClearMemory()
        {
            return true;
        }
        public async Task<bool> RestartDevice()
        {
            return true;
        }
        public async Task<bool> ResetDefault()
        {
            return true;
        }
        #endregion End System

        #region CallBack 回调
        public void Init()
        {


            try
            {
                NETClient.Init(m_DisConnectCallBack, IntPtr.Zero, null);
                NETClient.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void DisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            this.ControllerInfo.isConnect = false;
        }

        private void ReConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            this.ControllerInfo.isConnect = true;
        }

        private bool AlarmCallBack(int lCommand, IntPtr lLoginID, IntPtr pBuf, uint dwBufLen, IntPtr pchDVRIP, int nDVRPort, bool bAlarmAckFlag, int nEventID, IntPtr dwUser)
        {
            EM_ALARM_TYPE type = (EM_ALARM_TYPE)lCommand;
            switch (type)
            {
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_EVENT:
                    NET_ALARM_ACCESS_CTL_EVENT_INFO access_info = (NET_ALARM_ACCESS_CTL_EVENT_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_EVENT_INFO));

                    if (access_info.emOpenMethod == EM_ACCESS_DOOROPEN_METHOD.FINGERPRINT)
                    {
                        int userId = 0;
                        try
                        {
                            userId = int.Parse(Encoding.Default.GetString(access_info.szUserID));

                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    else
                    {
                        string cardNumber = access_info.szCardNo.ToString();
                        CallCardEvent(this.ControllerInfo, cardNumber, 1);
                    }

                    break;
                default:
                    break;
            }

            return true;
        }
        private void CallCardEvent(Bdk controller, string cardNumber, int readerIndex)
        {
            CardEventArgs e = new CardEventArgs
            {
                DeviceId = controller.id,
                AllCardFormats = new List<string>(),
            };
            string cardNumberHEX = cardNumber;
            if (!string.IsNullOrEmpty(cardNumberHEX))
            {
                e.AllCardFormats.Add(cardNumberHEX);

                if (cardNumberHEX.Length == 6)
                {
                    string maTruocToiGian = long.Parse(cardNumberHEX, NumberStyles.HexNumber).ToString();
                    string maTruocFull = Convert.ToInt64(cardNumberHEX, 16).ToString("0000000000");

                    string maSauFormat1 = int.Parse(cardNumberHEX.Substring(0, 2), NumberStyles.HexNumber).ToString("000") +
                                          int.Parse(cardNumberHEX.Substring(2, 4), NumberStyles.HexNumber).ToString("00000");

                    string maSauFormat2 = int.Parse(cardNumberHEX.Substring(0, 2), NumberStyles.HexNumber).ToString("000") + ":" +
                                          int.Parse(cardNumberHEX.Substring(2, 4), NumberStyles.HexNumber).ToString("00000");

                    string maSauFormat3 = int.Parse(cardNumberHEX.Substring(0, 2), NumberStyles.HexNumber).ToString() + ":" +
                      int.Parse(cardNumberHEX.Substring(2, 4), NumberStyles.HexNumber).ToString("");

                    e.PreferCard = maSauFormat3;

                    e.AllCardFormats.Add(maTruocToiGian);
                    if (maTruocToiGian != maTruocFull)
                    {
                        e.AllCardFormats.Add(maTruocFull);
                    }
                    e.AllCardFormats.Add(maSauFormat1);
                    e.AllCardFormats.Add(maSauFormat2);
                }
                else
                {
                    string maInt = Convert.ToInt64(cardNumberHEX, 16).ToString();
                    e.PreferCard = maInt;
                    e.AllCardFormats.Add(maInt);
                }
            }
            //string str_readerIndex = map.ContainsKey("reader") ? map["reader"] : "";
            e.ReaderIndex = readerIndex;
            this.CardEvent?.Invoke(this, e);
        }

        public async Task<bool> AddFinger(List<string> fingerDatas)
        {
            return false;
        }

        public async Task<bool> ModifyFInger(string userId, int fingerIndex, string fingerData)
        {
            return false;
        }

        public async Task<bool> DeleteFinger(string userId, int fingerIndex)
        {
            return false;
        }

        #endregion
    }
}