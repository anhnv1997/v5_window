using iParkingv5.Objects;
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
    public partial class frmCameraConfigSet : Form
    {
        private Image img;
        public Rectangle? config = null;
        private Point? StartPoint = null;
        private bool isDrawing = false;
        public frmCameraConfigSet(Image img, Rectangle? config)
        {
            InitializeComponent();
            this.img = img;
            this.config = config;
            panelCameraView.AutoScroll = true;
            this.Load += FrmCameraConfigSet_Load;
            pic.Paint += Pic_Paint;
            pic.MouseUp += Pic_MouseUp;
            pic.Invalidate();
        }
        private void FrmCameraConfigSet_Load(object? sender, EventArgs e)
        {
            btnOk1.Init(BtnOk1_Click);
            btnCancel1.Init(BtnCancel1_Click);
            if (img != null)
            {
                pic.Image = img;
                pic.Size = img.Size;
            }
            panelActions.Height = btnCancel1.Height + StaticPool.baseSize * 3;
           
            btnCancel1.Location = new Point(panelActions.Width - btnCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk1.Location = new Point(btnCancel1.Location.X - btnCancel1.Width - StaticPool.baseSize,
                                        StaticPool.baseSize);
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
    }
}
