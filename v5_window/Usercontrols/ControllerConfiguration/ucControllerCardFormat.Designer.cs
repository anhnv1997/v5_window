namespace iParkingv5_window.Usercontrols.ControllerConfiguration
{
    partial class ucControllerCardFormat
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
            panel1 = new Panel();
            cbController = new ComboBox();
            btnSave = new Button();
            label1 = new Label();
            panelConfigs = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cbController);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(649, 51);
            panel1.TabIndex = 0;
            // 
            // cbController
            // 
            cbController.DropDownStyle = ComboBoxStyle.DropDownList;
            cbController.FormattingEnabled = true;
            cbController.Location = new Point(53, 12);
            cbController.Name = "cbController";
            cbController.Size = new Size(298, 29);
            cbController.TabIndex = 1;
            cbController.SelectedIndexChanged += cbController_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.Location = new Point(357, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 0;
            label1.Text = "BĐK";
            // 
            // panelConfigs
            // 
            panelConfigs.Dock = DockStyle.Fill;
            panelConfigs.Location = new Point(0, 51);
            panelConfigs.Margin = new Padding(4);
            panelConfigs.Name = "panelConfigs";
            panelConfigs.Size = new Size(649, 327);
            panelConfigs.TabIndex = 1;
            // 
            // ucControllerCardFormat
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelConfigs);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "ucControllerCardFormat";
            Size = new Size(649, 378);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panelConfigs;
        private ComboBox cbController;
        private Button btnSave;
    }
}
