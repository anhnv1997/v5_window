namespace ALSE
{
    partial class frmController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmController));
            lblName = new Label();
            txtName = new TextBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            lblIp = new Label();
            txtPort = new TextBox();
            txtIp = new TextBox();
            cbControllerType = new ComboBox();
            lblType = new Label();
            cbCommunication = new ComboBox();
            lblCommunication = new Label();
            lblPort = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 26);
            lblName.Name = "lblName";
            lblName.Size = new Size(32, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Tên";
            // 
            // txtName
            // 
            txtName.Location = new Point(132, 23);
            txtName.Name = "txtName";
            txtName.Size = new Size(312, 27);
            txtName.TabIndex = 2;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(20, 59);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(30, 20);
            lblCode.TabIndex = 0;
            lblCode.Text = "Mã";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(132, 56);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(312, 27);
            txtCode.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 92);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(48, 20);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Mô tả";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(132, 89);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(312, 27);
            txtDescription.TabIndex = 4;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Image = Properties.Resources.confirm;
            btnConfirm.Location = new Point(236, 274);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(111, 52);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(353, 274);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(91, 52);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Đóng";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblIp
            // 
            lblIp.AutoSize = true;
            lblIp.Location = new Point(20, 193);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(21, 20);
            lblIp.TabIndex = 0;
            lblIp.Text = "IP";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(132, 223);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(312, 27);
            txtPort.TabIndex = 8;
            txtPort.KeyPress += txtPort_KeyPress;
            // 
            // txtIp
            // 
            txtIp.Location = new Point(132, 190);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(312, 27);
            txtIp.TabIndex = 7;
            // 
            // cbControllerType
            // 
            cbControllerType.FormattingEnabled = true;
            cbControllerType.Location = new Point(132, 122);
            cbControllerType.Name = "cbControllerType";
            cbControllerType.Size = new Size(312, 28);
            cbControllerType.TabIndex = 5;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(20, 125);
            lblType.Name = "lblType";
            lblType.Size = new Size(37, 20);
            lblType.TabIndex = 10;
            lblType.Text = "Loại";
            // 
            // cbCommunication
            // 
            cbCommunication.FormattingEnabled = true;
            cbCommunication.Location = new Point(132, 156);
            cbCommunication.Name = "cbCommunication";
            cbCommunication.Size = new Size(312, 28);
            cbCommunication.TabIndex = 6;
            // 
            // lblCommunication
            // 
            lblCommunication.AutoSize = true;
            lblCommunication.Location = new Point(20, 159);
            lblCommunication.Name = "lblCommunication";
            lblCommunication.Size = new Size(95, 20);
            lblCommunication.TabIndex = 10;
            lblCommunication.Text = "Truyền thông";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(20, 226);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(35, 20);
            lblPort.TabIndex = 0;
            lblPort.Text = "Port";
            // 
            // frmController
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 334);
            Controls.Add(cbCommunication);
            Controls.Add(lblCommunication);
            Controls.Add(lblType);
            Controls.Add(cbControllerType);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtIp);
            Controls.Add(txtCode);
            Controls.Add(txtPort);
            Controls.Add(lblPort);
            Controls.Add(lblIp);
            Controls.Add(txtDescription);
            Controls.Add(lblCode);
            Controls.Add(lblDescription);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmController";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tầng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnConfirm;
        private Button btnCancel;
        private Label lblIp;
        private TextBox txtPort;
        private TextBox txtIp;
        private ComboBox cbControllerType;
        private Label lblType;
        private ComboBox cbCommunication;
        private Label lblCommunication;
        private Label lblPort;
    }
}