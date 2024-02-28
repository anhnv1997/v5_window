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
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Location = new Point(23, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(166, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lựa chọn làn hoạt động";
            // 
            // panelActiveLanes
            // 
            panelActiveLanes.BackColor = SystemColors.Control;
            panelActiveLanes.Location = new Point(23, 88);
            panelActiveLanes.Name = "panelActiveLanes";
            panelActiveLanes.Size = new Size(427, 172);
            panelActiveLanes.TabIndex = 1;
            // 
            // chbSelectAll
            // 
            chbSelectAll.AutoSize = true;
            chbSelectAll.BackColor = Color.Transparent;
            chbSelectAll.Location = new Point(23, 58);
            chbSelectAll.Name = "chbSelectAll";
            chbSelectAll.Size = new Size(103, 24);
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
            lblStatus.Location = new Point(23, 214);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 7;
            // 
            // frmSelectLaneMode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 370);
            Controls.Add(lblStatus);
            Controls.Add(chbSelectAll);
            Controls.Add(panelActiveLanes);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmSelectLaneMode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lựa chọn làn hoạt động";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel panelActiveLanes;
        private CheckBox chbSelectAll;
        private System.Windows.Forms.Timer timer1;
        private Label lblStatus;
    }
}