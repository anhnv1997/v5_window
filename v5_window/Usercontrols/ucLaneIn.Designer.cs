namespace iParkingv5_window.Usercontrols
{
    partial class ucLaneIn
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
            lblLaneName = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblLaneName
            // 
            lblLaneName.BorderStyle = BorderStyle.FixedSingle;
            lblLaneName.Dock = DockStyle.Top;
            lblLaneName.Location = new Point(0, 0);
            lblLaneName.Name = "lblLaneName";
            lblLaneName.Size = new Size(547, 43);
            lblLaneName.TabIndex = 0;
            lblLaneName.Text = "label1";
            lblLaneName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(547, 416);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 416);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Controls.Add(button2);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 459);
            panel3.Name = "panel3";
            panel3.Size = new Size(547, 72);
            panel3.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(395, 14);
            button2.Name = "button2";
            button2.Size = new Size(118, 45);
            button2.TabIndex = 0;
            button2.Text = "CHỤP LẠI";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(271, 14);
            button1.Name = "button1";
            button1.Size = new Size(118, 45);
            button1.TabIndex = 1;
            button1.Text = "GHI VÉ VÀO";
            button1.UseVisualStyleBackColor = true;
            // 
            // ucLane
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(lblLaneName);
            Name = "ucLane";
            Size = new Size(547, 531);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblLaneName;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button1;
        private Button button2;
    }
}
