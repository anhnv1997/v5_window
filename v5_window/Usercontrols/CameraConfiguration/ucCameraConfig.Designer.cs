namespace iParkingv5_window.Usercontrols
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
            label1.Location = new Point(5, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 0;
            label1.Text = "Camera";
            // 
            // cbCamera
            // 
            cbCamera.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCamera.FormattingEnabled = true;
            cbCamera.Location = new Point(80, 10);
            cbCamera.Margin = new Padding(4, 3, 4, 3);
            cbCamera.Name = "cbCamera";
            cbCamera.Size = new Size(373, 29);
            cbCamera.TabIndex = 1;
            // 
            // panelCamera
            // 
            panelCamera.BackColor = SystemColors.Control;
            panelCamera.Dock = DockStyle.Fill;
            panelCamera.Location = new Point(0, 84);
            panelCamera.Margin = new Padding(4, 3, 4, 3);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(727, 428);
            panelCamera.TabIndex = 2;
            // 
            // btnLiveview
            // 
            btnLiveview.Location = new Point(464, 8);
            btnLiveview.Margin = new Padding(4, 3, 4, 3);
            btnLiveview.Name = "btnLiveview";
            btnLiveview.Size = new Size(108, 29);
            btnLiveview.TabIndex = 3;
            btnLiveview.Text = "Live view";
            btnLiveview.UseVisualStyleBackColor = true;
            // 
            // btnCarLprDetect
            // 
            btnCarLprDetect.Location = new Point(580, 8);
            btnCarLprDetect.Margin = new Padding(4, 3, 4, 3);
            btnCarLprDetect.Name = "btnCarLprDetect";
            btnCarLprDetect.Size = new Size(167, 29);
            btnCarLprDetect.TabIndex = 3;
            btnCarLprDetect.Text = "Đọc biển số ô tô";
            btnCarLprDetect.UseVisualStyleBackColor = true;
            btnCarLprDetect.Visible = false;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(752, 8);
            btnDraw.Margin = new Padding(4, 3, 4, 3);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(201, 29);
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
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1002, 84);
            panel2.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(752, 45);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(201, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu cấu hình";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnMotorLprDetect
            // 
            btnMotorLprDetect.Location = new Point(580, 45);
            btnMotorLprDetect.Margin = new Padding(4, 3, 4, 3);
            btnMotorLprDetect.Name = "btnMotorLprDetect";
            btnMotorLprDetect.Size = new Size(167, 29);
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
            tableLayoutPanel1.Location = new Point(727, 84);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(275, 428);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // picCutVehicleImage
            // 
            picCutVehicleImage.Location = new Point(2, 57);
            picCutVehicleImage.Margin = new Padding(0);
            picCutVehicleImage.Name = "picCutVehicleImage";
            picCutVehicleImage.Size = new Size(270, 182);
            picCutVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picCutVehicleImage.TabIndex = 0;
            picCutVehicleImage.TabStop = false;
            // 
            // picLprImage
            // 
            picLprImage.Location = new Point(2, 242);
            picLprImage.Margin = new Padding(0);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(270, 183);
            picLprImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picLprImage.TabIndex = 1;
            picLprImage.TabStop = false;
            // 
            // lblDetectPlate
            // 
            lblDetectPlate.Dock = DockStyle.Fill;
            lblDetectPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetectPlate.Location = new Point(6, 2);
            lblDetectPlate.Margin = new Padding(4, 0, 4, 0);
            lblDetectPlate.Name = "lblDetectPlate";
            lblDetectPlate.Size = new Size(263, 53);
            lblDetectPlate.TabIndex = 2;
            lblDetectPlate.Text = "_";
            lblDetectPlate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucCameraConfig
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panelCamera);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucCameraConfig";
            Size = new Size(1002, 512);
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
