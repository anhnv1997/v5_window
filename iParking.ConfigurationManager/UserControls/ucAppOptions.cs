﻿using iParkingv5.Objects.Configs;
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
            
            if (this.appOption != null)
            {
                txtAllowOpenBarrieTime.Text = appOption!.AllowBarrieDelayOpenTime.ToString();
                txtWaitSwipeCardTime.Text = appOption.MinDelayCardTime.ToString();
                cbPrintTemplate.SelectedIndex = appOption.PrintTemplate;
                chbIsSaveLog.Checked = appOption.IsSaveLog;
                numLoopDelay.Value = appOption.LoopDelay;
                numRetakePhotoTurn.Value = appOption.RetakePhotoTimes;
                numRetakePhotoDelayTime.Value = appOption.RetakePhotoDelay;
            }
            txtWaitSwipeCardTime.TextChanged += TxtWaitSwipeCardTime_TextChanged;
            txtAllowOpenBarrieTime.TextChanged += TxtAllowOpenBarrieTime_TextChanged;

            
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
