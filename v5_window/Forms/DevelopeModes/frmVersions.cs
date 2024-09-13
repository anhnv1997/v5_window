using IPaking.Ultility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.DevelopeModes
{
    public partial class frmVersions : Form
    {
        #region Properties

        #endregion End Properties

        #region Forms
        public frmVersions()
        {
            InitializeComponent();
            this.KeyDown += FrmVersions_KeyDown;
            btnCancel.Click += BtnCancel_Click;
            this.Load += FrmVersions_Load;
        }

        private void FrmVersions_Load(object? sender, EventArgs e)
        {
            try
            {
                ucFileInfoUltility.FilePath = Path.Combine(PathManagement.baseBath, "IPaking.Ultility.dll");
                ucFileInfoControl.FilePath = Path.Combine(PathManagement.baseBath, "iPakrkingv5.Controls.dll");
                ucFileInfoApi.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.ApiManager.dll");
                ucFileInfoAuth.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.Auth.dll");
                ucFileInfoController.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.Controller.dll");
                ucFileInfoLed.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.LedDisplay.dll");
                ucFileInfoLpr.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.Lpr.dll");
                ucFileInfoLprAI.FilePath = Path.Combine(PathManagement.baseBath, "NXT.Net6.LPR_AI.dll");
                ucFileInfoObject.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.Objects.dll");
                ucFileInfoPrinter.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.Printer.dll");
                ucFileInfoReporting.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5.Reporting.dll");
                ucFileInfoWindow.FilePath = Path.Combine(PathManagement.baseBath, "iParkingv5_window.dll");
                ucFileInfoCamera.FilePath = Path.Combine(PathManagement.baseBath, "Kztek.Cameras.dll");
                ucFileInfoTool.FilePath = Path.Combine(PathManagement.baseBath, "Kztek.Tool.dll");
                ucFileInfoHelper.FilePath = Path.Combine(PathManagement.baseBath, "Kztek.Helper.dll");
            }
            catch (Exception)
            {
            }
        }

        private void FrmVersions_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        #endregion End Controls In Form

        #region Private Function

        #endregion End Private Function

        #region Public Function

        #endregion End Public Function
    }
}
