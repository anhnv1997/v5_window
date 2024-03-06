using iPakrkingv5.Controls.Controls.Buttons;

namespace iParkingv5_window.Usercontrols.ShortcutConfiguration
{
    partial class ucControllerConfigBarrieItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucControllerConfigBarrieItem));
            lblCurrentConfig = new Label();
            lblBarrieName = new Label();
            picChangeConfig = new BtnSetting();
            SuspendLayout();
            // 
            // lblCurrentConfig
            // 
            lblCurrentConfig.Dock = DockStyle.Fill;
            lblCurrentConfig.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            lblCurrentConfig.ForeColor = Color.Navy;
            lblCurrentConfig.Location = new Point(84, 0);
            lblCurrentConfig.Name = "lblCurrentConfig";
            lblCurrentConfig.Size = new Size(684, 43);
            lblCurrentConfig.TabIndex = 4;
            lblCurrentConfig.Text = "label4";
            lblCurrentConfig.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBarrieName
            // 
            lblBarrieName.Dock = DockStyle.Left;
            lblBarrieName.Location = new Point(0, 0);
            lblBarrieName.Name = "lblBarrieName";
            lblBarrieName.Padding = new Padding(14, 0, 0, 0);
            lblBarrieName.Size = new Size(84, 43);
            lblBarrieName.TabIndex = 3;
            lblBarrieName.Text = "Barrie _";
            lblBarrieName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picChangeConfig
            // 
            picChangeConfig.AutoSize = true;
            picChangeConfig.Dock = DockStyle.Right;
            picChangeConfig.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            picChangeConfig.ForeColor = Color.Black;
            picChangeConfig.Image = (Image)resources.GetObject("picChangeConfig.Image");
            picChangeConfig.ImageAlign = ContentAlignment.MiddleRight;
            picChangeConfig.Location = new Point(768, 0);
            picChangeConfig.Name = "picChangeConfig";
            picChangeConfig.Size = new Size(15, 22);
            picChangeConfig.TabIndex = 6;
            picChangeConfig.Text = " ";
            // 
            // ucControllerConfigBarrieItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(lblCurrentConfig);
            Controls.Add(picChangeConfig);
            Controls.Add(lblBarrieName);
            Name = "ucControllerConfigBarrieItem";
            Size = new Size(783, 43);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentConfig;
        private Label lblBarrieName;
        private BtnSetting picChangeConfig;
    }
}
