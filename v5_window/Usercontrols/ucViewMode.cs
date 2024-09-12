using DocumentFormat.OpenXml.VariantTypes;
using iParkingv5.Objects;
using iParkingv5_window.Forms.SystemForms;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iParkingv5.Objects.Configs.AppViewModeConfig;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucViewMode : UserControl
    {
        private EmAppViewMode viewMode = EmAppViewMode.Horizontal;
        [Browsable(true)]
        [Category("Custom Message")]
        [Description("Sets the text of the Label")]
        public EmAppViewMode ViewMode
        {
            get { return viewMode; }
            set
            {
                this.viewMode = value;
                switch (viewMode)
                {
                    case EmAppViewMode.Optional:
                        radioOption.Checked = true;
                        tblOption.BackColor = Color.Aqua;
                        tblHorizontal.BackColor = SystemColors.ButtonHighlight;
                        tblVertical.BackColor = SystemColors.ButtonHighlight;
                        break;
                    case EmAppViewMode.Horizontal:
                        radioHorizontal.Checked = true;
                        tblHorizontal.BackColor = Color.Aqua;
                        tblOption.BackColor = SystemColors.ButtonHighlight;
                        tblVertical.BackColor = SystemColors.ButtonHighlight;
                        break;
                    case EmAppViewMode.Vertical:
                        radioVertical.Checked = true;
                        tblVertical.BackColor = Color.Aqua;
                        tblHorizontal.BackColor = SystemColors.ButtonHighlight;
                        tblOption.BackColor = SystemColors.ButtonHighlight;
                        break;
                    default:
                        break;
                }
                this.Refresh();
            }
        }

        public int RowCount
        {
            get => StaticPool.appViewModeConfig.RowCount;
            set
            {
                StaticPool.appViewModeConfig.RowCount = value;
                tblOption.RowCount = StaticPool.appViewModeConfig.RowCount = StaticPool.appViewModeConfig.RowCount;
                tblOption.ColumnCount = StaticPool.appViewModeConfig.ColumnCount = StaticPool.appViewModeConfig.ColumnCount;

                tblOption.ColumnStyles.Clear();
                tblOption.RowStyles.Clear();
                for (int i = 0; i < tblOption.ColumnCount; i++)
                {
                    tblOption.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / tblOption.RowCount));
                }
                for (int i = 0; i < tblOption.RowCount; i++)
                {
                    tblOption.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tblOption.RowCount));
                }
            }
        }

        public int ColumnCount
        {
            get => StaticPool.appViewModeConfig.ColumnCount;
            set
            {
                StaticPool.appViewModeConfig.ColumnCount = value;
                tblOption.RowCount = StaticPool.appViewModeConfig.RowCount = StaticPool.appViewModeConfig.RowCount;
                tblOption.ColumnCount = StaticPool.appViewModeConfig.ColumnCount = StaticPool.appViewModeConfig.ColumnCount;

                tblOption.ColumnStyles.Clear();
                tblOption.RowStyles.Clear();
                for (int i = 0; i < tblOption.ColumnCount; i++)
                {
                    tblOption.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / tblOption.RowCount));
                }
                for (int i = 0; i < tblOption.RowCount; i++)
                {
                    tblOption.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tblOption.RowCount));
                }
            }
        }

        public delegate void OnEdit(object sender, EventArgs e);
        public event OnEdit? onEdit;
        public ucViewMode()
        {
            InitializeComponent();
            this.Click += UcViewMode_Click;
            tblMain.Click += UcViewMode_Click;

            tblVertical.Click += UcViewMode_Click;
            tblOption.Click += UcViewMode_Click;
            tblHorizontal.Click += UcViewMode_Click;

            panelOption.Click += UcViewMode_Click;

            foreach (Control item in tblVertical.Controls)
            {
                item.Click += UcViewMode_Click;
            }
            foreach (Control item in tblOption.Controls)
            {
                item.Click += UcViewMode_Click;
            }
            foreach (Control item in tblHorizontal.Controls)
            {
                item.Click += UcViewMode_Click;
            }

            radioOption.CheckedChanged += RadioOption_CheckedChanged;
            radioHorizontal.CheckedChanged += RadioOption_CheckedChanged;
            radioVertical.CheckedChanged += RadioOption_CheckedChanged;
        }

        private void RadioOption_CheckedChanged(object? sender, EventArgs e)
        {
            onEdit?.Invoke(this, e);
            if (radioOption.Checked)
            {
                ViewMode = EmAppViewMode.Optional;
            }
            else if (radioHorizontal.Checked)
            {
                ViewMode = EmAppViewMode.Horizontal;
            }
            else if (radioVertical.Checked)
            {
                ViewMode = EmAppViewMode.Vertical;
            }
        }
        private void UcViewMode_Click(object? sender, EventArgs e)
        {
            onEdit?.Invoke(this, e);
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            var frmViewOption = new frmOptionViewMode();
            frmViewOption.MaximumCount = StaticPool.lanes.Where(e => e.enabled).Count();
            frmViewOption.RowCount = StaticPool.appViewModeConfig.RowCount;
            frmViewOption.ColumnCount = StaticPool.appViewModeConfig.ColumnCount;
            if (frmViewOption.ShowDialog(this) == DialogResult.OK)
            {
                tblOption.RowCount = StaticPool.appViewModeConfig.RowCount = frmViewOption.RowCount;
                tblOption.ColumnCount = StaticPool.appViewModeConfig.ColumnCount = frmViewOption.ColumnCount;

                tblOption.ColumnStyles.Clear();
                tblOption.RowStyles.Clear();
                for (int i = 0; i < tblOption.ColumnCount; i++)
                {
                    tblOption.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / tblOption.RowCount));
                }
                for (int i = 0; i < tblOption.RowCount; i++)
                {
                    tblOption.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tblOption.RowCount));
                }
            }
        }
    }
}
