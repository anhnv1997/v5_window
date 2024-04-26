using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv6.ApiManager.KzParkingv3Apis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucEventCount : UserControl
    {
        public ucEventCount()
        {
            InitializeComponent();
            this.Load += UcEventCount_Load;
        }

        private void UcEventCount_Load(object? sender, EventArgs e)
        {
            timerUpdateCount.Enabled = true;
        }

        private async void timerUpdateCount_Tick(object sender, EventArgs e)
        {
            timerUpdateCount.Enabled = false;
            var eventCountDetail = await KzParkingv5ApiHelper.SummaryEvent();
            int totalVehicleInPark = eventCountDetail.countAllEventIn;
            int vehicleInDay = eventCountDetail.totalVehicleIn;
            int vehicleOutDay = eventCountDetail.totalEventOut;

            lblCurrentVehicleInPark.Text = totalVehicleInPark.ToString();
            lblVehicleIn.Text = vehicleInDay.ToString();
            lblVehicleOutDay.Text =  vehicleOutDay.ToString();

            timerUpdateCount.Enabled = true;
        }
    }
}
