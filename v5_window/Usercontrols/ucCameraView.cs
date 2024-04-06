using iParkingv5.Objects;
using iParkingv5.Objects.Enums;
using iParkingv6.Objects.Datas;
using Kztek.Cameras;
using Kztek.LPR;
using Kztek.Tools;
using ParkingHelper.ModelSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucCameraView : UserControl
    {
        #region Properties
        public Kztek.Cameras.Camera? _Camera { get; set; }
        #endregion End Properties

        #region Forms
        public ucCameraView()
        {
            InitializeComponent();
            this.SizeChanged += UcCameraView_SizeChanged;
        }

        private void UcCameraView_SizeChanged(object? sender, EventArgs e)
        {
            this.Height = this.Width * 9 / 16 + lblCameraName.Height;
        }
        #endregion End Forms

        #region Controls In Form
        private void Control_DoubleClick(object? sender, EventArgs e)
        {
            frmViewCamera frm = new()
            {
                CurrentCamera = _Camera
            };
            frm.ShowDialog();
        }
        #endregion

        #region Public Function
        public void StartViewer(Kztek.Cameras.Camera camera, CameraErrorEventHandler cameraErrorFunc)
        {
            this._Camera = camera;

            lblCameraName.Text = camera.Name;
            camera.CameraError += cameraErrorFunc;
            camera.Start();

            if (camera != null && camera.videoSourcePlayer != null)
            {
                var control = (Control)camera.videoSourcePlayer;
                panelCameraView.Controls.Add(control);

                control.Name = camera.ID;
                control.Dock = DockStyle.Fill;
                control.DoubleClick += Control_DoubleClick;
                control.BringToFront();
            }
        }
        public void StartViewer2(Kztek.Cameras.Camera camera, int i)
        {
            this._Camera = camera;

            lblCameraName.Text = camera.Name;


            if (camera != null && camera.videoSourcePlayer!= null)
            {
                iCameraSourcePlayer iCameraSourcePlayer = camera.videoSourcePlayer;
                var control = (Control)iCameraSourcePlayer;
                panelCameraView.Controls.Add(control);

                control.Name = camera.ID;
                control.Dock = DockStyle.Fill;
                control.DoubleClick += Control_DoubleClick;
                control.BringToFront();
            }
        }

        private void VideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
        }

        public Image? GetFullCurrentImage()
        {
            //return Image.FromFile("E:\\2.Workspace\\10.LprTraining\\XuanCuongInput\\19.jpg");
            var bmp = _Camera!.GetCurrentVideoFrame();
            if (bmp == null)
            {
                bmp = _Camera.GetCurrentVideoFrame();
                if (bmp == null)
                {
                    return null;
                }
            }
            return bmp;
        }
        #endregion End Public Function
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this._Camera.videoSourcePlayer.Stop();
            this._Camera.Stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
