﻿using iPakrkingv5.Controls.Controls.Labels;
using iPakrkingv5.Controls.Usercontrols;

namespace iParkingv5_window.Forms.DataForms
{
    partial class frmConfirmIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmIn));
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtDetectPlate = new iPakrkingv5.Controls.Controls.TextBoxs.AutoFontSizeTextBox();
            label7 = new Label();
            label1 = new Label();
            label4 = new Label();
            lblTimeIn = new lblResult();
            panel2 = new Panel();
            lblRegisterPlate = new lblResult();
            btnCopy = new Button();
            label3 = new Label();
            lblIdentityCode = new lblResult();
            label5 = new Label();
            lblIdentityGroup = new lblResult();
            label6 = new Label();
            lblVehicleType = new lblResult();
            panelEventPic = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverview = new MovablePictureBox();
            picVehicle = new MovablePictureBox();
            lblMessage = new Label();
            panelAction = new Panel();
            lblGuide = new lblResult();
            lblCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            lblTimer = new Label();
            timerAutoConfirm = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            panelEventPic.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            panelAction.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(panelEventPic);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 44);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(883, 339);
            panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(txtDetectPlate, 1, 0);
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(lblTimeIn, 1, 2);
            tableLayoutPanel2.Controls.Add(panel2, 1, 1);
            tableLayoutPanel2.Controls.Add(label3, 0, 3);
            tableLayoutPanel2.Controls.Add(lblIdentityCode, 1, 3);
            tableLayoutPanel2.Controls.Add(label5, 0, 4);
            tableLayoutPanel2.Controls.Add(lblIdentityGroup, 1, 4);
            tableLayoutPanel2.Controls.Add(label6, 0, 5);
            tableLayoutPanel2.Controls.Add(lblVehicleType, 1, 5);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Font = new Font("Segoe UI", 12F);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4059124F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.64307F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.Size = new Size(602, 339);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // txtDetectPlate
            // 
            txtDetectPlate.BackColor = SystemColors.ActiveCaption;
            txtDetectPlate.Dock = DockStyle.Bottom;
            txtDetectPlate.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            txtDetectPlate.IsBold = true;
            txtDetectPlate.Location = new Point(147, 14);
            txtDetectPlate.MaxFontSize = 24;
            txtDetectPlate.Message = "";
            txtDetectPlate.MessageBackColor = SystemColors.ActiveCaption;
            txtDetectPlate.MessageForeColor = Color.White;
            txtDetectPlate.Name = "txtDetectPlate";
            txtDetectPlate.Size = new Size(451, 50);
            txtDetectPlate.TabIndex = 9;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(4, 1);
            label7.Name = "label7";
            label7.Size = new Size(136, 66);
            label7.TabIndex = 5;
            label7.Text = "Biển Số Nhận Dạng";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(4, 125);
            label1.Name = "label1";
            label1.Size = new Size(136, 52);
            label1.TabIndex = 0;
            label1.Text = "Giờ Vào";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(4, 68);
            label4.Name = "label4";
            label4.Size = new Size(136, 56);
            label4.TabIndex = 2;
            label4.Text = "Biển Số Đăng Ký";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeIn
            // 
            lblTimeIn.BackColor = SystemColors.Control;
            lblTimeIn.Dock = DockStyle.Fill;
            lblTimeIn.Font = new Font("Segoe UI", 12F);
            lblTimeIn.IsBold = true;
            lblTimeIn.IsUpper = false;
            lblTimeIn.Location = new Point(147, 125);
            lblTimeIn.MaxFontSize = 14;
            lblTimeIn.Message = "_ _ _ _ _";
            lblTimeIn.MessageBackColor = SystemColors.Control;
            lblTimeIn.MessageForeColor = Color.Black;
            lblTimeIn.Name = "lblTimeIn";
            lblTimeIn.Size = new Size(451, 52);
            lblTimeIn.TabIndex = 7;
            lblTimeIn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblRegisterPlate);
            panel2.Controls.Add(btnCopy);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(144, 68);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(457, 56);
            panel2.TabIndex = 14;
            // 
            // lblRegisterPlate
            // 
            lblRegisterPlate.BackColor = SystemColors.Control;
            lblRegisterPlate.Dock = DockStyle.Fill;
            lblRegisterPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRegisterPlate.IsBold = true;
            lblRegisterPlate.IsUpper = false;
            lblRegisterPlate.Location = new Point(0, 0);
            lblRegisterPlate.MaxFontSize = 14;
            lblRegisterPlate.Message = "_ _ _ _ _";
            lblRegisterPlate.MessageBackColor = SystemColors.Control;
            lblRegisterPlate.MessageForeColor = Color.Black;
            lblRegisterPlate.Name = "lblRegisterPlate";
            lblRegisterPlate.Size = new Size(410, 56);
            lblRegisterPlate.TabIndex = 10;
            lblRegisterPlate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCopy
            // 
            btnCopy.AutoSize = true;
            btnCopy.Dock = DockStyle.Right;
            btnCopy.Image = Properties.Resources.icons8_copy_24px;
            btnCopy.Location = new Point(410, 0);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(47, 56);
            btnCopy.TabIndex = 11;
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(4, 178);
            label3.Name = "label3";
            label3.Size = new Size(136, 52);
            label3.TabIndex = 1;
            label3.Text = "Tên Định Danh";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityCode
            // 
            lblIdentityCode.BackColor = SystemColors.Control;
            lblIdentityCode.Dock = DockStyle.Fill;
            lblIdentityCode.Font = new Font("Segoe UI", 12F);
            lblIdentityCode.IsBold = true;
            lblIdentityCode.IsUpper = false;
            lblIdentityCode.Location = new Point(147, 178);
            lblIdentityCode.MaxFontSize = 14;
            lblIdentityCode.Message = "_ _ _ _ _";
            lblIdentityCode.MessageBackColor = SystemColors.Control;
            lblIdentityCode.MessageForeColor = Color.Black;
            lblIdentityCode.Name = "lblIdentityCode";
            lblIdentityCode.Size = new Size(451, 52);
            lblIdentityCode.TabIndex = 9;
            lblIdentityCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(4, 231);
            label5.Name = "label5";
            label5.Size = new Size(136, 52);
            label5.TabIndex = 3;
            label5.Text = "Nhóm";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityGroup
            // 
            lblIdentityGroup.BackColor = SystemColors.Control;
            lblIdentityGroup.Dock = DockStyle.Fill;
            lblIdentityGroup.Font = new Font("Segoe UI", 12F);
            lblIdentityGroup.IsBold = true;
            lblIdentityGroup.IsUpper = false;
            lblIdentityGroup.Location = new Point(147, 231);
            lblIdentityGroup.MaxFontSize = 14;
            lblIdentityGroup.Message = "_ _ _ _ _";
            lblIdentityGroup.MessageBackColor = SystemColors.Control;
            lblIdentityGroup.MessageForeColor = Color.Black;
            lblIdentityGroup.Name = "lblIdentityGroup";
            lblIdentityGroup.Size = new Size(451, 52);
            lblIdentityGroup.TabIndex = 13;
            lblIdentityGroup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(4, 284);
            label6.Name = "label6";
            label6.Size = new Size(136, 54);
            label6.TabIndex = 4;
            label6.Text = "Loại Xe";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleType
            // 
            lblVehicleType.BackColor = SystemColors.Control;
            lblVehicleType.Dock = DockStyle.Fill;
            lblVehicleType.Font = new Font("Segoe UI", 12F);
            lblVehicleType.IsBold = true;
            lblVehicleType.IsUpper = false;
            lblVehicleType.Location = new Point(147, 284);
            lblVehicleType.MaxFontSize = 14;
            lblVehicleType.Message = "_ _ _ _ _";
            lblVehicleType.MessageBackColor = SystemColors.Control;
            lblVehicleType.MessageForeColor = Color.Black;
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(451, 54);
            lblVehicleType.TabIndex = 12;
            lblVehicleType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelEventPic
            // 
            panelEventPic.Controls.Add(tableLayoutPanel1);
            panelEventPic.Dock = DockStyle.Right;
            panelEventPic.Location = new Point(602, 0);
            panelEventPic.Margin = new Padding(3, 2, 3, 2);
            panelEventPic.Name = "panelEventPic";
            panelEventPic.Size = new Size(281, 339);
            panelEventPic.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picOverview, 0, 0);
            tableLayoutPanel1.Controls.Add(picVehicle, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(281, 339);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // picOverview
            // 
            picOverview.Dock = DockStyle.Fill;
            picOverview.Location = new Point(3, 2);
            picOverview.Margin = new Padding(3, 2, 3, 2);
            picOverview.Name = "picOverview";
            picOverview.Size = new Size(275, 165);
            picOverview.SizeMode = PictureBoxSizeMode.Zoom;
            picOverview.TabIndex = 0;
            picOverview.TabStop = false;
            // 
            // picVehicle
            // 
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Location = new Point(3, 171);
            picVehicle.Margin = new Padding(3, 2, 3, 2);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(275, 166);
            picVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(883, 44);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAction
            // 
            panelAction.Controls.Add(lblGuide);
            panelAction.Controls.Add(lblCancel1);
            panelAction.Controls.Add(btnOk1);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 410);
            panelAction.Margin = new Padding(3, 2, 3, 2);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(883, 46);
            panelAction.TabIndex = 5;
            // 
            // lblGuide
            // 
            lblGuide.BackColor = SystemColors.Control;
            lblGuide.Dock = DockStyle.Left;
            lblGuide.ForeColor = Color.FromArgb(255, 128, 0);
            lblGuide.IsBold = true;
            lblGuide.IsUpper = false;
            lblGuide.Location = new Point(0, 0);
            lblGuide.MaxFontSize = 12;
            lblGuide.Message = "Vui lòng kiểm tra và nhập biển số phương tiện vào ô biển số ra.\r\nNhấn Enter để xác nhận, Esc để hủy.";
            lblGuide.MessageBackColor = SystemColors.Control;
            lblGuide.MessageForeColor = Color.FromArgb(255, 128, 0);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(467, 46);
            lblGuide.TabIndex = 8;
            // 
            // lblCancel1
            // 
            lblCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCancel1.AutoSize = true;
            lblCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblCancel1.ForeColor = Color.Black;
            lblCancel1.Location = new Point(818, 7);
            lblCancel1.Margin = new Padding(3, 2, 3, 2);
            lblCancel1.Name = "lblCancel1";
            lblCancel1.Size = new Size(57, 30);
            lblCancel1.TabIndex = 5;
            lblCancel1.Text = "Đóng";
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(729, 7);
            btnOk1.Margin = new Padding(3, 2, 3, 2);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(83, 30);
            btnOk1.TabIndex = 4;
            btnOk1.Text = "Xác nhận";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Dock = DockStyle.Bottom;
            lblTimer.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblTimer.ForeColor = Color.FromArgb(255, 128, 0);
            lblTimer.Location = new Point(0, 383);
            lblTimer.Name = "lblTimer";
            lblTimer.Padding = new Padding(0, 3, 0, 3);
            lblTimer.Size = new Size(204, 27);
            lblTimer.TabIndex = 7;
            lblTimer.Text = "Tự động xác nhận/đóng sau";
            // 
            // timerAutoConfirm
            // 
            timerAutoConfirm.Interval = 1000;
            timerAutoConfirm.Tick += timerAutoConfirm_Tick;
            // 
            // frmConfirmIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 456);
            Controls.Add(panel1);
            Controls.Add(lblTimer);
            Controls.Add(lblMessage);
            Controls.Add(panelAction);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmConfirmIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            KeyDown += frmConfirmIn_KeyDown;
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelEventPic.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverview).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panelEventPic;
        private TableLayoutPanel tableLayoutPanel1;
        private MovablePictureBox picOverview;
        private MovablePictureBox picVehicle;
        private Label lblMessage;
        private Panel panelAction;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel lblCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.BtnOk btnOk1;
        private TableLayoutPanel tableLayoutPanel2;
        private lblResult lblIdentityGroup;
        private lblResult lblVehicleType;
        private Label label6;
        private Label label5;
        private Label label7;
        private Label label3;
        private Label label1;
        private Label label4;
        private lblResult lblTimeIn;
        private lblResult lblIdentityCode;
        private Panel panel2;
        private lblResult lblRegisterPlate;
        private Button btnCopy;
        private Label lblTimer;
        private System.Windows.Forms.Timer timerAutoConfirm;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblGuide;
        private iPakrkingv5.Controls.Controls.TextBoxs.AutoFontSizeTextBox txtDetectPlate;
    }
}