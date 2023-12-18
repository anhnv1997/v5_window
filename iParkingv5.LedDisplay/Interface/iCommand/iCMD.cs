using iParkingv5.LedDisplay.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.LedDisplay.Interface.iCommand
{
    public interface iCMD
    {
        #region: System Infor
        string GetFirmwareVersionCmd();
        string ResetDefaultCmd();
        #endregion: End System Infor

        #region: Module Type
        string GetModuleTypeCmd();
        string SetModuleTypeCmd(EmModuleType moduleType);
        #endregion: End Module type

        #region: Resolution
        string GetResolutionCmd();
        string SetResolutionCmd(int numberOfLine, int rowCount, int columnCount);
        #endregion: End Resolution

        string SetInvertDataPolarityCmd();

        #region: Default Screen
        string SetScreenDefaultCmd(Dictionary<int, LineConfig> datas);
        string SetScreenDefaultMultyColorCmd(Dictionary<int, LineConfig> datas);
        string ReturnDefaultScreenCmd();
        #endregion: End Default Screen

        #region: Current Screen
        string SetCurrentScreenCmd(Dictionary<int, LineConfig> datas);
        string SetCurrenScreenMultyColorCmd(Dictionary<int, LineConfig> datas);
        #endregion: End Current Screen

        #region: Network Infor
        string AutoDetectCmd();
        string ChangeNetworkInfor(string ipAddress, string subnetMask, string defaultGateway, string macAddress);
        string ChangeMacAddressCmd(string macAddress);
        #endregion: End Network Infor
    }
}
