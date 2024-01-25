namespace iParkingv5_CustomerRegister.Forms
{
    partial class frmCustomerFingerRegister
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
            panelFingers = new Panel();
            label5 = new Label();
            btnConfirm = new Button();
            lblFingerPrint = new Label();
            toolTip1 = new ToolTip(components);
            lblSubTitle = new Label();
            lblTitle = new Label();
            lblCustomerName = new Label();
            btnSearchCustomer = new Button();
            SuspendLayout();
            // 
            // panelFingers
            // 
            panelFingers.Location = new Point(223, 202);
            panelFingers.Name = "panelFingers";
            panelFingers.Size = new Size(525, 83);
            panelFingers.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(454, 26);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(21, 32);
            label5.TabIndex = 25;
            label5.Text = " ";
            // 
            // btnConfirm
            // 
            btnConfirm.Image = Properties.Resources.Checkmark_0_0_0_24px;
            btnConfirm.Location = new Point(567, 304);
            btnConfirm.Margin = new Padding(4);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(181, 41);
            btnConfirm.TabIndex = 11;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.TextAlign = ContentAlignment.MiddleRight;
            btnConfirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lblFingerPrint
            // 
            lblFingerPrint.AutoSize = true;
            lblFingerPrint.BackColor = Color.Transparent;
            lblFingerPrint.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFingerPrint.Location = new Point(23, 202);
            lblFingerPrint.Margin = new Padding(4, 0, 4, 0);
            lblFingerPrint.Name = "lblFingerPrint";
            lblFingerPrint.Size = new Size(90, 30);
            lblFingerPrint.TabIndex = 21;
            lblFingerPrint.Text = "Vân tay";
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.BackColor = Color.Transparent;
            lblSubTitle.Font = new Font("Segoe UI", 24F);
            lblSubTitle.Location = new Point(13, 79);
            lblSubTitle.Margin = new Padding(4, 0, 4, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(626, 45);
            lblSubTitle.TabIndex = 28;
            lblSubTitle.Text = "Đăng ký thông tin vân tay cho khách hàng ";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTitle.Location = new Point(13, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 59);
            lblTitle.TabIndex = 12;
            lblTitle.Text = "Đăng ký vân tay";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomerName.Location = new Point(22, 159);
            lblCustomerName.Margin = new Padding(4, 0, 4, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(174, 30);
            lblCustomerName.TabIndex = 19;
            lblCustomerName.Text = "Tên khách hàng";
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Location = new Point(223, 159);
            btnSearchCustomer.Margin = new Padding(4);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(525, 36);
            btnSearchCustomer.TabIndex = 22;
            btnSearchCustomer.Text = "_Chọn_";
            btnSearchCustomer.UseVisualStyleBackColor = true;
            // 
            // frmCustomerFingerRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 480);
            Controls.Add(panelFingers);
            Controls.Add(label5);
            Controls.Add(btnConfirm);
            Controls.Add(btnSearchCustomer);
            Controls.Add(lblFingerPrint);
            Controls.Add(lblSubTitle);
            Controls.Add(lblTitle);
            Controls.Add(lblCustomerName);
            Name = "frmCustomerFingerRegister";
            Text = "frmCustomerFingerRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelFingers;
        private Label label5;
        private Button btnConfirm;
        private Label lblFingerPrint;
        private ToolTip toolTip1;
        private Label lblSubTitle;
        private Label lblTitle;
        private Label lblCustomerName;
        private Button btnSearchCustomer;
    }
}