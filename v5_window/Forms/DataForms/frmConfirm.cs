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

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmConfirm : Form
    {
        #region PROPERTIES
        private int autoReturnTime = 0;
        #endregion End PROPERTIES

        #region FORMS
        public frmConfirm(string message, MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1)
        {
            InitializeComponent();
            lblMessage.Text = message;
            this.KeyPreview = true;

            switch (messageBoxDefaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    this.ActiveControl = btnOk1;
                    break;
                default:
                    this.ActiveControl = lblCancel1;
                    break;
            }

            this.KeyDown += FrmConfirm_KeyDown;
            this.Load += FrmConfirm_Load;
            this.FormClosing += FrmConfirm_FormClosing;
        }

        private void FrmConfirm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            StopTimer();
        }

        private void FrmConfirm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BtnOk_Click(null, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnCancel1_Click(null, EventArgs.Empty);
            }
        }

        private void FrmConfirm_Load(object? sender, EventArgs e)
        {
            lblCancel1.InitControl(BtnCancel1_Click);
            btnOk1.InitControl(BtnOk_Click);

            lblCancel1.Location = new Point(panelActions.Width - lblCancel1.Width - StaticPool.baseSize * 2,
                                            StaticPool.baseSize);
            btnOk1.Location = new Point(lblCancel1.Location.X - btnOk1.Width - StaticPool.baseSize,
                                       StaticPool.baseSize);

            if (StaticPool.appOption.AutoRejectDialogTime > 0)
            {
                lblTimer.Visible = true;
                lblTimer.BringToFront();
                lblTimer.Text = "";
                timerAutoConfirm.Enabled = true;
            }
        }
        #endregion End FORMS

        #region CONTROLS IN FORM
        private void BtnOk_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion End CONTROLS IN FORM

        #region TIMER
        private void timerAutoConfirm_Tick(object? sender, EventArgs e)
        {
            if (autoReturnTime < StaticPool.appOption.AutoRejectDialogTime)
            {
                string message = StaticPool.appOption.AutoRejectDialogResult ? "Xác nhận" : "Đóng";
                int remainingTime = StaticPool.appOption.AutoRejectDialogTime - autoReturnTime;
                lblTimer.Text = $"Tự động {message} sau {remainingTime}s!";
                autoReturnTime++;
            }
            else
            {
                StopTimer();
                if (StaticPool.appOption.AutoRejectDialogResult)
                {
                    BtnOk_Click(null, EventArgs.Empty);
                }
                else
                {
                    BtnCancel1_Click(null, EventArgs.Empty);
                }
            }
        }
        private void StopTimer()
        {
            autoReturnTime = 0;
            timerAutoConfirm.Tick -= timerAutoConfirm_Tick;
            timerAutoConfirm.Enabled = false;
        }
        #endregion End TIMER
    }
}
