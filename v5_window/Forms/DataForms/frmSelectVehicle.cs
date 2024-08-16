using IPaking.Ultility;
using iParkingv5.Objects.Datas;
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
    public partial class frmSelectVehicle : Form
    {
        #region Properties
        private List<RegisteredVehicle> vehicles = new List<RegisteredVehicle>();
        public string selectedPlate;
        #endregion End Properties

        #region Forms
        public frmSelectVehicle(List<RegisteredVehicle> registeredVehicles)
        {
            InitializeComponent();
            this.vehicles = registeredVehicles;
            this.Load += FrmSelectVehicle_Load;
        }

        private void FrmSelectVehicle_Load(object? sender, EventArgs e)
        {
            int index = 0;
            foreach (var vehicle in vehicles)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = vehicle.Name + " - " + vehicle.PlateNumber;
                radioButton.Tag = vehicle.PlateNumber;
                this.Controls.Add(radioButton);
                radioButton.Location = new Point(lblTitle.Location.X,
                                                lblTitle.Location.Y + lblTitle.Height + 10 * (index + 1) + radioButton.Height * index);
                if (index == 0)
                {
                    radioButton.Checked = true;
                }
                index++;
            }

            btnOk1.InitControl(BtnOk1_Click);
            lblCancel1.InitControl(LblCancel1_Click);

            lblCancel1.Location = new Point(this.DisplayRectangle.Width - lblCancel1.Width - TextManagement.ROOT_SIZE * 2,
                                            this.DisplayRectangle.Height - lblCancel1.Height - TextManagement.ROOT_SIZE * 2);
            btnOk1.Location = new Point(lblCancel1.Location.X - btnOk1.Width - TextManagement.ROOT_SIZE,
                                        lblCancel1.Location.Y);
            btnOk1.Focus();
        }

        private void LblCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item is RadioButton)
                {
                    if (((RadioButton)item).Checked)
                    {

                        selectedPlate = ((RadioButton)item).Tag.ToString()!;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }
        #endregion End Forms

        #region Controls In Form

        #endregion End Controls In Form

        #region Private Function

        #endregion End Private Funciton

        #region Public Function

        #endregion End Public Function

    }
}
