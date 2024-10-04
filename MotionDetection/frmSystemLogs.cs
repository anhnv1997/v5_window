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
            dgvData.SelectionChanged += DgvData_SelectionChanged;
            var currentTime = DateTime.Now;
            dtpStartTime.Value = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 23,59,59);
            this.ActiveControl = btnSearch;
        }

        private void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            string lprPath = dgvData.CurrentRow.Cells[4].Value.ToString();
            string vehiclePath = dgvData.CurrentRow.Cells[3].Value.ToString();
            try
            {
                picVehicle.Load(vehiclePath);
            }
            catch (Exception)
            {
                picVehicle.Image = null;
            }
            try
            {
                picLpr.Load(lprPath);
            }
            catch (Exception)
            {
                picVehicle.Image = null;
            }
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
            var data = tblMotionLog.GetLogData(dtpStartTime.Value, dtpEndTime.Value);
            dgvData.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {
                dgvData.Rows.Add(dgvData.Rows.Count + 1, row["CreatedDate"].ToString(), row["DetectPlate"].ToString(),
                                        row["VehicleImage"].ToString(), row["LprImage"].ToString());
            }
            if (dgvData.Rows.Count > 0)
            {
                dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
            }
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
