using IPaking.Ultility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPakrkingv5.Controls.Usercontrols.BuildControls
{
    public partial class ucNotify : UserControl
    {
        public delegate void OnSelectResult(DialogResult result);
        public enum EmNotiType
        {
            Information,
            Error,
            Warning,
            Question
        }

        #region Properties
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Display Message"), Category("Display Message")]
        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2,
                                                lblMessageType.Location.Y + lblMessageType.Height + 7);
            }
        }

        private EmNotiType emNotiType;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Display Message"), Category("Display Message")]
        public EmNotiType NotiType
        {
            get { return emNotiType; }
            set
            {
                emNotiType = value;
                switch (emNotiType)
                {
                    case EmNotiType.Information:
                        lblMessageType.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.NOTIFY_INFORMATION,TextManagement.ROOT_LANGUAGE);
                        picNotiType.Image = Properties.Resources.noti_ok_64;
                        break;
                    case EmNotiType.Error:
                        lblMessageType.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.NOTIFY_ERROR, TextManagement.ROOT_LANGUAGE);
                        picNotiType.Image = Properties.Resources.noti_error_64;
                        break;
                    case EmNotiType.Warning:
                        lblMessageType.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.NOTIFY_WARNING, TextManagement.ROOT_LANGUAGE);
                        picNotiType.Image = Properties.Resources.noti_warning_64;
                        break;
                    case EmNotiType.Question:
                        lblMessageType.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.NOTIFY_QUESTION, TextManagement.ROOT_LANGUAGE);
                        picNotiType.Image = Properties.Resources.noti_question_64;
                        break;
                    default:
                        lblMessageType.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.NOTIFY_INFORMATION, TextManagement.ROOT_LANGUAGE);
                        picNotiType.Image = Properties.Resources.noti_ok_64;
                        break;
                }
                lblMessageType.Location = new Point((this.Width - lblMessageType.Width) / 2,
                                                     picNotiType.Location.Y + picNotiType.Height + 30);
            }
        }

        public event OnSelectResult? OnSelectResultEvent;
        #endregion End Properties

        #region Forms
        public ucNotify()
        {
            InitializeComponent();
            this.Load += UcNotify_Load;
        }
        private void UcNotify_Load(object? sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;

            btnConfirm.Init(BtnConfirm_Click);
            btnCancel.Init(BtnCancel_Click);

            lblMessage.MaximumSize = new Size(this.Width - TextManagement.ROOT_SIZE * 2, 0);
            lblMessage.MinimumSize = new Size(this.Width - 80, 0);

            picNotiType.Location = new Point((this.Width - picNotiType.Width) / 2, 40);
            lblMessageType.Location = new Point((this.Width - lblMessageType.Width) / 2, picNotiType.Location.Y + picNotiType.Height + 30);
            lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2,
                                        lblMessageType.Location.Y + lblMessageType.Height + 7);

            btnCancel.Location = new Point(this.Width - btnCancel.Width - TextManagement.ROOT_SIZE * 2,
                                           this.Height - btnCancel.Height - TextManagement.ROOT_SIZE * 2);
            btnConfirm.Location = new Point(btnCancel.Location.X - btnConfirm.Width - TextManagement.ROOT_SIZE,
                                            btnCancel.Location.Y);
            this.Visible = false;
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Visible = false;
            this.Parent.SizeChanged -= Parent_SizeChanged;
            OnSelectResultEvent?.Invoke(DialogResult.Cancel);
        }
        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            this.Visible = false;
            this.Parent.SizeChanged -= Parent_SizeChanged;
            OnSelectResultEvent?.Invoke(DialogResult.OK);
        }
        #endregion End Controls In Form

        #region Public Function
        public void Show(EmNotiType emNotiType, string message, DialogResult preferResult = DialogResult.OK)
        {
            this.Parent.SizeChanged -= Parent_SizeChanged;

            this.NotiType = emNotiType;
            this.Message = message;
            btnConfirm.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.RESULT_CONFIRM, TextManagement.ROOT_LANGUAGE);
            btnCancel.Text = TextManagement.GetDisplayStr(TextManagement.EmTextDisplay.RESULT_CANCEL, TextManagement.ROOT_LANGUAGE);
            this.Location = new Point(this.Parent.Location.X + (this.Parent.Width - this.Width) / 2,
                                      this.Parent.Location.Y + (this.Parent.Height - this.Height) / 2);

            if (preferResult == DialogResult.OK | preferResult == DialogResult.Yes)
            {
                this.ActiveControl = btnConfirm;
            }
            else
            {
                this.ActiveControl = btnCancel;
            }

            this.Visible = true;
            this.Parent.SizeChanged += Parent_SizeChanged;

            this.BringToFront();
        }

        private void Parent_SizeChanged(object? sender, EventArgs e)
        {
            this.Location = new Point(this.Parent.Location.X + (this.Parent.Width - this.Width) / 2,
                                      this.Parent.Location.Y + (this.Parent.Height - this.Height) / 2);
        }
        #endregion End Public Function
    }
}
