using iParkingv5.ApiManager.KzParkingv5Apis;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucEventCount : UserControl
    {
        #region Forms
        public ucEventCount()
        {
            InitializeComponent();
            this.Load += UcEventCount_Load;
        }
        private void UcEventCount_Load(object? sender, EventArgs e)
        {
            timerUpdateCount.Enabled = true;
        }
        #endregion End Forms

        #region Timer
        private async void timerUpdateCount_Tick(object sender, EventArgs e)
        {
            return;
            try
            {
                timerUpdateCount.Enabled = false;
                var eventCountDetail = await KzParkingv5ApiHelper.SummaryEventAsync();
                int totalVehicleInPark = eventCountDetail.countAllEventIn;
                int vehicleInDay = eventCountDetail.totalVehicleIn;
                int vehicleOutDay = eventCountDetail.totalEventOut;

                lblCurrentVehicleInPark.Text = totalVehicleInPark.ToString();
                lblVehicleIn.Text = vehicleInDay.ToString();
                lblVehicleOutDay.Text = vehicleOutDay.ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
                timerUpdateCount.Enabled = true;
            }
        }
        #endregion End Timer

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
