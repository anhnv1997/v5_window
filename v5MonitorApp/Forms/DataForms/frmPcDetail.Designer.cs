namespace v5MonitorApp.Forms.DataForms
{
    partial class frmPcDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPcDetail));
            btnGetVersion = new Button();
            btnRestart = new Button();
            btnCheckForUpdate = new Button();
            lblResult1 = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnClear = new Button();
            btnSupport = new Button();
            toolTipBtnCheckVersion = new ToolTip(components);
            toolTipBtnCheckForUpdate = new ToolTip(components);
            toolTipBtnRestart = new ToolTip(components);
            toolTipBtnClean = new ToolTip(components);
            toolTipBtnSupport = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGetVersion
            // 
            btnGetVersion.AutoSize = true;
            btnGetVersion.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnGetVersion.Image = (Image)resources.GetObject("btnGetVersion.Image");
            btnGetVersion.ImageAlign = ContentAlignment.MiddleLeft;
            btnGetVersion.Location = new Point(301, 24);
            btnGetVersion.Name = "btnGetVersion";
            btnGetVersion.Size = new Size(286, 70);
            btnGetVersion.TabIndex = 0;
            btnGetVersion.Text = "Kiểm Tra Phiên Bản";
            btnGetVersion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGetVersion.UseVisualStyleBackColor = true;
            btnGetVersion.Click += btnGetVersion_Click;
            // 
            // btnRestart
            // 
            btnRestart.AutoSize = true;
            btnRestart.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnRestart.Image = (Image)resources.GetObject("btnRestart.Image");
            btnRestart.ImageAlign = ContentAlignment.MiddleLeft;
            btnRestart.Location = new Point(301, 176);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(285, 70);
            btnRestart.TabIndex = 0;
            btnRestart.Text = "Khởi Động Lại";
            btnRestart.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnCheckForUpdate
            // 
            btnCheckForUpdate.AutoSize = true;
            btnCheckForUpdate.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCheckForUpdate.Image = (Image)resources.GetObject("btnCheckForUpdate.Image");
            btnCheckForUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCheckForUpdate.Location = new Point(301, 100);
            btnCheckForUpdate.Name = "btnCheckForUpdate";
            btnCheckForUpdate.Size = new Size(285, 70);
            btnCheckForUpdate.TabIndex = 0;
            btnCheckForUpdate.Text = "Kiểm Tra Cập Nhật";
            btnCheckForUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCheckForUpdate.UseVisualStyleBackColor = true;
            btnCheckForUpdate.Click += btnCheckForUpdate_Click;
            // 
            // lblResult1
            // 
            lblResult1.Dock = DockStyle.Top;
            lblResult1.Location = new Point(0, 0);
            lblResult1.Name = "lblResult1";
            lblResult1.Size = new Size(888, 40);
            lblResult1.TabIndex = 1;
            lblResult1.Text = "PC_NAME";
            lblResult1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnGetVersion, 1, 1);
            tableLayoutPanel1.Controls.Add(btnCheckForUpdate, 1, 2);
            tableLayoutPanel1.Controls.Add(btnRestart, 1, 3);
            tableLayoutPanel1.Controls.Add(btnClear, 1, 4);
            tableLayoutPanel1.Controls.Add(btnSupport, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(888, 422);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.AutoSize = true;
            btnClear.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            btnClear.ImageAlign = ContentAlignment.MiddleLeft;
            btnClear.Location = new Point(301, 252);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(285, 70);
            btnClear.TabIndex = 0;
            btnClear.Text = "Dọn dẹp dữ liệu";
            btnClear.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSupport
            // 
            btnSupport.AutoSize = true;
            btnSupport.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnSupport.Image = (Image)resources.GetObject("btnSupport.Image");
            btnSupport.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupport.Location = new Point(301, 328);
            btnSupport.Name = "btnSupport";
            btnSupport.Size = new Size(285, 70);
            btnSupport.TabIndex = 0;
            btnSupport.Text = "Hỗ Trợ";
            btnSupport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSupport.UseVisualStyleBackColor = true;
            btnSupport.Click += btnSupport_Click;
            // 
            // frmPcDetail
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 462);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblResult1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmPcDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin chi tiết";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetVersion;
        private Button btnRestart;
        private Button btnCheckForUpdate;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblResult1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSupport;
        private Button btnClear;
        private ToolTip toolTipBtnCheckVersion;
        private ToolTip toolTipBtnCheckForUpdate;
        private ToolTip toolTipBtnRestart;
        private ToolTip toolTipBtnClean;
        private ToolTip toolTipBtnSupport;
    }
}