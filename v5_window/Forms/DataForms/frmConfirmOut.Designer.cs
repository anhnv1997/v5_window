using iPakrkingv5.Controls.Controls.Buttons;
using iPakrkingv5.Controls.Usercontrols;

namespace iParkingv5_window.Forms.DataForms
{
    partial class frmConfirmOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmOut));
            lblMessage = new Label();
            panelAction = new Panel();
            lblGuide = new Label();
            btnCancel1 = new LblCancel();
            btnOk = new BtnOk();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblIdentityGroup = new Label();
            lblVehicleType = new Label();
            label6 = new Label();
            label5 = new Label();
            label7 = new Label();
            txtPlateOut = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            lblTimeOut = new Label();
            lblTimeIn = new Label();
            lblIdentityCode = new Label();
            panel2 = new Panel();
            lblPlateIn = new Label();
            btnCopy = new Button();
            panelEventPic = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverview = new MovablePictureBox();
            picVehicle = new MovablePictureBox();
            toolTip1 = new ToolTip(components);
            panelAction.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            panelEventPic.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(945, 58);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAction
            // 
            panelAction.Controls.Add(lblGuide);
            panelAction.Controls.Add(btnCancel1);
            panelAction.Controls.Add(btnOk);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 423);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(945, 62);
            panelAction.TabIndex = 1;
            // 
            // lblGuide
            // 
            lblGuide.Dock = DockStyle.Left;
            lblGuide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGuide.ForeColor = Color.FromArgb(255, 128, 0);
            lblGuide.Location = new Point(0, 0);
            lblGuide.Name = "lblGuide";
            lblGuide.Size = new Size(624, 62);
            lblGuide.TabIndex = 4;
            lblGuide.Text = "Vui lòng kiểm tra và nhập biển số phương tiện vào ô biển số ra.\r\nNhấn Enter để xác nhận, Esc để hủy.";
            lblGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(865, 14);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(57, 30);
            btnCancel1.TabIndex = 2;
            btnCancel1.Text = "Đóng";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.AutoSize = true;
            btnOk.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk.ForeColor = Color.Black;
            btnOk.Location = new Point(784, 14);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(83, 30);
            btnOk.TabIndex = 1;
            btnOk.Text = "Xác nhận";
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(panelEventPic);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(945, 365);
            panel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.91667F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.08333F));
            tableLayoutPanel2.Controls.Add(lblIdentityGroup, 1, 5);
            tableLayoutPanel2.Controls.Add(lblVehicleType, 1, 6);
            tableLayoutPanel2.Controls.Add(label6, 0, 6);
            tableLayoutPanel2.Controls.Add(label5, 0, 5);
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Controls.Add(txtPlateOut, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 4);
            tableLayoutPanel2.Controls.Add(label2, 0, 3);
            tableLayoutPanel2.Controls.Add(label1, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(lblTimeOut, 1, 3);
            tableLayoutPanel2.Controls.Add(lblTimeIn, 1, 2);
            tableLayoutPanel2.Controls.Add(lblIdentityCode, 1, 4);
            tableLayoutPanel2.Controls.Add(panel2, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Font = new Font("Segoe UI", 12F);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3076916F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.5604391F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135145F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135145F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135145F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135145F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135145F));
            tableLayoutPanel2.Size = new Size(624, 365);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // lblIdentityGroup
            // 
            lblIdentityGroup.Dock = DockStyle.Fill;
            lblIdentityGroup.Font = new Font("Segoe UI", 12F);
            lblIdentityGroup.Location = new Point(147, 264);
            lblIdentityGroup.Name = "lblIdentityGroup";
            lblIdentityGroup.Size = new Size(473, 48);
            lblIdentityGroup.TabIndex = 13;
            lblIdentityGroup.Text = "_";
            lblIdentityGroup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleType
            // 
            lblVehicleType.Dock = DockStyle.Fill;
            lblVehicleType.Font = new Font("Segoe UI", 12F);
            lblVehicleType.Location = new Point(147, 313);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(473, 51);
            lblVehicleType.TabIndex = 12;
            lblVehicleType.Text = "_";
            lblVehicleType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(4, 313);
            label6.Name = "label6";
            label6.Size = new Size(136, 51);
            label6.TabIndex = 4;
            label6.Text = "Loại Xe";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(4, 264);
            label5.Name = "label5";
            label5.Size = new Size(136, 48);
            label5.TabIndex = 3;
            label5.Text = "Nhóm";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(4, 1);
            label7.Name = "label7";
            label7.Size = new Size(136, 62);
            label7.TabIndex = 5;
            label7.Text = "Biển Số Ra";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPlateOut
            // 
            txtPlateOut.Dock = DockStyle.Bottom;
            txtPlateOut.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            txtPlateOut.Location = new Point(147, 13);
            txtPlateOut.Name = "txtPlateOut";
            txtPlateOut.Size = new Size(473, 47);
            txtPlateOut.TabIndex = 0;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(4, 215);
            label3.Name = "label3";
            label3.Size = new Size(136, 48);
            label3.TabIndex = 1;
            label3.Text = "Tên Định Danh";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(4, 166);
            label2.Name = "label2";
            label2.Size = new Size(136, 48);
            label2.TabIndex = 0;
            label2.Text = "Giờ ra";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(4, 117);
            label1.Name = "label1";
            label1.Size = new Size(136, 48);
            label1.TabIndex = 0;
            label1.Text = "Giờ Vào";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(4, 64);
            label4.Name = "label4";
            label4.Size = new Size(136, 52);
            label4.TabIndex = 2;
            label4.Text = "Biển Số Vào";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeOut
            // 
            lblTimeOut.Dock = DockStyle.Fill;
            lblTimeOut.Font = new Font("Segoe UI", 12F);
            lblTimeOut.Location = new Point(147, 166);
            lblTimeOut.Name = "lblTimeOut";
            lblTimeOut.Size = new Size(473, 48);
            lblTimeOut.TabIndex = 8;
            lblTimeOut.Text = "_";
            lblTimeOut.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeIn
            // 
            lblTimeIn.Dock = DockStyle.Fill;
            lblTimeIn.Font = new Font("Segoe UI", 12F);
            lblTimeIn.Location = new Point(147, 117);
            lblTimeIn.Name = "lblTimeIn";
            lblTimeIn.Size = new Size(473, 48);
            lblTimeIn.TabIndex = 7;
            lblTimeIn.Text = "_";
            lblTimeIn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdentityCode
            // 
            lblIdentityCode.Dock = DockStyle.Fill;
            lblIdentityCode.Font = new Font("Segoe UI", 12F);
            lblIdentityCode.Location = new Point(147, 215);
            lblIdentityCode.Name = "lblIdentityCode";
            lblIdentityCode.Size = new Size(473, 48);
            lblIdentityCode.TabIndex = 9;
            lblIdentityCode.Text = "_";
            lblIdentityCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblPlateIn);
            panel2.Controls.Add(btnCopy);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(144, 64);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(479, 52);
            panel2.TabIndex = 14;
            // 
            // lblPlateIn
            // 
            lblPlateIn.Dock = DockStyle.Fill;
            lblPlateIn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPlateIn.Location = new Point(0, 0);
            lblPlateIn.Name = "lblPlateIn";
            lblPlateIn.Size = new Size(432, 52);
            lblPlateIn.TabIndex = 10;
            lblPlateIn.Text = "_";
            lblPlateIn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCopy
            // 
            btnCopy.AutoSize = true;
            btnCopy.Dock = DockStyle.Right;
            btnCopy.Image = Properties.Resources.icons8_copy_24px;
            btnCopy.Location = new Point(432, 0);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(47, 52);
            btnCopy.TabIndex = 11;
            toolTip1.SetToolTip(btnCopy, "Bấm để chỉnh sửa biển số ra giống biển số vào");
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // panelEventPic
            // 
            panelEventPic.Controls.Add(tableLayoutPanel1);
            panelEventPic.Dock = DockStyle.Right;
            panelEventPic.Location = new Point(624, 0);
            panelEventPic.Name = "panelEventPic";
            panelEventPic.Size = new Size(321, 365);
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
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(321, 365);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // picOverview
            // 
            picOverview.Dock = DockStyle.Fill;
            picOverview.Location = new Point(3, 3);
            picOverview.Name = "picOverview";
            picOverview.Size = new Size(315, 176);
            picOverview.SizeMode = PictureBoxSizeMode.Zoom;
            picOverview.TabIndex = 0;
            picOverview.TabStop = false;
            toolTip1.SetToolTip(picOverview, "Kích đúp để xem hình ảnh phóng to");
            // 
            // picVehicle
            // 
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Location = new Point(3, 185);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(315, 177);
            picVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            toolTip1.SetToolTip(picVehicle, "Kích đúp để xem hình ảnh phóng to");
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // frmConfirmOut
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(945, 485);
            Controls.Add(panel1);
            Controls.Add(lblMessage);
            Controls.Add(panelAction);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfirmOut";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            KeyDown += frmConfirmOut_KeyDown;
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelEventPic.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverview).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
        private Panel panelAction;
        private BtnOk btnOk;
        private LblCancel btnCancel1;
        private Panel panel1;
        private Panel panelEventPic;
        private TableLayoutPanel tableLayoutPanel1;
        private MovablePictureBox picOverview;
        private MovablePictureBox picVehicle;
        private Label lblGuide;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label lblVehicleType;
        private Label lblPlateIn;
        private Label lblIdentityCode;
        private Label lblTimeOut;
        private Label lblTimeIn;
        private Label label5;
        private TextBox txtPlateOut;
        private Label lblIdentityGroup;
        private Panel panel2;
        private Button btnCopy;
        private ToolTip toolTip1;
    }
}