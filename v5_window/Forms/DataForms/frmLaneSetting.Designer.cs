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
            tabDisplayConfig = new TabPage();
            tabController = new TabPage();
            tabSetting.SuspendLayout();
            SuspendLayout();
            // 
            // tabSetting
            // 
            tabSetting.Controls.Add(tabLedConfig);
            tabSetting.Controls.Add(tabCameraConfig);
            tabSetting.Controls.Add(tabShortcut);
            tabSetting.Controls.Add(tabDisplayConfig);
            tabSetting.Controls.Add(tabController);
            tabSetting.Dock = DockStyle.Fill;
            tabSetting.Location = new Point(0, 0);
            tabSetting.Margin = new Padding(3, 2, 3, 2);
            tabSetting.Name = "tabSetting";
            tabSetting.SelectedIndex = 0;
            tabSetting.Size = new Size(786, 414);
            tabSetting.TabIndex = 0;
            // 
            // tabLedConfig
            // 
            tabLedConfig.Location = new Point(4, 24);
            tabLedConfig.Margin = new Padding(3, 2, 3, 2);
            tabLedConfig.Name = "tabLedConfig";
            tabLedConfig.Padding = new Padding(3, 2, 3, 2);
            tabLedConfig.Size = new Size(778, 386);
            tabLedConfig.TabIndex = 0;
            tabLedConfig.Text = "Led";
            tabLedConfig.UseVisualStyleBackColor = true;
            // 
            // tabCameraConfig
            // 
            tabCameraConfig.Location = new Point(4, 24);
            tabCameraConfig.Margin = new Padding(3, 2, 3, 2);
            tabCameraConfig.Name = "tabCameraConfig";
            tabCameraConfig.Padding = new Padding(3, 2, 3, 2);
            tabCameraConfig.Size = new Size(778, 386);
            tabCameraConfig.TabIndex = 1;
            tabCameraConfig.Text = "Camera";
            tabCameraConfig.UseVisualStyleBackColor = true;
            // 
            // tabShortcut
            // 
            tabShortcut.Location = new Point(4, 24);
            tabShortcut.Margin = new Padding(3, 2, 3, 2);
            tabShortcut.Name = "tabShortcut";
            tabShortcut.Padding = new Padding(3, 2, 3, 2);
            tabShortcut.Size = new Size(778, 386);
            tabShortcut.TabIndex = 2;
            tabShortcut.Text = "Phím tắt";
            tabShortcut.UseVisualStyleBackColor = true;
            // 
            // tabDisplayConfig
            // 
            tabDisplayConfig.Location = new Point(4, 24);
            tabDisplayConfig.Margin = new Padding(3, 2, 3, 2);
            tabDisplayConfig.Name = "tabDisplayConfig";
            tabDisplayConfig.Padding = new Padding(3, 2, 3, 2);
            tabDisplayConfig.Size = new Size(778, 386);
            tabDisplayConfig.TabIndex = 3;
            tabDisplayConfig.Text = "Hiển thị";
            tabDisplayConfig.UseVisualStyleBackColor = true;
            // 
            // tabController
            // 
            tabController.Font = new Font("Segoe UI", 12F);
            tabController.Location = new Point(4, 24);
            tabController.Name = "tabController";
            tabController.Padding = new Padding(3);
            tabController.Size = new Size(778, 386);
            tabController.TabIndex = 4;
            tabController.Text = "Controller";
            tabController.UseVisualStyleBackColor = true;
            // 
            // frmLaneSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 414);
            Controls.Add(tabSetting);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmLaneSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cấu hình làn";
            WindowState = FormWindowState.Maximized;
            tabSetting.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabSetting;
        private TabPage tabLedConfig;
        private TabPage tabCameraConfig;
        private TabPage tabShortcut;
        private TabPage tabDisplayConfig;
        private TabPage tabController;
    }
}