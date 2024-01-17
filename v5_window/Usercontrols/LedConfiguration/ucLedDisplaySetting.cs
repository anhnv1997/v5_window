using IPaking.Ultility;
using iParkingv5.Controller.KztekDevices;
using iParkingv5.LedDisplay.LEDs;
using iParkingv5.LedDisplay.LEDs.KztekLeds;
using iParkingv5_window.Usercontrols;
using iParkingv6.Objects.Datas;
using Kztek.Tool;
using Kztek.Tools;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class ucLedDisplaySetting : UserControl
    {
        #region Properties
        private List<Led> leds = new List<Led>();
        private Led? currentLed = null;
        int stepOrder = 0;
        private List<ucLedLineConfig> UCConfigs = new List<ucLedLineConfig>();
        IDisplayLED? displayLED = null;
        private string laneId;
        #endregion End Properties

        #region Forms
        public ucLedDisplaySetting(string laneId, List<Led> leds)
        {
            InitializeComponent();
            this.leds = leds;
            this.laneId = laneId;
            this.Load += UcLedDisplaySetting_Load;
            panelLedConfigs.AutoScroll = true;
        }

        private void UcLedDisplaySetting_Load(object? sender, EventArgs e)
        {
            foreach (Led item in this.leds)
            {
                cbLeds.Items.Add(item.name ?? string.Empty);
            }
            if (cbLeds.Items.Count > 0)
            {
                cbLeds.SelectedIndex = 0;
            }

            foreach (var item in this.leds)
            {
                if (item.name == cbLeds.Text)
                {
                    currentLed = item;
                    displayLED = LedFactory.CreateLed(this.currentLed);
                    break;
                }
            }

            LedDisplayConfig? configData = NewtonSoftHelper<LedDisplayConfig>.DeserializeObjectFromPath(
                                                PathManagement.laneLedConfigPath(laneId, this.currentLed?.id ?? ""));
            if (configData != null)
            {
                foreach (var item in configData.LedDisplaySteps)
                {
                    stepOrder = item.Key;

                    panelLedConfigs.SuspendLayout();
                    ucLedLineConfig uc = new ucLedLineConfig(currentLed?.row ?? 1, stepOrder);
                    uc.LoadOldConfig(item.Value);

                    panelLedConfigs.Controls.Add(uc);

                    uc.Dock = DockStyle.Top;
                    uc.BorderStyle = BorderStyle.Fixed3D;
                    uc.OnDeleteItemEvent += Uc_OnDeleteItemEvent;
                    uc.BringToFront();
                    UCConfigs.Add(uc);
                    panelLedConfigs.ResumeLayout();

                }
            }
            cbLeds.SelectedIndexChanged += cbLeds_SelectedIndexChanged;
        }
        #endregion End Forms

        #region Controls In Form
        private void cbLeds_SelectedIndexChanged(object? sender, EventArgs e)
        {
            btnSave.PerformClick();
            stepOrder = 0;
            foreach (var item in this.leds)
            {
                if (item.name == cbLeds.Text)
                {
                    currentLed = item;
                    displayLED = LedFactory.CreateLed(this.currentLed);
                    break;
                }
            }
        }
        private void btnAddStep_Click(object sender, EventArgs e)
        {
            panelLedConfigs.SuspendLayout();
            stepOrder++;
            ucLedLineConfig uc = new ucLedLineConfig(currentLed?.row ?? 1, stepOrder);
            panelLedConfigs.Controls.Add(uc);
            uc.Dock = DockStyle.Top;
            uc.BorderStyle = BorderStyle.Fixed3D;
            uc.OnDeleteItemEvent += Uc_OnDeleteItemEvent;
            uc.BringToFront();
            UCConfigs.Add(uc);
            panelLedConfigs.ResumeLayout();
        }
        private void Uc_OnDeleteItemEvent(object sender)
        {
            this.stepOrder--;
            ucLedLineConfig? deleteUC = sender as ucLedLineConfig;
            if (deleteUC == null)
            {
                return;
            }
            UCConfigs.Remove(deleteUC);

            this.Invoke(new Action(() =>
            {
                for (int i = 0; i < UCConfigs.Count; i++)
                {
                    if (UCConfigs[i].Order > deleteUC.Order)
                    {
                        UCConfigs[i].Order = UCConfigs[i].Order - 1;
                    }
                }
                panelLedConfigs.Controls.Remove(deleteUC);
            }));

            deleteUC.Dispose();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.currentLed == null)
            {
                return;
            }
            Dictionary<int, DisplayStepDetail> steps = new Dictionary<int, DisplayStepDetail>();
            for (int i = 0; i < UCConfigs.Count; i++)
            {
                var stepDetail = UCConfigs[i].GetConfig();
                steps.Add(UCConfigs[i].Order, stepDetail);
            }
            LedDisplayConfig ledDisplayConfig = new LedDisplayConfig()
            {
                LedId = this.currentLed.id,
                LedDisplaySteps = steps,
            };
            SaveConfig(ledDisplayConfig);
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (displayLED == null)
            {
                MessageBox.Show("Loại LED không được hỗ trợ chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmTestLedDisplay frm = new frmTestLedDisplay();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Dictionary<int, DisplayStepDetail> steps = new Dictionary<int, DisplayStepDetail>();
                for (int i = 0; i < UCConfigs.Count; i++)
                {
                    var stepDetail = UCConfigs[i].GetConfig();
                    steps.Add(UCConfigs[i].Order, stepDetail);
                }
                LedDisplayConfig ledDisplayConfig = new LedDisplayConfig()
                {
                    LedId = this.currentLed.id,
                    LedDisplaySteps = steps,
                };
                displayLED.Connect(this.currentLed);
                displayLED.SendToLED(frm.TestData, ledDisplayConfig);
            }
        }
        #endregion End Controls In Form

        #region Private Function
        private void SaveConfig(LedDisplayConfig ledDisplayConfig)
        {
            bool isSaveSuccess = NewtonSoftHelper<LedDisplayConfig>.SaveConfig(ledDisplayConfig, PathManagement.laneLedConfigPath(laneId, this.currentLed?.id ?? ""));
            if (isSaveSuccess)
            {
                MessageBox.Show("Lưu cấu hình hiển thị LED thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lưu cấu hình hiển thị LED thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion End Private Function

        #region Public Function
        #endregion End Public Function


    }
}
