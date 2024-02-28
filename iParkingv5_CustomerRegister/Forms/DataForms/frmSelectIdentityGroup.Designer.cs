namespace iParkingv5_CustomerRegister.Forms
{
    partial class frmSelectIdentityGroup
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectIdentityGroup));
            lblTitle = new Label();
            lblIdentityGroupName = new Label();
            cbVehicleType = new ComboBox();
            txtIdentityGroupName = new TextBox();
            lblVehicleType = new Label();
            lblSearch1 = new iPakrkingv5.Controls.Controls.Buttons.LblSearch();
            dgvData = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            lblCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            lblOk1 = new iPakrkingv5.Controls.Controls.Buttons.LblOk();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(72, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Danh sách nhóm định danh";
            // 
            // lblIdentityGroupName
            // 
            lblIdentityGroupName.AutoSize = true;
            lblIdentityGroupName.Location = new Point(71, 86);
            lblIdentityGroupName.Name = "lblIdentityGroupName";
            lblIdentityGroupName.Size = new Size(74, 20);
            lblIdentityGroupName.TabIndex = 1;
            lblIdentityGroupName.Text = "Tên nhóm";
            // 
            // cbVehicleType
            // 
            cbVehicleType.FormattingEnabled = true;
            cbVehicleType.Location = new Point(151, 116);
            cbVehicleType.Name = "cbVehicleType";
            cbVehicleType.Size = new Size(366, 28);
            cbVehicleType.TabIndex = 1;
            // 
            // txtIdentityGroupName
            // 
            txtIdentityGroupName.Location = new Point(151, 83);
            txtIdentityGroupName.Name = "txtIdentityGroupName";
            txtIdentityGroupName.Size = new Size(366, 27);
            txtIdentityGroupName.TabIndex = 0;
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.Location = new Point(84, 125);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(56, 20);
            lblVehicleType.TabIndex = 4;
            lblVehicleType.Text = "Loại xe";
            // 
            // lblSearch1
            // 
            lblSearch1.AutoSize = true;
            lblSearch1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblSearch1.Location = new Point(545, 77);
            lblSearch1.Name = "lblSearch1";
            lblSearch1.Size = new Size(91, 30);
            lblSearch1.TabIndex = 2;
            lblSearch1.Text = "lblSearch1";
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column5, Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            dgvData.Location = new Point(75, 166);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 29;
            dgvData.Size = new Size(510, 204);
            dgvData.TabIndex = 3;
            // 
            // Column5
            // 
            Column5.HeaderText = "ID";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Visible = false;
            Column5.Width = 37;
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
            Column2.HeaderText = "Tên";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 65;
            // 
            // Column3
            // 
            Column3.HeaderText = "Mã";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 62;
            // 
            // Column4
            // 
            Column4.HeaderText = "Loại xe";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 89;
            // 
            // lblCancel1
            // 
            lblCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCancel1.AutoSize = true;
            lblCancel1.Location = new Point(605, 385);
            lblCancel1.Name = "lblCancel1";
            lblCancel1.Size = new Size(88, 30);
            lblCancel1.TabIndex = 5;
            // 
            // lblOk1
            // 
            lblOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblOk1.AutoSize = true;
            lblOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblOk1.Location = new Point(474, 388);
            lblOk1.Name = "lblOk1";
            lblOk1.Size = new Size(64, 30);
            lblOk1.TabIndex = 4;
            // 
            // frmSelectIdentityGroup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblOk1);
            Controls.Add(lblCancel1);
            Controls.Add(dgvData);
            Controls.Add(lblSearch1);
            Controls.Add(lblVehicleType);
            Controls.Add(txtIdentityGroupName);
            Controls.Add(cbVehicleType);
            Controls.Add(lblIdentityGroupName);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSelectIdentityGroup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chọn nhóm định danh";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblIdentityGroupName;
        private ComboBox cbVehicleType;
        private TextBox txtIdentityGroupName;
        private Label lblVehicleType;
        private iPakrkingv5.Controls.Controls.Buttons.LblSearch lblSearch1;
        private DataGridView dgvData;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel lblCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.LblOk lblOk1;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}