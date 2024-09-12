namespace iParkingv5_window.Forms.SystemForms
{
    partial class frmSelectLaneMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectLaneMode));
            lblTitle = new Label();
            panelActiveLanes = new Panel();
            chbSelectAll = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            lblStatus = new Label();
            ucViewMode1 = new Usercontrols.ucViewMode();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(133, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lựa chọn làn hoạt động";
            // 
            // panelActiveLanes
            // 
            panelActiveLanes.BackColor = SystemColors.Control;
            panelActiveLanes.Dock = DockStyle.Fill;
            panelActiveLanes.Location = new Point(0, 0);
            panelActiveLanes.Margin = new Padding(3, 2, 3, 2);
            panelActiveLanes.Name = "panelActiveLanes";
            panelActiveLanes.Size = new Size(646, 292);
            panelActiveLanes.TabIndex = 1;
            // 
            // chbSelectAll
            // 
            chbSelectAll.AutoSize = true;
            chbSelectAll.BackColor = Color.Transparent;
            chbSelectAll.Location = new Point(20, 44);
            chbSelectAll.Margin = new Padding(3, 2, 3, 2);
            chbSelectAll.Name = "chbSelectAll";
            chbSelectAll.Size = new Size(87, 19);
            chbSelectAll.TabIndex = 4;
            chbSelectAll.Text = "Chọn tất cả";
            chbSelectAll.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(20, 428);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 7;
            // 
            // ucViewMode1
            // 
            ucViewMode1.BackColor = SystemColors.ButtonHighlight;
            ucViewMode1.ColumnCount = 0;
            ucViewMode1.Dock = DockStyle.Bottom;
            ucViewMode1.Location = new Point(0, 292);
            ucViewMode1.Margin = new Padding(0);
            ucViewMode1.Name = "ucViewMode1";
            ucViewMode1.RowCount = 0;
            ucViewMode1.Size = new Size(646, 160);
            ucViewMode1.TabIndex = 8;
            ucViewMode1.ViewMode = iParkingv5.Objects.Configs.AppViewModeConfig.EmAppViewMode.Vertical;
            // 
            // panel1
            // 
            panel1.Controls.Add(panelActiveLanes);
            panel1.Controls.Add(ucViewMode1);
            panel1.Location = new Point(20, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(646, 452);
            panel1.TabIndex = 9;
            // 
            // frmSelectLaneMode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 546);
            Controls.Add(panel1);
            Controls.Add(lblStatus);
            Controls.Add(chbSelectAll);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectLaneMode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lựa chọn làn hoạt động";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel panelActiveLanes;
        private CheckBox chbSelectAll;
        private System.Windows.Forms.Timer timer1;
        private Label lblStatus;
        private Usercontrols.ucViewMode ucViewMode1;
        private Panel panel1;
    }
}