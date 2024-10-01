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
    public partial class ucTienPhong : UserControl
    {
        public ucTienPhong(TienPhongConfig config)
        {
            InitializeComponent();

            txbUrlServer.Text = config.UrlServer;
        }

        public TienPhongConfig GetConfig()
        {
            return new TienPhongConfig()
            {
                UrlServer = txbUrlServer.Text,
            };
        }
    }
}
