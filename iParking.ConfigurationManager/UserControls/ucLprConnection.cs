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
using static iParkingv5.Objects.Configs.LprDetecter;

namespace iParking.ConfigurationManager.UserControls
{
    public partial class ucLprConnection : UserControl
    {
        public ucLprConnection(LprConfig lprCOnfig)
        {
            InitializeComponent();
            LoadLprType();
            cbLprType.SelectedIndexChanged += CbLprType_SelectedIndexChanged;
            if (lprCOnfig != null)
            {
                cbLprType.SelectedIndex = (int)lprCOnfig.LPRDetecterType;
                txtLprUrl.Text = lprCOnfig.Url;
                txtUsername.Text = lprCOnfig.Username;
                txtPassword.Text = lprCOnfig.Password;
            }
        }

        private void LoadLprType()
        {
            foreach (var item in Enum.GetValues(typeof(EmLprDetecter)))
            {
                cbLprType.Items.Add(item.ToString());
            }
        }

        private void CbLprType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            switch ((EmLprDetecter)cbLprType.SelectedIndex)
            {
                case EmLprDetecter.KztekLpr:
                    panelLprInfo.Visible = false;
                    break;
                case EmLprDetecter.AmericalLpr:
                    panelLprInfo.Visible = true;
                    break;
                default:
                    break;
            }
        }


        #region Public Function
        public LprConfig GetConfig()
        {
            return new LprConfig()
            {
                LPRDetecterType = (EmLprDetecter)cbLprType.SelectedIndex,
                Url = txtLprUrl.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
            };
        }
        #endregion End Public Function
    }
}
