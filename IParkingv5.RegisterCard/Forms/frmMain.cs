using iParkingv5.Controller;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.Enums;
using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using Kztek.Tool.LogDatabases;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iParkingv5.Objects.Enums.CardFormat;

namespace IParkingv5.RegisterCard
{
    public partial class frmMain : Form
    {
        #region Properties
        private IController controller;
        private List<Bdk> Bdks = new List<Bdk>();
        private List<IdentityGroup> IdentityGroups = new List<IdentityGroup>();
        #endregion End Properties

        #region Forms
        public frmMain()
        {
            InitializeComponent();
        }
        private async void frmMain_Load(object sender, EventArgs e)
        {
            await CreateUI();
            RegisterUIEvent();
        }
        private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (this.controller != null)
            {
                this.controller.CardEvent -= Controller_CardEvent;
            }
            this.controller?.PollingStop();
            Application.Exit();
            Environment.Exit(0);
        }

        #endregion End Forms

        #region Controls In Form
        private async void BtnStart_Click(object? sender, EventArgs e)
        {
            string controllerId = ((ListItem)cbController.SelectedItem)?.Value ?? "";
            if (string.IsNullOrWhiteSpace(controllerId))
            {
                MessageBox.Show("Hãy chọn bộ điều khiển đăng ký định danh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
            if (string.IsNullOrWhiteSpace(identityGroupId))
            {
                MessageBox.Show("Hãy chọn nhóm định danh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Bdk bdk = (from Bdk in Bdks
                       where Bdk.Id == controllerId
                       select Bdk).FirstOrDefault()!;
            this.controller = ControllerFactory.CreateController(bdk)!;
            bool isConnect = await this.controller.ConnectAsync();
            if (isConnect)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                this.controller.CardEvent += Controller_CardEvent;
                this.controller.PollingStart();
            }
            else
            {
                MessageBox.Show("Không kết nối được tới thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void BtnStop_Click(object? sender, EventArgs e)
        {
            btnStart.Enabled = true;
            if (this.controller != null)
            {
                this.controller.CardEvent -= Controller_CardEvent;
            }
            this.controller?.PollingStop();
        }
        #endregion End Controls In Form

        #region Private Function
        private async Task CreateUI()
        {
            //Load IdentityType
            foreach (var item in Enum.GetValues(typeof(IdentityType)))
            {
                cbIdentityType.Items.Add(item);
            }
            foreach (CardFormat.EmCardFormat item in Enum.GetValues(typeof(CardFormat.EmCardFormat)))
            {
                cbInputFormat.Items.Add(CardFormat.ToString(item));
                cbOutputFormat.Items.Add(CardFormat.ToString(item));
            }
            foreach (CardFormat.EmCardFormatOption item in Enum.GetValues(typeof(CardFormat.EmCardFormatOption)))
            {
                cbOption.Items.Add(CardFormat.ToString(item));
            }
            cbInputFormat.SelectedIndexChanged += CbInputFormat_SelectedIndexChanged;
            cbOutputFormat.SelectedIndexChanged += CbOutputFormat_SelectedIndexChanged;
            cbOption.SelectedIndexChanged += CbOption_SelectedIndexChanged;
            cbInputFormat.SelectedIndex = Properties.Settings.Default.input_format;
            cbOutputFormat.SelectedIndex = Properties.Settings.Default.output_format;
            cbOption.SelectedIndex = Properties.Settings.Default.option;
            //Load IdentityGroups
            IdentityGroups = (await AppData.ApiServer.parkingDataService.GetIdentityGroupsAsync())?.Item1 ?? new List<IdentityGroup>();
            foreach (var item in IdentityGroups)
            {
                ListItem li = new ListItem();
                li.Value = item.Id.ToString();
                li.Name = item.Name;
                cbIdentityGroup.Items.Add(li);
            }
            //Load Controllers
            Bdks = (await AppData.ApiServer.deviceService.GetControlUnitsAsync()).Item1 ?? new List<Bdk>();
            foreach (var item in Bdks)
            {
                ListItem li = new ListItem();
                li.Value = item.Id.ToString();
                li.Name = item.Name;
                cbController.Items.Add(li);
            }

            cbIdentityGroup.ValueMember = "Value";
            cbIdentityGroup.DisplayMember = "Name";

            cbController.ValueMember = "Value";
            cbController.DisplayMember = "Name";

            cbController.SelectedIndex = cbController.Items.Count > 0 ? 0 : -1;
            cbIdentityGroup.SelectedIndex = cbIdentityGroup.Items.Count > 0 ? 0 : -1;
            cbIdentityType.SelectedIndex = cbIdentityType.Items.Count > 0 ? 0 : -1;
            cbFormat.SelectedIndex = 0;

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void CbOption_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Properties.Settings.Default.option = cbOption.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void CbOutputFormat_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Properties.Settings.Default.output_format = cbOutputFormat.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void CbInputFormat_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Properties.Settings.Default.input_format = cbInputFormat.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void RegisterUIEvent()
        {
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            this.FormClosing += FrmMain_FormClosing;
        }
        private async void Controller_CardEvent(object sender, iParkingv5.Objects.Events.CardEventArgs e)
        {
            tblSystemLog.SaveLog(tblSystemLog.EmSystemAction.Application, tblSystemLog.EmSystemActionDetail.PROCESS, "Card Event", e);

            string identityGroupId = "";
            this.Invoke(new Action(() =>
            {
                identityGroupId = ((ListItem)cbIdentityGroup.SelectedItem)?.Value ?? "";
                if (string.IsNullOrWhiteSpace(identityGroupId))
                {
                    MessageBox.Show("Hãy chọn nhóm định danh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }));
            string code = "";
            this.Invoke(new Action(() =>
            {
                code = CardFactory.StandardlizedCardNumber(e.PreferCard, new iParkingv5.Objects.Configs.CardFormatConfig()
                {
                    InputFormat = (EmCardFormat)cbInputFormat.SelectedIndex,
                    OutputFormat = (EmCardFormat)cbOutputFormat.SelectedIndex,
                    OutputOption = (EmCardFormatOption)cbOption.SelectedIndex,
                });
            }));
            Identity? identity = (await AppData.ApiServer.parkingDataService.GetIdentityByCodeAsync(code)).Item1;
            if (identity == null)
            {
                int currentIndex = (int)numericUpDown1.Value + 1;
                string format = "";
                IdentityType type = IdentityType.Card;
                this.Invoke(new Action(() =>
                {
                    format = cbFormat.Text;
                    type = (IdentityType)cbIdentityType.SelectedIndex;

                }));
                //Thêm mới
                identity = new Identity()
                {
                    Name = txtLetter.Text + currentIndex.ToString(format),
                    Code = code,
                    IdentityGroupId = identityGroupId,
                    Type = type,
                };

                identity = (await AppData.ApiServer.parkingDataService.CreateIdentityAsync(identity))?.Item1 ?? null;
                if (identity != null)
                {
                    this.Invoke(new Action(() =>
                    {
                        numericUpDown1.Value = currentIndex;
                        lsbShow.Items.Add(code + " - Thêm mới");
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        numericUpDown1.Value = currentIndex;
                        lsbShow.Items.Add(code + " - Thêm mới thất bại");
                    }));
                }
            }
            else
            {
                this.Invoke((Action)(() =>
                {
                    //Thông báo đã có
                    lsbShow.Items.Add(code + " - đã tồn tại trong hệ thống");
                }));
            }

        }
        #endregion End Private Function

        private async void btnStart_Click_1(object sender, EventArgs e)
        {

        }
    }
}
