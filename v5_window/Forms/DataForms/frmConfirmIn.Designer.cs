using iPakrkingv5.Controls.Usercontrols;

namespace iParkingv5_window.Forms.DataForms
{
    partial class frmConfirmIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmIn));
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label7 = new Label();
            txtDetectPlate = new TextBox();
            label1 = new Label();
            label4 = new Label();
            lblTimeIn = new Label();
            panel2 = new Panel();
            lblRegisterPlate = new Label();
            btnCopy = new Button();
            label3 = new Label();
            lblIdentityCode = new Label();
            label5 = new Label();
            lblIdentityGroup = new Label();
            label6 = new Label();
            lblVehicleType = new Label();
            panelEventPic = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverview = new MovablePictureBox();
            picVehicle = new MovablePictureBox();
            lblMessage = new Label();
            panelAction = new Panel();
            lblGuide = new Label();
            lblCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            lblTimer = new Label();
            timerAutoConfirm = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            panelEventPic.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            panelAction.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(panelEventPic);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 44);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(883, 300);
            panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Controls.Add(txtDetectPlate, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(lblTimeIn, 1, 2);
            tableLayoutPanel2.Controls.Add(panel2, 1, 1);
            tableLayoutPanel2.Controls.Add(label3, 0, 3);
            tableLayoutPanel2.Controls.Add(lblIdentityCode, 1, 3);
            tableLayoutPanel2.Controls.Add(label5, 0, 4);
            tableLayoutPanel2.Controls.Add(lblIdentityGroup, 1, 4);
            tableLayoutPanel2.Controls.Add(label6, 0, 5);
            tableLayoutPanel2.Controls.Add(lblVehicleType, 1, 5);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Font = new Font("Segoe UI", 12F);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4059124F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.64307F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5902042F));
            tableLayoutPanel2.Size = new Size(602, 300);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(4, 1);
            label7.Name = "label7";
            label7.Size = new Size(136, 59);
            label7.TabIndex = 5;
            label7.Text = "Biển Số Nhận Dạng";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDetectPlate
            // 
            txtDetectPlate.Dock = DockStyle.Bottom;
            txtDetectPlate.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txtDetectPlate.Location = new Point(147, 10);
            txtDetectPlate.Name = "txtDetectPlate";
            txtDetectPlate.Size = new Size(451, 47);
            txtDetectPlate.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(4, 111);
            label1.Name = "label1";
            label1.Size = new Size(136, 46);
            label1.TabIndex = 0;
            label1.Text = "Giờ Vào";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(4, 61);
            label4.Name = "label4";
            label4.Size = new Size(136, 49);
            label4.TabIndex = 2;
            label4.Text = "Biển Số Đăng Ký";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeIn
            // 
            lblTimeIn.Dock = DockStyle.Fill;
            lblTimeIn.Font = new Font("Segoe UI", 12F);
            lblTimeIn.Location = new Point(147, 111);
            lblTimeIn.Name = "lblTimeIn";
            lblTimeIn.Size = new Size(451, 46);
            lblTimeIn.TabIndex = 7;
            lblTimeIn.Text = "_";
            lblTimeIn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblRegisterPlate);
            panel2.Controls.Add(btnCopy);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(144, 61);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(457, 49);
            panel2.TabIndex = 14;
            // 
            // lblRegisterPlate
            // 
            lblRegisterPlate.Dock = DockStyle.Fill;
            lblRegisterPlate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRegisterPlate.Location = new Point(0, 0);
            lblRegisterPlate.Name = "lblRegisterPlate";
            lblRegisterPlate.Size = new Size(410, 49);
            lblRegisterPlate.TabIndex = 10;
            lblRegisterPlate.Text = "_";
            lblRegisterPlate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCopy
            // 
            btnCopy.AutoSize = true;
            btnCopy.Dock = DockStyle.Right;
            btnCopy.Image = Properties.Resources.icons8_copy_24px;
            btnCopy.Location = new Point(410, 0);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(47, 49);
            btnCopy.TabIndex = 11;
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(4, 158);
            label3.Name = "label3";
            label3.Size = new Size(136, 46);
            label3.TabIndex = 1;
            label3.Text = "Tên Định Danh";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityCode
            // 
            lblIdentityCode.Dock = DockStyle.Fill;
            lblIdentityCode.Font = new Font("Segoe UI", 12F);
            lblIdentityCode.Location = new Point(147, 158);
            lblIdentityCode.Name = "lblIdentityCode";
            lblIdentityCode.Size = new Size(451, 46);
            lblIdentityCode.TabIndex = 9;
            lblIdentityCode.Text = "_";
            lblIdentityCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(4, 205);
            label5.Name = "label5";
            label5.Size = new Size(136, 46);
            label5.TabIndex = 3;
            label5.Text = "Nhóm";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityGroup
            // 
            lblIdentityGroup.Dock = DockStyle.Fill;
            lblIdentityGroup.Font = new Font("Segoe UI", 12F);
            lblIdentityGroup.Location = new Point(147, 205);
            lblIdentityGroup.Name = "lblIdentityGroup";
            lblIdentityGroup.Size = new Size(451, 46);
            lblIdentityGroup.TabIndex = 13;
            lblIdentityGroup.Text = "_";
            lblIdentityGroup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(4, 252);
            label6.Name = "label6";
            label6.Size = new Size(136, 47);
            label6.TabIndex = 4;
            label6.Text = "Loại Xe";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleType
            // 
            lblVehicleType.Dock = DockStyle.Fill;
            lblVehicleType.Font = new Font("Segoe UI", 12F);
            lblVehicleType.Location = new Point(147, 252);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(451, 47);
            lblVehicleType.TabIndex = 12;
            lblVehicleType.Text = "_";
            lblVehicleType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelEventPic
            // 
            panelEventPic.Controls.Add(tableLayoutPanel1);
            panelEventPic.Dock = DockStyle.Right;
            panelEventPic.Location = new Point(602, 0);
            panelEventPic.Margin = new Padding(3, 2, 3, 2);
            panelEventPic.Name = "panelEventPic";
            panelEventPic.Size = new Size(281, 300);
            panelEventPic.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picOverview, 0, 0);
            tableLayoutPanel1.Controls.Add(picVehicle, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(281, 300);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // picOverview
            // 
            picOverview.Dock = DockStyle.Fill;
            picOverview.Location = new Point(3, 2);
            picOverview.Margin = new Padding(3, 2, 3, 2);
            picOverview.Name = "picOverview";
            picOverview.Size = new Size(275, 146);
            picOverview.SizeMode = PictureBoxSizeMode.Zoom;
            picOverview.TabIndex = 0;
            picOverview.TabStop = false;
            // 
            // picVehicle
            // 
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Location = new Point(3, 152);
            picVehicle.Margin = new Padding(3, 2, 3, 2);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(275, 146);
            picVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(883, 44);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAction
            // 
            panelAction.Controls.Add(lblGuide);
            panelAction.Controls.Add(lblCancel1);
            panelAction.Controls.Add(btnOk1);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 371);
            panelAction.Margin = new Padding(3, 2, 3, 2);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(883, 46);
            panelAction.TabIndex = 5;
            // 
            // lblGuide
            // 
            lblGuide.Dock = DockStyle.Left;
            lblGuide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGuide.ForeColor = Color.FromArgb(255, 128, 0);
            lblGuide.Location = new Point(0, 0);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(624, 46);
            lblGuide.TabIndex = 6;
            lblGuide.Text = "Vui lòng kiểm tra và nhập biển số phương tiện vào ô biển số ra.\r\nNhấn Enter để xác nhận, Esc để hủy.";
            lblGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCancel1
            // 
            lblCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCancel1.AutoSize = true;
            lblCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblCancel1.ForeColor = Color.Black;
            lblCancel1.Location = new Point(818, 7);
            lblCancel1.Margin = new Padding(3, 2, 3, 2);
            lblCancel1.Name = "lblCancel1";
            lblCancel1.Size = new Size(57, 30);
            lblCancel1.TabIndex = 5;
            lblCancel1.Text = "Đóng";
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(729, 7);
            btnOk1.Margin = new Padding(3, 2, 3, 2);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(83, 30);
            btnOk1.TabIndex = 4;
            btnOk1.Text = "Xác nhận";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Dock = DockStyle.Bottom;
            lblTimer.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblTimer.ForeColor = Color.FromArgb(255, 128, 0);
            lblTimer.Location = new Point(0, 344);
            lblTimer.Name = "lblTimer";
            lblTimer.Padding = new Padding(0, 3, 0, 3);
            lblTimer.Size = new Size(204, 27);
            lblTimer.TabIndex = 7;
            lblTimer.Text = "Tự động xác nhận/đóng sau";
            // 
            // timerAutoConfirm
            // 
            timerAutoConfirm.Interval = 1000;
            timerAutoConfirm.Tick += timerAutoConfirm_Tick;
            // 
            // frmConfirmIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 417);
            Controls.Add(panel1);
            Controls.Add(lblTimer);
            Controls.Add(lblMessage);
            Controls.Add(panelAction);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmConfirmIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            KeyDown += frmConfirmIn_KeyDown;
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelEventPic.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverview).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panelEventPic;
        private TableLayoutPanel tableLayoutPanel1;
        private MovablePictureBox picOverview;
        private MovablePictureBox picVehicle;
        private Label lblMessage;
        private Panel panelAction;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel lblCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.BtnOk btnOk1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblIdentityGroup;
        private Label lblVehicleType;
        private Label label6;
        private Label label5;
        private Label label7;
        private TextBox txtDetectPlate;
        private Label label3;
        private Label label1;
        private Label label4;
        private Label lblTimeIn;
        private Label lblIdentityCode;
        private Panel panel2;
        private Label lblRegisterPlate;
        private Button btnCopy;
        private Label lblGuide;
        private Label lblTimer;
        private System.Windows.Forms.Timer timerAutoConfirm;
    }
}