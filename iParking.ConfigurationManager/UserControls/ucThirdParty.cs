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
    public partial class ucThirdParty : UserControl
    {
        #region Properties
        public ThirdPartyConfig? serverConfig = new ThirdPartyConfig();
        #endregion End Properties

        #region Forms
        public ucThirdParty(ThirdPartyConfig? serverConfig)
        {
            InitializeComponent();
            this.serverConfig = serverConfig;
            if (serverConfig != null)
            {
                txtServerUrl.Text = this.serverConfig!.ServerUrl;
                txtUsername.Text = this.serverConfig.Username;
                txtPassword.Text = this.serverConfig.Password;
                chbIsUse.Checked = this.serverConfig.IsUse;
            }
        }
        #endregion End Forms

        #region Public Function
        public ThirdPartyConfig GetServerConfig()
        {
            return new ThirdPartyConfig()
            {
                ServerUrl = txtServerUrl.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                IsUse = chbIsUse.Checked,
            };
        }
        #endregion End Public Function
    }
}
