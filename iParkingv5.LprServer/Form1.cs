//using iParkingv5.Lpr.Objects;
//using iParkingv5.LprDetecter.LprDetecters;

namespace iParkingv5.LprServer
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            //CreateKztLPR();
            try
            {
                CreateHostBuilder().Build().RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region API
        private static IHostBuilder CreateHostBuilder() =>
          Host.CreateDefaultBuilder()
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseUrls("http://*:" + 8091);// 
                  webBuilder.UseStartup<Startup>();
              });
        //private void CreateKztLPR()
        //{
        //    var lprConfig = new LprConfig()
        //    {
        //        LPRDetecterType = LprDetecter.Objects.LprDetecter.EmLprDetecter.KztekLpr,
        //    };
        //    StaticPool.LprDetect = LprFactory.CreateLprDetecter(lprConfig, null);
        //    StaticPool.LprDetect?.CreateLpr(lprConfig);
        //}
        //public static void showEvent(string input, string output, string plate)
        //{
        //    instance.dgvData.Invoke(new Action(() =>
        //    {
        //        if (instance.dgvData.Rows.Count > 200)
        //        {
        //            instance.dgvData.Rows.RemoveAt(200);
        //        }
        //        instance.dgvData.Rows.Insert(0,DateTime.Now, plate, input, output);
        //    }));
        //}
        #endregion
    }
}
