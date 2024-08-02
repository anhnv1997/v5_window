using iParkingv5.Objects.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParking.ConfigurationManager.UserControls
{
    public partial class ucOEM : UserControl
    {
        #region Properties
        public ThirdPartyConfig? serverConfig = new ThirdPartyConfig();
        #endregion End Properties

        #region Forms
        public ucOEM(OEMConfig oem)
        {
            InitializeComponent();
            txtAppName.Text = oem.AppName;
            txtCompanyName.Text = oem.CompanyName;
            cbLanguage.SelectedIndex = oem.Language;
            numTimeToDefaultConfig.Value = oem.TimeToDefautUI;
            chbIsReturnDefaultConfig.Checked = oem.IsAutoReturnToDefault;
        }
        #endregion End Forms

        #region Public Function
        public OEMConfig GetConfig()
        {
            return new OEMConfig()
            {
                AppName = txtAppName.Text,
                CompanyName = txtCompanyName.Text,
                Language = cbLanguage.SelectedIndex,
                TimeToDefautUI = (int)numTimeToDefaultConfig.Value,
                IsAutoReturnToDefault = chbIsReturnDefaultConfig.Checked
            };
        }
        #endregion End Public Function
    }
}
