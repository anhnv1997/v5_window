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
    public partial class ucServerConfig : UserControl
    {
        #region Properties
        public ServerConfig? serverConfig = new ServerConfig();
        #endregion End Properties

        #region Forms
        public ucServerConfig(ServerConfig? serverConfig)
        {
            InitializeComponent();
            this.serverConfig = serverConfig;
            if (serverConfig != null)
            {
                txtParkingServerUrl.Text = this.serverConfig.ParkingServerUrl;
                txtMinioServerUrl.Text = this.serverConfig.MinioServerUrl;
                txtMinioServerUsername.Text = this.serverConfig.MinioServerUsername;
                txtMinioServerPassword.Text = this.serverConfig.MinioServerPassword;
            }
        }
        #endregion End Forms


        #region Public Function
        public ServerConfig GetServerConfig()
        {
            return new ServerConfig()
            {
                ParkingServerUrl = txtParkingServerUrl.Text,
                MinioServerUrl = txtMinioServerUrl.Text,
                MinioServerUsername = txtMinioServerUsername.Text,
                MinioServerPassword = txtMinioServerPassword.Text,
            };
        }
        #endregion End Public Function
    }
}
