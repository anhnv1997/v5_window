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
    public class P10FullColor_v1 : GeneralIpLedController
    {
        public P10FullColor_v1(string ipAddress, int port, EmModuleType modultType, string username = "", string password = "") : base(ipAddress, port, modultType, username, password)
        {
        }

        #region: Override
        public new iConnectBehavior ConnectBehavior { get; set; } = new IpConnectBehavior();
        public new iCMD CmdBehavior { get; set; } = new ip_v1_cmd_controller();
        #endregion: End Override

        #region: Implement
        public override bool ChangeDisplay(EmScreenType screen, Dictionary<int, LineConfig> datas, EmDisplayMode displayMode, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll =false)
        {
            foreach (var data in datas)
            {
                data.Value.DisplayColor = CheckColor(data.Value.DisplayColor);
            }
            return screen switch
            {
                EmScreenType.CurrentScreen => displayMode switch
                {
                    EmDisplayMode.ONE_COLOR_EACH_LINE => ChangeCurrentScreenSingleColor(datas, mergeSettings, scrollSettings, isScroll),
                    EmDisplayMode.MULTY_COLOR_EACH_LINE => ChangeCurrentScreenMultipleColor(datas),
                    _ => throw new Exception("Invalid Display Mode"),
                },
                EmScreenType.DefaultScreen => displayMode switch
                {
                    EmDisplayMode.ONE_COLOR_EACH_LINE => ChangeDefaultScreenSingleColor(datas),
                    EmDisplayMode.MULTY_COLOR_EACH_LINE => ChangeDefaultScreenMultipleColor(datas),
                    _ => throw new Exception("Invalid Display Mode"),
                },
                _ => throw new Exception("Invalid Screen Type"),
            };
        }
        #endregion: End Implement

        #region: Private Func
        private bool ChangeCurrentScreenSingleColor(Dictionary<int, LineConfig> datas, List<MergeSetting> mergeSettings, List<ScrollSetting> scrollSettings, bool isScroll = false)
        {
            string cmd = CmdBehavior.SetCurrentScreenCmd(datas);
            return GeneralSetCmd(cmd);
        }
        private bool ChangeCurrentScreenMultipleColor(Dictionary<int, LineConfig> datas)
        {
            string cmd = CmdBehavior.SetCurrenScreenMultyColorCmd(datas);
            return GeneralSetCmd(cmd);
        }
        private bool ChangeDefaultScreenSingleColor(Dictionary<int, LineConfig> datas)
        {
            string cmd = CmdBehavior.SetScreenDefaultCmd(datas);
            return GeneralSetCmd(cmd);
        }
        private bool ChangeDefaultScreenMultipleColor(Dictionary<int, LineConfig> datas)
        {
            string cmd = CmdBehavior.SetScreenDefaultMultyColorCmd(datas);
            return GeneralSetCmd(cmd);
        }

        public override void ChangeDisplayWithScroll(Dictionary<int, LineConfig> lineConfigs, List<string> scrollDatas, bool isScroll = false)
        {
            throw new NotImplementedException();
        }

        public override void Stop(bool a)
        {
        }
        #endregion: End Private Func

    }
}
