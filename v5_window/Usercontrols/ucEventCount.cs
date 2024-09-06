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
        private async void UcEventCount_Load(object? sender, EventArgs e)
        {
            CreateUI();

            var eventCountDetail = await AppData.ApiServer.reportingService.SummaryEventAsync();
            int totalVehicleInPark = eventCountDetail.countAllEventIn;
            int vehicleInDay = eventCountDetail.totalVehicleIn;
            int vehicleOutDay = eventCountDetail.totalEventOut;

            lblCurrentVehicleInPark.Message = totalVehicleInPark.ToString();
            lblVehicleIn.Message = vehicleInDay.ToString();
            lblVehicleOutDay.Message = vehicleOutDay.ToString();

            lblVehicleInTitle.MaxFontSize = lblVehicleOutDayTitle.MaxFontSize = lblCurrentVehicleInParkTitle.MaxFontSize =
                Math.Min(Math.Min(lblVehicleInTitle.CurrentFontSize, 
                                lblVehicleOutDayTitle.CurrentFontSize), 
                                lblCurrentVehicleInParkTitle.CurrentFontSize);

        }

        private void CreateUI()
        {
            lblVehicleInTitle.Text = "";
            lblVehicleOutDayTitle.Text = "";
            lblCurrentVehicleInParkTitle.Text = "";

            lblVehicleInTitle.Message = "Xe Vào   ";
            lblVehicleOutDayTitle.Message = "Xe Ra    ";
            lblCurrentVehicleInParkTitle.Message = "Trong Bãi";

            lblVehicleInTitle.MessageForeColor = Color.Black;
            lblVehicleOutDayTitle.MessageForeColor = Color.Black;
            lblCurrentVehicleInParkTitle.MessageForeColor = Color.Black;

            lblVehicleInTitle.MessageBackColor = Color.White;
            lblVehicleOutDayTitle.MessageBackColor = Color.White;
            lblCurrentVehicleInParkTitle.MessageBackColor = Color.White;

            lblVehicleInTitle.FontName = "Segoe UI";
            lblVehicleOutDayTitle.FontName = "Segoe UI";
            lblCurrentVehicleInParkTitle.FontName = "Segoe UI";

            lblVehicleInTitle.MaxFontSize = lblVehicleOutDayTitle.MaxFontSize = lblCurrentVehicleInParkTitle.MaxFontSize =
                    Math.Min(Math.Min(lblVehicleInTitle.CurrentFontSize, lblVehicleOutDayTitle.CurrentFontSize), lblCurrentVehicleInParkTitle.CurrentFontSize);

            lblCurrentVehicleInPark.Text = "";
            lblVehicleIn.Text = "";
            lblVehicleOutDay.Text = "";

            lblCurrentVehicleInPark.Message = "0";
            lblVehicleIn.Message = "0";
            lblVehicleOutDay.Message = "0";

            lblCurrentVehicleInPark.MessageBackColor = Color.White;
            lblVehicleIn.MessageBackColor = Color.White;
            lblVehicleOutDay.MessageBackColor = Color.White;

            lblCurrentVehicleInPark.MessageForeColor = Color.DarkBlue;
            lblVehicleIn.MessageForeColor = Color.DarkGreen;
            lblVehicleOutDay.MessageForeColor = Color.DarkRed;

            lblVehicleIn.FontName = "Digital-7";
            lblCurrentVehicleInPark.FontName = "Digital-7";
            lblVehicleOutDay.FontName = "Digital-7";
            this.SizeChanged += UcEventCount_SizeChanged;
        }

        private void UcEventCount_SizeChanged(object? sender, EventArgs e)
        {
            lblVehicleInTitle.MaxFontSize = lblVehicleOutDayTitle.MaxFontSize = lblCurrentVehicleInParkTitle.MaxFontSize = 100;

            lblVehicleInTitle.MaxFontSize = lblVehicleOutDayTitle.MaxFontSize = lblCurrentVehicleInParkTitle.MaxFontSize =
                  Math.Min(Math.Min(lblVehicleInTitle.CurrentFontSize, lblVehicleOutDayTitle.CurrentFontSize), lblCurrentVehicleInParkTitle.CurrentFontSize);
        }
        #endregion End Forms

        #region Timer
        private async void timerUpdateCount_Tick(object? sender, EventArgs e)
        {
            try
            {
                timerUpdateCount.Enabled = false;
                var eventCountDetail = await AppData.ApiServer.reportingService.SummaryEventAsync();
                int totalVehicleInPark = eventCountDetail.countAllEventIn;
                int vehicleInDay = eventCountDetail.totalVehicleIn;
                int vehicleOutDay = eventCountDetail.totalEventOut;

                lblCurrentVehicleInPark.Message = totalVehicleInPark.ToString();
                lblVehicleIn.Message = vehicleInDay.ToString();
                lblVehicleOutDay.Message = vehicleOutDay.ToString();
                lblVehicleInTitle.Message = "Xe Vào   ";
                lblVehicleOutDayTitle.Message = "Xe Ra    ";
                lblCurrentVehicleInParkTitle.Message = "Trong Bãi";

                lblVehicleInTitle.MaxFontSize = lblVehicleOutDayTitle.MaxFontSize = lblCurrentVehicleInParkTitle.MaxFontSize =
                    Math.Min(Math.Min(lblVehicleInTitle.CurrentFontSize, lblVehicleOutDayTitle.CurrentFontSize), lblCurrentVehicleInParkTitle.CurrentFontSize);

            }
            catch (Exception)
            {
            }
            finally
            {
                timerUpdateCount.Enabled = true;
            }
        }
        public void Stop()
        {
            timerUpdateCount.Tick -= timerUpdateCount_Tick;
            timerUpdateCount.Enabled = false;
        }
        #endregion End Timer
    }
}
