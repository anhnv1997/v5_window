namespace iParkingv5_window.Forms.DataForms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            menuStrip1 = new MenuStrip();
            miSystem = new ToolStripMenuItem();
            tsmiActiveLanesConfig = new ToolStripMenuItem();
            tsmiExit = new ToolStripMenuItem();
            miReport = new ToolStripMenuItem();
            tsmiReportIn = new ToolStripMenuItem();
            tsmiReportInOut = new ToolStripMenuItem();
            tsmiAlarmReport = new ToolStripMenuItem();
            đăngKýToolStripMenuItem = new ToolStripMenuItem();
            btnRegisterCar = new ToolStripMenuItem();
            btnRegisterMotor = new ToolStripMenuItem();
            btnRegisterWalker = new ToolStripMenuItem();
            btnRegisterList = new ToolStripMenuItem();
            panelMain = new Panel();
            ucViewGrid1 = new Usercontrols.ucViewGrid();
            panelAppStatus = new Panel();
            lblLoadingStatus = new Label();
            lblCompanyName = new Label();
            lblTime = new Label();
            lblServerName = new Label();
            lblSoftwareName = new Label();
            timerUpdateTime = new System.Windows.Forms.Timer(components);
            panelDevelopeMode = new Panel();
            dgvWaitingEvents = new DataGridView();
            label1 = new Label();
            splitterDevelopeMode = new Splitter();
            timerUpdateControllerConnection = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            panelMain.SuspendLayout();
            panelAppStatus.SuspendLayout();
            panelDevelopeMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaitingEvents).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { miSystem, miReport, đăngKýToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(883, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // miSystem
            // 
            miSystem.DropDownItems.AddRange(new ToolStripItem[] { tsmiActiveLanesConfig, tsmiExit });
            miSystem.Name = "miSystem";
            miSystem.Size = new Size(86, 25);
            miSystem.Text = "Hệ thống";
            // 
            // tsmiActiveLanesConfig
            // 
            tsmiActiveLanesConfig.Image = (Image)resources.GetObject("tsmiActiveLanesConfig.Image");
            tsmiActiveLanesConfig.Name = "tsmiActiveLanesConfig";
            tsmiActiveLanesConfig.Size = new Size(242, 26);
            tsmiActiveLanesConfig.Text = "Cấu hình làn hoạt động";
            tsmiActiveLanesConfig.Click += tsmiActiveLanesConfig_Click;
            // 
            // tsmiExit
            // 
            tsmiExit.Image = (Image)resources.GetObject("tsmiExit.Image");
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(242, 26);
            tsmiExit.Text = "Thoát";
            tsmiExit.Click += tsmiExit_Click;
            tsmiExit.MouseEnter += tsmiExit_MouseEnter;
            tsmiExit.MouseLeave += tsmiExit_MouseLeave;
            // 
            // miReport
            // 
            miReport.DropDownItems.AddRange(new ToolStripItem[] { tsmiReportIn, tsmiReportInOut, tsmiAlarmReport });
            miReport.Name = "miReport";
            miReport.Size = new Size(76, 25);
            miReport.Text = "Báo cáo";
            // 
            // tsmiReportIn
            // 
            tsmiReportIn.Image = (Image)resources.GetObject("tsmiReportIn.Image");
            tsmiReportIn.Name = "tsmiReportIn";
            tsmiReportIn.Size = new Size(203, 26);
            tsmiReportIn.Text = "Xe đang trong bãi";
            tsmiReportIn.Click += tsmiReportIn_Click;
            tsmiReportIn.MouseEnter += tsmiReport_MouseEnter;
            tsmiReportIn.MouseLeave += tsmiReport_MouseLeave;
            // 
            // tsmiReportInOut
            // 
            tsmiReportInOut.Image = (Image)resources.GetObject("tsmiReportInOut.Image");
            tsmiReportInOut.Name = "tsmiReportInOut";
            tsmiReportInOut.Size = new Size(203, 26);
            tsmiReportInOut.Text = "Xe ra khỏi bãi";
            tsmiReportInOut.Click += tsmiReportInOut_Click;
            tsmiReportInOut.MouseEnter += tsmiReport_MouseEnter;
            tsmiReportInOut.MouseLeave += tsmiReport_MouseLeave;
            // 
            // tsmiAlarmReport
            // 
            tsmiAlarmReport.Image = (Image)resources.GetObject("tsmiAlarmReport.Image");
            tsmiAlarmReport.Name = "tsmiAlarmReport";
            tsmiAlarmReport.Size = new Size(203, 26);
            tsmiAlarmReport.Text = "Sự kiện cảnh báo";
            tsmiAlarmReport.Click += tsmiAlarmReport_Click;
            tsmiAlarmReport.MouseEnter += tsmiReport_MouseEnter;
            tsmiAlarmReport.MouseLeave += tsmiReport_MouseLeave;
            // 
            // đăngKýToolStripMenuItem
            // 
            đăngKýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnRegisterCar, btnRegisterMotor, btnRegisterWalker, btnRegisterList });
            đăngKýToolStripMenuItem.Name = "đăngKýToolStripMenuItem";
            đăngKýToolStripMenuItem.Size = new Size(79, 25);
            đăngKýToolStripMenuItem.Text = "Đăng ký";
            // 
            // btnRegisterCar
            // 
            btnRegisterCar.Image = (Image)resources.GetObject("btnRegisterCar.Image");
            btnRegisterCar.Name = "btnRegisterCar";
            btnRegisterCar.Size = new Size(211, 26);
            btnRegisterCar.Text = "Ô tô";
            btnRegisterCar.Click += btnRegisterCar_Click;
            // 
            // btnRegisterMotor
            // 
            btnRegisterMotor.Image = (Image)resources.GetObject("btnRegisterMotor.Image");
            btnRegisterMotor.Name = "btnRegisterMotor";
            btnRegisterMotor.Size = new Size(211, 26);
            btnRegisterMotor.Text = "Xe máy";
            btnRegisterMotor.Click += btnRegisterMotor_Click;
            // 
            // btnRegisterWalker
            // 
            btnRegisterWalker.Image = (Image)resources.GetObject("btnRegisterWalker.Image");
            btnRegisterWalker.Name = "btnRegisterWalker";
            btnRegisterWalker.Size = new Size(211, 26);
            btnRegisterWalker.Text = "Người đi bộ";
            btnRegisterWalker.Click += btnRegisterWalker_Click;
            // 
            // btnRegisterList
            // 
            btnRegisterList.Image = (Image)resources.GetObject("btnRegisterList.Image");
            btnRegisterList.Name = "btnRegisterList";
            btnRegisterList.Size = new Size(211, 26);
            btnRegisterList.Text = "Danh sách đăng ký";
            btnRegisterList.Click += btnRegisterList_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(ucViewGrid1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 29);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(512, 436);
            panelMain.TabIndex = 1;
            // 
            // ucViewGrid1
            // 
            ucViewGrid1.BackColor = SystemColors.Control;
            ucViewGrid1.ColumnsCount = 2;
            ucViewGrid1.Dock = DockStyle.Fill;
            ucViewGrid1.Location = new Point(0, 0);
            ucViewGrid1.Margin = new Padding(0);
            ucViewGrid1.Name = "ucViewGrid1";
            ucViewGrid1.RowsCount = 2;
            ucViewGrid1.Size = new Size(512, 436);
            ucViewGrid1.TabIndex = 0;
            // 
            // panelAppStatus
            // 
            panelAppStatus.BorderStyle = BorderStyle.Fixed3D;
            panelAppStatus.Controls.Add(lblLoadingStatus);
            panelAppStatus.Controls.Add(lblCompanyName);
            panelAppStatus.Controls.Add(lblTime);
            panelAppStatus.Controls.Add(lblServerName);
            panelAppStatus.Controls.Add(lblSoftwareName);
            panelAppStatus.Dock = DockStyle.Bottom;
            panelAppStatus.Location = new Point(0, 465);
            panelAppStatus.Name = "panelAppStatus";
            panelAppStatus.Size = new Size(883, 36);
            panelAppStatus.TabIndex = 2;
            // 
            // lblLoadingStatus
            // 
            lblLoadingStatus.Dock = DockStyle.Fill;
            lblLoadingStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblLoadingStatus.ForeColor = Color.FromArgb(192, 64, 0);
            lblLoadingStatus.Location = new Point(260, 0);
            lblLoadingStatus.Name = "lblLoadingStatus";
            lblLoadingStatus.Padding = new Padding(10, 0, 0, 0);
            lblLoadingStatus.Size = new Size(378, 32);
            lblLoadingStatus.TabIndex = 4;
            lblLoadingStatus.Text = "Đang Tải Thông Tin ...";
            lblLoadingStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCompanyName
            // 
            lblCompanyName.Dock = DockStyle.Right;
            lblCompanyName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            lblCompanyName.ForeColor = Color.Navy;
            lblCompanyName.Location = new Point(638, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Padding = new Padding(10, 0, 0, 0);
            lblCompanyName.Size = new Size(135, 32);
            lblCompanyName.TabIndex = 3;
            lblCompanyName.Text = "http://kztek.net";
            lblCompanyName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            lblTime.Dock = DockStyle.Right;
            lblTime.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblTime.Location = new Point(773, 0);
            lblTime.Name = "lblTime";
            lblTime.Padding = new Padding(10, 0, 0, 0);
            lblTime.Size = new Size(106, 32);
            lblTime.TabIndex = 2;
            lblTime.Text = "16:04:04";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblServerName
            // 
            lblServerName.Dock = DockStyle.Left;
            lblServerName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblServerName.Location = new Point(143, 0);
            lblServerName.Name = "lblServerName";
            lblServerName.Padding = new Padding(10, 0, 0, 0);
            lblServerName.Size = new Size(117, 32);
            lblServerName.TabIndex = 1;
            lblServerName.Text = "VIETANHPC";
            lblServerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSoftwareName
            // 
            lblSoftwareName.Dock = DockStyle.Left;
            lblSoftwareName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSoftwareName.Location = new Point(0, 0);
            lblSoftwareName.Name = "lblSoftwareName";
            lblSoftwareName.Padding = new Padding(10, 0, 0, 0);
            lblSoftwareName.Size = new Size(143, 32);
            lblSoftwareName.TabIndex = 0;
            lblSoftwareName.Text = "IPARKINGv5";
            lblSoftwareName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timerUpdateTime
            // 
            timerUpdateTime.Enabled = true;
            timerUpdateTime.Interval = 1000;
            timerUpdateTime.Tick += timerUpdateTime_Tick;
            // 
            // panelDevelopeMode
            // 
            panelDevelopeMode.BackColor = SystemColors.Control;
            panelDevelopeMode.Controls.Add(dgvWaitingEvents);
            panelDevelopeMode.Controls.Add(label1);
            panelDevelopeMode.Dock = DockStyle.Right;
            panelDevelopeMode.Location = new Point(522, 29);
            panelDevelopeMode.Name = "panelDevelopeMode";
            panelDevelopeMode.Size = new Size(361, 436);
            panelDevelopeMode.TabIndex = 3;
            panelDevelopeMode.Visible = false;
            // 
            // dgvWaitingEvents
            // 
            dgvWaitingEvents.AllowUserToAddRows = false;
            dgvWaitingEvents.AllowUserToDeleteRows = false;
            dgvWaitingEvents.BackgroundColor = SystemColors.Control;
            dgvWaitingEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWaitingEvents.Dock = DockStyle.Fill;
            dgvWaitingEvents.Location = new Point(0, 47);
            dgvWaitingEvents.Name = "dgvWaitingEvents";
            dgvWaitingEvents.ReadOnly = true;
            dgvWaitingEvents.RowTemplate.Height = 29;
            dgvWaitingEvents.Size = new Size(361, 389);
            dgvWaitingEvents.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = Color.Navy;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(361, 47);
            label1.TabIndex = 0;
            label1.Text = "Chế độ cho nhà phát triển";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitterDevelopeMode
            // 
            splitterDevelopeMode.BackColor = Color.FromArgb(192, 0, 0);
            splitterDevelopeMode.Dock = DockStyle.Right;
            splitterDevelopeMode.Location = new Point(512, 29);
            splitterDevelopeMode.Name = "splitterDevelopeMode";
            splitterDevelopeMode.Size = new Size(10, 436);
            splitterDevelopeMode.TabIndex = 4;
            splitterDevelopeMode.TabStop = false;
            splitterDevelopeMode.Visible = false;
            // 
            // timerUpdateControllerConnection
            // 
            timerUpdateControllerConnection.Enabled = true;
            timerUpdateControllerConnection.Interval = 1000;
            timerUpdateControllerConnection.Tick += timerUpdateControllerConnection_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 501);
            Controls.Add(panelMain);
            Controls.Add(splitterDevelopeMode);
            Controls.Add(panelDevelopeMode);
            Controls.Add(panelAppStatus);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.Manual;
            Text = "iParkingv5";
            FormClosing += frmMain_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelMain.ResumeLayout(false);
            panelAppStatus.ResumeLayout(false);
            panelDevelopeMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWaitingEvents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem miSystem;
        private ToolStripMenuItem miReport;
        private ToolStripMenuItem tsmiReportIn;
        private ToolStripMenuItem tsmiReportInOut;
        private ToolStripMenuItem tsmiExit;
        private Panel panelMain;
        private Usercontrols.ucViewGrid ucViewGrid1;
        private Panel panelAppStatus;
        private Label lblLoadingStatus;
        private Label lblCompanyName;
        private Label lblTime;
        private Label lblServerName;
        private Label lblSoftwareName;
        private System.Windows.Forms.Timer timerUpdateTime;
        private Panel panelDevelopeMode;
        private Splitter splitterDevelopeMode;
        private Label label1;
        private DataGridView dgvWaitingEvents;
        private ToolStripMenuItem tsmiAlarmReport;
        private System.Windows.Forms.Timer timerUpdateControllerConnection;
        private ToolStripMenuItem tsmiActiveLanesConfig;
        private ToolStripMenuItem đăngKýToolStripMenuItem;
        private ToolStripMenuItem btnRegisterCar;
        private ToolStripMenuItem btnRegisterMotor;
        private ToolStripMenuItem btnRegisterWalker;
        private ToolStripMenuItem btnRegisterList;
    }
}