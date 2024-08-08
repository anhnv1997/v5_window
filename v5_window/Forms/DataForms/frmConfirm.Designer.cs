namespace iParkingv5_window.Forms.DataForms
{
    partial class frmConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirm));
            tableLayoutPanel1 = new TableLayoutPanel();
            panelActions = new Panel();
            lblGuide = new Label();
            lblCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            panel1 = new Panel();
            lblMessage = new Label();
            lblTimer = new Label();
            timerAutoConfirm = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            panelActions.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelActions, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new Size(489, 289);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(lblGuide);
            panelActions.Controls.Add(lblCancel1);
            panelActions.Controls.Add(btnOk1);
            panelActions.Dock = DockStyle.Fill;
            panelActions.Location = new Point(0, 202);
            panelActions.Margin = new Padding(0);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(489, 87);
            panelActions.TabIndex = 1;
            // 
            // lblGuide
            // 
            lblGuide.Dock = DockStyle.Left;
            lblGuide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGuide.ForeColor = Color.FromArgb(255, 128, 0);
            lblGuide.Location = new Point(0, 0);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(173, 87);
            lblGuide.TabIndex = 7;
            lblGuide.Text = "Enter để xác nhận.\r\nEsc để hủy.";
            lblGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCancel1
            // 
            lblCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCancel1.Location = new Point(375, 23);
            lblCancel1.Name = "lblCancel1";
            lblCancel1.Size = new Size(102, 52);
            lblCancel1.TabIndex = 1;
            lblCancel1.Text = "lblCancel1";
            lblCancel1.UseVisualStyleBackColor = true;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOk1.Location = new Point(268, 23);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(101, 52);
            btnOk1.TabIndex = 0;
            btnOk1.Text = "btnOk1";
            btnOk1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblMessage);
            panel1.Controls.Add(lblTimer);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(489, 202);
            panel1.TabIndex = 2;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Padding = new Padding(0, 0, 0, 50);
            lblMessage.Size = new Size(489, 181);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "_";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Dock = DockStyle.Bottom;
            lblTimer.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblTimer.ForeColor = Color.FromArgb(255, 128, 0);
            lblTimer.Location = new Point(0, 181);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(204, 21);
            lblTimer.TabIndex = 8;
            lblTimer.Text = "Tự động đóng/xác nhận sau";
            lblTimer.Visible = false;
            // 
            // timerAutoConfirm
            // 
            timerAutoConfirm.Interval = 1000;
            timerAutoConfirm.Tick += timerAutoConfirm_Tick;
            // 
            // frmConfirm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(489, 289);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "frmConfirm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            tableLayoutPanel1.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblMessage;
        private Panel panelActions;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel lblCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.BtnOk btnOk1;
        private Label lblGuide;
        private System.Windows.Forms.Timer timerAutoConfirm;
        private Panel panel1;
        private Label lblTimer;
    }
}