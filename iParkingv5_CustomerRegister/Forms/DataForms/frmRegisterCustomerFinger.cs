using IPaking.Ultility;
using iParkingv5.Objects;
using iParkingv5.Objects.Datas.parking;
using iParkingv5_CustomerRegister.Databases;
using iParkingv5_CustomerRegister.UserControls;
using iParkingv5_window;
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
    public partial class frmRegisterCustomerFinger : Form
    {
        #region Properties
        private string customerID = string.Empty;
        private string customerName = string.Empty;
        private string identityGroupId = string.Empty;
        private Identity? identity = null;
        private string identityGroupName = string.Empty;
        bool isExistIdentity = false;
        #endregion End Properties

        #region Forms
        public frmRegisterCustomerFinger()
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

            btnChooseIdentityGroup.Location = new Point(btnSearchCustomer.Location.X, btnSearchCustomer.Location.Y + btnSearchCustomer.Height + TextManagement.ROOT_SIZE);
            btnChooseIdentityGroup.Width = btnSearchCustomer.Width;
            lblIdentityGroup.Location = new Point(lblCustomerName.Location.X, btnChooseIdentityGroup.Location.Y + (btnChooseIdentityGroup.Height - lblIdentityGroup.Height) / 2);

            panelFingers.Location = new Point(btnChooseIdentityGroup.Location.X, btnChooseIdentityGroup.Location.Y + btnChooseIdentityGroup.Height + TextManagement.ROOT_SIZE);
            panelFingers.Width = btnChooseIdentityGroup.Width;
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
            btnChooseIdentityGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (Properties.Settings.Default.preferFingerWidth > 0 && Properties.Settings.Default.preferFingerHeight > 0)
            {
                this.Size = new Size(Properties.Settings.Default.preferFingerWidth, Properties.Settings.Default.preferFingerHeight);
            }

            btnSearchCustomer.Click += BtnSearchCustomer_Click;
            btnSearchCustomer.MouseEnter += BtnSearchCustomer_MouseEnter;
            btnSearchCustomer.MouseLeave += BtnSearchCustomer_MouseLeave;

            btnChooseIdentityGroup.Click += BtnChooseIdentityGroup_Click;
            btnChooseIdentityGroup.MouseEnter += BtnChooseIdentityGroup_MouseEnter;
            btnChooseIdentityGroup.MouseLeave += BtnChooseIdentityGroup_MouseLeave;

            btnConfirm.Click += BtnConfirm_Click;
            btnConfirm.MouseEnter += BtnConfirm_MouseEnter;
            btnConfirm.MouseLeave += BtnConfirm_MouseLeave;
            this.ResizeEnd += FrmCustomerFingerRegister_ResizeEnd;
        }

        private void FrmCustomerFingerRegister_ResizeEnd(object? sender, EventArgs e)
        {
            Properties.Settings.Default.preferFingerWidth = this.Width;
            Properties.Settings.Default.preferFingerHeight = this.Height;
            Properties.Settings.Default.Save();
        }
        #endregion End Forms

        #region Controls In Form
        private void BtnSearchCustomer_MouseLeave(object? sender, EventArgs e)
        {
            btnSearchCustomer.Cursor = Cursors.Default;
            btnSearchCustomer.ForeColor = Color.Black;
        }
        private void BtnSearchCustomer_MouseEnter(object? sender, EventArgs e)
        {
            btnSearchCustomer.Cursor = Cursors.Hand;
            btnSearchCustomer.ForeColor = Color.Red;
        }
        private async void BtnSearchCustomer_Click(object? sender, EventArgs e)
        {
            frmSearchCustomer frm = new frmSearchCustomer();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                customerID = frm.SelectCustomerId;
                btnSearchCustomer.Text = customerName = frm.SelectCustomerName;

                var registedFingersResponse = await tblFingerCustomer.GetRegisterFingersByCustomerId(this.customerID);

                bool isRegistered = registedFingersResponse.Item1.Count > 0;

                panelFingers.Enabled = true;
                panelFingers.Controls.Clear();

                if (isRegistered)
                {
                    List<string> registedFingers = registedFingersResponse.Item1;
                    string fingerCustomerCode = registedFingersResponse.Item2;
                    List<Tuple<string, string>> fingerDatas = await tblFingerprint.GetFingerDatas(registedFingers);

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

                    //Kiểm tra xem người dùng có đăng ký trước đó hay không
                    Tuple<Identity, string> identityResponse = null;// await KzParkingApiHelper.GetIdentityByCodeAsync(fingerCustomerCode);
                    if (identityResponse.Item1 != null)
                    {
                        this.identity = identityResponse.Item1;
                        isExistIdentity = true;
                        string identityGroupId = identityResponse.Item1?.IdentityGroupId?.ToString();
                        if (!string.IsNullOrEmpty(identityGroupId))
                        {
                            this.identityGroupId = identityGroupId;
                            IdentityGroup identityGroup = null;// await KzParkingApiHelper.GetIdentityGroupByIdAsync(identityGroupId);
                            if (identityGroup != null)
                            {
                                btnChooseIdentityGroup.Text = identityGroup.Name;
                            }
                        }
                    }
                    else
                    {
                        isExistIdentity = false;
                        this.identity = null;
                    }
                }
                else
                {
                    this.identity = null;
                    this.isExistIdentity = false;

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
                }
            }
        }

        private void BtnChooseIdentityGroup_MouseLeave(object? sender, EventArgs e)
        {
            btnChooseIdentityGroup.Cursor = Cursors.Default;
            btnSearchCustomer.ForeColor = Color.Black;
        }
        private void BtnChooseIdentityGroup_MouseEnter(object? sender, EventArgs e)
        {
            btnChooseIdentityGroup.Cursor = Cursors.Hand;
            btnSearchCustomer.ForeColor = Color.Red;
        }
        private void BtnChooseIdentityGroup_Click(object? sender, EventArgs e)
        {
            frmSelectIdentityGroup frm = new frmSelectIdentityGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                identityGroupId = frm.IdentityGroupId;
                btnChooseIdentityGroup.Text = frm.IdentityGroupName;
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

            bool isAllSuccess = true;
            string fingerCustomerCode = tblFingerCustomer.GetFingerCustomeCode(customerID, out bool valid);
            tblFingerCustomer.DeleteByCustomerId(this.customerID);

            if (fingerDatas.Count > 0)
            {
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
            if (!isAllSuccess)
            {
                MessageBox.Show("Thêm thông tin vân tay vào hệ thống thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Đã tồn tại, cập nhật thông tin nếu có thay đổi
                if (this.isExistIdentity)
                {
                    if (this.identity!.IdentityGroupId.ToString() != this.identityGroupId)
                    {
                        var updateIdentity = new Identity()
                        {
                            Id = this.identity.Id,
                            Name = this.identity.Name,
                            Code = this.identity.Code,
                            IdentityGroupId = this.identityGroupId,
                            Note = "Vân tay " + customerName,
                        };
                        bool isUpdateSuccess = false;// await AppData.ApiServer.UpdateIdentityById(updateIdentity);
                        if (isUpdateSuccess)
                        {
                            this.identity.IdentityGroupId = this.identityGroupId;
                        }
                        else
                        {
                            MessageBox.Show("Thêm thông tin vân tay vào hệ thống thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                //Chưa tồn tại thêm mới
                else
                {
                    var insertIdentity = new Identity()
                    {
                        Name = "Vân tay " + customerName,
                        Code = fingerCustomerCode,
                        IdentityGroupId = this.identityGroupId,
                        Type = IdentityType.FingerPrint,
                        Note = "Vân tay " + customerName,
                    };
                    Identity _identity = null;// await AppData.ApiServer.crea(insertIdentity);
                    if (_identity != null)
                    {
                        this.isExistIdentity = true;
                        this.identity = new Identity()
                        {
                            Id = _identity.Id,
                            Name = "Vân tay " + customerName,
                            Code = fingerCustomerCode,
                            IdentityGroupId = this.identityGroupId,
                            Type = IdentityType.FingerPrint,
                            Note = "Vân tay " + customerName,
                        };
                    }
                    else
                    {
                        MessageBox.Show("Thêm thông tin vân tay vào hệ thống thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                bool isContinue = MessageBox.Show("Thêm thông tin vân tay vào hệ thống thành công, bạn có muốn đăng ký tiếp?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
                if (!isContinue)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        #endregion
    }
}
