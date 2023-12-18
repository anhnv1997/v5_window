using iParkingv5.LedDisplay.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Interface.iCommand
{
    public class ip_v1_cmd_controller : iCMD
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
            return $"SetScreenResolution?/Row={rowCount}/Col={columnCount}";
        }
        #endregion: End Resolution

        public string SetInvertDataPolarityCmd() => "SetInvertDataPolarity?/";

        #region: Default Screen
        //SetScreenDefault?/NumLine=2/Effect1=1/Speed1=5/FontSize1=10/Text1=<Colour1=1>Hẹn<Colour1=2>Gặp<Colour1=3>Lại/Effect2=3/Speed2=5/FontSize2=10/Text2=<Colour2=1>iParking
        public string SetScreenDefaultCmd(Dictionary<int, LineConfig> datas)
        {
            string cmd = "SetScreenDefault?/";
            cmd += "/NumLine=" + datas.Count;

            if (!CheckDictionaryFormat(datas))
            {
                throw new Exception("Wrong Line Config Format - Invalid Line");
            }
            for (int i = 0; i < datas.Count; i++)
            {
                int lineIndex = i + 1;
                int effect = (int)datas[lineIndex].Effect;
                int speed = datas[lineIndex].Speed;
                int fontsize = datas[lineIndex].FontSize;
                int color = (int)datas[lineIndex].DisplayColor;
                cmd += "/Effect" + lineIndex + "=" + effect;
                cmd += "/Speed" + lineIndex + "=" + speed;
                cmd += "/FontSize" + lineIndex + "=" + fontsize;
                cmd += "/Text" + lineIndex + "=";
                cmd += "<Colour" + lineIndex + "=" + color + ">";
                cmd += datas[lineIndex].Data;
            }
            return cmd;
        }
        public string SetScreenDefaultMultyColorCmd(Dictionary<int, LineConfig> datas)
        {
            string cmd = "SetScreenDefault?/";
            cmd += "/NumLine=" + datas.Count;

            if (!CheckDictionaryFormat(datas))
            {
                throw new Exception("Wrong Line Config Format - Invalid Line");
            }
            for (int i = 0; i < datas.Count; i++)
            {
                int lineIndex = i + 1;
                int effect = (int)datas[lineIndex].Effect;
                int speed = datas[lineIndex].Speed;
                int fontsize = datas[lineIndex].FontSize;
                cmd += "/Effect" + lineIndex + "=" + effect;
                cmd += "/Speed" + lineIndex + "=" + speed;
                cmd += "/FontSize" + lineIndex + "=" + fontsize;
                cmd += "/Text" + lineIndex + "=";
                foreach (var data in datas[lineIndex].MultyColorDatas)
                {
                    int color = (int)data.Item1;
                    string displayText = data.Item2;
                    cmd += "<Colour" + lineIndex + "=" + color + ">" + displayText;
                }
            }
            return cmd;
        }
        public string ReturnDefaultScreenCmd() => "ReturnDefaultScreen?/";
        #endregion: End Default Screen

        #region: Current Screen
        public string SetCurrentScreenCmd(Dictionary<int, LineConfig> datas)
        {
            string cmd = "SetScreenCurrent?";
            cmd += "/NumLine=" + datas.Count;

            if (!CheckDictionaryFormat(datas))
            {
                throw new Exception("Wrong Line Config Format - Invalid Line");
            }
            for (int i = 0; i < datas.Count; i++)
            {
                int lineIndex = i + 1;
                int effect = (int)datas[lineIndex].Effect;
                int speed = datas[lineIndex].Speed == 0 ? 5 : datas[lineIndex].Speed;
                int fontsize = datas[lineIndex].FontSize;
                string data = datas[lineIndex].Data;
                int color = (int)datas[lineIndex].DisplayColor;
                cmd += "/Effect" + lineIndex + "=" + effect;
                cmd += "/Speed" + lineIndex + "=" + speed;
                cmd += "/FontSize" + lineIndex + "=" + fontsize;
                cmd += "/Text" + lineIndex + "=";
                cmd += "<Colour" + lineIndex + "=" + color + ">";
                cmd += data;

            }
            return cmd;
        }
        public string SetCurrenScreenMultyColorCmd(Dictionary<int, LineConfig> datas)
        {
            string cmd = "SetScreenCurrent?/";
            cmd += "/NumLine=" + datas.Count;

            if (!CheckDictionaryFormat(datas))
            {
                throw new Exception("Wrong Line Config Format - Invalid Line");
            }
            for (int i = 0; i < datas.Count; i++)
            {
                int lineIndex = i + 1;
                int effect = (int)datas[lineIndex].Effect;
                int speed = datas[lineIndex].Speed;
                int fontsize = datas[lineIndex].FontSize;
                cmd += "/Effect" + lineIndex + "=" + effect;
                cmd += "/Speed" + lineIndex + "=" + speed;
                cmd += "/FontSize" + lineIndex + "=" + fontsize;
                cmd += "/Text" + lineIndex + "=";
                foreach (var data in datas[lineIndex].MultyColorDatas)
                {
                    int color = (int)data.Item1;
                    string displayText = data.Item2;
                    cmd += "<Colour" + lineIndex + "=" + color + ">" + displayText;
                }
            }
            return cmd;
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
