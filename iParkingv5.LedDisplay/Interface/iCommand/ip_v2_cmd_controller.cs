using iParkingv5.LedDisplay.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static iParkingv5.LedDisplay.Enums.LedColors;

namespace iParkingv5.LedDisplay.Interface.iCommand
{
    public class ip_v2_cmd_controller : iCMD
    {
        #region: System Infor
        public string GetFirmwareVersionCmd() => "GetFirmwareVersion?/";
        public string ResetDefaultCmd() => "ResetDefault?/";
        #endregion: End System Infor

        #region: Module Type
        public string GetModuleTypeCmd() => "GetModuleType?/";
        public string SetModuleTypeCmd(EmModuleType moduleType)
        {
            string defaultCmd = "SetModuleType?/ModuleType=";
            switch (moduleType)
            {
                case EmModuleType.P10FullColor:
                case EmModuleType.P10FullColor_Outdoor:
                    return defaultCmd + "1";
                case EmModuleType.P10Red:
                case EmModuleType.P10Red_Outdoor:
                    return defaultCmd + "2";
                case EmModuleType.P7_62_RGY:
                case EmModuleType.P10_RG_OutDoor:
                    return defaultCmd + "3";
                default:
                    throw new Exception("Not Support");

            }
        }
        #endregion: End Module type

        #region: Resolution
        public string GetResolutionCmd() => "GetScreenResolution?/";
        public string SetResolutionCmd(int numberOfLine, int rowCount, int columnCount)
        {
            return $"SetScreenResolution?/NumOfLine={numberOfLine}/Row={rowCount}/Col={columnCount}";
        }
        #endregion: End Resolution

        public string SetInvertDataPolarityCmd() => "SetInvertDataPolarity?/";

        #region: Default Screen
        //SetScreenDefault?/NumLine=2/Effect1=1/Speed1=5/FontSize1=10/Text1=<Colour1=1>Hẹn<Colour1=2>Gặp<Colour1=3>Lại/Effect2=3/Speed2=5/FontSize2=10/Text2=<Colour2=1>iParking
        public string SetScreenDefaultCmd(Dictionary<int, LineConfig> datas)
        {
            throw new Exception("NOT SUPPORTED");
        }
        public string SetScreenDefaultMultyColorCmd(Dictionary<int, LineConfig> datas)
        {
            throw new Exception("NOT SUPPORTED");
        }
        public string ReturnDefaultScreenCmd() => "ReturnDefaultScreen?/";
        #endregion: End Default Screen

        #region: Current Screen
        public string SetCurrentScreenCmd(Dictionary<int, LineConfig> datas)
        {
            //SetLineCurrent?/Line=1/FontSize=10/Text=<Colour=1>0312
            string cmd = ""; ;
            if (!CheckDictionaryFormat(datas))
            {
                throw new Exception("Wrong Line Config Format - Invalid Line");
            }
            for (int i = 0; i < datas.Count; i++)
            {

                cmd += "SetLineCurrent?";
                int lineIndex = i + 1;
                int fontsize = datas[lineIndex].FontSize;
                int color = 0;
                switch (datas[lineIndex].DisplayColor)
                {
                    case EmLedColor.RED:
                        color = 1;
                        break;
                    case EmLedColor.GREEN:
                        color = 2;
                        break;
                    case EmLedColor.YELLOW:
                        color = 3;
                        break;
                    case EmLedColor.BLUE:
                        color = 4;
                        break;
                    case EmLedColor.PURPLE:
                        color = 5;
                        break;
                    case EmLedColor.GREEN_BLUE:
                        color = 6;
                        break;
                    case EmLedColor.WHITE:
                        color = 7;
                        break;
                }
                cmd += "/Line=" + lineIndex;
                cmd += "/FontSize=" + fontsize;
                cmd += "/Text=";
                cmd += "<Colour=" + color + ">";
                cmd += datas[lineIndex].Data;
                cmd += "\r\n";
            }
            return cmd;
        }
        public string SetCurrenScreenMultyColorCmd(Dictionary<int, LineConfig> datas)
        {
            throw new Exception("NOT SUPPORTED");
        }
        #endregion: End Current Screen

        #region: Network Infor
        public string AutoDetectCmd() => "AutoDetect?";
        public string ChangeNetworkInfor(string ipAddress, string subnetMask, string defaultGateway, string macAddress)
        {
            return $"ChangeIP?/IP={ipAddress}/SubnetMask={subnetMask}/DefaultGateWay={defaultGateway}/HostMac={macAddress}/";
        }
        public string ChangeMacAddressCmd(string macAddress)
        {
            return "ChangeMacAddress?/Mac=" + macAddress;
        }
        #endregion: End Network Infor

        private bool CheckDictionaryFormat(Dictionary<int, LineConfig> datas)
        {
            for (int i = 0; i < datas.Count; i++)
            {
                if (!datas.ContainsKey(i + 1))
                {
                    return false;
                }
            }
            return true;
        }
    }

}
