using iPakrkingv5.Controls.Controls.Labels;

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
            chứcNăngToolStripMenuItem = new ToolStripMenuItem();
            btnRegister = new ToolStripMenuItem();
            btnPrintQR = new ToolStripMenuItem();
            tsmiRegister = new ToolStripMenuItem();
            inQRToolStripMenuItem = new ToolStripMenuItem();
            panelMain = new Panel();
            ucViewGrid1 = new Usercontrols.ucViewGrid();
            panelAppStatus = new Panel();
            lblLoadingStatus = new lblResult();
            lblTime = new Label();
            lblSoftwareName = new Label();
            lblUserName = new Label();
            ucEventCount1 = new Usercontrols.ucEventCount();
            timerUpdateTime = new System.Windows.Forms.Timer(components);
            panelDevelopeMode = new Panel();
            btnShowSystemLog = new Button();
            btnCheckVersion = new Button();
            btnShowConnectionConfig = new Button();
            label1 = new Label();
            splitterDevelopeMode = new Splitter();
            timerUpdateControllerConnection = new System.Windows.Forms.Timer(components);
            timerRestartSockerServer = new System.Windows.Forms.Timer(components);
            timerClearLog = new System.Windows.Forms.Timer(components);
            tToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            panelMain.SuspendLayout();
            panelAppStatus.SuspendLayout();
            panelDevelopeMode.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonHighlight;
            menuStrip1.Font = new Font("Segoe UI", 12F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { miSystem, miReport, chứcNăngToolStripMenuItem, tsmiRegister, inQRToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1058, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.DoubleClick += menuStrip1_DoubleClick;
            // 
            // miSystem
            // 
            miSystem.DropDownItems.AddRange(new ToolStripItem[] { tsmiActiveLanesConfig, tsmiExit, tToolStripMenuItem });
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
            // 
            // tsmiReportInOut
            // 
            tsmiReportInOut.Image = (Image)resources.GetObject("tsmiReportInOut.Image");
            tsmiReportInOut.Name = "tsmiReportInOut";
            tsmiReportInOut.Size = new Size(203, 26);
            tsmiReportInOut.Text = "Xe ra khỏi bãi";
            tsmiReportInOut.Click += tsmiReportInOut_Click;
            // 
            // tsmiAlarmReport
            // 
            tsmiAlarmReport.Image = (Image)resources.GetObject("tsmiAlarmReport.Image");
            tsmiAlarmReport.Name = "tsmiAlarmReport";
            tsmiAlarmReport.Size = new Size(203, 26);
            tsmiAlarmReport.Text = "Sự kiện cảnh báo";
            tsmiAlarmReport.Visible = false;
            tsmiAlarmReport.Click += tsmiAlarmReport_Click;
            // 
            // chứcNăngToolStripMenuItem
            // 
            chứcNăngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnRegister, btnPrintQR });
            chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            chứcNăngToolStripMenuItem.Size = new Size(96, 25);
            chứcNăngToolStripMenuItem.Text = "Chức năng";
            chứcNăngToolStripMenuItem.Visible = false;
            // 
            // btnRegister
            // 
            btnRegister.Image = (Image)resources.GetObject("btnRegister.Image");
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(137, 26);
            btnRegister.Text = "Đăng ký";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnPrintQR
            // 
            btnPrintQR.Image = (Image)resources.GetObject("btnPrintQR.Image");
            btnPrintQR.Name = "btnPrintQR";
            btnPrintQR.Size = new Size(137, 26);
            btnPrintQR.Text = "In QR";
            btnPrintQR.Click += btnPrintQR_Click;
            // 
            // tsmiRegister
            // 
            tsmiRegister.Name = "tsmiRegister";
            tsmiRegister.Size = new Size(79, 25);
            tsmiRegister.Text = "Đăng Ký";
            tsmiRegister.Click += btnRegister_Click;
            // 
            // inQRToolStripMenuItem
            // 
            inQRToolStripMenuItem.Name = "inQRToolStripMenuItem";
            inQRToolStripMenuItem.Size = new Size(61, 25);
            inQRToolStripMenuItem.Text = "In QR";
            inQRToolStripMenuItem.Click += btnPrintQR_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(ucViewGrid1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 29);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(733, 442);
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
            ucViewGrid1.Size = new Size(733, 442);
            ucViewGrid1.TabIndex = 0;
            // 
            // panelAppStatus
            // 
            panelAppStatus.BackColor = SystemColors.ButtonHighlight;
            panelAppStatus.BorderStyle = BorderStyle.Fixed3D;
            panelAppStatus.Controls.Add(lblLoadingStatus);
            panelAppStatus.Controls.Add(lblTime);
            panelAppStatus.Controls.Add(lblSoftwareName);
            panelAppStatus.Controls.Add(lblUserName);
            panelAppStatus.Controls.Add(ucEventCount1);
            panelAppStatus.Dock = DockStyle.Bottom;
            panelAppStatus.Location = new Point(0, 471);
            panelAppStatus.Margin = new Padding(3, 2, 3, 2);
            panelAppStatus.Name = "panelAppStatus";
            panelAppStatus.Size = new Size(1058, 37);
            panelAppStatus.TabIndex = 2;
            // 
            // lblLoadingStatus
            // 
            lblLoadingStatus.BackColor = SystemColors.ButtonHighlight;
            lblLoadingStatus.Dock = DockStyle.Fill;
            lblLoadingStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblLoadingStatus.ForeColor = Color.FromArgb(192, 64, 0);
            lblLoadingStatus.IsBold = true;
            lblLoadingStatus.IsUpper = true;
            lblLoadingStatus.Location = new Point(189, 0);
            lblLoadingStatus.MaxFontSize = 12;
            lblLoadingStatus.Message = "Event Message";
            lblLoadingStatus.MessageBackColor = SystemColors.ButtonHighlight;
            lblLoadingStatus.MessageForeColor = Color.Black;
            lblLoadingStatus.Name = "lblLoadingStatus";
            lblLoadingStatus.Padding = new Padding(9, 0, 0, 0);
            lblLoadingStatus.Size = new Size(430, 33);
            lblLoadingStatus.TabIndex = 4;
            lblLoadingStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            lblTime.Dock = DockStyle.Right;
            lblTime.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblTime.Location = new Point(619, 0);
            lblTime.Name = "lblTime";
            lblTime.Padding = new Padding(9, 0, 0, 0);
            lblTime.Size = new Size(93, 33);
            lblTime.TabIndex = 2;
            lblTime.Text = "16:04:04";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSoftwareName
            // 
            lblSoftwareName.Dock = DockStyle.Left;
            lblSoftwareName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSoftwareName.Location = new Point(59, 0);
            lblSoftwareName.Name = "lblSoftwareName";
            lblSoftwareName.Padding = new Padding(9, 0, 0, 0);
            lblSoftwareName.Size = new Size(130, 33);
            lblSoftwareName.TabIndex = 0;
            lblSoftwareName.Text = "KZTEK-Parking";
            lblSoftwareName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Left;
            lblUserName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblUserName.Location = new Point(0, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Padding = new Padding(9, 0, 0, 0);
            lblUserName.Size = new Size(59, 33);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "_";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucEventCount1
            // 
            ucEventCount1.Dock = DockStyle.Right;
            ucEventCount1.Font = new Font("Segoe UI", 12F);
            ucEventCount1.Location = new Point(712, 0);
            ucEventCount1.Margin = new Padding(4, 3, 4, 3);
            ucEventCount1.Name = "ucEventCount1";
            ucEventCount1.Padding = new Padding(3, 0, 0, 0);
            ucEventCount1.Size = new Size(342, 33);
            ucEventCount1.TabIndex = 7;
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
            panelDevelopeMode.Controls.Add(btnShowSystemLog);
            panelDevelopeMode.Controls.Add(btnCheckVersion);
            panelDevelopeMode.Controls.Add(btnShowConnectionConfig);
            panelDevelopeMode.Controls.Add(label1);
            panelDevelopeMode.Dock = DockStyle.Right;
            panelDevelopeMode.Font = new Font("Segoe UI", 12F);
            panelDevelopeMode.Location = new Point(742, 29);
            panelDevelopeMode.Margin = new Padding(3, 2, 3, 2);
            panelDevelopeMode.Name = "panelDevelopeMode";
            panelDevelopeMode.Size = new Size(316, 442);
            panelDevelopeMode.TabIndex = 3;
            panelDevelopeMode.Visible = false;
            // 
            // btnShowSystemLog
            // 
            btnShowSystemLog.Dock = DockStyle.Top;
            btnShowSystemLog.Location = new Point(0, 109);
            btnShowSystemLog.Name = "btnShowSystemLog";
            btnShowSystemLog.Size = new Size(316, 37);
            btnShowSystemLog.TabIndex = 2;
            btnShowSystemLog.Text = "+ Xem log hệ thống";
            btnShowSystemLog.TextAlign = ContentAlignment.MiddleLeft;
            btnShowSystemLog.UseVisualStyleBackColor = true;
            btnShowSystemLog.Click += btnShowSystemLog_Click;
            // 
            // btnCheckVersion
            // 
            btnCheckVersion.Dock = DockStyle.Top;
            btnCheckVersion.Location = new Point(0, 72);
            btnCheckVersion.Name = "btnCheckVersion";
            btnCheckVersion.Size = new Size(316, 37);
            btnCheckVersion.TabIndex = 1;
            btnCheckVersion.Text = "+ Kiểm tra phiên bản";
            btnCheckVersion.TextAlign = ContentAlignment.MiddleLeft;
            btnCheckVersion.UseVisualStyleBackColor = true;
            btnCheckVersion.Click += btnCheckVersion_Click;
            // 
            // btnShowConnectionConfig
            // 
            btnShowConnectionConfig.Dock = DockStyle.Top;
            btnShowConnectionConfig.Location = new Point(0, 35);
            btnShowConnectionConfig.Name = "btnShowConnectionConfig";
            btnShowConnectionConfig.Size = new Size(316, 37);
            btnShowConnectionConfig.TabIndex = 3;
            btnShowConnectionConfig.Text = "+ Xem cài đặt hệ thống";
            btnShowConnectionConfig.TextAlign = ContentAlignment.MiddleLeft;
            btnShowConnectionConfig.UseVisualStyleBackColor = true;
            btnShowConnectionConfig.Click += btnShowConnectionConfig_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Navy;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(316, 35);
            label1.TabIndex = 0;
            label1.Text = "Chế độ cho nhà phát triển";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitterDevelopeMode
            // 
            splitterDevelopeMode.BackColor = Color.FromArgb(192, 0, 0);
            splitterDevelopeMode.Dock = DockStyle.Right;
            splitterDevelopeMode.Location = new Point(733, 29);
            splitterDevelopeMode.Margin = new Padding(3, 2, 3, 2);
            splitterDevelopeMode.Name = "splitterDevelopeMode";
            splitterDevelopeMode.Size = new Size(9, 442);
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
            // timerRestartSockerServer
            // 
            timerRestartSockerServer.Interval = 3600000;
            // 
            // timerClearLog
            // 
            timerClearLog.Enabled = true;
            timerClearLog.Interval = 60000;
            timerClearLog.Tick += timerClearLog_Tick;
            // 
            // tToolStripMenuItem
            // 
            tToolStripMenuItem.Name = "tToolStripMenuItem";
            tToolStripMenuItem.Size = new Size(242, 26);
            tToolStripMenuItem.Text = "t";
            tToolStripMenuItem.Click += tToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 508);
            Controls.Add(panelMain);
            Controls.Add(splitterDevelopeMode);
            Controls.Add(panelDevelopeMode);
            Controls.Add(menuStrip1);
            Controls.Add(panelAppStatus);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmMain";
            StartPosition = FormStartPosition.Manual;
            Text = "KZTEK-Parking";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelMain.ResumeLayout(false);
            panelAppStatus.ResumeLayout(false);
            panelDevelopeMode.ResumeLayout(false);
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
        private lblResult lblLoadingStatus;
        private Label lblTime;
        private Label lblSoftwareName;
        private System.Windows.Forms.Timer timerUpdateTime;
        private Panel panelDevelopeMode;
        private Splitter splitterDevelopeMode;
        private Label label1;
        private ToolStripMenuItem tsmiAlarmReport;
        private System.Windows.Forms.Timer timerUpdateControllerConnection;
        private ToolStripMenuItem tsmiActiveLanesConfig;
        private System.Windows.Forms.Timer timerRestartSockerServer;
        private System.Windows.Forms.Timer timerClearLog;
        private Label lblUserName;
        private ToolStripMenuItem chứcNăngToolStripMenuItem;
        private ToolStripMenuItem btnRegister;
        private ToolStripMenuItem btnPrintQR;
        private ToolStripMenuItem tsmiRegister;
        private ToolStripMenuItem inQRToolStripMenuItem;
        private Usercontrols.ucEventCount ucEventCount1;
        private Button btnShowSystemLog;
        private Button btnCheckVersion;
        private Button btnShowConnectionConfig;
        private ToolStripMenuItem tToolStripMenuItem;
    }
}