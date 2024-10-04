﻿using iParkingv5.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols.CameraConfiguration
{
    public partial class frmCameraVirtualLoopConfigSet : Form
    {
        private Image img;
        private Rectangle? config = null;
        private Point? StartPoint = null;
        private bool isDrawing = false;
        public frmCameraVirtualLoopConfigSet(Image img, Rectangle? config)
        {
            InitializeComponent();
            this.img = img;
            this.config = config;
            panelCameraView.AutoScroll = true;
            this.Load += FrmCameraConfigSet_Load;
            pic.Paint += Pic_Paint;
            pic.MouseUp += Pic_MouseUp;
        }
        private void FrmCameraConfigSet_Load(object? sender, EventArgs e)
        {
            btnOk1.Click += BtnOk1_Click;
            btnCancel1.Click += BtnCancel1_Click;
            if (img != null)
            {
                pic.Image = img;
                pic.Location = new Point(0, 0);
                pic.Height = this.DisplayRectangle.Height - panelActions.Height;
                pic.Width = (int)(((float)img.Size.Width / (img.Size.Height)) * pic.Height);
            }
            this.config = GetSaveDisplayConfig(config);
            pic.Invalidate();
            panelActions.Height = btnCancel1.Height;

            btnCancel1.Location = new Point(panelActions.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);

            btnOk1.Location = new Point(btnCancel1.Location.X - btnOk1.Width - StaticPool.baseSize,
                                        StaticPool.baseSize);
        }

        private void BtnOk1_Click1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Pic_Paint(object? sender, PaintEventArgs e)
        {
            if (config != null)
            {
                Pen blackPen = new Pen(Color.RebeccaPurple, 3);
                e.Graphics.DrawRectangle(blackPen, (Rectangle)config);
            }
        }
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            this.StartPoint = e.Location;
            pic.Invalidate();
        }
        private void Pic_MouseUp(object? sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.StartPoint != null && isDrawing)
            {
                config = new Rectangle(Math.Min(StartPoint.Value.X, e.X),
                                        Math.Min(StartPoint.Value.Y, e.Y),
                                        Math.Abs(StartPoint.Value.X - e.X),
                                        Math.Abs(StartPoint.Value.Y - e.Y));
                pic.Invalidate();
            }
        }
        public Rectangle? GetSaveConfig()
        {
            if (pic.Image == null || config == null)
            {
                return null;
            }
            float ratioWidth = (float)pic.Width / pic.Image.Width;
            float ratioHeight = (float)pic.Height / pic.Image.Height;

            return new Rectangle((int)(config.Value.X / ratioWidth), (int)(config.Value.Y / ratioHeight),
                                (int)(config.Value.Width / ratioWidth), (int)(config.Value.Height / ratioHeight));
        }

        public Rectangle? GetSaveDisplayConfig(Rectangle? config)
        {
            if (pic.Image == null || config == null)
            {
                return null;
            }
            float ratioWidth = (float)pic.Width / pic.Image.Width;
            float ratioHeight = (float)pic.Height / pic.Image.Height;

            return new Rectangle((int)(config.Value.X * ratioWidth), (int)(config.Value.Y * ratioHeight),
                                (int)(config.Value.Width * ratioWidth), (int)(config.Value.Height * ratioHeight));
        }
    }
}
