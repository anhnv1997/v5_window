namespace iParking.ConfigurationManager.UserControls
{
    partial class ucScaleConfig
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
            cbComport = new ComboBox();
            lblScaleDevice = new Label();
            chbIsUseScale = new CheckBox();
            groupBox2 = new GroupBox();
            txtScaleServer = new TextBox();
            label7 = new Label();
            numTimeOut = new NumericUpDown();
            numStopBit = new NumericUpDown();
            numDataBits = new NumericUpDown();
            txtBaudrate = new TextBox();
            label6 = new Label();
            cbScaleType = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTimeOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStopBit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDataBits).BeginInit();
            SuspendLayout();
            // 
            // cbComport
            // 
            cbComport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbComport.DropDownStyle = ComboBoxStyle.DropDownList;
            cbComport.FormattingEnabled = true;
            cbComport.Location = new Point(129, 99);
            cbComport.Margin = new Padding(4, 3, 4, 3);
            cbComport.Name = "cbComport";
            cbComport.Size = new Size(514, 29);
            cbComport.TabIndex = 2;
            // 
            // lblScaleDevice
            // 
            lblScaleDevice.AutoSize = true;
            lblScaleDevice.Location = new Point(6, 104);
            lblScaleDevice.Margin = new Padding(4, 0, 4, 0);
            lblScaleDevice.Name = "lblScaleDevice";
            lblScaleDevice.Size = new Size(46, 21);
            lblScaleDevice.TabIndex = 8;
            lblScaleDevice.Text = "COM";
            // 
            // chbIsUseScale
            // 
            chbIsUseScale.AutoSize = true;
            chbIsUseScale.Location = new Point(129, 274);
            chbIsUseScale.Margin = new Padding(4, 3, 4, 3);
            chbIsUseScale.Name = "chbIsUseScale";
            chbIsUseScale.Size = new Size(167, 25);
            chbIsUseScale.TabIndex = 7;
            chbIsUseScale.Text = "Sử dụng thiết bị cân";
            chbIsUseScale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(txtScaleServer);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(numTimeOut);
            groupBox2.Controls.Add(numStopBit);
            groupBox2.Controls.Add(numDataBits);
            groupBox2.Controls.Add(txtBaudrate);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cbScaleType);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cbComport);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(lblScaleDevice);
            groupBox2.Controls.Add(chbIsUseScale);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(651, 327);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin thiết bị cân";
            // 
            // txtScaleServer
            // 
            txtScaleServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtScaleServer.Location = new Point(129, 29);
            txtScaleServer.Margin = new Padding(4, 3, 4, 3);
            txtScaleServer.Name = "txtScaleServer";
            txtScaleServer.Size = new Size(514, 29);
            txtScaleServer.TabIndex = 13;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(612, 241);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(31, 21);
            label7.TabIndex = 12;
            label7.Text = "ms";
            // 
            // numTimeOut
            // 
            numTimeOut.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numTimeOut.Location = new Point(129, 239);
            numTimeOut.Margin = new Padding(4, 3, 4, 3);
            numTimeOut.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numTimeOut.Name = "numTimeOut";
            numTimeOut.Size = new Size(480, 29);
            numTimeOut.TabIndex = 6;
            numTimeOut.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // numStopBit
            // 
            numStopBit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numStopBit.Location = new Point(129, 204);
            numStopBit.Margin = new Padding(4, 3, 4, 3);
            numStopBit.Name = "numStopBit";
            numStopBit.Size = new Size(516, 29);
            numStopBit.TabIndex = 5;
            numStopBit.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numDataBits
            // 
            numDataBits.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numDataBits.Location = new Point(129, 171);
            numDataBits.Margin = new Padding(4, 3, 4, 3);
            numDataBits.Name = "numDataBits";
            numDataBits.Size = new Size(516, 29);
            numDataBits.TabIndex = 4;
            numDataBits.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // txtBaudrate
            // 
            txtBaudrate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBaudrate.Location = new Point(129, 136);
            txtBaudrate.Margin = new Padding(4, 3, 4, 3);
            txtBaudrate.Name = "txtBaudrate";
            txtBaudrate.Size = new Size(514, 29);
            txtBaudrate.TabIndex = 3;
            txtBaudrate.Text = "9600";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 241);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(67, 21);
            label6.TabIndex = 8;
            label6.Text = "Timeout";
            // 
            // cbScaleType
            // 
            cbScaleType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbScaleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbScaleType.FormattingEnabled = true;
            cbScaleType.Location = new Point(129, 64);
            cbScaleType.Margin = new Padding(4, 3, 4, 3);
            cbScaleType.Name = "cbScaleType";
            cbScaleType.Size = new Size(514, 29);
            cbScaleType.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 207);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(63, 21);
            label5.TabIndex = 8;
            label5.Text = "Stop Bit";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 32);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 21);
            label3.TabIndex = 8;
            label3.Text = "Server";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 67);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 8;
            label1.Text = "Loại cân";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 172);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 21);
            label4.TabIndex = 8;
            label4.Text = "Data Bits";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 139);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 8;
            label2.Text = "Baudrate";
            // 
            // ucScaleConfig
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(groupBox2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucScaleConfig";
            Size = new Size(651, 370);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTimeOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStopBit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDataBits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbComport;
        private Label lblScaleDevice;
        private CheckBox chbIsUseScale;
        private GroupBox groupBox2;
        private TextBox txtBaudrate;
        private ComboBox cbScaleType;
        private Label label1;
        private Label label2;
        private Label label7;
        private NumericUpDown numTimeOut;
        private NumericUpDown numStopBit;
        private NumericUpDown numDataBits;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtScaleServer;
        private Label label3;
    }
}
