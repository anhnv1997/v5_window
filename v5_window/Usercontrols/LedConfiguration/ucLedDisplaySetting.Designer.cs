namespace iParkingv5_window.Forms.DataForms
{
    partial class ucLedDisplaySetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLedDisplaySetting));
            lblLed = new Label();
            cbLeds = new ComboBox();
            btnAddLedDisplay = new Button();
            panelLedConfigs = new Panel();
            btnSave = new Button();
            btnTest = new Button();
            SuspendLayout();
            // 
            // lblLed
            // 
            lblLed.AutoSize = true;
            lblLed.Location = new Point(1, 13);
            lblLed.Margin = new Padding(4, 0, 4, 0);
            lblLed.Name = "lblLed";
            lblLed.Size = new Size(35, 21);
            lblLed.TabIndex = 0;
            lblLed.Text = "Led";
            // 
            // cbLeds
            // 
            cbLeds.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLeds.FormattingEnabled = true;
            cbLeds.Location = new Point(45, 10);
            cbLeds.Margin = new Padding(4, 3, 4, 3);
            cbLeds.Name = "cbLeds";
            cbLeds.Size = new Size(388, 29);
            cbLeds.TabIndex = 1;
            // 
            // btnAddLedDisplay
            // 
            btnAddLedDisplay.AutoSize = true;
            btnAddLedDisplay.Image = (Image)resources.GetObject("btnAddLedDisplay.Image");
            btnAddLedDisplay.Location = new Point(442, 3);
            btnAddLedDisplay.Margin = new Padding(4, 3, 4, 3);
            btnAddLedDisplay.Name = "btnAddLedDisplay";
            btnAddLedDisplay.Size = new Size(127, 42);
            btnAddLedDisplay.TabIndex = 2;
            btnAddLedDisplay.Text = "Thêm";
            btnAddLedDisplay.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddLedDisplay.UseVisualStyleBackColor = true;
            btnAddLedDisplay.Click += btnAddStep_Click;
            // 
            // panelLedConfigs
            // 
            panelLedConfigs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLedConfigs.Location = new Point(4, 51);
            panelLedConfigs.Margin = new Padding(4, 3, 4, 3);
            panelLedConfigs.Name = "panelLedConfigs";
            panelLedConfigs.Size = new Size(887, 495);
            panelLedConfigs.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(576, 3);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 42);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu cấu hình";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnTest
            // 
            btnTest.AutoSize = true;
            btnTest.Image = (Image)resources.GetObject("btnTest.Image");
            btnTest.Location = new Point(725, 3);
            btnTest.Margin = new Padding(4, 3, 4, 3);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(138, 42);
            btnTest.TabIndex = 4;
            btnTest.Text = "Test hiển thị";
            btnTest.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // ucLedDisplaySetting
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnTest);
            Controls.Add(btnSave);
            Controls.Add(panelLedConfigs);
            Controls.Add(btnAddLedDisplay);
            Controls.Add(cbLeds);
            Controls.Add(lblLed);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucLedDisplaySetting";
            Size = new Size(894, 546);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLed;
        private ComboBox cbLeds;
        private Button btnAddLedDisplay;
        private Panel panelLedConfigs;
        private Button btnSave;
        private Button btnTest;
    }
}
