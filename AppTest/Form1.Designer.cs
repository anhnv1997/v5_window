namespace AppTest
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
            label1 = new Label();
            txtCardNumber = new TextBox();
            label2 = new Label();
            txtPlate = new TextBox();
            label3 = new Label();
            txtUrl = new TextBox();
            btnCheckIn = new Button();
            btnCheckOut = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 44);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã thẻ";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(95, 41);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(282, 27);
            txtCardNumber.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 77);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 0;
            label2.Text = "BSX";
            // 
            // txtPlate
            // 
            txtPlate.Location = new Point(95, 74);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(282, 27);
            txtPlate.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 11);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 0;
            label3.Text = "Server";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(95, 8);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(282, 27);
            txtUrl.TabIndex = 1;
            txtUrl.Text = "http://localhost:8081/";
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(414, 8);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(93, 27);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "Check In";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(414, 44);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(93, 27);
            btnCheckOut.TabIndex = 2;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCheckOut);
            Controls.Add(btnCheckIn);
            Controls.Add(txtPlate);
            Controls.Add(label2);
            Controls.Add(txtUrl);
            Controls.Add(label3);
            Controls.Add(txtCardNumber);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCardNumber;
        private Label label2;
        private TextBox txtPlate;
        private Label label3;
        private TextBox txtUrl;
        private Button btnCheckIn;
        private Button btnCheckOut;
    }
}
