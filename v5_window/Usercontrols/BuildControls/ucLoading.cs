using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5_window.Controls.Buttons;
using iParkingv5_window.Forms.DataForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IPaking.Ultility.TextManagement;
using static iParkingv5_window.Usercontrols.BuildControls.ucNotify;

namespace iParkingv5_window.Usercontrols.BuildControls
{
    public partial class ucLoading : UserControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Display Message"), Category("Display Message")]
        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                lblMessage.Location = new Point(picWaiting.Location.X + picWaiting.Width,
                                                picWaiting.Location.Y + (picWaiting.Height - lblMessage.Height) / 2);
                this.Height = Math.Max(lblMessage.Location.Y + lblMessage.Height + StaticPool.baseSize * 2, picWaiting.Location.Y + picWaiting.Height + StaticPool.baseSize * 2);

            }
        }

        private EmLanguage language;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Display Message"), Category("Display Message")]
        public EmLanguage Language
        {
            get { return language; }
            set
            {
                language = value;
                lblWaiting.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.NOTIFY_WAITING, language);
            }
        }

        public ucLoading()
        {
            InitializeComponent();
            this.Load += UcLoading_Load;
        }

        private void UcLoading_Load(object? sender, EventArgs e)
        {
            lblMessage.Location = new Point(picWaiting.Location.X + picWaiting.Width,
                                            picWaiting.Location.Y + (picWaiting.Height - lblMessage.Height) / 2);
            lblMessage.MaximumSize = lblMessage.MinimumSize = new Size(this.Width - lblMessage.Location.X - 30, 0);
            this.Visible = false;
        }

        public void Show(string message, EmLanguage language)
        {
            this.Parent.SizeChanged -= Parent_SizeChanged;

            this.language = language;
            this.Message = message;
            this.Location = new Point(this.Parent.Location.X + (this.Parent.Width - this.Width) / 2,
                                      this.Parent.Location.Y + (this.Parent.Height - this.Height) / 2);

            this.Visible = true;
            this.Parent.SizeChanged += Parent_SizeChanged;

            this.BringToFront();
        }
        public void HideLoading()
        {
            this.Visible = false;
            this.Parent.SizeChanged -= Parent_SizeChanged;
        }
        private void Parent_SizeChanged(object? sender, EventArgs e)
        {
            this.Location = new Point(this.Parent.Location.X + (this.Parent.Width - this.Width) / 2,
                                      this.Parent.Location.Y + (this.Parent.Height - this.Height) / 2);
        }
    }
}
