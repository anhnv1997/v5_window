namespace iParking.ConfigurationManager.UserControls
{
    partial class ucOEM
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chbIsReturnDefaultConfig = new CheckBox();
            numTimeToDefaultConfig = new NumericUpDown();
            label7 = new Label();
            txtAppName = new TextBox();
            label5 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtCompanyName = new TextBox();
            label1 = new Label();
            cbLanguage = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numTimeToDefaultConfig).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // chbIsReturnDefaultConfig
            // 
            chbIsReturnDefaultConfig.AutoSize = true;
            chbIsReturnDefaultConfig.Location = new Point(248, 169);
            chbIsReturnDefaultConfig.Margin = new Padding(4);
            chbIsReturnDefaultConfig.Name = "chbIsReturnDefaultConfig";
            chbIsReturnDefaultConfig.Size = new Size(222, 25);
            chbIsReturnDefaultConfig.TabIndex = 10;
            chbIsReturnDefaultConfig.Text = "Tự động giao diện mặc định";
            chbIsReturnDefaultConfig.UseVisualStyleBackColor = true;
            chbIsReturnDefaultConfig.Visible = false;
            // 
            // numTimeToDefaultConfig
            // 
            numTimeToDefaultConfig.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numTimeToDefaultConfig.Location = new Point(248, 133);
            numTimeToDefaultConfig.Margin = new Padding(4, 3, 4, 3);
            numTimeToDefaultConfig.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numTimeToDefaultConfig.Name = "numTimeToDefaultConfig";
            numTimeToDefaultConfig.Size = new Size(421, 29);
            numTimeToDefaultConfig.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 135);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(231, 21);
            label7.TabIndex = 7;
            label7.Text = "Thời gian về giao diện mặc định";
            // 
            // txtAppName
            // 
            txtAppName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAppName.Location = new Point(248, 28);
            txtAppName.Margin = new Padding(4, 3, 4, 3);
            txtAppName.Name = "txtAppName";
            txtAppName.PlaceholderText = "Tên ứng dụng";
            txtAppName.Size = new Size(448, 29);
            txtAppName.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 66);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(88, 21);
            label5.TabIndex = 2;
            label5.Text = "Tên công ty";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 31);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 2;
            label2.Text = "Tên ứng dụng";
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(cbLanguage);
            groupBox2.Controls.Add(chbIsReturnDefaultConfig);
            groupBox2.Controls.Add(numTimeToDefaultConfig);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtCompanyName);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtAppName);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(700, 223);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "OEM";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCompanyName.Location = new Point(248, 63);
            txtCompanyName.Margin = new Padding(4, 3, 4, 3);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.PlaceholderText = "Tên công ty";
            txtCompanyName.Size = new Size(448, 29);
            txtCompanyName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 101);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 2;
            label1.Text = "Ngôn ngữ";
            // 
            // cbLanguage
            // 
            cbLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Items.AddRange(new object[] { "Tiếng việt", "Tiếng Anh" });
            cbLanguage.Location = new Point(248, 98);
            cbLanguage.Margin = new Padding(4, 3, 4, 3);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(448, 29);
            cbLanguage.TabIndex = 11;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(676, 135);
            label3.Name = "label3";
            label3.Size = new Size(17, 21);
            label3.TabIndex = 12;
            label3.Text = "s";
            // 
            // ucOEM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "ucOEM";
            Padding = new Padding(3);
            Size = new Size(706, 275);
            ((System.ComponentModel.ISupportInitialize)numTimeToDefaultConfig).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chbIsReturnDefaultConfig;
        private NumericUpDown numTimeToDefaultConfig;
        private Label label7;
        private TextBox txtAppName;
        private Label label5;
        private Label label2;
        private GroupBox groupBox2;
        private TextBox txtCompanyName;
        private Label label1;
        private ComboBox cbLanguage;
        private Label label3;
    }
}
