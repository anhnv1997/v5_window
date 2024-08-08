using iParkingv5.Objects.Configs;
using System.IO.Ports;
using static iParkingv5.Objects.Enums.PrintHelpers;

namespace iParking.ConfigurationManager.UserControls
{
    public partial class ucAppOptions : UserControl
    {
        #region Properties
        private AppOption? appOption;
        #endregion End Properties

        #region Forms
        public ucAppOptions(AppOption? appOption)
        {
            InitializeComponent();
            this.appOption = appOption;
            LoadPrintTemplate();
            numAutoReturnDialogTime.ValueChanged += NumAutoReturnDialogTime_ValueChanged;
            if (this.appOption != null)
            {
                txtAllowOpenBarrieTime.Text = appOption!.AllowBarrieDelayOpenTime.ToString();
                txtWaitSwipeCardTime.Text = appOption.MinDelayCardTime.ToString();
                cbPrintTemplate.SelectedIndex = appOption.PrintTemplate;
                chbIsSaveLog.Checked = appOption.IsSaveLog;
                numLoopDelay.Value = appOption.LoopDelay;
                numRetakePhotoTurn.Value = appOption.RetakePhotoTimes;
                numRetakePhotoDelayTime.Value = appOption.RetakePhotoDelay;
                txtUpdatePath.Text = appOption.CheckForUpdatePath;
                chbIsAllowEditPlateOut.Checked = appOption.IsAllowEditPlateOut;
                chbIsIntergratedScaleStation.Checked = appOption.IsIntergratedScaleStation;
                chbIsCheckKey.Checked = appOption.IsCheckKey;
                chbIsUseInvoice.Checked = appOption.IsIntergratedEInvoice;
                numAutoReturnDialogTime.Value = appOption.AutoRejectDialogTime;
                cbAutoReturnDialogResult.SelectedIndex = appOption.AutoRejectDialogResult ? 0 : 1;
            }
            txtWaitSwipeCardTime.TextChanged += TxtWaitSwipeCardTime_TextChanged;
            txtAllowOpenBarrieTime.TextChanged += TxtAllowOpenBarrieTime_TextChanged;
        }

        private void NumAutoReturnDialogTime_ValueChanged(object? sender, EventArgs e)
        {
            if (numAutoReturnDialogTime.Value <= 0)
            {
                cbAutoReturnDialogResult.Enabled = false;
            }
            else
            {
                cbAutoReturnDialogResult.Enabled = true;
            }
        }

        public void DisplayDevelopMode(bool isDisplay)
        {
            chbIsCheckKey.Visible = isDisplay;
        }
        #endregion End Forms

        #region Controls In Form
        private void TxtAllowOpenBarrieTime_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAllowOpenBarrieTime.Text))
            {
                txtAllowOpenBarrieTime.Text = "5";
            }
        }
        private void TxtWaitSwipeCardTime_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWaitSwipeCardTime.Text))
            {
                txtWaitSwipeCardTime.Text = "5";
            }
        }
        #endregion End Controls In Form

        #region Public Function
        public AppOption GetAppOptionConfig()
        {
            return new AppOption()
            {
                AllowBarrieDelayOpenTime = int.Parse(txtAllowOpenBarrieTime.Text),
                MinDelayCardTime = int.Parse(txtWaitSwipeCardTime.Text),
                PrintTemplate = cbPrintTemplate.SelectedIndex,
                IsSaveLog = chbIsSaveLog.Checked,
                LoopDelay = (int)numLoopDelay.Value,
                RetakePhotoTimes = (int)numRetakePhotoTurn.Value,
                RetakePhotoDelay = (int)numRetakePhotoDelayTime.Value,
                CheckForUpdatePath = txtUpdatePath.Text,
                IsAllowEditPlateOut = chbIsAllowEditPlateOut.Checked,
                IsIntergratedScaleStation = chbIsIntergratedScaleStation.Checked,
                IsCheckKey = chbIsCheckKey.Checked,
                IsIntergratedEInvoice = chbIsUseInvoice.Checked,
                AutoRejectDialogResult = cbAutoReturnDialogResult.SelectedIndex == 0 ? true : false,
                AutoRejectDialogTime = (int)numAutoReturnDialogTime.Value,
            };
        }
        #endregion End Public Function

        #region Private Function
        private void LoadPrintTemplate()
        {
            foreach (var item in Enum.GetValues(typeof(EmPrintTemplate)))
            {
                cbPrintTemplate.Items.Add(item.ToString());
            }
        }
        #endregion End Private Funciton

    }
}
