using IPaking.Ultility;
using System.ComponentModel;
using static IPaking.Ultility.TextManagement;

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
                this.Height = Math.Max(lblMessage.Location.Y + lblMessage.Height + 32, picWaiting.Location.Y + picWaiting.Height + 32);

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
            this.DoubleBuffered = true;
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
