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
            tsmiSystem = new ToolStripMenuItem();
            tsmiLanguage = new ToolStripMenuItem();
            tsmiLogout = new ToolStripMenuItem();
            tsmiExit = new ToolStripMenuItem();
            miReport = new ToolStripMenuItem();
            tsmiReportIn = new ToolStripMenuItem();
            tsmiReportInOut = new ToolStripMenuItem();
            tsmiAlarmReport = new ToolStripMenuItem();
            tsmiDevelopeMode = new ToolStripMenuItem();
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
            menuStrip1.SuspendLayout();
            panelMain.SuspendLayout();
            panelAppStatus.SuspendLayout();
            panelDevelopeMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaitingEvents).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { miSystem, miReport });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1344, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // miSystem
            // 
            miSystem.DropDownItems.AddRange(new ToolStripItem[] { tsmiSystem, tsmiLanguage, tsmiLogout, tsmiExit });
            miSystem.Name = "miSystem";
            miSystem.Size = new Size(83, 24);
            miSystem.Text = "Hệ thống";
            // 
            // tsmiSystem
            // 
            tsmiSystem.Name = "tsmiSystem";
            tsmiSystem.Size = new Size(198, 24);
            tsmiSystem.Text = "Cấu hình hệ thống";
            tsmiSystem.Click += tsmiSystem_Click;
            // 
            // tsmiLanguage
            // 
            tsmiLanguage.Name = "tsmiLanguage";
            tsmiLanguage.Size = new Size(198, 24);
            tsmiLanguage.Text = "Ngôn ngữ";
            tsmiLanguage.Click += tsmiLanguage_Click;
            // 
            // tsmiLogout
            // 
            tsmiLogout.Name = "tsmiLogout";
            tsmiLogout.Size = new Size(198, 24);
            tsmiLogout.Text = "Đăng xuất";
            tsmiLogout.Click += tsmiLogout_Click;
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(198, 24);
            tsmiExit.Text = "Thoát";
            tsmiExit.Click += tsmiExit_Click;
            // 
            // miReport
            // 
            miReport.DropDownItems.AddRange(new ToolStripItem[] { tsmiReportIn, tsmiReportInOut, tsmiAlarmReport, tsmiDevelopeMode });
            miReport.Name = "miReport";
            miReport.Size = new Size(75, 24);
            miReport.Text = "Báo cáo";
            // 
            // tsmiReportIn
            // 
            tsmiReportIn.Name = "tsmiReportIn";
            tsmiReportIn.Size = new Size(249, 24);
            tsmiReportIn.Text = "Xe đang trong bãi";
            tsmiReportIn.Click += tsmiReportIn_Click;
            // 
            // tsmiReportInOut
            // 
            tsmiReportInOut.Name = "tsmiReportInOut";
            tsmiReportInOut.Size = new Size(249, 24);
            tsmiReportInOut.Text = "Xe ra khỏi bãi";
            tsmiReportInOut.Click += tsmiReportInOut_Click;
            // 
            // tsmiAlarmReport
            // 
            tsmiAlarmReport.Name = "tsmiAlarmReport";
            tsmiAlarmReport.Size = new Size(249, 24);
            tsmiAlarmReport.Text = "Sự kiện cảnh báo";
            tsmiAlarmReport.Click += tsmiAlarmReport_Click;
            // 
            // tsmiDevelopeMode
            // 
            tsmiDevelopeMode.Name = "tsmiDevelopeMode";
            tsmiDevelopeMode.Size = new Size(249, 24);
            tsmiDevelopeMode.Text = "Chế độ cho nhà phát triển";
            tsmiDevelopeMode.Click += tsmiDevelopeMode_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(ucViewGrid1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 28);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(973, 665);
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
            ucViewGrid1.Size = new Size(973, 665);
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
            panelAppStatus.Location = new Point(0, 693);
            panelAppStatus.Name = "panelAppStatus";
            panelAppStatus.Size = new Size(1344, 36);
            panelAppStatus.TabIndex = 2;
            // 
            // lblLoadingStatus
            // 
            lblLoadingStatus.Dock = DockStyle.Fill;
            lblLoadingStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoadingStatus.ForeColor = Color.FromArgb(192, 64, 0);
            lblLoadingStatus.Location = new Point(234, 0);
            lblLoadingStatus.Name = "lblLoadingStatus";
            lblLoadingStatus.Padding = new Padding(10, 0, 0, 0);
            lblLoadingStatus.Size = new Size(886, 32);
            lblLoadingStatus.TabIndex = 4;
            lblLoadingStatus.Text = "Đang Tải Thông Tin ...";
            lblLoadingStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCompanyName
            // 
            lblCompanyName.Dock = DockStyle.Right;
            lblCompanyName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblCompanyName.ForeColor = Color.Navy;
            lblCompanyName.Location = new Point(1120, 0);
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
            lblTime.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTime.Location = new Point(1255, 0);
            lblTime.Name = "lblTime";
            lblTime.Padding = new Padding(10, 0, 0, 0);
            lblTime.Size = new Size(85, 32);
            lblTime.TabIndex = 2;
            lblTime.Text = "16:04:04";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblServerName
            // 
            lblServerName.Dock = DockStyle.Left;
            lblServerName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblServerName.Location = new Point(117, 0);
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
            lblSoftwareName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSoftwareName.Location = new Point(0, 0);
            lblSoftwareName.Name = "lblSoftwareName";
            lblSoftwareName.Padding = new Padding(10, 0, 0, 0);
            lblSoftwareName.Size = new Size(117, 32);
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
            panelDevelopeMode.Location = new Point(983, 28);
            panelDevelopeMode.Name = "panelDevelopeMode";
            panelDevelopeMode.Size = new Size(361, 665);
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
            dgvWaitingEvents.Size = new Size(361, 618);
            dgvWaitingEvents.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = Color.Navy;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
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
            splitterDevelopeMode.Location = new Point(973, 28);
            splitterDevelopeMode.Name = "splitterDevelopeMode";
            splitterDevelopeMode.Size = new Size(10, 665);
            splitterDevelopeMode.TabIndex = 4;
            splitterDevelopeMode.TabStop = false;
            splitterDevelopeMode.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 729);
            Controls.Add(panelMain);
            Controls.Add(splitterDevelopeMode);
            Controls.Add(panelDevelopeMode);
            Controls.Add(panelAppStatus);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
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
        private ToolStripMenuItem tsmiSystem;
        private ToolStripMenuItem tsmiLanguage;
        private ToolStripMenuItem tsmiLogout;
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
        private ToolStripMenuItem tsmiDevelopeMode;
        private Label label1;
        private DataGridView dgvWaitingEvents;
        private ToolStripMenuItem tsmiAlarmReport;
    }
}