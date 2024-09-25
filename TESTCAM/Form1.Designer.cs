namespace TESTCAM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            lblResolution = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(485, 527);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(868, 241);
            button1.Name = "button1";
            button1.Size = new Size(96, 41);
            button1.TabIndex = 1;
            button1.Text = "START";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(868, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "192.168.20.98";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(868, 50);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(169, 23);
            textBox2.TabIndex = 2;
            textBox2.Text = "MJPEG";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(868, 96);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(169, 23);
            textBox3.TabIndex = 3;
            textBox3.Text = "1280x720";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(868, 125);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(169, 23);
            textBox4.TabIndex = 4;
            textBox4.Text = "Hanse";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(868, 154);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(169, 23);
            textBox5.TabIndex = 5;
            textBox5.Text = "admin";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(868, 183);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(169, 23);
            textBox6.TabIndex = 6;
            textBox6.Text = "Kztek123456";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(868, 212);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(169, 23);
            textBox7.TabIndex = 7;
            textBox7.Text = "554";
            // 
            // button2
            // 
            button2.Location = new Point(970, 241);
            button2.Name = "button2";
            button2.Size = new Size(96, 41);
            button2.TabIndex = 1;
            button2.Text = "Take Photo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(491, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(315, 239);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // lblResolution
            // 
            lblResolution.AutoSize = true;
            lblResolution.Location = new Point(500, 264);
            lblResolution.Name = "lblResolution";
            lblResolution.Size = new Size(38, 15);
            lblResolution.TabIndex = 9;
            lblResolution.Text = "label1";
            // 
            // button3
            // 
            button3.Location = new Point(970, 288);
            button3.Name = "button3";
            button3.Size = new Size(96, 41);
            button3.TabIndex = 1;
            button3.Text = "save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 527);
            Controls.Add(lblResolution);
            Controls.Add(pictureBox1);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox4);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button button2;
        private PictureBox pictureBox1;
        private Label lblResolution;
        private Button button3;
    }
}
