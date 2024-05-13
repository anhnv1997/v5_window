﻿namespace iParkingv5_window.Usercontrols
{
    partial class ucCameraConfig
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cbCamera = new ComboBox();
            panelCamera = new Panel();
            btnLiveview = new Button();
            btnCarLprDetect = new Button();
            btnDraw = new Button();
            panel2 = new Panel();
            btnSave = new Button();
            btnMotorLprDetect = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            picCutVehicleImage = new MovablePictureBox();
            picLprImage = new MovablePictureBox();
            lblDetectPlate = new Label();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCutVehicleImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLprImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Camera";
            // 
            // cbCamera
            // 
            cbCamera.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCamera.FormattingEnabled = true;
            cbCamera.Location = new Point(62, 7);
            cbCamera.Margin = new Padding(3, 2, 3, 2);
            cbCamera.Name = "cbCamera";
            cbCamera.Size = new Size(291, 23);
            cbCamera.TabIndex = 1;
            // 
            // panelCamera
            // 
            panelCamera.BackColor = SystemColors.Control;
            panelCamera.Dock = DockStyle.Fill;
            panelCamera.Location = new Point(0, 60);
            panelCamera.Margin = new Padding(3, 2, 3, 2);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(706, 307);
            panelCamera.TabIndex = 2;
            // 
            // btnLiveview
            // 
            btnLiveview.Location = new Point(361, 6);
            btnLiveview.Margin = new Padding(3, 2, 3, 2);
            btnLiveview.Name = "btnLiveview";
            btnLiveview.Size = new Size(84, 21);
            btnLiveview.TabIndex = 3;
            btnLiveview.Text = "Live view";
            btnLiveview.UseVisualStyleBackColor = true;
            // 
            // btnCarLprDetect
            // 
            btnCarLprDetect.Location = new Point(451, 6);
            btnCarLprDetect.Margin = new Padding(3, 2, 3, 2);
            btnCarLprDetect.Name = "btnCarLprDetect";
            btnCarLprDetect.Size = new Size(130, 21);
            btnCarLprDetect.TabIndex = 3;
            btnCarLprDetect.Text = "Đọc biển số ô tô";
            btnCarLprDetect.UseVisualStyleBackColor = true;
            btnCarLprDetect.Visible = false;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(585, 6);
            btnDraw.Margin = new Padding(3, 2, 3, 2);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(156, 21);
            btnDraw.TabIndex = 3;
            btnDraw.Text = "Vẽ vùng nhận diện";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbCamera);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnDraw);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnMotorLprDetect);
            panel2.Controls.Add(btnCarLprDetect);
            panel2.Controls.Add(btnLiveview);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(920, 60);
            panel2.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(585, 32);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(156, 21);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu cấu hình";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnMotorLprDetect
            // 
            btnMotorLprDetect.Location = new Point(451, 32);
            btnMotorLprDetect.Margin = new Padding(3, 2, 3, 2);
            btnMotorLprDetect.Name = "btnMotorLprDetect";
            btnMotorLprDetect.Size = new Size(130, 21);
            btnMotorLprDetect.TabIndex = 3;
            btnMotorLprDetect.Text = "Đọc biển số xe máy";
            btnMotorLprDetect.UseVisualStyleBackColor = true;
            btnMotorLprDetect.Visible = false;
            btnMotorLprDetect.Click += btnMotorLprDetect_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(picCutVehicleImage, 0, 1);
            tableLayoutPanel1.Controls.Add(picLprImage, 0, 2);
            tableLayoutPanel1.Controls.Add(lblDetectPlate, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Right;
            tableLayoutPanel1.Location = new Point(706, 60);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(214, 307);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // picCutVehicleImage
            // 
            picCutVehicleImage.Location = new Point(2, 42);
            picCutVehicleImage.Margin = new Padding(0);
            picCutVehicleImage.Name = "picCutVehicleImage";
            picCutVehicleImage.Size = new Size(210, 130);
            picCutVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picCutVehicleImage.TabIndex = 0;
            picCutVehicleImage.TabStop = false;
            // 
            // picLprImage
            // 
            picLprImage.Location = new Point(2, 174);
            picLprImage.Margin = new Padding(0);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(210, 131);
            picLprImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picLprImage.TabIndex = 1;
            picLprImage.TabStop = false;
            // 
            // lblDetectPlate
            // 
            lblDetectPlate.Dock = DockStyle.Fill;
            lblDetectPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetectPlate.Location = new Point(5, 2);
            lblDetectPlate.Name = "lblDetectPlate";
            lblDetectPlate.Size = new Size(204, 38);
            lblDetectPlate.TabIndex = 2;
            lblDetectPlate.Text = "_";
            lblDetectPlate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucCameraConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panelCamera);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucCameraConfig";
            Size = new Size(920, 367);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCutVehicleImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLprImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox cbCamera;
        private Panel panelCamera;
        private Button btnLiveview;
        private Button btnCarLprDetect;
        private Button btnDraw;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private MovablePictureBox picCutVehicleImage;
        private MovablePictureBox picLprImage;
        private Label lblDetectPlate;
        private Button btnSave;
        private Button btnMotorLprDetect;
    }
}
