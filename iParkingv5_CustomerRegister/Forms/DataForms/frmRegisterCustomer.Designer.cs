namespace iParkingv5_CustomerRegister
{
    partial class frmRegisterCustomer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterCustomer));
            lblTitle = new Label();
            btnAdd = new Button();
            label5 = new Label();
            btnSearchCustomer = new Button();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            lblSubTitle = new Label();
            lblCustomerCode = new Label();
            txtCustomerCode = new TextBox();
            toolTip1 = new ToolTip(components);
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTitle.Location = new Point(32, 32);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(438, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng ký khách hàng";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.Checkmark_0_0_0_24px;
            btnAdd.Location = new Point(700, 461);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(181, 41);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm mới";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(473, 49);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(21, 32);
            label5.TabIndex = 4;
            label5.Text = " ";
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Image = Properties.Resources.search_0_0_0_24px;
            btnSearchCustomer.Location = new Point(824, 195);
            btnSearchCustomer.Margin = new Padding(4);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(61, 36);
            btnSearchCustomer.TabIndex = 1;
            btnSearchCustomer.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerName.Location = new Point(359, 195);
            txtCustomerName.Margin = new Padding(4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(454, 36);
            txtCustomerName.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.Transparent;
            lblCustomerName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomerName.Location = new Point(53, 195);
            lblCustomerName.Margin = new Padding(4, 0, 4, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(174, 30);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Tên khách hàng";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.BackColor = Color.Transparent;
            lblSubTitle.Font = new Font("Segoe UI", 24F);
            lblSubTitle.Location = new Point(32, 102);
            lblSubTitle.Margin = new Padding(4, 0, 4, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(695, 45);
            lblSubTitle.TabIndex = 5;
            lblSubTitle.Text = "Tạo một khách hàng mới và thêm vào hệ thống";
            // 
            // lblCustomerCode
            // 
            lblCustomerCode.AutoSize = true;
            lblCustomerCode.BackColor = Color.Transparent;
            lblCustomerCode.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCustomerCode.Location = new Point(53, 245);
            lblCustomerCode.Margin = new Padding(4, 0, 4, 0);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(171, 30);
            lblCustomerCode.TabIndex = 1;
            lblCustomerCode.Text = "Mã khách hàng";
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCustomerCode.Location = new Point(359, 245);
            txtCustomerCode.Margin = new Padding(4);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.Size = new Size(522, 36);
            txtCustomerCode.TabIndex = 2;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Image = Properties.Resources.edit_0_0_0_24px;
            btnUpdate.Location = new Point(511, 461);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(181, 41);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.TextAlign = ContentAlignment.MiddleRight;
            btnUpdate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // frmCustomerRegister
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 525);
            Controls.Add(lblSubTitle);
            Controls.Add(label5);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnSearchCustomer);
            Controls.Add(lblTitle);
            Controls.Add(txtCustomerCode);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerCode);
            Controls.Add(lblCustomerName);
            Font = new Font("Segoe UI", 16F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmCustomerRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký khách hàng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnAdd;
        private Label label5;
        private Button btnSearchCustomer;
        private TextBox txtCustomerName;
        private Label lblCustomerName;
        private Label lblSubTitle;
        private Label lblCustomerCode;
        private TextBox txtCustomerCode;
        private ToolTip toolTip1;
        private Button btnUpdate;
    }
}
