namespace ALS_BacNinh.Forms.SystemForms
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            miSystemConfig = new ToolStripMenuItem();
            miExit = new ToolStripMenuItem();
            báoCáoToolStripMenuItem = new ToolStripMenuItem();
            miReportInOut = new ToolStripMenuItem();
            lịchSửMởCưỡngBứcToolStripMenuItem = new ToolStripMenuItem();
            dgvEvent = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            panelControllerStatus = new Panel();
            timerDisplayEvent = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvent).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, báoCáoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miSystemConfig, miExit });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(83, 24);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // miSystemConfig
            // 
            miSystemConfig.Name = "miSystemConfig";
            miSystemConfig.Size = new Size(198, 24);
            miSystemConfig.Text = "Cấu hình hệ thống";
            miSystemConfig.Click += miSystemConfig_Click;
            // 
            // miExit
            // 
            miExit.Name = "miExit";
            miExit.Size = new Size(198, 24);
            miExit.Text = "Thoát";
            miExit.Click += miExit_Click;
            // 
            // báoCáoToolStripMenuItem
            // 
            báoCáoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miReportInOut, lịchSửMởCưỡngBứcToolStripMenuItem });
            báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            báoCáoToolStripMenuItem.Size = new Size(75, 24);
            báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // miReportInOut
            // 
            miReportInOut.Name = "miReportInOut";
            miReportInOut.Size = new Size(224, 24);
            miReportInOut.Text = "Lịch sử vào ra";
            miReportInOut.Click += miReportInOut_Click;
            // 
            // lịchSửMởCưỡngBứcToolStripMenuItem
            // 
            lịchSửMởCưỡngBứcToolStripMenuItem.Name = "lịchSửMởCưỡngBứcToolStripMenuItem";
            lịchSửMởCưỡngBứcToolStripMenuItem.Size = new Size(224, 24);
            lịchSửMởCưỡngBứcToolStripMenuItem.Text = "Lịch sử mở cưỡng bức";
            lịchSửMởCưỡngBứcToolStripMenuItem.Click += lịchSửMởCưỡngBứcToolStripMenuItem_Click;
            // 
            // dgvEvent
            // 
            dgvEvent.AllowUserToAddRows = false;
            dgvEvent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvEvent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEvent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEvent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEvent.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEvent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEvent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvent.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEvent.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEvent.Dock = DockStyle.Fill;
            dgvEvent.Location = new Point(0, 28);
            dgvEvent.Name = "dgvEvent";
            dgvEvent.ReadOnly = true;
            dgvEvent.RowHeadersVisible = false;
            dgvEvent.RowTemplate.Height = 29;
            dgvEvent.Size = new Size(800, 379);
            dgvEvent.TabIndex = 1;
            // 
            // Column1
            // 
            Column1.HeaderText = "STT";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 66;
            // 
            // Column2
            // 
            Column2.HeaderText = "Mã Thẻ";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 92;
            // 
            // Column3
            // 
            Column3.HeaderText = "Reader";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 89;
            // 
            // Column4
            // 
            Column4.HeaderText = "Thời Gian";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 107;
            // 
            // panelControllerStatus
            // 
            panelControllerStatus.Dock = DockStyle.Bottom;
            panelControllerStatus.Location = new Point(0, 407);
            panelControllerStatus.Name = "panelControllerStatus";
            panelControllerStatus.Size = new Size(800, 43);
            panelControllerStatus.TabIndex = 2;
            // 
            // timerDisplayEvent
            // 
            timerDisplayEvent.Interval = 500;
            timerDisplayEvent.Tick += timerDisplayEvent_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvEvent);
            Controls.Add(panelControllerStatus);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ALS - Bắc Ninh";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem miExit;
        private ToolStripMenuItem báoCáoToolStripMenuItem;
        private ToolStripMenuItem miReportInOut;
        private DataGridView dgvEvent;
        private ToolStripMenuItem miSystemConfig;
        private Panel panelControllerStatus;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Timer timerDisplayEvent;
        private ToolStripMenuItem lịchSửMởCưỡngBứcToolStripMenuItem;
    }
}