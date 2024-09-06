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
        private string selectedLogoPath = string.Empty;
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
            btnChooseLogoPath.Text = oem.LogoPath;
        }
        #endregion End Forms

        #region Controls In Form
        private void btnChooseLogoPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|GIF files|*.gif|TIFF files|*.tif|Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Chọn logo hiển thị phần mềm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedLogoPath = ofd.FileName;
                btnChooseLogoPath.Text = ofd.FileName;
            }
        }
        #endregion

        #region Public Function
        public OEMConfig GetConfig()
        {
            return new OEMConfig()
            {
                AppName = txtAppName.Text,
                CompanyName = txtCompanyName.Text,
                Language = cbLanguage.SelectedIndex,
                TimeToDefautUI = (int)numTimeToDefaultConfig.Value,
                IsAutoReturnToDefault = chbIsReturnDefaultConfig.Checked,
                LogoPath = selectedLogoPath,
            };
        }
        #endregion End Public Function


    }
}
