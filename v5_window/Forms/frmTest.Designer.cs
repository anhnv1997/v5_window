﻿using IPaking.Ultility;

namespace iParkingv5_window.Forms
{
    partial class frmTest
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            ucEventInInfo1 = new Usercontrols.ucEventInInfo();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(229, 100);
            button1.Name = "button1";
            button1.Size = new Size(176, 64);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(229, 170);
            button2.Name = "button2";
            button2.Size = new Size(176, 64);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F);
            label1.Image = Properties.Resources.Excel_0_0_0_32px;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(284, 289);
            label1.Name = "label1";
            label1.Size = new Size(95, 53);
            label1.TabIndex = 2;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucEventInInfo1
            // 
            ucEventInInfo1.Location = new Point(140, 55);
            ucEventInInfo1.Margin = new Padding(8, 8, 8, 8);
            ucEventInInfo1.Name = "ucEventInInfo1";
            ucEventInInfo1.Size = new Size(494, 337);
            ucEventInInfo1.TabIndex = 3;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 481);
            Controls.Add(ucEventInInfo1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 30F);
            Margin = new Padding(8);
            Name = "frmTest";
            Text = "frmTest";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Usercontrols.ucPages ucPages1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Usercontrols.ucEventInInfo ucEventInInfo1;
    }
}