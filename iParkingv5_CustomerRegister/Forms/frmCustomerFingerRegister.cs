using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5_CustomerRegister.Databases;
using iParkingv5_CustomerRegister.UserControls;
using iParkingv6.ApiManager.KzParkingv3Apis;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_CustomerRegister.Forms
{
    public partial class frmCustomerFingerRegister : Form
    {
        #region Properties
        private string customerID = string.Empty;
        #endregion End Properties

        #region Forms
        public frmCustomerFingerRegister()
        {
            InitializeComponent();
            this.Load += FrmCustomerFingerRegister_Load;
        }
        private void FrmCustomerFingerRegister_Load(object? sender, EventArgs e)
        {
            lblTitle.Location = new Point(TextManagement.ROOT_SIZE * 2, TextManagement.ROOT_SIZE * 2);
            lblSubTitle.Location = new Point(lblTitle.Location.X, lblTitle.Location.Y + lblTitle.Height + TextManagement.ROOT_SIZE);

            lblCustomerName.Location = new Point(lblTitle.Location.X, lblSubTitle.Location.Y + lblSubTitle.Height + TextManagement.ROOT_SIZE * 2);
            btnSearchCustomer.Location = new Point((int)(lblCustomerName.Location.X + lblCustomerName.Width + TextManagement.ROOT_SIZE * 2), lblCustomerName.Location.Y + (lblCustomerName.Height - btnSearchCustomer.Height) / 2);

            panelFingers.Location = new Point(btnSearchCustomer.Location.X, btnSearchCustomer.Location.Y + btnSearchCustomer.Height + TextManagement.ROOT_SIZE);
            panelFingers.Width = btnSearchCustomer.Width;
            lblFingerPrint.Location = new Point(lblCustomerName.Location.X, panelFingers.Location.Y + (panelFingers.Height - lblFingerPrint.Height) / 2);

            panelFingers.Enabled = false;
            for (ushort i = 0; i < 3; i++)
            {
                string fingerData = string.Empty;
                ushort fingerId = 0;
                ucFinger uc = new ucFinger(i + 1, fingerData, fingerId);
                panelFingers.Controls.Add(uc);
                uc.Dock = DockStyle.Top;
                uc.BorderStyle = BorderStyle.Fixed3D;
                uc.BringToFront();
            }
            panelFingers.Height = panelFingers.PreferredSize.Height;

            panelFingers.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnConfirm.Location = new Point(panelFingers.Location.X + (panelFingers.Width - btnConfirm.Width), panelFingers.Location.Y + panelFingers.Height + TextManagement.ROOT_SIZE);

            this.Height = btnConfirm.Location.Y + btnConfirm.Height + TextManagement.ROOT_SIZE * 2 + this.Height - this.DisplayRectangle.Height;
            this.Width = btnSearchCustomer.Location.X + btnSearchCustomer.Width + TextManagement.ROOT_SIZE * 2;

            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelFingers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            
            toolTip1.SetToolTip(btnSearchCustomer, "Bấm để tìm kiếm khách hàng theo thông tin đã nhập.");
            toolTip1.SetToolTip(btnConfirm, "Bấm để lưu thông tin lên hệ thống.");
            panelFingers.AutoScroll = true;

            btnSearchCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnSearchCustomer.Click += BtnSearchCustomer_Click;
            btnSearchCustomer.MouseEnter += BtnSearchCustomer_MouseEnter;
            btnSearchCustomer.MouseLeave += BtnSearchCustomer_MouseLeave;

            btnConfirm.Click += BtnConfirm_Click;
            btnConfirm.MouseEnter += BtnConfirm_MouseEnter;
            btnConfirm.MouseLeave += BtnConfirm_MouseLeave;
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnSearchCustomer_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnSearchCustomer.ForeColor = Color.Black;
        }
        private void BtnSearchCustomer_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnSearchCustomer.ForeColor = Color.Red;
        }
        private async void BtnSearchCustomer_Click(object? sender, EventArgs e)
        {
            frmSearchCustomer frm = new frmSearchCustomer();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                customerID = frm.SelectCustomerId;
                btnSearchCustomer.Text = frm.SelectCustomerName;

                List<string> registedFingers = await tblFingerCustomer.GetFingerIdsByCustomerId(this.customerID);
                List<Tuple<string, string>> fingerDatas = await tblFingerprint.GetFingerDatas(registedFingers);
               
                panelFingers.Enabled = true;
                panelFingers.Controls.Clear();
                for (ushort i = 0; i < 3; i++)
                {
                    string fingerData = string.Empty;
                    ushort fingerId = 0;
                    if (fingerDatas.Count > i)
                    {
                        fingerId = ushort.Parse(fingerDatas[i].Item1);
                        fingerData = fingerDatas[i].Item2;
                    }
                    ucFinger uc = new ucFinger(i + 1, fingerData, fingerId);
                    panelFingers.Controls.Add(uc);
                    uc.Dock = DockStyle.Top;
                    uc.BorderStyle = BorderStyle.Fixed3D;
                    uc.BringToFront();
                }
            }
        }

        private void BtnConfirm_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            btnConfirm.ForeColor = Color.Black;
            btnConfirm.Image = Properties.Resources.Checkmark_0_0_0_24px;
        }
        private void BtnConfirm_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnConfirm.ForeColor = Color.Red;
            btnConfirm.Image = Properties.Resources.Checkmark_255_255_255_24px;
        }
        private async void BtnConfirm_Click(object? sender, EventArgs e)
        {
            btnConfirm.Enabled = false;

            if (string.IsNullOrEmpty(customerID))
            {
                MessageBox.Show("Hãy chọn khách hàng cần đăng ký vân tay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Tuple<ushort, string>> fingerDatas = new List<Tuple<ushort, string>>();
            foreach (ucFinger item in panelFingers.Controls)
            {
                Tuple<ushort, string> fingerData = item.GetFingerData();
                if (!string.IsNullOrEmpty(fingerData.Item2))
                {
                    fingerDatas.Add(fingerData);
                }
            }

            tblFingerCustomer.DeleteByCustomerId(this.customerID);

            bool isAllSuccess = true;
            if (fingerDatas.Count > 0)
            {
                string fingerCustomerCode = tblFingerCustomer.GetFingerCustomeCode(customerID);
                for (int i = 0; i < fingerDatas.Count; i++)
                {
                    string fingerId = fingerDatas[i].Item1.ToString();
                    string fingerData = fingerDatas[i].Item2;
                    if (!tblFingerCustomer.Insert(customerID, fingerId, fingerCustomerCode))
                    {
                        isAllSuccess = false;
                    }
                }
            }
            btnConfirm.Enabled = true;
            if (isAllSuccess)
            {
                MessageBox.Show("Thêm thông tin vân tay vào hệ thống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Thêm thông tin vân tay vào hệ thống thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
