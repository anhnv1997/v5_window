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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActiveLanesConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlarmReport = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegisterCar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegisterMotor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegisterWalker = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegisterList = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.ucViewGrid1 = new iParkingv5_window.Usercontrols.ucViewGrid();
            this.panelAppStatus = new System.Windows.Forms.Panel();
            this.lblLoadingStatus = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblSoftwareName = new System.Windows.Forms.Label();
            this.timerUpdateTime = new System.Windows.Forms.Timer(this.components);
            this.panelDevelopeMode = new System.Windows.Forms.Panel();
            this.dgvWaitingEvents = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.splitterDevelopeMode = new System.Windows.Forms.Splitter();
            this.timerUpdateControllerConnection = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelAppStatus.SuspendLayout();
            this.panelDevelopeMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSystem,
            this.miReport,
            this.đăngKýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(773, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miSystem
            // 
            this.miSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiActiveLanesConfig,
            this.tsmiExit});
            this.miSystem.Name = "miSystem";
            this.miSystem.Size = new System.Drawing.Size(86, 25);
            this.miSystem.Text = "Hệ thống";
            // 
            // tsmiActiveLanesConfig
            // 
            this.tsmiActiveLanesConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsmiActiveLanesConfig.Image")));
            this.tsmiActiveLanesConfig.Name = "tsmiActiveLanesConfig";
            this.tsmiActiveLanesConfig.Size = new System.Drawing.Size(242, 26);
            this.tsmiActiveLanesConfig.Text = "Cấu hình làn hoạt động";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExit.Image")));
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(242, 26);
            this.tsmiExit.Text = "Thoát";
            // 
            // miReport
            // 
            this.miReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReportIn,
            this.tsmiReportInOut,
            this.tsmiAlarmReport});
            this.miReport.Name = "miReport";
            this.miReport.Size = new System.Drawing.Size(76, 25);
            this.miReport.Text = "Báo cáo";
            // 
            // tsmiReportIn
            // 
            this.tsmiReportIn.Image = ((System.Drawing.Image)(resources.GetObject("tsmiReportIn.Image")));
            this.tsmiReportIn.Name = "tsmiReportIn";
            this.tsmiReportIn.Size = new System.Drawing.Size(203, 26);
            this.tsmiReportIn.Text = "Xe đang trong bãi";
            // 
            // tsmiReportInOut
            // 
            this.tsmiReportInOut.Image = ((System.Drawing.Image)(resources.GetObject("tsmiReportInOut.Image")));
            this.tsmiReportInOut.Name = "tsmiReportInOut";
            this.tsmiReportInOut.Size = new System.Drawing.Size(203, 26);
            this.tsmiReportInOut.Text = "Xe ra khỏi bãi";
            // 
            // tsmiAlarmReport
            // 
            this.tsmiAlarmReport.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAlarmReport.Image")));
            this.tsmiAlarmReport.Name = "tsmiAlarmReport";
            this.tsmiAlarmReport.Size = new System.Drawing.Size(203, 26);
            this.tsmiAlarmReport.Text = "Sự kiện cảnh báo";
            // 
            // đăngKýToolStripMenuItem
            // 
            this.đăngKýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegisterCar,
            this.btnRegisterMotor,
            this.btnRegisterWalker,
            this.btnRegisterList});
            this.đăngKýToolStripMenuItem.Name = "đăngKýToolStripMenuItem";
            this.đăngKýToolStripMenuItem.Size = new System.Drawing.Size(79, 25);
            this.đăngKýToolStripMenuItem.Text = "Đăng ký";
            // 
            // btnRegisterCar
            // 
            this.btnRegisterCar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegisterCar.Image")));
            this.btnRegisterCar.Name = "btnRegisterCar";
            this.btnRegisterCar.Size = new System.Drawing.Size(211, 26);
            this.btnRegisterCar.Text = "Ô tô";
            this.btnRegisterCar.Click += new System.EventHandler(this.btnRegisterCar_Click);
            // 
            // btnRegisterMotor
            // 
            this.btnRegisterMotor.Image = ((System.Drawing.Image)(resources.GetObject("btnRegisterMotor.Image")));
            this.btnRegisterMotor.Name = "btnRegisterMotor";
            this.btnRegisterMotor.Size = new System.Drawing.Size(211, 26);
            this.btnRegisterMotor.Text = "Xe máy";
            // 
            // btnRegisterWalker
            // 
            this.btnRegisterWalker.Image = ((System.Drawing.Image)(resources.GetObject("btnRegisterWalker.Image")));
            this.btnRegisterWalker.Name = "btnRegisterWalker";
            this.btnRegisterWalker.Size = new System.Drawing.Size(211, 26);
            this.btnRegisterWalker.Text = "Người đi bộ";
            this.btnRegisterWalker.Visible = false;
            // 
            // btnRegisterList
            // 
            this.btnRegisterList.Image = ((System.Drawing.Image)(resources.GetObject("btnRegisterList.Image")));
            this.btnRegisterList.Name = "btnRegisterList";
            this.btnRegisterList.Size = new System.Drawing.Size(211, 26);
            this.btnRegisterList.Text = "Danh sách đăng ký";
            this.btnRegisterList.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.ucViewGrid1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 29);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(448, 319);
            this.panelMain.TabIndex = 1;
            // 
            // ucViewGrid1
            // 
            this.ucViewGrid1.BackColor = System.Drawing.SystemColors.Control;
            this.ucViewGrid1.ColumnsCount = 2;
            this.ucViewGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucViewGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucViewGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.ucViewGrid1.Name = "ucViewGrid1";
            this.ucViewGrid1.RowsCount = 2;
            this.ucViewGrid1.Size = new System.Drawing.Size(448, 319);
            this.ucViewGrid1.TabIndex = 0;
            // 
            // panelAppStatus
            // 
            this.panelAppStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAppStatus.Controls.Add(this.lblLoadingStatus);
            this.panelAppStatus.Controls.Add(this.lblCompanyName);
            this.panelAppStatus.Controls.Add(this.lblTime);
            this.panelAppStatus.Controls.Add(this.lblServerName);
            this.panelAppStatus.Controls.Add(this.lblSoftwareName);
            this.panelAppStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAppStatus.Location = new System.Drawing.Point(0, 348);
            this.panelAppStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAppStatus.Name = "panelAppStatus";
            this.panelAppStatus.Size = new System.Drawing.Size(773, 28);
            this.panelAppStatus.TabIndex = 2;
            // 
            // lblLoadingStatus
            // 
            this.lblLoadingStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoadingStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblLoadingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblLoadingStatus.Location = new System.Drawing.Point(201, 0);
            this.lblLoadingStatus.Name = "lblLoadingStatus";
            this.lblLoadingStatus.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblLoadingStatus.Size = new System.Drawing.Size(357, 24);
            this.lblLoadingStatus.TabIndex = 4;
            this.lblLoadingStatus.Text = "Đang Tải Thông Tin ...";
            this.lblLoadingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Navy;
            this.lblCompanyName.Location = new System.Drawing.Point(558, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblCompanyName.Size = new System.Drawing.Size(118, 24);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "http://kztek.net";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(676, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblTime.Size = new System.Drawing.Size(93, 24);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "16:04:04";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServerName
            // 
            this.lblServerName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServerName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblServerName.Location = new System.Drawing.Point(99, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblServerName.Size = new System.Drawing.Size(102, 24);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "VIETANHPC";
            this.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoftwareName
            // 
            this.lblSoftwareName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSoftwareName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSoftwareName.Location = new System.Drawing.Point(0, 0);
            this.lblSoftwareName.Name = "lblSoftwareName";
            this.lblSoftwareName.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblSoftwareName.Size = new System.Drawing.Size(99, 24);
            this.lblSoftwareName.TabIndex = 0;
            this.lblSoftwareName.Text = "IPARKINGv5";
            this.lblSoftwareName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerUpdateTime
            // 
            this.timerUpdateTime.Enabled = true;
            this.timerUpdateTime.Interval = 1000;
            // 
            // panelDevelopeMode
            // 
            this.panelDevelopeMode.BackColor = System.Drawing.SystemColors.Control;
            this.panelDevelopeMode.Controls.Add(this.dgvWaitingEvents);
            this.panelDevelopeMode.Controls.Add(this.label1);
            this.panelDevelopeMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDevelopeMode.Location = new System.Drawing.Point(457, 29);
            this.panelDevelopeMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDevelopeMode.Name = "panelDevelopeMode";
            this.panelDevelopeMode.Size = new System.Drawing.Size(316, 319);
            this.panelDevelopeMode.TabIndex = 3;
            this.panelDevelopeMode.Visible = false;
            // 
            // dgvWaitingEvents
            // 
            this.dgvWaitingEvents.AllowUserToAddRows = false;
            this.dgvWaitingEvents.AllowUserToDeleteRows = false;
            this.dgvWaitingEvents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvWaitingEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaitingEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWaitingEvents.Location = new System.Drawing.Point(0, 35);
            this.dgvWaitingEvents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWaitingEvents.Name = "dgvWaitingEvents";
            this.dgvWaitingEvents.ReadOnly = true;
            this.dgvWaitingEvents.RowTemplate.Height = 29;
            this.dgvWaitingEvents.Size = new System.Drawing.Size(316, 284);
            this.dgvWaitingEvents.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chế độ cho nhà phát triển";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitterDevelopeMode
            // 
            this.splitterDevelopeMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitterDevelopeMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterDevelopeMode.Location = new System.Drawing.Point(448, 29);
            this.splitterDevelopeMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitterDevelopeMode.Name = "splitterDevelopeMode";
            this.splitterDevelopeMode.Size = new System.Drawing.Size(9, 319);
            this.splitterDevelopeMode.TabIndex = 4;
            this.splitterDevelopeMode.TabStop = false;
            this.splitterDevelopeMode.Visible = false;
            // 
            // timerUpdateControllerConnection
            // 
            this.timerUpdateControllerConnection.Enabled = true;
            this.timerUpdateControllerConnection.Interval = 1000;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 376);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.splitterDevelopeMode);
            this.Controls.Add(this.panelDevelopeMode);
            this.Controls.Add(this.panelAppStatus);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "iParkingv5";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelAppStatus.ResumeLayout(false);
            this.panelDevelopeMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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