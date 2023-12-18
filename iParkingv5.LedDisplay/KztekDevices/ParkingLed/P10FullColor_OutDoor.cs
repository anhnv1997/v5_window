using iParkingv5.LedDisplay.Behavior.ConnectBehavior;
using iParkingv5.LedDisplay.Enums;
using iParkingv5.LedDisplay.Interface.iCommand;
using iParkingv5.LedDisplay.Interface.iDevice;
using iParkingv5.LedDisplay.KztekDevices;
using iParkingv5.LedDisplay.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace KzLedLibraryv2.IpLed
{
    public class P10FullColor_OutDoor : GeneralIpLedController
    {
        public P10FullColor_OutDoor(string ipAddress, int port, EmModuleType modultType, string username = "", string password = "") : base(ipAddress, port, modultType, username, password)
        {
            LedController = this;
        }
        #region: Override
        public override iConnectBehavior ConnectBehavior { get; set; } = new IpConnectBehavior();
        public override iCMD CmdBehavior { get; set; } = new ip_v2_cmd_controller();
        #endregion: End Override

        #region: Implement
        public override bool ChangeDisplay(EmScreenType screen, Dictionary<int, LineConfig> datas, EmDisplayMode displayMode, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll = false)
        {
            this.IsStop = true;
            this.IsScroll = false;
            foreach (var data in datas)
            {
                data.Value.DisplayColor = CheckColor(data.Value.DisplayColor);
            }
            return screen switch
            {
                EmScreenType.CurrentScreen => displayMode switch
                {
                    EmDisplayMode.ONE_COLOR_EACH_LINE => ChangeCurrentScreenSingleColor(datas, mergeSettings, scrollSettings, isScroll),
                    EmDisplayMode.MULTY_COLOR_EACH_LINE => throw new Exception("Not Support"),
                    _ => throw new Exception("Invalid Display Mode"),
                },
                EmScreenType.DefaultScreen => throw new Exception("Not Support"),
                _ => throw new Exception("Invalid Screen Type"),
            };
        }
        private bool isStop = false;
        public bool IsStop { 
            get=> isStop;
            set
            {
                isStop = value;
            }
        }
        public bool IsHaveUpdateCountRequest { get; set; } = false;
        private bool isBusy = false;
        List<string> scrollDatas = new List<string>();
        List<string> updateScrollDatas = new List<string>();
        public bool IsUpdate { get; set; } = false;

        public override void ChangeDisplayWithScroll(Dictionary<int, LineConfig> lineConfigs, List<string> _scrollDatas, bool isUpdate = true)
        {
            this.IsScroll = true;

            if (!isUpdate)
            {
                this.scrollDatas = _scrollDatas;
            }
            else
            {
                this.updateScrollDatas = _scrollDatas;
                this.IsUpdate = true;
                return;
            }
            while (isBusy)
            {
                Thread.Sleep(10);
            }
            foreach (var lineConfig in lineConfigs)
            {
                lineConfig.Value.DisplayColor = CheckColor(lineConfig.Value.DisplayColor);
            }
            if (_scrollDatas.Count < lineConfigs.Count)
            {
                for (int i = 0; i < _scrollDatas.Count; i++)
                {
                    lineConfigs[i + 1].Data = _scrollDatas[i];
                }
                string[] cmds = CmdBehavior.SetCurrentScreenCmd(lineConfigs).Split("\r\n");
                foreach (string cmd in cmds)
                {
                    if (string.IsNullOrEmpty(cmd)) continue;
                    GeneralSetCmd(cmd);
                }
            }
            else
            {
                isBusy = true;
                IsStop = false;
                while (true)
                {
                    if (IsStop)
                    {
                        isBusy = false;
                        break;
                    }
                    else if (IsUpdate)
                    {
                        for (int i = 0; i < this.scrollDatas.Count; i++)
                        {
                            string scrollData = this.scrollDatas[i];
                            string[] productDetail = scrollData.Split(":");
                            if (productDetail.Length > 1)
                            {
                                foreach (string update in updateScrollDatas)
                                {
                                    string[] updateProductDetail = update.Split(":");
                                    if (updateProductDetail[0] == productDetail[0])
                                    {
                                        productDetail[1] = updateProductDetail[1];
                                        break;
                                    }
                                }
                            }
                            this.scrollDatas[i] = productDetail[0] + ":" + productDetail[1];
                        }
                        IsUpdate = false;
                    }
                    for (int i = 0; i < lineConfigs.Count; i++)
                    {
                        lineConfigs[i + 1].Data = this.scrollDatas[i];
                    }
                    string[] cmds = CmdBehavior.SetCurrentScreenCmd(lineConfigs).Split("\r\n");
                    foreach (string cmd in cmds)
                    {
                        if (string.IsNullOrEmpty(cmd)) continue;
                        GeneralSetCmd(cmd);
                    }
                    this.scrollDatas = ScrollDisplayList(this.scrollDatas);
                    Thread.Sleep(1000);
                };
            }
        }
        #endregion: End Implement

        #region: Private Func
        private bool ChangeCurrentScreenSingleColor(Dictionary<int, LineConfig> datas, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll = false)
        {
            string[] cmds = CmdBehavior.SetCurrentScreenCmd(datas).Split("\r\n");
            bool isAllSuccess = true;
            foreach (string cmd in cmds)
            {
                if (string.IsNullOrWhiteSpace(cmd)) continue;
                if (!GeneralSetCmd(cmd))
                {
                    isAllSuccess = false;
                }
            }
            return isAllSuccess;
        }

        public List<string> ScrollDisplayList(List<string> currentData)
        {
            string[] scrollDatas = new string[currentData.Count];
            for (int i = 0; i < currentData.Count; i++)
            {
                if (i < currentData.Count - 1)
                    scrollDatas[i] = currentData[i + 1];
                else
                {
                    scrollDatas[i] = currentData[0];
                }
            }
            return scrollDatas.ToList();
        }

        public override void Stop(bool isStop)
        {
            this.IsStop = isStop;
        }
        #endregion: End Private Func
    }
}
