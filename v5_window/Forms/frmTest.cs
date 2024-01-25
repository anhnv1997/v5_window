using IPaking.Ultility;
using iParkingv5.Controller.Dahua;
using iParkingv5.Objects.Enums;
using iParkingv5_window.Forms.DataForms;
using iParkingv5_window.Forms.ReportForms;
using iParkingv5_window.Usercontrols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            this.Load += FrmTest_Load;
        }

        private void FrmTest_Load(object? sender, EventArgs e)
        {
            //Kztek.Cameras.Camera cam = new Kztek.Cameras.Camera();
            //cam.Name = "";
            //cam.VideoSource = "192.168.20.182";
            //cam.HttpPort = 80;
            //cam.Login = "admin";
            //cam.Password = "Kztek123456";
            //cam.Chanel = 1;
            //string camType = "Tiandy";
            //cam.CameraType = Kztek.Cameras.CameraTypes.GetType(camType);
            //cam.StreamType = Kztek.Cameras.StreamTypes.GetType("H264");
            //int i = 0;
            //cam.NewFrame += Cam_NewFrame;
            //cam.Start(1);
            //ucCameraView1.StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //i++;
            //for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            //{
            //    ((ucCameraView)tableLayoutPanel1.Controls[i]).StartViewer2(cam, i);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new frmReportIn().Show();
            this.Controls.Add(new ucEventOutInfo());
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            DahuaAccessControl dahuaAccessControl = new DahuaAccessControl();
            dahuaAccessControl.ControllerInfo = new iParkingv6.Objects.Datas.Bdk()
            {
                comport = "192.168.1.108",
                baudrate = "37777",
                communicationType = (int)CommunicationTypes.EM_CommunicationType.TCP_IP
            };
            dahuaAccessControl.Init();
            bool isSuccess = await dahuaAccessControl.ConnectAsync();
            dahuaAccessControl.PollingStart();
        }

        //private void Cam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        //{
        //    this.Invoke(new Action(() =>
        //    {
        //        foreach (Control item in tableLayoutPanel1.Controls)
        //        {
        //            if (item is PictureBox)
        //            {
        //                ((PictureBox)item).Image = eventArgs.Frame;
        //            }
        //        }
        //    }));
        //}
    }
}
