namespace iParkingv5_window.Usercontrols
{
    partial class ucShortcutConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucShortcutConfig));
            panelActions = new Panel();
            btnOk1 = new Controls.Buttons.LblOk();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnOk1);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 444);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(832, 54);
            panelActions.TabIndex = 0;
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Image = (Image)resources.GetObject("btnOk1.Image");
            btnOk1.Location = new Point(688, 5);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(141, 46);
            btnOk1.TabIndex = 1;
            btnOk1.Text = "Lưu cấu hình";
            // 
            // ucShortcutConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelActions);
            Name = "ucShortcutConfig";
            Size = new Size(832, 498);
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelActions;
        private Controls.Buttons.LblOk btnOk1;
    }
}
