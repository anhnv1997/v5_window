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
            btnLprDetect = new Button();
            btnDraw = new Button();
            panel2 = new Panel();
            btnSave = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            picCutVehicleImage = new PictureBox();
            picLprImage = new PictureBox();
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
            label1.Location = new Point(5, 12);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Camera";
            // 
            // cbCamera
            // 
            cbCamera.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCamera.FormattingEnabled = true;
            cbCamera.Location = new Point(71, 9);
            cbCamera.Name = "cbCamera";
            cbCamera.Size = new Size(332, 28);
            cbCamera.TabIndex = 1;
            // 
            // panelCamera
            // 
            panelCamera.BackColor = SystemColors.Control;
            panelCamera.Dock = DockStyle.Fill;
            panelCamera.Location = new Point(0, 48);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(808, 441);
            panelCamera.TabIndex = 2;
            // 
            // btnLiveview
            // 
            btnLiveview.Location = new Point(409, 9);
            btnLiveview.Name = "btnLiveview";
            btnLiveview.Size = new Size(96, 28);
            btnLiveview.TabIndex = 3;
            btnLiveview.Text = "Live view";
            btnLiveview.UseVisualStyleBackColor = true;
            // 
            // btnLprDetect
            // 
            btnLprDetect.Location = new Point(511, 9);
            btnLprDetect.Name = "btnLprDetect";
            btnLprDetect.Size = new Size(96, 28);
            btnLprDetect.TabIndex = 3;
            btnLprDetect.Text = "Đọc biển số";
            btnLprDetect.UseVisualStyleBackColor = true;
            btnLprDetect.Visible = false;
            btnLprDetect.Click += btnLprDetect_Click_1;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(613, 9);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(178, 28);
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
            panel2.Controls.Add(btnLprDetect);
            panel2.Controls.Add(btnLiveview);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1052, 48);
            panel2.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(797, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 28);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu cấu hình";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
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
            tableLayoutPanel1.Location = new Point(808, 48);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(244, 441);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // picCutVehicleImage
            // 
            picCutVehicleImage.Location = new Point(2, 55);
            picCutVehicleImage.Margin = new Padding(0);
            picCutVehicleImage.Name = "picCutVehicleImage";
            picCutVehicleImage.Size = new Size(240, 191);
            picCutVehicleImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picCutVehicleImage.TabIndex = 0;
            picCutVehicleImage.TabStop = false;
            // 
            // picLprImage
            // 
            picLprImage.Dock = DockStyle.Fill;
            picLprImage.Location = new Point(2, 248);
            picLprImage.Margin = new Padding(0);
            picLprImage.Name = "picLprImage";
            picLprImage.Size = new Size(240, 191);
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
            lblDetectPlate.Size = new Size(234, 51);
            lblDetectPlate.TabIndex = 2;
            lblDetectPlate.Text = "_";
            lblDetectPlate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucCameraConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panelCamera);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Name = "ucCameraConfig";
            Size = new Size(1052, 489);
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
        private Button btnLprDetect;
        private Button btnDraw;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox picCutVehicleImage;
        private PictureBox picLprImage;
        private Label lblDetectPlate;
        private Button btnSave;
    }
}
