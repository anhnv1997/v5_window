//using iParkingv5.Objects.Configs;
//using Kztek.Scale_net6.Objects;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO.Ports;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static iParkingv5.Objects.Enums.PrintHelpers;
//using static Kztek.Scale_net6.Objects.ScaleType;

namespace iParking.ConfigurationManager.UserControls
{
    public partial class ucScaleConfig : UserControl
    {
        //#region Properties
        //private ScaleConfig? scaleConfig;
        //#endregion End Properties

        //#region Forms
        //public ucScaleConfig(ScaleConfig scaleConfig)
        //{
        //    InitializeComponent();
        //    this.scaleConfig = scaleConfig;

        //    List<string> validPorts = SerialPort.GetPortNames().ToList();
        //    foreach (var item in validPorts)
        //    {
        //        cbComport.Items.Add(item);
        //    }
        //    foreach (var item in Enum.GetValues(typeof(EmScaleType)))
        //    {
        //        cbScaleType.Items.Add(item.ToString());
        //    }
        //    if (this.scaleConfig != null)
        //    {
        //        cbScaleType.SelectedIndex = cbScaleType.FindStringExact(scaleConfig.ScaleType.ToString());
        //        cbComport.SelectedIndex = cbComport.FindStringExact(scaleConfig.Comport);
        //        txtBaudrate.Text = scaleConfig.Baudrate.ToString();
        //        numDataBits.Value = scaleConfig.DataBits;
        //        numStopBit.Value = scaleConfig.StopBit;
        //        numTimeOut.Value = scaleConfig.ReceiveTimeout;
        //        chbIsUseScale.Checked = scaleConfig.IsUseScaleDevice;
        //        txtScaleServer.Text = scaleConfig.ScaleServer;
        //    }
        //}
        //#endregion End Forms

        //#region Controls In Form

        //#endregion End Controls In Form

        //#region Private Function

        //#endregion End Private Function

        //#region Public Function
        //public ScaleConfig GetScaleConfig()
        //{
        //    EmScaleType scaleType = EmScaleType.D2008;
        //    string comport = cbComport.Text;
        //    int baudrate = int.Parse(txtBaudrate.Text);
        //    int dataBits = (int)numDataBits.Value;
        //    int stopBit = (int)numStopBit.Value;
        //    int timeOut = (int)numTimeOut.Value;
        //    bool isUseScaleDevice = chbIsUseScale.Checked;
        //    string scaleConfig = txtScaleServer.Text;
        //    string server = txtScaleServer.Text;
        //    if (cbScaleType.Text != "")
        //    {
        //        scaleType = (EmScaleType)cbScaleType.SelectedIndex;
        //    }

        //    return new ScaleConfig(scaleType, comport, baudrate, dataBits, stopBit, timeOut, isUseScaleDevice, server);
        //}
        //#endregion End Public Function
    }
}
