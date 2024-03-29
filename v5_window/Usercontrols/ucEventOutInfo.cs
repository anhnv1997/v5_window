﻿using iParkingv5.Objects;
using iParkingv5.Objects.Datas;
using iParkingv5.Objects.Enums;
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

namespace iParkingv5_window.Usercontrols
{
    public partial class ucEventOutInfo : UserControl
    {
        public delegate void OnBackClick(object sender);
        public event OnBackClick onBackClickEvent;
        public ucEventOutInfo()
        {
            InitializeComponent();
            this.Load += UcEventOutInfo_Load;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Visible = false;
                onBackClickEvent?.Invoke(this);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void UcEventOutInfo_Load(object? sender, EventArgs e)
        {
            this.Visible = false;
            lblEventInTitle.Location = lblEventOutTitle.Location = lblDescriptionTitle.Location = new Point(StaticPool.baseSize * 2, StaticPool.baseSize * 2);
            lblLaneNameIn.Location = lblLaneNameOut.Location = lblLaneNameTitle.Location = new Point(lblEventOutTitle.Location.X,
                                                   lblEventOutTitle.Location.Y + lblEventOutTitle.Height + StaticPool.baseSize);
            lblTimeIn.Location = lblTimeOut.Location = lblTimeInTitle.Location = new Point(lblEventOutTitle.Location.X, lblLaneNameTitle.Location.Y + lblTimeInTitle.Height + StaticPool.baseSize);
            lblPlateNumberIn.Location = lblPlateNumberOut.Location = lblPlateNumberTitle.Location = new Point(lblEventOutTitle.Location.X, lblTimeInTitle.Location.Y + lblTimeInTitle.Height + StaticPool.baseSize);
            lblVehilceTypeIn.Location = lblVehilceTypeOut.Location = lblVehilceTypeTitle.Location = new Point(lblEventOutTitle.Location.X, lblPlateNumberTitle.Location.Y + lblPlateNumberTitle.Height + StaticPool.baseSize);
            lblIdentityNameIn.Location = lblIdentityNameOut.Location = lblIdentityNameTitle.Location = new Point(lblEventOutTitle.Location.X, lblVehilceTypeTitle.Location.Y + lblVehilceTypeTitle.Height + StaticPool.baseSize);
            lblIdentityCodeIn.Location = lblIdentityCodeOut.Location = lblIdentityCodeTitle.Location = new Point(lblEventOutTitle.Location.X, lblIdentityNameTitle.Location.Y + lblIdentityNameTitle.Height + StaticPool.baseSize);
            lblIdentityGroupIn.Location = lblIdentityGroupOut.Location = lblIdentityGroupTitle.Location = new Point(lblEventOutTitle.Location.X, lblIdentityCodeTitle.Location.Y + lblIdentityCodeTitle.Height + StaticPool.baseSize);

            dgvData.Height = lblIdentityGroupIn.Location.Y + lblIdentityGroupOut.Height + StaticPool.baseSize;

            lblCancel1.InitControl(LblCancel1_Click);
            this.Height = dgvData.Location.Y + dgvData.Height + StaticPool.baseSize * 3 + lblCancel1.Height;
            lblCancel1.Location = new Point(this.DisplayRectangle.Width - lblCancel1.Width - StaticPool.baseSize * 2,
                                            dgvData.Location.Y + dgvData.Height + StaticPool.baseSize);
            Refresh();
        }
        private void LblCancel1_Click(object? sender, EventArgs e)
        {
            this.Visible = false;
            Refresh();

            onBackClickEvent?.Invoke(this);
        }

        private void Refresh()
        {
            lblLaneNameIn.Text = "_";
            lblTimeIn.Text = "_";
            lblPlateNumberIn.Text = "_";
            lblVehilceTypeIn.Text = "_";
            lblIdentityNameIn.Text = "_";
            lblIdentityCodeIn.Text = "_";
            lblIdentityGroupIn.Text = "_";

            lblLaneNameOut.Text = "_";
            lblTimeOut.Text = "_";
            lblPlateNumberOut.Text = "_";
            lblVehilceTypeOut.Text = "_";
            lblIdentityNameOut.Text = "_";
            lblIdentityCodeOut.Text = "_";
            lblIdentityGroupOut.Text = "_";
        }

        public async void ShowInfo(Point position, string laneIdIn, string datetimeIn, string plateIn, string identityIdIn, string userIdIn,
                                                   string laneIdOut, string datetimeOut, string plateOut, string identityIdOut, string userIdOut)
        {
            try
            {
                this.SuspendLayout();
                this.Location = position;

                if (this.Location.X + this.Width > this.Parent.Width)
                {
                    this.Location = new Point(this.Parent.Width - this.Width - StaticPool.baseSize * 2, this.Location.Y);
                }
                if (this.Location.Y + this.Height > this.Parent.Height)
                {
                    this.Location = new Point(this.Location.X, this.Parent.Height - this.Height - StaticPool.baseSize * 2);
                }

                this.BackColor = Color.FromArgb(255, 224, 192);
                this.Visible = true;

                Lane? laneIn = await KzParkingApiHelper.GetLaneByIdAsync(laneIdIn);
                Identity? identityIn = await KzParkingApiHelper.GetIdentityById(identityIdIn);
                IdentityGroup? identityGroupIn = null;
                VehicleType? vehicleTypeIn = null;
                if (identityIn != null)
                {
                    identityGroupIn = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identityIn.IdentityGroupId.ToString());
                    if (identityGroupIn != null)
                    {
                        vehicleTypeIn = await KzParkingApiHelper.GetVehicleTypeById(identityGroupIn.VehicleTypeId.ToString());
                    }
                }
                lblLaneNameIn.Text = laneIn == null ? "_" : laneIn.name;
                lblTimeIn.Text = datetimeIn;
                lblPlateNumberIn.Text = plateIn;
                lblVehilceTypeIn.Text = vehicleTypeIn == null ? "_" : vehicleTypeIn.Name;
                lblIdentityNameIn.Text = identityIn == null ? "_" : identityIn.Name;
                lblIdentityCodeIn.Text = identityIn == null ? "_" : identityIn.Code;
                lblIdentityGroupIn.Text = identityGroupIn == null ? "_" : identityGroupIn.Name;

                Lane? laneOut = await KzParkingApiHelper.GetLaneByIdAsync(laneIdOut);
                Identity? identityOut = await KzParkingApiHelper.GetIdentityById(identityIdOut);
                IdentityGroup? identityGroupOut = null;
                VehicleType? vehicleTypeOut = null;
                if (identityOut != null)
                {
                    identityGroupOut = await KzParkingApiHelper.GetIdentityGroupByIdAsync(identityOut.IdentityGroupId.ToString());
                    if (identityGroupOut != null)
                    {
                        vehicleTypeOut = await KzParkingApiHelper.GetVehicleTypeById(identityGroupOut.VehicleTypeId.ToString());
                    }
                }
                lblLaneNameOut.Text = laneOut == null ? "_" : laneOut.name;
                lblTimeOut.Text = datetimeOut;
                lblPlateNumberOut.Text = plateOut;
                lblVehilceTypeOut.Text = vehicleTypeOut == null ? "_" : vehicleTypeOut.Name;
                lblIdentityNameOut.Text = identityOut == null ? "_" : identityOut.Name;
                lblIdentityCodeOut.Text = identityOut == null ? "_" : identityOut.Code;
                lblIdentityGroupOut.Text = identityGroupOut == null ? "_" : identityGroupOut.Name;


                //lblLaneNameOut.Location = new Point(this.DisplayRectangle.Width - lblLaneNameOut.Width - StaticPool.baseSize * 2, lblLaneNameTitle.Location.Y);
                //lblTimeIn.Location = new Point(this.DisplayRectangle.Width - lblTimeIn.Width - StaticPool.baseSize * 2, lblTimeInTitle.Location.Y);
                //lblPlateNumberIn.Location = new Point(this.DisplayRectangle.Width - lblPlateNumberIn.Width - StaticPool.baseSize * 2, lblPlateNumberTitle.Location.Y);
                //lblVehilceTypeIn.Location = new Point(this.DisplayRectangle.Width - lblVehilceTypeIn.Width - StaticPool.baseSize * 2, lblVehilceTypeTitle.Location.Y);
                //lblIdentityNameIn.Location = new Point(this.DisplayRectangle.Width - lblIdentityNameIn.Width - StaticPool.baseSize * 2, lblIdentityNameTitle.Location.Y);
                //lblIdentityCodeIn.Location = new Point(this.DisplayRectangle.Width - lblIdentityCodeIn.Width - StaticPool.baseSize * 2, lblIdentityCodeTitle.Location.Y);
                //lblIdentityGroupIn.Location = new Point(this.DisplayRectangle.Width - lblIdentityGroupIn.Width - StaticPool.baseSize * 2, lblIdentityGroupTitle.Location.Y);

                this.BringToFront();
                this.ResumeLayout();
                this.ActiveControl = lblCancel1;
            }
            catch (Exception)
            {
            }
        }
    }
}