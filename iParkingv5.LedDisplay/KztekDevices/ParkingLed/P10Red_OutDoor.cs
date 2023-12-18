using iParkingv5.LedDisplay.Behavior.ConnectBehavior;
using iParkingv5.LedDisplay.Enums;
using iParkingv5.LedDisplay.Interface.iCommand;
using iParkingv5.LedDisplay.Interface.iDevice;
using iParkingv5.LedDisplay.KztekDevices;
using iParkingv5.LedDisplay.Objects;
using System;
using System.Collections.Generic;

namespace KzLedLibraryv2.IpLed
{
    public class P10Red_OutDoor : GeneralIpLedController
    {
        public P10Red_OutDoor(string ipAddress, int port, EmModuleType modultType, string username = "", string password = "") : base(ipAddress, port, modultType, username, password)
        {
        }

        #region: Override
        public new iConnectBehavior ConnectBehavior { get; set; } = new IpConnectBehavior();
        public new iCMD CmdBehavior { get; set; } = new ip_v2_cmd_controller();
        #endregion: End Override

        #region: Implement
        public override bool ChangeDisplay(EmScreenType screen, Dictionary<int, LineConfig> datas, EmDisplayMode displayMode, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll = false)
        {
            foreach (var data in datas)
            {
                data.Value.DisplayColor = CheckColor(data.Value.DisplayColor);
            }
            return screen switch
            {
                EmScreenType.CurrentScreen => displayMode switch
                {
                    EmDisplayMode.ONE_COLOR_EACH_LINE => ChangeCurrentScreenSingleColor(datas),
                    EmDisplayMode.MULTY_COLOR_EACH_LINE => throw new Exception("Not Support"),
                    _ => throw new Exception("Invalid Display Mode"),
                },
                EmScreenType.DefaultScreen => throw new Exception("Not Support"),
                _ => throw new Exception("Invalid Screen Type"),
            };
        }

        public override void ChangeDisplayWithScroll(Dictionary<int, LineConfig> lineConfigs, List<string> scrollDatas, bool isScroll = false)
        {
            throw new NotImplementedException();
        }

        public override void Stop(bool a)
        {
            throw new NotImplementedException();
        }
        #endregion: End Implement

        #region: Private Func
        private bool ChangeCurrentScreenSingleColor(Dictionary<int, LineConfig> datas)
        {
            string[] cmds = CmdBehavior.SetCurrentScreenCmd(datas).Split("\r\n");
            bool isAllSuccess = true;
            foreach (string cmd in cmds)
            {
                if (!GeneralSetCmd(cmd))
                {
                    isAllSuccess = false;
                }
            }
            return isAllSuccess;
        }
        #endregion: End Private Func
    }
}
