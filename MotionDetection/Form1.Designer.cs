namespace MotionDetection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            label6 = new Label();
            txtPlateNumber = new Label();
            txtTime = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            btnReport = new Button();
            numAlarmLevel = new NumericUpDown();
            btnDetectConfig = new Button();
            btnConnect = new Button();
            txtResolution = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtIP = new TextBox();
            cbType = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelCamera = new Panel();
            picLpr = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAlarmLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLpr).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(panelCamera, 1, 0);
            tableLayoutPanel1.Controls.Add(picLpr, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(905, 617);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtPlateNumber);
            panel2.Controls.Add(txtTime);
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(457, 313);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(443, 299);
            panel2.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 60);
            label6.Name = "label6";
            label6.Size = new Size(79, 21);
            label6.TabIndex = 0;
            label6.Text = "Biển số xe";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.AutoSize = true;
            txtPlateNumber.Location = new Point(119, 60);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(17, 21);
            txtPlateNumber.TabIndex = 0;
            txtPlateNumber.Text = "_";
            // 
            // txtTime
            // 
            txtTime.AutoSize = true;
            txtTime.Location = new Point(119, 20);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(17, 21);
            txtTime.TabIndex = 0;
            txtTime.Text = "_";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 20);
            label5.Name = "label5";
            label5.Size = new Size(75, 21);
            label5.TabIndex = 0;
            label5.Text = "Thời gian";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReport);
            groupBox1.Controls.Add(numAlarmLevel);
            groupBox1.Controls.Add(btnDetectConfig);
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Controls.Add(txtResolution);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(txtIP);
            groupBox1.Controls.Add(cbType);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(5, 5);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(443, 299);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin kết nối";
            // 
            // btnReport
            // 
            btnReport.Location = new Point(294, 248);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(143, 45);
            btnReport.TabIndex = 8;
            btnReport.Text = "Báo cáo";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // numAlarmLevel
            // 
            numAlarmLevel.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numAlarmLevel.Location = new Point(128, 208);
            numAlarmLevel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numAlarmLevel.Name = "numAlarmLevel";
            numAlarmLevel.Size = new Size(309, 29);
            numAlarmLevel.TabIndex = 6;
            // 
            // btnDetectConfig
            // 
            btnDetectConfig.Location = new Point(128, 248);
            btnDetectConfig.Name = "btnDetectConfig";
            btnDetectConfig.Size = new Size(160, 45);
            btnDetectConfig.TabIndex = 7;
            btnDetectConfig.Text = "Cấu hình nhận diện";
            btnDetectConfig.UseVisualStyleBackColor = true;
            btnDetectConfig.Click += btnDetectConfig_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(7, 248);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(120, 45);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Kết nối";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtResolution
            // 
            txtResolution.Location = new Point(128, 173);
            txtResolution.Name = "txtResolution";
            txtResolution.Size = new Size(309, 29);
            txtResolution.TabIndex = 5;
            txtResolution.Text = "1920x1080";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(128, 103);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(309, 29);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(128, 68);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(309, 29);
            txtUsername.TabIndex = 2;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(128, 33);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(309, 29);
            txtIP.TabIndex = 1;
            // 
            // cbType
            // 
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(128, 138);
            cbType.Name = "cbType";
            cbType.Size = new Size(309, 29);
            cbType.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 210);
            label7.Name = "label7";
            label7.Size = new Size(107, 21);
            label7.TabIndex = 0;
            label7.Text = "Mức cảnh báo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 176);
            label8.Name = "label8";
            label8.Size = new Size(98, 21);
            label8.TabIndex = 0;
            label8.Text = "Độ phân giải";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 141);
            label4.Name = "label4";
            label4.Size = new Size(39, 21);
            label4.TabIndex = 0;
            label4.Text = "Loại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 106);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 71);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 0;
            label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 36);
            label1.Name = "label1";
            label1.Size = new Size(23, 21);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // panelCamera
            // 
            panelCamera.Dock = DockStyle.Fill;
            panelCamera.Location = new Point(457, 5);
            panelCamera.Margin = new Padding(4);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(443, 299);
            panelCamera.TabIndex = 1;
            // 
            // picLpr
            // 
            picLpr.Dock = DockStyle.Fill;
            picLpr.Image = (Image)resources.GetObject("picLpr.Image");
            picLpr.Location = new Point(4, 312);
            picLpr.Name = "picLpr";
            picLpr.Size = new Size(445, 301);
            picLpr.SizeMode = PictureBoxSizeMode.StretchImage;
            picLpr.TabIndex = 3;
            picLpr.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 617);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Camera - Motion";
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAlarmLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLpr).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panelCamera;
        private GroupBox groupBox1;
        private PictureBox picLpr;
        private Label label6;
        private Label txtPlateNumber;
        private Label txtTime;
        private Label label5;
        private Button btnConnect;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtIP;
        private ComboBox cbType;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown numAlarmLevel;
        private Label label7;
        private TextBox txtResolution;
        private Label label8;
        private Button btnDetectConfig;
        private Button btnReport;
    }
}
