using iParkingv5.Objects.Databases;
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

namespace iParkingv5_window.Forms.DevelopeModes
{
    public partial class frmSystemLogs : Form
    {
        #region Properties
        Mdb sqliteCOnnection;
        #endregion End Properties

        #region Forms
        public frmSystemLogs()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += FrmSystemLogs_KeyDown;
            btnCancel.Click += BtnCancel_Click;
            btnSearch.Click += BtnSearch_Click;
            this.ActiveControl = btnSearch;
        }


        private void FrmSystemLogs_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
           else if (e.KeyCode == Keys.Return)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void CbLogTable_SelectedIndexChanged(object? sender, EventArgs e)
        {
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            var data = LogHelper.GetLogData(txtCmd.Text);
            dgvData.DataSource = data;
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        #endregion End Controls In Form

        #region Private Function

        #endregion End Private Function

        #region Public Function

        #endregion End Public Function
    }
}
