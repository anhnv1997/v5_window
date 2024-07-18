using iParkingv5.ApiManager.KzScaleApis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v5_IScale.Usercontrols.BuildControls
{
    public partial class ucScaleCount : UserControl
    {
        #region Properties
        private DateTime? startTime = null;
        private DateTime? endTime = null;
        #endregion End Properties

        #region Forms
        public ucScaleCount()
        {
            InitializeComponent();
            this.Load += UcScaleCount_Load;
        }
        private void UcScaleCount_Load(object? sender, EventArgs e)
        {
            timerUpdateCount.Enabled = true;
        }
        #endregion End Forms

        #region Timer
        private async void timerUpdateCount_Tick(object sender, EventArgs e)
        {
            timerUpdateCount.Enabled = false;
            try
            {
                var countInDay = await KzScaleApiHelper.GetCountInDayRoute();
                lblFirstCount.Text = countInDay.numberFirstWeighing.ToString();
                lblSecondCount.Text = countInDay.numberSecondWeighing.ToString();
                lblMoreThanSecondCount.Text = countInDay.numberOtherWeighing.ToString();
            }
            catch (Exception)
            {
            }
            timerUpdateCount.Enabled = true;
        }
        #endregion End Timer
    }
}
