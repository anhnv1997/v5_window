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

namespace iParkingv5_window.Forms.SystemForms
{
    public partial class frmOptionViewMode : Form
    {
        #region Properties
        private int rowCount = 0;
        [Browsable(true)]
        [Category("Custom row count")]
        [Description("Sets the row count")]
        public int RowCount
        {
            get { return rowCount; }
            set
            {
                this.rowCount = value == 0 ? 1 : value;
                numRow.Value = value == 0 ? 1 : value;
                this.Refresh();
            }
        }

        private int columnCount = 0;
        [Browsable(true)]
        [Category("Custom column count")]
        [Description("Sets the column count")]
        public int ColumnCount
        {
            get { return columnCount; }
            set
            {
                this.columnCount = value == 0 ? 1 : value;
                numColumn.Value = value == 0 ? 1 : value;
                this.Refresh();
            }
        }

        private int maximumCount = 0;
        [Browsable(true)]
        [Category("Custom maximum count")]
        [Description("Sets the maximum count")]
        public int MaximumCount
        {
            get { return maximumCount; }
            set
            {
                this.maximumCount = value;
                this.Refresh();
            }
        }
        #endregion End Properties

        #region Forms
        public frmOptionViewMode()
        {
            InitializeComponent();
            numRow.ValueChanged += NumRow_ValueChanged;
            numColumn.ValueChanged += NumColumn_ValueChanged;
        }
        private void frmOptionViewMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnOk.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }
        #endregion

        #region Controls In Form
        private void NumColumn_ValueChanged(object? sender, EventArgs e)
        {
            this.columnCount = (int)numColumn.Value;
            if (this.columnCount > 0)
            {
                numRow.Value = (this.MaximumCount / this.columnCount) > 0 ? (this.MaximumCount / this.columnCount) : 1;
            }
        }

        private void NumRow_ValueChanged(object? sender, EventArgs e)
        {
            this.rowCount = (int)numRow.Value;
            if (this.rowCount > 0)
            {
                numColumn.Value = (this.MaximumCount / this.rowCount) > 0 ? (this.MaximumCount / this.rowCount) : 1;
            }
        }
        #endregion
    }
}
