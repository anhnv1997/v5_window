using IPaking.Ultility;

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
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(94, 39);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(94, 66);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(72, 25);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F);
            label1.Image = Properties.Resources.Excel_0_0_0_32px;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(116, 112);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 2;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucEventInInfo1
            // 
            ucEventInInfo1.BackColor = Color.FromArgb(255, 224, 192);
            ucEventInInfo1.Location = new Point(57, 21);
            ucEventInInfo1.Name = "ucEventInInfo1";
            ucEventInInfo1.Size = new Size(202, 364);
            ucEventInInfo1.TabIndex = 3;
            // 
            // button3
            // 
            button3.Location = new Point(-7, 47);
            button3.Margin = new Padding(1);
            button3.Name = "button3";
            button3.Size = new Size(81, 38);
            button3.TabIndex = 4;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(333, 78);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 485);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(ucEventInInfo1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 12F);
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
        private Button button3;
        private Button button4;
    }
}