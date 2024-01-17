namespace iParkingv5_window.Forms.DataForms
{
    partial class frmLaneSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaneSetting));
            tabSetting = new TabControl();
            tabLedConfig = new TabPage();
            tabCameraConfig = new TabPage();
            tabShortcut = new TabPage();
            tabSetting.SuspendLayout();
            SuspendLayout();
            // 
            // tabSetting
            // 
            tabSetting.Controls.Add(tabLedConfig);
            tabSetting.Controls.Add(tabCameraConfig);
            tabSetting.Controls.Add(tabShortcut);
            tabSetting.Dock = DockStyle.Fill;
            tabSetting.Location = new Point(0, 0);
            tabSetting.Name = "tabSetting";
            tabSetting.SelectedIndex = 0;
            tabSetting.Size = new Size(898, 552);
            tabSetting.TabIndex = 0;
            // 
            // tabLedConfig
            // 
            tabLedConfig.Location = new Point(4, 29);
            tabLedConfig.Name = "tabLedConfig";
            tabLedConfig.Padding = new Padding(3);
            tabLedConfig.Size = new Size(890, 519);
            tabLedConfig.TabIndex = 0;
            tabLedConfig.Text = "Led";
            tabLedConfig.UseVisualStyleBackColor = true;
            // 
            // tabCameraConfig
            // 
            tabCameraConfig.Location = new Point(4, 29);
            tabCameraConfig.Name = "tabCameraConfig";
            tabCameraConfig.Padding = new Padding(3);
            tabCameraConfig.Size = new Size(1013, 546);
            tabCameraConfig.TabIndex = 1;
            tabCameraConfig.Text = "Camera";
            tabCameraConfig.UseVisualStyleBackColor = true;
            // 
            // tabShortcut
            // 
            tabShortcut.Location = new Point(4, 29);
            tabShortcut.Name = "tabShortcut";
            tabShortcut.Padding = new Padding(3);
            tabShortcut.Size = new Size(1013, 546);
            tabShortcut.TabIndex = 2;
            tabShortcut.Text = "Phím tắt";
            tabShortcut.UseVisualStyleBackColor = true;
            // 
            // frmLaneSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 552);
            Controls.Add(tabSetting);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLaneSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cấu hình làn";
            tabSetting.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabSetting;
        private TabPage tabLedConfig;
        private TabPage tabCameraConfig;
        private TabPage tabShortcut;
    }
}