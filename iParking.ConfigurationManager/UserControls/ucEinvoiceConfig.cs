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
    public partial class ucEinvoiceConfig : UserControl
    {
        #region Properties
        private EInvoiceConfig einvoiceConfig;
        #endregion End Properties

        #region Forms
        public ucEinvoiceConfig(EInvoiceConfig? eInvoiceConfig)
        {
            InitializeComponent();
            this.einvoiceConfig = eInvoiceConfig;
            btnShowGuideFile.Click += BtnShowGuideFile_Click;
            LoadEInvoiceType();
            LoadCurrentConfig();
        }

        #endregion End Form

        #region Controls In Form
        private void BtnShowGuideFile_Click(object? sender, EventArgs e)
        {
        }
        #endregion

        #region Public Function
        public EInvoiceConfig GetEInvoiceConfig()
        {
            if (chbIsUseEInvoice.Checked)
            {
                return new EInvoiceConfig()
                {
                    EInvoiceType = (EInvoiceType.EmEinvoiceType)cbEInvoiceType.SelectedIndex,
                    ServerUrl = txtServerUrl.Text,
                    ServerTemplateFile = txtTemplateFile.Text,
                    ServerAction = txtAction.Text,
                    AppId = txtAppID.Text,
                    TaxCode = txtTaxCode.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    TicketSerie = txtSerie.Text,
                    TicketTemplate = txtTemplate.Text,
                    VatRate = int.Parse(txtVatRate.Text),
                    BillReceiveLink = txtReceiveLink.Text,
                    IsUseEInvoice = chbIsUseEInvoice.Checked,
                };
            }
            else
            {
                return new EInvoiceConfig();
            }
           
        }
        #endregion

        #region Private Function
        private void LoadEInvoiceType()
        {
            foreach (var item in Enum.GetValues(typeof(EInvoiceType.EmEinvoiceType)))
            {
                cbEInvoiceType.Items.Add(item.ToString());
            }
        }
        private void LoadCurrentConfig()
        {
            if (this.einvoiceConfig != null)
            {
                cbEInvoiceType.SelectedIndex = (int)this.einvoiceConfig.EInvoiceType;
                txtServerUrl.Text = einvoiceConfig.ServerUrl;
                txtTemplateFile.Text = einvoiceConfig.ServerTemplateFile;
                txtAction.Text = einvoiceConfig.ServerAction;
                txtAppID.Text = einvoiceConfig.AppId;
                txtTaxCode.Text = einvoiceConfig.TaxCode;
                txtUsername.Text = einvoiceConfig.Username;
                txtPassword.Text = einvoiceConfig.Password;
                txtSerie.Text = einvoiceConfig.TicketSerie;
                txtTemplate.Text = einvoiceConfig.TicketTemplate;
                txtVatRate.Text = einvoiceConfig.VatRate.ToString();
                txtReceiveLink.Text = einvoiceConfig.BillReceiveLink;
                chbIsUseEInvoice.Checked = einvoiceConfig.IsUseEInvoice;
            }
        }
        #endregion
    }
}
